using NeonWorld.Entities;
using NeonWorld.ViewModels.System.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeonWorld.Application.System.Orders
{
    public interface IOrderService
    {
        public OrderVm GetOrder(Guid userId);

        public bool CreateOrder(Order orders);
    }
}
