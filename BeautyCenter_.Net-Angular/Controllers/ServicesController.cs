using BeautyCenter_.Net_Angular.DTO;
using BeautyCenter_.Net_Angular.Models;
using BeautyCenter_.Net_Angular.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BeautyCenter_.Net_Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ServicesController : ControllerBase
    {
        UnitWork unit;
        public ServicesController(UnitWork unit)
        {
            this.unit = unit;
        }






        [HttpGet]
        public IActionResult GetAllServices()
        {
            List<ServiceResponse> ServiseList = unit.ServiceRepository.selectall();
            List<serviceD> ServiseListDTO = new List<serviceD>();
            foreach (ServiceResponse serv in ServiseList)
            {
                serviceD servD = new serviceD()
                {
                    Id = serv.Id,
                    Name = serv.Name,
                    Price = serv.Price,
                    Category = serv.Category,
                };
                ServiseListDTO.Add(servD);
            }
            if (ServiseListDTO.Count > 0)
            {
                return Ok(ServiseListDTO);

            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetServiceById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            ServiceResponse service = unit.ServiceRepository.selectbyid(id);
            if (service == null)
            {
                return NotFound();
            }
            else
            {
                serviceD serviceDTO = new serviceD()
                {
                    Id = service.Id,
                    Name = service.Name,
                    Price = service.Price,
                    Category = service.Category,
                };
                return Ok(serviceDTO);

            }
        }
        //[HttpGet("/api/SerName/{name}")]
        //public IActionResult GetServiceByName(string name)
        //{
        //    if (name == null)
        //    {
        //        return BadRequest();
        //    }
        //    else
        //    {
        //        List<Service> ListOfServices = unit.ServiceRepository.GetServicesByCategory(name);
        //        List<serviceD> ListOfServicesDTO = new List<serviceD>();
        //        foreach (Service service in ListOfServices)
        //        {
        //            serviceD servD = new serviceD()
        //            {
        //                Id = service.Id,
        //                Name = service.Name,
        //                Price = service.Price,
        //                Category = service.Category
        //            };
        //            ListOfServicesDTO.Add(servD);
        //        }
        //        return Ok(ListOfServicesDTO);
        //    }
        //}
        [HttpGet("/api/SerCateg/{categ}")]

        //[HttpGet("{categ:alpha}")]
        public IActionResult GetServiceByCategory(string categ)
        {
            if (categ == null)
            {
                return BadRequest();
            }
            else
            {
                List<ServiceResponse> ListOfServices = unit.ServiceRepository.GetServicesByCategory(categ);
                List<serviceD> ListOfServicesDTO = new List<serviceD>();
                foreach (ServiceResponse service in ListOfServices)
                {
                    serviceD servD = new serviceD()
                    {
                        Id = service.Id,
                        Name = service.Name,
                        Price = service.Price,
                        Category=service.Category
                    };
                    ListOfServicesDTO.Add(servD);
                }
                return Ok(ListOfServicesDTO);
            }
        }
        

        [HttpPost]
        public IActionResult AddNewService(serviceD service)
        {
            if (service == null)
            {
                return BadRequest();
            }
            else
            {
                ServiceResponse NewService = new ServiceResponse()
                {
                    Id = service.Id,
                    Name= service.Name,
                    Price = service.Price,
                    Category= service.Category,
                };
                unit.ServiceRepository.add(NewService);
                unit.ServiceRepository.save();
                return Ok(service);
            }
        }



        [HttpPut]
        public IActionResult AddServiceById(serviceD service)
        {
            if (service == null)
            {
                return BadRequest();
            }
            ServiceResponse serv = unit.ServiceRepository.selectbyid(service.Id);
            if (service == null)
            {
                return NotFound();
            }
            else
            {
                serv.Name = service.Name;
                serv.Price = service.Price;
                serv.Category = service.Category;
                
                unit.ServiceRepository.update(serv);
                unit.ServiceRepository.save();
                return Ok(service);
            }    
        }

        [HttpDelete]
        public IActionResult DeleteServiceById(int id)
        {
            if(id==0)
            {
                return BadRequest();
            }
            ServiceResponse ser=unit.ServiceRepository.selectbyid(id);
            if(ser ==null)
            {
                return NotFound();
            }
            else
            {
                unit.ServiceRepository.delete(id);
                unit.ServiceRepository.save();
                return Ok();
            }
        }


    }
}
