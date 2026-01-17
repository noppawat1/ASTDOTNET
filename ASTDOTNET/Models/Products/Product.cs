using ASTDOTNET.Models.Products;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public int? CategoryType { get; set; }   // FK
    public Category Category { get; set; }
}

