using AutoMapper;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using WingsOn.API.ViewModel;
using WingsOn.BLL;
using WingsOn.Domain;

namespace WingsOn.API
{
    public class AutoMapperConfig
    {
        public static void Register()
        {
            //define mapping objects
            Mapper.Initialize(cfg =>
            {
                //mapping between Person and PersonViewModel
                cfg.CreateMap<Person, PersonViewModel>();
               
            });
        }
    }
}