using I3Lab.Works.Domain.WorkComments;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Infrastructure.Domain.WorkComments
{
    public class WorkCommentConfiguration : IEntityTypeConfiguration<WorkComment>
    {
        public void Configure(EntityTypeBuilder<WorkComment> builder)
        {
            builder.HasKey(e => e.Id); 

            builder.Property(e => e.Content)
                .IsRequired(); 

            builder.HasMany(e => e.PinedFiles) 
                   .WithOne() 
                   .HasForeignKey(e => e.WorkCommentId); 

        }
    }
}
