namespace WS.CustomerBase.Application.Models.ViewModels;

public class ProductViewModel
{
    public ProductViewModel(int id, string name, decimal price, string description, DateTime createdAt, DateTime updatedAt)
    {
        this.Id = id;
        this.Name = name;
        this.Price = price;
        this.CreatedAt = createdAt;
        this.UpdatedAt = updatedAt;
        this.Description = description;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public string Description { get; private set; }
}