using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using WebApiWithAuth.Models;

namespace WebApiWithAuth.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private readonly AuthRepository _repo;

        public AccountController()
        {
            _repo = new AuthRepository();
        }

        [HttpPost,Route("Register")]
        public async Task<IHttpActionResult> Register([FromBody]UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(modelState: ModelState);
            }

            var result = await _repo.Register(userModel);
            var erroResult = GetErrorResult(result);

            return erroResult ?? Ok();
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    return BadRequest();
                }
                return BadRequest(modelState: ModelState);
            }
            return null;
        }
    }
}