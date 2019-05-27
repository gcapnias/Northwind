using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.BindingModels;
using Northwind.Models;
using Northwind.ViewModels;

namespace Northwind.Repositories
{
    public class OrdersRepository : Repository<Order>
    {
        public OrdersRepository(NorthwindEntities dbContext) :
            base(dbContext)
        {
        }

        public virtual IEnumerable<OrderViewModel> GetViewModels()
        {
            List<OrderViewModel> result = _dbContext.Orders
                .Include(m => m.Customer)
                .Include(m => m.Employee)
                .Include(m => m.Order_Details)
                .Include(m => m.Shipper)
                .ToList()
                .Select(m => m.ToViewModel())
                .ToList();

            return result;
        }


    }

    public static class OrdersRepositoryExtensions
    {
        public static OrderBindingModel ToBindingModel(this Order model)
        {
            OrderBindingModel result = null;

            if (model != null)
            {
                result = new OrderBindingModel();
                result.OrderID = model.OrderID;
                result.CustomerID = model.CustomerID;
                result.EmployeeID = model.EmployeeID;
                result.Freight = model.Freight;
                result.OrderDate = model.OrderDate;
                result.RequiredDate = model.RequiredDate;
                result.ShipAddress = model.ShipAddress;
                result.ShipCity = model.ShipCity;
                result.ShipCountry = model.ShipCountry;
                result.ShipName = model.ShipName;
                result.ShippedDate = model.ShippedDate;
                result.ShipPostalCode = model.ShipPostalCode;
                result.ShipRegion = model.ShipRegion;
                result.ShipVia = model.ShipVia;

            }

            return result;
        }

        public static OrderViewModel ToViewModel(this Order model)
        {
            OrderViewModel result = null;

            if (model != null)
            {
                result = new OrderViewModel();
                result.OrderID = model.OrderID;
                result.CustomerID = model.CustomerID;
                result.EmployeeID = model.EmployeeID;
                result.Freight = model.Freight;
                result.OrderDate = model.OrderDate;
                result.RequiredDate = model.RequiredDate;
                result.ShipAddress = model.ShipAddress;
                result.ShipCity = model.ShipCity;
                result.ShipCountry = model.ShipCountry;
                result.ShipName = model.ShipName;
                result.ShippedDate = model.ShippedDate;
                result.ShipPostalCode = model.ShipPostalCode;
                result.ShipRegion = model.ShipRegion;
                result.ShipVia = model.ShipVia;

                if (model.Customer != null)
                {
                    result.CustomerCompanyName = model.Customer.CompanyName;
                }

                if (model.Employee != null)
                {
                    result.EmployeeFirstName = model.Employee.FirstName;
                    result.EmployeeLastName = model.Employee.LastName;
                }

                if (model.Shipper != null)
                {
                    result.ShipperCompanyName = model.Shipper.CompanyName;
                }

                if (model.Order_Details != null)
                {
                    result.OrderDetailCount = model.Order_Details.Count;
                }

            }

            return result;
        }

    }
}
