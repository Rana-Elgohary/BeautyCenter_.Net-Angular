using BeautyCenter_.Net_Angular.DTO;
using BeautyCenter_.Net_Angular.Models;
using BeautyCenter_.Net_Angular.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace BeautyCenter_.Net_Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : Controller
    {
        UnitWork unit;

       
        public PackageController(UnitWork unit)
        {
            this.unit = unit;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Package> packages = unit.PackageRepository.selectall();   
            List<PackageD> packagesDTO = new List<PackageD>();

            foreach(Package package in packages)
            {
                PackageD PDTO = new PackageD()
                {
                    Id = package.Id,
                    Name = package.Name,
                    Price = package.Price,
                    ServicesName = package.Services.Select(s => s.Name).ToList()

                };
                packagesDTO.Add(PDTO);
            }
            return Ok(packagesDTO);
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            Package package = unit.PackageRepository.selectbyid(id);
            PackageD PDTO = new PackageD()
            {
                Id = package.Id,
                Name = package.Name,
                Price = package.Price,
                ServicesName=package.Services.Select(s=>s.Name).ToList()
            };
            return Ok(PDTO);


        }

        [HttpPost("add")]
        public IActionResult add(PackageADD packageDto)
        {

            if (packageDto == null)
            {
                return BadRequest();
            }
            Package p = new Package()
            {
                Id = packageDto.Id,
                Name = packageDto.Name,
                Price = packageDto.Price
            };
            //List<Service> s = new List<Service>();
            //foreach (serviceD serviceD in packageDto.ServicesId)
            //{
            //    Service Ser = new Service()
            //    {
            //        Id = serviceD.Id,
            //        Name = serviceD.Name,
            //        Price = serviceD.Price,
            //        Category = serviceD.Category
            //    };
            //    p.Services.Add(Ser);
            //}
            unit.PackageRepository.add(p);
            unit.SaveChanges();
            return Ok();
        }

        [HttpPut("edit")] // Route for editing a package

        public IActionResult edit(PackageADD packageDto)
        {

            if (packageDto == null)
            {
                return BadRequest();
            }
            Package p = new Package()
            {
                Id = packageDto.Id,
                Name = packageDto.Name,
                Price = packageDto.Price
            };
            //List<Service> s = new List<Service>();
            //foreach (serviceD serviceD in packageDto.ServicesId)
            //{
            //    Service Ser = new Service()
            //    {
            //        Id = serviceD.Id,
            //        Name = serviceD.Name,
            //        Price = serviceD.Price,
            //        Category = serviceD.Category
            //    };
            //    p.Services.Add(Ser);
            //}
            unit.PackageRepository.update(p);
            unit.SaveChanges();
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult deleteItem(int id)
        {
            Package p = unit.PackageRepository.selectbyid(id);
            if (p == null)
            {
                return BadRequest();
            }
            unit.PackageRepository.delete(id);
            unit.SaveChanges();
            return Ok();
        }

    }
}
