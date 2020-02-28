using ngCookingWebApi.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ngCookingWebApi.Controllers
{
    public class RecettesController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;
        public RecettesController(IUnitOfWork _unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetAllRecette")]
        IHttpActionResult GetAllRecette()
        {
            
        }
    }
}
