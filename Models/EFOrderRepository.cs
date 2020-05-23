using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _ctx;

        public EFOrderRepository(ApplicationDbContext ctx)
        {
            this._ctx = ctx;
        }
        public IQueryable<Order> Orders => _ctx.Orders
            .Include(o => o.Lines)
            .ThenInclude(l => l.Product);

        public void SaveOrder(Order order)
        {
            _ctx.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderID == 0)
                _ctx.Orders.Add(order);
            _ctx.SaveChanges();
        }
    }
}
