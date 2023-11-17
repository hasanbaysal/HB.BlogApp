using HB.BlogApp.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.BlogApp.DAL.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {

            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();
            builder.Property(x => x.SurName).HasMaxLength(30).IsRequired();

            builder.Property(x => x.LastLogin).IsRequired(false);



        }
    }
}
