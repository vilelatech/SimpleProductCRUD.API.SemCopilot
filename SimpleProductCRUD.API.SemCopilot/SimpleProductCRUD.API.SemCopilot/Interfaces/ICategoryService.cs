using SimpleProductCRUD.API.SemCopilot.DTOs;

namespace SimpleProductCRUD.API.SemCopilot.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetAllCategories();
    Task<CategoryDTO> GetCategoryById(int? id);
    Task Add(CategoryDTO categoryDTO);

    Task Update(CategoryDTO categoryDTO);
    Task Remove(int? id);
}