using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.WorkChats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace I3Lab.Works.Infrastructure.Domain.WorkChats
{
    public class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessage>
    {
        public void Configure(EntityTypeBuilder<ChatMessage> builder)
        {
            // Установка имени таблицы
            builder.ToTable("ChatMessages");


            builder.HasKey(cm => cm.Id);

            
            builder.Property(cm => cm.MessageText)
                   .IsRequired()
                   .HasMaxLength(1000); 

            builder.Property(cm => cm.SentDate)
                   .IsRequired();

            builder.Property(cm => cm.EditDate)
                   .IsRequired(false); 

            // Настройка отношения с WorkChat
            builder.HasOne<WorkChat>()
                   .WithMany(wc => wc.Messages)
                   .HasForeignKey(cm => cm.WorkChatId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Настройка отношения с Member
            builder.HasOne<Member>()
                   .WithMany()
                   .HasForeignKey(cm => cm.SenderId);
                   //.OnDelete(DeleteBehavior.Restrict);

            // Настройка навигационных свойств
            builder.Navigation(cm => cm.SenderId).AutoInclude();
        }
    }
}
