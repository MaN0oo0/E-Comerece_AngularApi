using AutoMapper;
using Core.Entites;
using Core.Helpers;
using Core.Helpers.ProductHelperParam;
using Core.Interfaces;
using E_Comerece_AngularApi.ModelVM;
using Infrerastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Comerece_AngularApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : BaseApiController
    {
        //private readonly IProduct ProductRep;
        private readonly IGenricRepo<Product> ProductRep;
        private readonly IGenricRepo<ProductBrand> ProductBrandRepo;
        private readonly IGenricRepo<ProductType> ProductTypeRep;
        private readonly IMapper mapper;

        public ProductController(IGenricRepo<Product> productRep, IGenricRepo<ProductBrand> productBrandRepo, IGenricRepo<ProductType> productTypeRep, IMapper mapper)
        {
            ProductRep = productRep;
            ProductBrandRepo = productBrandRepo;
            ProductTypeRep = productTypeRep;
            this.mapper = mapper;
        }




        [HttpGet("Products")]
        public async Task<ActionResult<Pagination<ProductVM>>> GetProducts([FromQuery]ProductHelpParam productHelpParam)
        {
            var Filter = new ProductWithIncludes(productHelpParam);
            var Count = new ProductWithFilterCount(productHelpParam);
            var TotalIteams = await ProductRep.GetCountAsync(Count);
            var Products = await ProductRep.listAllByFilterAsync(Filter);

            var data = mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductVM>>(Products);
            return Ok(new Pagination<ProductVM>(productHelpParam.PageIndex,productHelpParam.PageSize,TotalIteams,data));
        }

        [HttpGet("ProductById/{Id}")]
        public async Task<ActionResult<Product>> GetProduct(int Id)
        {
            var Filter = new ProductWithIncludes(Id);
            if (Id != 0)
            {
                var data = await ProductRep.GetByFilterAsync(Filter);
                if (data != null)
                {
                    return Ok(mapper.Map<ProductVM>(data));

                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet("Brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductsBrand()
        {
            return Ok(await ProductBrandRepo.ListAllAsync());
        }


        [HttpGet("Types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductsType()
        {
            return Ok(await ProductTypeRep.ListAllAsync());
        }
    }
}
