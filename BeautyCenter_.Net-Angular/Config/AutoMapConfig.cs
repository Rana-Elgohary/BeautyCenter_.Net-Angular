using AutoMapper;
using BeautyCenter_.Net_Angular.DTO;
using BeautyCenter_.Net_Angular.Models;

namespace BeautyCenter_.Net_Angular.Config
{
    public class AutoMapConfig : Profile
    {
        public AutoMapConfig() 
        {
            CreateMap<Userr, User>();
        }
    }
}
