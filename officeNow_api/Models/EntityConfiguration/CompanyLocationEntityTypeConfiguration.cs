using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace officeNow_api.Models.EntityConfiguration
{
    public class LocationEntityTypeConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder
                .Property(b => b.Id).ValueGeneratedOnAdd();
            builder
                .Property(b => b.LocationDescription)
                .IsRequired();
        }
    }
}
