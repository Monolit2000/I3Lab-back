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
            // Установка ключа для WorkFile
            builder.HasKey(wf => wf.FileId );

            builder.Property(wf => wf.FileId)
                .HasConversion<BlobFileIdConverter>()
                .IsRequired();

            // Конвертеры для идентификаторов
            builder.Property(wf => wf.WorkId)
                .HasConversion<WorkIdConverter>()
                .IsRequired();

            // Настройка других свойств
            builder.Property(wf => wf.ContainerName)
                .IsRequired();

            builder.Property(wf => wf.CreateDate)
                .IsRequired();
        }
    }
}
