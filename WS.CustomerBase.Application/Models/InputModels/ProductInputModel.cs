namespace WS.CustomerBase.Application.Models.InputModels;

public class ProductInputModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; } = decimal.Zero;
    public string Description { get;  set; } = string.Empty;
}