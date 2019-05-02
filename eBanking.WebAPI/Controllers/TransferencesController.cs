using eBanking.BLL.BusinessLogic;
using eBanking.Model.DBModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace eBanking.WebAPI.Controllers
{
    [Route("api/transferences")]
    public class TransferencesController : ApiController
    {
        IUsersLogic _usersLogic;
        ITransferencesLogic _transferencesLogic;

        public TransferencesController(IUsersLogic usersLogic, ITransferencesLogic transferencesLogic)
        {
            _usersLogic = usersLogic;
            _transferencesLogic = transferencesLogic;
        }

        // GET api/<controller>
        [Route("user/{id}/accounts")]
        [HttpGet]
        public IEnumerable<Account> Get(int id)
        {
            return _usersLogic.GetAccountsByUser(id);
        }

        [Route("send")]
        [HttpPost]
        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Transference tr)
        {
            try
            {
                var result = _transferencesLogic.CompleteTransference(tr);
                if (result.Success)
                {
                    return Ok();
                }
                else
                {
                    return Content(HttpStatusCode.InternalServerError, result);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}