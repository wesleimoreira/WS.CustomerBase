namespace WS.CustomerBase.Domain.Entities;
public class Product
{
    public Product(string name, decimal price, string description, DateTime createdAt)
    {
        Name = name;
        Price = price;
        CreatedAt = createdAt;
        Description = description;
    }
    
    public int Id { get;  set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    
    public void UpdateProduct(string name, decimal price, string description, DateTime updatedAt)
    {
        Name = name;
        Price = price;
        UpdatedAt = updatedAt;
        Description = description;
    }
}