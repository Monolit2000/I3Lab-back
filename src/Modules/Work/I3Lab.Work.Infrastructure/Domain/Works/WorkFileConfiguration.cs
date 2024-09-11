using I3Lab.Works.Domain.Works;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3Lab.Works.Infrastructure.Domain.Works
{
    public class WorkFileConfiguration : IEntityTypeConfiguration<WorkFile>
    {
        public void Configure(EntityTypeBuilder<WorkFile> builder)
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
