using I3Lab.Works.Domain.Members;
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

            //builder.HasMany(wc => wc.ChatMembers)
            //       .WithOne()
            //       .OnDelete(DeleteBehavior.Cascade);

            builder.OwnsMany(wc => wc.ChatMembers, b =>
            {
                b.ToTable("ChatMembers");

                b.HasKey(wc => wc.Id);  

                b.WithOwner()
                 .HasForeignKey(cm => cm.WorkChatId);

                b.Property(cm => cm.MemberId)
                 .IsRequired();

                b.Property(cm => cm.WorkChatId)
                 .IsRequired();
            });

            // Configuration for Messages using OwnsMany
            builder.OwnsMany(wc => wc.Messages, b =>
            {
                b.ToTable("WorkChatMessages");

                // Reuse the ChatMessage configuration for properties and relationships
                b.WithOwner()
                 .HasForeignKey(cm => cm.WorkChatId);

                b.HasKey(cm => cm.Id);

                b.Property(cm => cm.MessageText)
                 .IsRequired()
                 .HasMaxLength(1000);

                b.Property(cm => cm.SentDate)
                 .IsRequired();

                b.Property(cm => cm.EditDate)
                 .IsRequired(false);

                // Configuration for relationship with Member
                b.HasOne<Member>()
                 .WithMany()
                 .HasForeignKey(cm => cm.SenderId);
            });


            //builder.Navigation(wc => wc.Messages).AutoInclude();
            //builder.Navigation(wc => wc.ChatMembers).AutoInclude();
        }
    }
}


//b.ToTable("Messages");

//b.HasKey(wc => wc.Id);

//b.Property(cm => cm.MessageText)
//  .IsRequired()
//  .HasMaxLength(1000);

//b.Property(cm => cm.SentDate)
//       .IsRequired();

//b.Property(cm => cm.EditDate)
//       .IsRequired(false);