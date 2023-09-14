using SimpleProductCRUD.API.SemCopilot.DTOs;

namespace SimpleProductCRUD.API.SemCopilot.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetProducts();
    Task<ProductDTO> GetById(int? id);
    Task Add(ProductDTO productDTO);
    Task Update(ProductDTO productDTO);
    Task Remove(int? id);
}