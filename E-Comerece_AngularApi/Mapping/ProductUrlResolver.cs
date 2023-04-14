using AutoMapper;
using Core.Entites;
using E_Comerece_AngularApi.ModelVM;

namespace E_Comerece_AngularApi.Mapping
{
    public class ProductUrlResolver : IValueResolver<Product, ProductVM, string>
    {

        //Get APIUrl Key Form Config File
        private readonly IConfiguration config;

        public ProductUrlResolver(IConfiguration config)
        {
            this.config = config;
        }

        public string Resolve(Product source, ProductVM destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return config["ApiUrl"] + source.PictureUrl;
            }
            else
            {
                return "";
            }
        }
    }
}
