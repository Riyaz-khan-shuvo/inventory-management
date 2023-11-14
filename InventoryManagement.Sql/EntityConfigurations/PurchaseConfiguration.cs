using InventoryManagement.Sql.Entities.Enrols;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Sql.EntityConfigurations
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Company).WithMany(m => m.PurchasesMasters).HasForeignKey(f => f.CompanyId);
            builder.HasOne(x => x.User).WithMany(m => m.PurchasesMasters).HasForeignKey(f => f.UserId);
            builder.HasOne(x => x.Supplier).WithMany(m => m.PurchasesMasters).HasForeignKey(f => f.SupplierId);

        }
    }
}
