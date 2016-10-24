var API_URL = "http://localhost:54837/api/";

var ExamView = new Vue({
    el: "#app",
    data: {
        currentSectionIndex: 0,
        Exam: {},
        Sections: [],
        answers: [],
        willShowLoader: false,
        Section: {}
    },

    ready: function () {
        this.getExam(currentExamId).then(

            // Success callback
            function (response) {
                this.Exam = response.body;
                this.Sections = response.body.Sections;
                
                // Check if the localStorage is set for the first time
                if (!this.isStorageSet()) {
                    this.setInitialStorage();
                }

                this.currentSectionIndex = parseInt(this.getStorage("currentSectionIndex"));
                this.answers = JSON.parse(this.getStorage("answers"));
                this.Section = this.getSectionByIndex(this.currentSectionIndex);
            },

            // Error callback
            function (response) {
                console.log(response);
            }
            );
    },


    computed: {

        completedPercentage: function () {
            var currentSection = this.currentSectionIndex + 1;
            var totalSectionsCount = this.totalSectionsCount;
            return (currentSection / totalSectionsCount) * 100;
        },

        completedPercentageRounded: function () {
            return Math.ceil(this.completedPercentage);
        },

        currentSection: function () {
            return this.currentSectionIndex + 1;
        },

        totalSectionsCount: function () {
            return this.getSections().length;
        }
    },


    // Methods of the vue instance
    methods: {

        // Check if the index is the current section index
        isCurrentSectionIndex: function (index) {
            return this.currentSectionIndex == index;
        },

        // Go to a section using the section index starting with 0 
        // upto the count of the sections
        goToSectionByIndex: function (sectionIndex) {
            this.Section = this.getSectionByIndex(sectionIndex);
            this.removeSectionErrors(sectionIndex);
            this.setStorage("answers", JSON.stringify(this.answers));
            this.setStorage("currentSectionIndex", sectionIndex);
            this.currentSectionIndex = sectionIndex;
        },

        // Go to the previous section
        goToPrev: function () {
            // Don't execute when the current section is the first section
            if (this.isFirstSection()) {
                return;
            }

            // Minus one to go to previous section
            this.goToSectionByIndex(this.currentSectionIndex - 1);
        },

        // Go to the next section
        goToNext: function () {
            // Don't execute when the current section is the last section
            if (this.isLastSection()) {
                return;
            }

            var section = this.getCurrentSection();
            var sectionIndex = this.currentSectionIndex;
            var sectionAnswers = this.getSectionAnswersByIndex(sectionIndex);

            this.showLoader();

            this.validateExamSection(section.ExamSectionId, sectionAnswers).then(

                // Success
                function (response) {
                    this.goToSectionByIndex(sectionIndex + 1);
                    this.hideLoader();
                }.bind(this),

                // Error
                function (response) {
                    this.displayQuestionErrorsToSection(sectionIndex, response.body.ModelState);
                    this.hideLoader();
                }.bind(this)
                );
        },

        // Save the answers
        submit: function () {
            var section = this.getCurrentSection();
            var sectionIndex = this.currentSectionIndex;
            var sectionAnswers = this.getSectionAnswersByIndex(sectionIndex);

            this.showLoader();
            // Validate
            this.validateExamSection(section.ExamSectionId, sectionAnswers).then(

                // Success
                function () {
                    // Save the entry
                    this.postRequest("Entries/" + currentExamId, {
                        ExamId: 1,
                        ExamineeId: 1,
                        SubmittedAt: "2016-10-25 12:00:00",
                        Answers: this.getAllAnswers()
                    }).then(
                        function (resp) {
                            this.removeSectionErrors(this.currentSectionIndex);
                            // Reset storage
                            this.setInitialStorage();
                            window.location = window.location;
                        }.bind(this),

                        function (resp) {
                            alert(resp.body);
                            this.hideLoader();
                        }
                    );

                    
                }.bind(this),

                // Error
                function (response) {
                    this.displayQuestionErrorsToSection(sectionIndex, response.body.ModelState);
                    this.hideLoader();
                }.bind(this)
                );
        },

        showLoader: function() {
            this.willShowLoader = true;
        },

        hideLoader: function() {
            this.willShowLoader = false;
        },

        getCurrentSection: function () {
            return this.getSectionByIndex(this.currentSectionIndex);
        },

        // Get the sections of the Exam
        getSections: function () {
            return this.Sections;
        },

        getAllAnswers: function () {
            var answers = [];

            this.getSections().map(function (map, index) {
                answers = answers.concat(this.getSectionAnswersByIndex(index));
            }.bind(this));

            return answers;
        },

        removeSectionErrors: function (sectionIndex) {
            var section = this.getSectionByIndex(sectionIndex);
            var questions = section.Questions;

            for (var k in questions) {
                // Remove errors 
                this.$set("Sections[" + sectionIndex + "].Questions[" + k + "].Errors", []);
            }
        },

        isStorageSet: function() {
            return this.getStorage("storageIsSet");
        },

        setInitialStorage: function() {
            this.setStorage("storageIsSet", true);
            this.setStorage("currentSectionIndex", 0);
            this.setStorage("answers", JSON.stringify([]));
        },

        setStorage: function (key, data) {
            // Check if localStorage is available in the browser
            if (typeof(Storage) == "undefined") {
                return false;
            }

            localStorage.setItem(key, data);
        },

        getStorage: function (key) {
            // Check if localStorage is available in the browser
            if (typeof (Storage) == "undefined") {
                return false;
            }

            return localStorage.getItem(key);
        },

        displayQuestionErrorsToSection: function (sectionIndex, errorSet) {
            var section = this.getSectionByIndex(sectionIndex);
            var questions = section.Questions;

            this.removeSectionErrors(sectionIndex);

            // Find question object
            for (var k in questions) {
                var question = questions[k];
                var errors = errorSet[question.QuestionId];

                // Continue to next question if there are no errors
                if (typeof errors == 'undefined') {
                    continue;
                }

                // Assign errors to question
                this.$set("Sections[" + sectionIndex + "].Questions[" + k + "].Errors", errors);
            }
        },
        
        getSectionAnswersByIndex: function(sectionIndex) {
            var questions = this.getSectionByIndex(sectionIndex).Questions;
            var answers = [];

            for (var k in questions) {
                var question = questions[k];
                var questionType = question.QuestionType.Name;
                
                // Check if the question has an answer
                if (typeof this.answers[question.QuestionId] == 'undefined') {
                    continue;
                }

                var answer = this.answers[question.QuestionId];

                // If question type is "checklist" we need to
                // format the answer and make it ready for the request
                if (questionType == "checklist") {
                    var tmpAnswer = answer;
                    var answer = [];
                    var answerItems = [];

                    for (var tak in tmpAnswer) {
                        // Only include the id values with true false and not false
                        if (tmpAnswer[tak] != true) {
                            continue;
                        }

                        answerItems.push({
                            NumberValue: parseInt(tak)
                        });
                        
                    }

                    answers.push({
                        QuestionId: question.QuestionId,
                        AnswerItems: answerItems
                    });

                } else if(questionType == "true_false" || questionType == "input") {
                    answers.push({
                        QuestionId: question.QuestionId,
                        StringValue: answer
                    });
                } else {
                    answers.push({
                        QuestionId: question.QuestionId,
                        NumberValue: answer
                    });
                }
            }

            return answers;
        },

        // Get section using the index
        getSectionByIndex: function (index) {
            return this.getSections()[index];
        },

        // Check if the current section is the first section
        isFirstSection: function () {
            // The first index is 0
            return this.currentSectionIndex == 0;
        },

        // Check if the current section is the last section
        isLastSection: function () {
            // Minus 1 to the length because we are using the index that starts with zero
            return this.currentSectionIndex == (this.getSections().length - 1);
        },

        // api/Exams/{id}
        // Get the exam data
        getExam: function (id) {
            return this.getRequest('Exams/' + id);
        },

        // Validate section
        validateExamSection: function(examSectionId, answers) {
            return this
                .postRequest('ExamSections/' + examSectionId + '/Validate', answers);
        },

        // Perform POST request to the api/
        postRequest: function (endpoint, data) {
            return this.$http
                .post(API_URL + endpoint, data);
        },

        // Perform GET request to the api/
        getRequest: function (endpoint, data) {
            return this.$http
                .get(API_URL + endpoint, data);
        }
    }
});

