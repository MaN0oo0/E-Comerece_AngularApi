using AutoMapper;
using Core.Entites;
using E_Comerece_AngularApi.ModelVM;

namespace E_Comerece_AngularApi.Mapping
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductVM>()
                .ForMember(p => p.productBrand, o => o.MapFrom(p => p.productBrand.Name))
                .ForMember(p => p.productType, O => O.MapFrom(p => p.productType.Name))
                .ForMember(p => p.PictureUrl, o => o.MapFrom<ProductUrlResolver>());

            //CreateMap<ProductVM, Product>();
        }
    }
}
