﻿using I3Lab.Works.Domain.Treatment;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace I3Lab.Works.Infrastructure.Domain.Treatments
{
    public class TreatmentConfiguration : IEntityTypeConfiguration<Treatment>
    {
        public void Configure(EntityTypeBuilder<Treatment> builder)
        {
            builder.HasKey(e => e.Id); 

            builder.Property(e => e.Name)
                .IsRequired(); 

            builder.HasMany(e => e.TreatmentStages) 
                   .WithOne() 
                   .HasForeignKey(e => e.TreatmentId); 

            builder.HasOne(e => e.TreatmentPreview) 
                   .WithOne() 
                   .HasForeignKey<TreatmentPreview>(e => e.TreatmentId); 
        }
    }
}