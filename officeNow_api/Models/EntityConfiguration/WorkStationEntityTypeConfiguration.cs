using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace officeNow_api.Models.EntityConfiguration
{
    public class WorkStationEntityTypeConfiguration : IEntityTypeConfiguration<WorkStation>
    {
        public void Configure(EntityTypeBuilder<WorkStation> builder)
        {
            builder
                .Property(b => b.Id).ValueGeneratedOnAdd();
        }
    }
}
