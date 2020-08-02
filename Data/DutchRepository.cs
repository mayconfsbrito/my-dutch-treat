using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DutchTreat.Data
{
    public class DutchRepository : IDutchRepository
    {
        private readonly DutchContext ctx;
        private readonly ILogger<DutchRepository> logger;

        public DutchRepository(DutchContext ctx, ILogger<DutchRepository> logger)
        {
            this.ctx = ctx;
            this.logger = logger;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                logger.LogInformation("GetAllProducts");
                return ctx.Products.OrderBy(p => p.Title).ToList();

            } catch (Exception ex)
            {
                logger.LogError($"Failed to get all products: {ex}");
                return null;
            }
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            try
            {
                logger.LogInformation("GetAllOrders");

                if (includeItems)
                {
                    return ctx.Orders
                        .Include(o => o.Items)
                        .ThenInclude(i => i.Product)
                        .OrderByDescending(p => p.OrderDate).ToList();
                } 
                else
                {
                    return ctx.Orders
                        .OrderByDescending(p => p.OrderDate).ToList();
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get all orders: {ex}");
                return null;
            }
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return ctx.Products.Where(p => p.Category == category).ToList();
        }

        public bool SaveAll()
        {
            ctx.SaveChanges();
            return true;
        }

        public Order GetOrderById(int id)
        {
            return ctx.Orders
                    .Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                    .Where(o => o.Id == id)
                    .FirstOrDefault();
        }

        public void AddEntity(object model)
        {
            ctx.Add(model);
        }
    }
}
