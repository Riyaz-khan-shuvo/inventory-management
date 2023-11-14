using InventoryManagement.Sql.Entities.Enrols;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Sql.EntityConfigurations
{
    public class PurchaseItemConfigurations : IEntityTypeConfiguration<PurchaseItem>
    {
        public void Configure(EntityTypeBuilder<PurchaseItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Item).WithMany(m => m.PurchaseItems).HasForeignKey(f => f.ItemId);
            builder.HasOne(x => x.Purchase).WithMany(m => m.PurchaseItems).HasForeignKey(f => f.PurchaseId);          

        }
    }
}
