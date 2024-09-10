using I3Lab.Works.Domain.WorkChats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace I3Lab.Works.Infrastructure.Domain.WorkChats
{
    public class WorkChatConfiguration : IEntityTypeConfiguration<WorkChat>
    {
        public void Configure(EntityTypeBuilder<WorkChat> builder)
        {
            builder.ToTable("WorkChats");

            builder.HasKey(wc => wc.Id);

            builder.Property(wc => wc.WorkId)
                   .IsRequired();

            builder.HasMany(wc => wc.Messages)
                   .WithOne()
                   .HasForeignKey(cm => cm.WorkChatId)
                   .OnDelete(DeleteBehavior.Cascade); 

            builder.HasMany(wc => wc.ChatMembers)
                   .WithOne()
                   .OnDelete(DeleteBehavior.Cascade); 

            builder.Navigation(wc => wc.Messages).AutoInclude();
            builder.Navigation(wc => wc.ChatMembers).AutoInclude();
        }
    }
}
