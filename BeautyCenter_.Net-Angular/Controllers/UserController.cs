using BeautyCenter_.Net_Angular.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautyCenter_.Net_Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UnitWork unit;

        public UserController(UnitWork unit)
        {
            this.unit = unit;
        }
    }
}
