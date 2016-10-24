using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Maxe.DAL.Models
{
    /**
     * A maxe database context.
     *
     * @author  Allan.carlos
     * @date    10/17/2016
     */

    public class MaxeDbContext: DbContext
    {
        /**
         * Static constructor.
         *
         * @author  Allan.carlos
         * @date    10/17/2016
         */

        static MaxeDbContext()
        {
            Database.SetInitializer<MaxeDbContext>(null);
        }

        /**
         * Default constructor.
         *
         * @author  Allan.carlos
         * @date    10/17/2016
         */

        public MaxeDbContext()
            : base("name=DefaultConnection")
        {

        }

        /**
         * Gets or sets the questions.
         *
         * @return  The questions.
         */

        public DbSet<Question> Questions { get; set; }

        /**
         * Gets or sets the exams.
         *
         * @return  The exams.
         */

        public DbSet<Exam> Exams { get; set; }

        /**
         * Gets or sets the exam sections.
         *
         * @return  The exam sections.
         */

        public DbSet<ExamSection> ExamSections { get; set; }

        /**
         * Gets or sets a list of types of the questions.
         *
         * @return  A list of types of the questions.
         */

        public DbSet<QuestionType> QuestionTypes { get; set; }

        /**
         * Gets or sets the examinees.
         *
         * @return  The examinees.
         */

        public DbSet<Examinee> Examinees { get; set; }

        /**
         * Gets or sets the answers.
         *
         * @return  The answers.
         */

        public DbSet<Answer> Answers { get; set; }

        /**
         * Gets or sets the entries.
         *
         * @return  The entries.
         */

        public DbSet<Entry> Entries { get; set; }

        /**
         * Gets or sets the option choices.
         *
         * @return  The option choices.
         */

        public DbSet<OptionChoice> OptionChoices { get; set; }

        /**
         * Gets or sets the groups the option belongs to.
         *
         * @return  The option groups.
         */

        public DbSet<OptionGroup> OptionGroups { get; set; }

        /**
         * Gets or sets options for controlling the question.
         *
         * @return  Options that control the question.
         */

        public DbSet<QuestionOption> QuestionOptions { get; set; }
    }
}