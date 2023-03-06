//using Microsoft.AspNetCore.Mvc;
//using TrackingAPI.Models.Base;

//namespace TrackingAPI.Controllers
//{
//    [ApiController]
//    public class BaseController : ControllerBase
//    {
//        [NonAction]
//        public IActionResult CreateResult<T>(Response<T> response)
//        {
//            return new ObjectResult(response.Data)
//            {
//                StatusCode = response.StatusCode
//            };
//        }
//    }
//}
