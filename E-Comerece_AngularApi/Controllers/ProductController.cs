using Core.Entites;
using Core.Helpers;
using Core.Interfaces;
using Infrerastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Comerece_AngularApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private readonly IProduct ProductRep;
        private readonly IGenricRepo<Product> ProductRep;
        private readonly IGenricRepo<ProductBrand> ProductBrandRepo;
        private readonly IGenricRepo<ProductType> ProductTypeRep;

        public ProductController(IGenricRepo<Product> productRep, IGenricRepo<ProductBrand> productBrandRepo, IGenricRepo<ProductType> productTypeRep)
        {
            ProductRep = productRep;
            ProductBrandRepo = productBrandRepo;
            ProductTypeRep = productTypeRep;
        }




        [HttpGet]
        public async Task<ActionResult<List<Product>>>GetProducts()
        {
            var Filter = new ProductWithIncludes();
            var data = await ProductRep.listAllByFilterAsync(Filter);
            return Ok(data);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Product>> GetProduct(int Id)
        {
            var Filter = new ProductWithIncludes();
            if (Id!=0)
            {
                var data = await ProductRep.GetByFilterAsync(Filter) ;
                if (data!=null)
                {
                return data;

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
