using I3Lab.Treatments.Domain.TreatmentStageComments;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Infrastructure.Domain.WorkComments
{
    public class TreatmentStageCommentConfiguration : IEntityTypeConfiguration<TreatmentStageComment>
    {
        public void Configure(EntityTypeBuilder<TreatmentStageComment> builder)
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
