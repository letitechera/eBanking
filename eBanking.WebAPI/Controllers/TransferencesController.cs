using eBanking.BLL.BusinessLogic;
using eBanking.Model.DBModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace eBanking.WebAPI.Controllers
{
    [RoutePrefix("api/transferences")]
    public class TransferencesController : ApiController
    {
        public IUsersLogic _usersLogic;
        public ITransferencesLogic _transferencesLogic;

        public TransferencesController(IUsersLogic usersLogic, ITransferencesLogic transferencesLogic)
        {
            _usersLogic = usersLogic;
            _transferencesLogic = transferencesLogic;
        }

        [Route("user/{id}/accounts")]
        [HttpGet]
        public IEnumerable<Account> GetAccounts(int id)
        {
            return _usersLogic.GetAccountsByUser(id);
        }

        [Route("send")]
        [HttpPost]
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