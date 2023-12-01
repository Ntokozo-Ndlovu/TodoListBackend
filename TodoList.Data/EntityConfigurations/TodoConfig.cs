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
    public class TodoConfig: IEntityTypeConfiguration<TodoEntity>
    {

        public TodoConfig()
        {
            //Affluent stuff will be done here to config it
         }

        public void Configure(EntityTypeBuilder<TodoEntity> builder)
        {
            builder.ToTable("TodoList");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Completed).HasColumnType("boolean");
            builder.Property(table => table.CreatedBy).IsRequired();
        }
    }
}
