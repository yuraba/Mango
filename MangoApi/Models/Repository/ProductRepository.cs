using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using MangoApi.DbContext;
using MangoApi.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace MangoApi.Models.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _db;
        private IMapper _mapper;

        public ProductRepository(AppDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List <Product> productList = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product); 
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);
            if (product.ProductId>0)
            {
                _db.Products.Update(product);
            }
            else
            {
                _db.Products.Add(product);
            }

            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _db.Products.FirstOrDefaultAsync(u => u.ProductId == productId);
                if (product==null)
                {
                    return false;
                }

                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}  