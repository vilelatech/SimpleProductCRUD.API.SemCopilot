using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SimpleProductCRUD.API.SemCopilot.Entities;

namespace SimpleProductCRUD.API.SemCopilot.EntitiesConfiguration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
    }
}