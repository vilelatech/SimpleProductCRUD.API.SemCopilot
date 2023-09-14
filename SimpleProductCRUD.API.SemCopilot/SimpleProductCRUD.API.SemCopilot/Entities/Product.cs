using SimpleProductCRUD.API.SemCopilot.Validations;

namespace SimpleProductCRUD.API.SemCopilot.Entities;

public sealed class Product : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public Product(int id, string name, string description, decimal price, int stock)
    {
        ExceptionValidation.When(id < 0, "Invalid ID value");
        Id = id;
        Validate(name, description, price, stock);
    }

    public Product(string name, string description, decimal price, int stock)
    {
        Validate(name, description, price, stock);
    }


    public void Update(string name, string description, decimal price, int stock, int categoryId)
    {
        Validate(name, description, price, stock);
        CategoryId = categoryId;
    }

    private void Validate(string name, string description, decimal price, int stock)
    {
        ExceptionValidation.When(string.IsNullOrEmpty(name),
            "Invalid name. Name is required");

        ExceptionValidation.When(name?.Length < 3,
            "Invalid name, too short, minimum 3 characters");

        ExceptionValidation.When(string.IsNullOrEmpty(description),
            "Invalid description. Description is required");

        ExceptionValidation.When(description?.Length < 5,
            "Invalid description, too short, minimum 5 characters");

        ExceptionValidation.When(price < 0, "Invalid price value");

        ExceptionValidation.When(stock < 0, "Invalid stock value");


        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
    }
}