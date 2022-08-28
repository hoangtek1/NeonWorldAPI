using NeonWorld.ViewModels.System.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonWorld.Application.System.Carts
{
    public interface ICartService
    {
        public Task<IEnumerable<CartVm>> GetUserCartAsync(Guid userId);
        public Task UpdateUserCart(Guid userId, int productId, int amount);
        public Task RemoveUserCart(Guid userId, int productId);

    }
}
