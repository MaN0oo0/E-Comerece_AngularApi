using AutoMapper;
using Core.Entites;
using Core.Helpers;
using Core.Interfaces;
using E_Comerece_AngularApi.ModelVM;
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
        private readonly IMapper mapper;

        public ProductController(IGenricRepo<Product> productRep, IGenricRepo<ProductBrand> productBrandRepo, IGenricRepo<ProductType> productTypeRep, IMapper mapper)
        {
            ProductRep = productRep;
            ProductBrandRepo = productBrandRepo;
            ProductTypeRep = productTypeRep;
            this.mapper = mapper;
        }




        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var Filter = new ProductWithIncludes();
            var data = await ProductRep.listAllByFilterAsync(Filter);
            return Ok(mapper.Map<List<ProductVM>>(data));
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ProductVM>> GetProduct(int Id)
        {
            var Filter = new ProductWithIncludes(Id);
            if (Id != 0)
            {
                var data = await ProductRep.GetByFilterAsync(Filter);
                if (data != null)
                {
                    return mapper.Map<ProductVM>(data);

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
