﻿using Microsoft.EntityFrameworkCore;
using SimpleProductCRUD.API.SemCopilot.Context;
using SimpleProductCRUD.API.SemCopilot.Entities;
using SimpleProductCRUD.API.SemCopilot.Interfaces;

namespace SimpleProductCRUD.API.SemCopilot.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _categoryContext;

    public CategoryRepository(ApplicationDbContext categoryContext)
    {
        _categoryContext = categoryContext;
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await _categoryContext.Categories.ToListAsync();
    }

    public async Task<Category> GetByIdAsync(int? id)
    {
        return await _categoryContext.Categories.FindAsync(id);
    }

    public async Task<Category> CreateAsync(Category category)
    {
        _categoryContext.Add(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        _categoryContext.Update(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category> RemoveAsync(Category category)
    {
        _categoryContext.Remove(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }
}