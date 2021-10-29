using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace officeNow_api.Models.EntityConfiguration
{
    public class UserRoleEntityTypeConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder
                .Property(b => b.Id).ValueGeneratedOnAdd();
            builder
                .Property(b => b.RoleDesc)
                .IsRequired();
        }
    }
}
