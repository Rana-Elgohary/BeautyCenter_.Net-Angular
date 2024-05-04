using BeautyCenter_.Net_Angular.DTO;
using BeautyCenter_.Net_Angular.Models;
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

        [HttpGet]
        public ActionResult GetAll()
        {
            List<Userr> userrs = unit.UserRepository.selectall();
            List<User> usersDTO = new List<User>();

            foreach (Userr userr in userrs)
            {
                User userDTO = new User() { 
                    Id = userr.Id,
                    Name = userr.Name,
                    Email = userr.Email,
                    Password = userr.Password,
                    BankAccount = userr.BankAccount 
                };
                usersDTO.Add(userDTO);
            }
            return Ok(usersDTO);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            Userr usserr = unit.UserRepository.selectbyid(id);

            if (usserr == null)
                return NotFound();
            else
            {
                User userDTO = new User()
                {
                    Id = usserr.Id,
                    Name = usserr.Name,
                    Email = usserr.Email,
                    Password = usserr.Password,
                    BankAccount = usserr.BankAccount
                };
                return Ok(userDTO);
            }
        }
    }
}
