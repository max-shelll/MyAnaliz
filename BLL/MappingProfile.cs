using AutoMapper;
using MyAnaliz.DAL.Models.Request.Account;
using MyAnaliz.DAL.Models.Request.Events;
using MyAnaliz.DAL.Models.Response.Account;
using MyAnaliz.DAL.Models.Response.Events;

namespace MyAnaliz.BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<RegisterRequest, User>()
                .ForMember(x => x.Email, opt => opt.MapFrom(c => c.Email))
                .ForMember(x => x.UserName, opt => opt.MapFrom(c => c.UserName));

            CreateMap<AdditionRequest, Transaction>();
            CreateMap<WasteRequest, Transaction>();
        }
    }
}
