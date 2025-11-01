//namespace WebApIFaod2025.Helpers
//{
//    using AutoMapper;
//    using WebApIFaod2025.Entities;
//    using WebApIFaod2025.Models.UsersColis;

//    public class AutoMapperProfile:Profile
//    {
//        public AutoMapperProfile()
//        {
//            // CreateRequest -- user
//            CreateMap<CreateRequest, UsersColis>();

//            CreateMap<UpdateRequest, UsersColis>()
//    .ForAllMembers(x => x.Condition((src, dest, prop) =>
//    {
//        // Ignorer les propriétés nulles
//        if (prop == null)
//            return false;

//        // Ignorer les chaînes vides
//        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop))
//            return false;


//        return true;
//    }));

//        }

//    }
//}



using AutoMapper;
using WebApIFaod2025.Entities;
using WebApIFaod2025.Models.UsersColis;

namespace WebApIFaod2025.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateRequest, UsersColis>();
            CreateMap<UpdateRequest, UsersColis>();
        }
    }
}