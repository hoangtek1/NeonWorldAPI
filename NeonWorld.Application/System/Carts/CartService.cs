using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NeonWorld.EF;
using NeonWorld.Entities;
using NeonWorld.ViewModels.System.Carts;
using NeonWorld.ViewModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonWorld.Application.System.Carts
{
    public class CartService : ICartService
    {
        private readonly NeonWorldDbContext _context;
        private readonly IMapper _mapper;
        public CartService(NeonWorldDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CartVm>> GetUserCartAsync(Guid userId)
        {
            var query = from c in _context.Carts
                        join p in _context.Products on c.ProductID equals p.ProductID
                        where c.UserID == userId
                        select new CartVm()
                        {
                            Product = _mapper.Map<ProductVm>(p),
                            Amount = c.Quantity
                        };
            return await query.ToListAsync();
        }

        public async Task RemoveUserCart(Guid userId, int productId)
        {
            var productInCart = await _context.Carts.FirstOrDefaultAsync(c => c.ProductID == productId);
            _context.Carts.Remove(productInCart);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserCart(Guid userId, int productId, int amount)
        {
            var productInCart = await _context.Carts.FirstOrDefaultAsync(c => c.ProductID == productId);
            if (productInCart != null)
            {
                productInCart.Quantity = amount;
                _context.Carts.Update(productInCart);
            }
            else
            {
                _context.Carts.Add(new Cart()
                {
                    ProductID = productId,
                    UserID = userId,
                    Quantity = amount,
                    DateCreated = DateTime.Now
                });
            }
            await _context.SaveChangesAsync();
        }
    }
}
