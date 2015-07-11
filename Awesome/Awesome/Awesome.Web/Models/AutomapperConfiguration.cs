using AutoMapper;

namespace Awesome.Web.Models
{
    public class AutomapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Core.Person, ViewModels.Person>();
            Mapper.CreateMap<ViewModels.Person, Core.Person>();
        }
    }
}