using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeautyCenter_.Net_Angular.DTO
{
    public class PackageD
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public List<string> Service { get; set; } = new List<string>();
    }
}
