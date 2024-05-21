using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OrderConfigurations : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.OrderId);

        builder.HasOne(x => x.Customer)
                .WithMany(x => x.Orders).
                HasForeignKey(x => x.CustomerId);

    }
}