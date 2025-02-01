using System;

class Order
{
    private List<Product> _products;

    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double totalCost = 0;

        foreach (Product product in _products)
        {
            totalCost += product.GetTotalCost();
        }

        double shippingCost;

        if (_customer.BasedInUSA())
        {
            shippingCost = 5.0;
        }
        else
        {
            shippingCost = 35.0;
        }

        return totalCost + shippingCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";

        foreach (Product product in _products)
        {
            packingLabel += $"Name: {product.GetName()}, Product ID: {product.GetProductId()}\n";
        }

        return packingLabel;
    }

    public string GetShippingLabel()
    {
        string shippingLabel = "Shipping Label:\n";
        shippingLabel += $"Name: {_customer.GetName()}\n";
        shippingLabel += _customer.GetAddress().GetFullAddress();

        return shippingLabel;
    }
}