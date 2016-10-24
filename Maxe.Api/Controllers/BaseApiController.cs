using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Maxe.DAL.Models;

namespace Maxe.Api.Controllers
{
    public class BaseApiController : ApiController
    {
        protected MaxeDbContext db = new MaxeDbContext();
    }
}
