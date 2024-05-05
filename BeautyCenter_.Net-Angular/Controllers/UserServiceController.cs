using BeautyCenter_.Net_Angular.DTO;
using BeautyCenter_.Net_Angular.Models;
using BeautyCenter_.Net_Angular.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautyCenter_.Net_Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserServiceController : ControllerBase
    {
        UnitWork unit;
        public UserServiceController(UnitWork unit)
        {
            this.unit = unit;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            List<UserService> usrModelServices = unit.UserServiceRepository.selectall(); //db
            List<Uservice> userServicesDTO = new List<Uservice>(); //properties dto


            foreach (UserService usrModelService in usrModelServices)

            {
                Uservice userServiceDTO = new Uservice()
                {


                    UserId = usrModelService.UserId,
                    ServiceId = usrModelService.ServiceId,
                    Date = usrModelService.Date,

                };
                userServicesDTO.Add(userServiceDTO);

            }
            return Ok(userServicesDTO);
        }

        [HttpGet("{userId}/{serviceId}")]
        public ActionResult GetById(int userId, int serviceId)
        {
            UserService usrS = unit.UserServiceRepository.SelectByCompositeKey(userId, serviceId);
            Userr usserr = unit.UserRepository.selectbyid(userId);
            if (usserr == null)
                return NotFound();
            else
            {
                Uservice userServiceDTO = new Uservice()
                {
                    UserId = usrS.UserId,
                    ServiceId = usrS.ServiceId,
                    Date = usrS.Date,
                };
                //User userDTO = new User()
                //{ 
                //  Name= usserr.Name,
                //  Email= usserr.Email,
                //  Password = usserr.Password,
                //  BankAccount = usserr.BankAccount
                //};
                var userobj = new
                {
                    usserr.Name
                };

                //createDTO of the service to retrive only its name (SALMAAAAAAAAAAAAAAA)

                var Object = new
                {
                    User = userobj,
                    UserService = userServiceDTO
                    //don't forget to add service name when salma finish it(SALMAAAAAAAA)
                };

                // Return the response
                return Ok(Object);
            }
        }

        public class UserServiceResponse
        {
            public string UserName { get; set; }
            public List<Uservice> UserServices { get; set; }
        }

        [HttpGet("userservices/{date}")]
        public ActionResult GetUserServicesByDate(DateTime date)
        {
            // Retrieve UserService records for the specified date
            var dateUService = unit.UserServiceRepository.GetUserServicesByDate(date);

            if (dateUService == null || !dateUService.Any())
                return NotFound("No user services found for the specified date");

            // Retrieve the user name (assuming all user services have the same user)
            var userId = dateUService.FirstOrDefault()?.UserId;
            var userName = userId != null ? unit.UserRepository.selectbyid(userId.Value)?.Name : null;

            //var serviceName = unit.ServiceRepository.selectbyid(userService.ServiceId)?.Name;  SALMAAAA (m7taga ttzabat)

            // Construct a list to hold the result
            var result = new List<Uservice>();

            // Iterate through the retrieved user services to extract user and service names
            foreach (var userService in dateUService)
            {
                var userServiceDTO = new Uservice
                {
                    UserId = userService.UserId,
                    ServiceId = userService.ServiceId,
                    Date = userService.Date,
                };

                result.Add(userServiceDTO);
            }

            // DON'T FORGET TO ADD SALMAAAAA'S SERVICE=servicename
            var response = new UserServiceResponse
            {
                UserName = userName,
                UserServices = result
            };

            return Ok(response);
        }


    }
}









