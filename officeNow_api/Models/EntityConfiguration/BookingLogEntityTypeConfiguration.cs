using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace officeNow_api.Models.EntityConfiguration
{
    public class BookingLogEntityTypeConfiguration : IEntityTypeConfiguration<BookingLog>
    {
        public void Configure(EntityTypeBuilder<BookingLog> builder)
        {
            builder
                .Property(b => b.Id).ValueGeneratedOnAdd();
        }
    }
}
