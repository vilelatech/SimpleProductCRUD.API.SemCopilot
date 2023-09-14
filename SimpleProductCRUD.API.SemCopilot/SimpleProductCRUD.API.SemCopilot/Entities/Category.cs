using SimpleProductCRUD.API.SemCopilot.Validations;

namespace SimpleProductCRUD.API.SemCopilot.Entities;

public sealed class Category : Entity
{
    public string Name { get; private set; }
    public ICollection<Product> Products { get; set; }

    public void Update(string name)
    {
        Validate(name);
    }

    public Category(string name)
    {
        Validate(name);
    }

    public Category(int id, string name)
    {
        ExceptionValidation.When(Id < 0, "Invalid ID");
        Id = id;
        Validate(name);
    }

    private void Validate(string name)
    {
        ExceptionValidation.When(string.IsNullOrEmpty(name),
            "Invalid name. Name is required");

        ExceptionValidation.When(name.Length < 3,
            "Invalid name, too short, minimum 3 characters");
        Name = name;
    }
}