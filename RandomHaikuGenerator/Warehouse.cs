using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomHaikuGenerator
{

    public class Warehouse : IWarehouse
    {
        public Dictionary<string, int> Product { set; get; }
        public bool HasInventory(string nameProduct, int quantity)
        {
            int QuantityInWarehouse;
            if (Product.TryGetValue(nameProduct, out QuantityInWarehouse))
            {
                if (QuantityInWarehouse >= quantity)
                {
                    return true;
                }
            }

            return false;
        }

        public void RemoveInventory(string nameProduct, int quantity)
        {
            if (HasInventory(nameProduct, quantity))
            {
                this.Product[nameProduct] -= quantity;
            }
        }
    }
    public class Order
    {

        public Order(string _orderName, int _quantity)
        {
            this.ProductName = _orderName;
            this.Quantity = _quantity;
        }
        public string ProductName { private set; get; }
        public int Quantity { private set; get; }

        public bool isCompleted { get; private set; }

        public void Completed(Warehouse _warehouse)
        {
            if (_warehouse.HasInventory(this.ProductName, this.Quantity))
            {
                _warehouse.RemoveInventory(this.ProductName, this.Quantity);
                this.isCompleted = true;
            }
        }
    }

    public class OrderUsesInterface
    {
        public OrderUsesInterface(string _orderName, int _quantity)
        {
            this.ProductName = _orderName;
            this.Quantity = _quantity;
        }
        public string ProductName { private set; get; }
        public int Quantity { private set; get; }

        public bool isCompleted { get; private set; }

        public void Completed(IWarehouse _warehouse)
        {
            if (_warehouse.HasInventory(this.ProductName, this.Quantity))
            {
                _warehouse.RemoveInventory(this.ProductName, this.Quantity);
                this.isCompleted = true;
            }
        }
    }
        public interface IWarehouse
    {
        public bool HasInventory(string nameProduct, int quantity);
        public void RemoveInventory(string nameProduct, int quantity);
    }

   
}
