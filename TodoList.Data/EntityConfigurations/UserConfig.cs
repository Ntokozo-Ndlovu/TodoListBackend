using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Data.Entities;

namespace TodoList.Data.EntityConfigurations
{
    public class UserConfig: IEntityTypeConfiguration<UserEntity>
    {
        public UserConfig() {
                  }

        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Name).IsRequired().HasMaxLength(255);
            builder.Property(user => user.Email).IsRequired().HasMaxLength(255);
            builder.Property(user => user.Password).IsRequired().HasMaxLength(255);
        }
    }
}
