using Core.Entites;
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
        private readonly IProduct ProductRep;

        public ProductController(IProduct productRep)
        {
            ProductRep = productRep;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>>GetProducts()
        {
            var data = await ProductRep.GetProductsAsync();
            return Ok(data);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Product>> GetProduct(int Id)
        {
            if (Id!=0)
            {
                var data = await ProductRep.GetProductByIdAsync(Id) ;
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
            return Ok(await ProductRep.GetProductsBrandAsync());
        }


        [HttpGet("Types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductsType()
        {
            return Ok(await ProductRep.GetProductsTypeAsync());
        }
    }
}
