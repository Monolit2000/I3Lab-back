using I3Lab.Treatments.Domain.TreatmentStages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Treatments.Infrastructure.Domain.Works
{
    public class TreatmentStageFileConfiguration : IEntityTypeConfiguration<TreatmentStageFile>
    {
        public void Configure(EntityTypeBuilder<TreatmentStageFile> builder)
        {
            builder.HasKey(wf => wf.WorkId);

           // builder.Property(wf => wf.File).IsRequired();

            builder.HasOne(wf => wf.File)
              .WithMany();

            builder.Property(wf => wf.WorkId).IsRequired();

            //builder.Property(wf => wf.ContainerName).IsRequired();

            builder.Property(wf => wf.CreateDate).IsRequired();
        }
    }
}
