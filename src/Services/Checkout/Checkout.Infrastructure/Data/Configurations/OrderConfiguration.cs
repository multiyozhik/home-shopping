namespace Checkout.Infrastructure.Data.Configurations;

/// <summary> Конфигурации для сущности заказа </summary>
public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.AccountName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(o => o.TotalAmount)
            .HasColumnType("decimal(18,2)");

        builder.Property(o => o.CurrentOrderStatus)
            .HasConversion<string>()
            .HasMaxLength(50);

        builder.Property(o => o.CurrentPaymentMethod)
            .HasConversion<string>()
            .HasMaxLength(50);

        builder.Property(o => o.CurrentPaymentStatus)
            .HasConversion<string>()
            .HasMaxLength(50);

        builder.OwnsOne(o => o.ContactInfo, contact =>
        {
            contact.Property(c => c.FirstName)
                .HasMaxLength(100);

            contact.Property(c => c.Lastname)
                .HasMaxLength(100);

            contact.Property(c => c.Email)
                .HasMaxLength(255);
        });

        builder.OwnsOne(o => o.DeliveryAddress, address =>
        {
            address.Property(a => a.Region)
                .HasMaxLength(100);

            address.Property(a => a.City)
                .HasMaxLength(100);

            address.Property(a => a.Street)
                .HasMaxLength(200);

            address.Property(a => a.PostalCode)
                .HasMaxLength(20);
        });

        builder.OwnsOne(o => o.CurrentCartDetails, cart =>
        {
            cart.Property(c => c.CartNumber)
                .HasMaxLength(20);

            cart.Property(c => c.OwnerFirstName)
                .HasMaxLength(100);

            cart.Property(c => c.OwnerLastName)
                .HasMaxLength(100);

            cart.Property(c => c.ExpirationDate)
                .HasMaxLength(10);

            cart.Property(c => c.CvvCode)
                .HasMaxLength(10);
        });

        builder.OwnsMany(o => o.Items, item =>
        {
            item.Property(i => i.CatalogItemName)
                .HasMaxLength(200)
                .IsRequired();

            item.Property(i => i.Quantity)
                .IsRequired();

            item.Property(i => i.UnitPrice)
                .HasColumnType("decimal(18,2)");
        });

        builder.HasIndex(o => o.AccountName);
        builder.HasIndex(o => o.CurrentOrderStatus);
        builder.HasIndex(o => o.CurrentPaymentStatus);
    }
}
