//using I3Lab.Treatments.Domain.Members;
//using I3Lab.Treatments.Domain.TreatmentStageChats;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace I3Lab.Treatments.Infrastructure.Domain.WorkChats
//{
//    public class ChatMessageConfiguration : IEntityTypeConfiguration<Message>
//    {
//        public void Configure(EntityTypeBuilder<Message> builder)
//        {
//            builder.ToTable("ChatMessages");


//            builder.HasKey(cm => cm.Id);


//            builder.Property(cm => cm.MessageText)
//                   .IsRequired()
//                   .HasMaxLength(1000);

//            builder.Property(cm => cm.SentDate)
//                   .IsRequired();

//            builder.Property(cm => cm.EditDate)
//                   .IsRequired(false);

//            builder.HasOne<TreatmentStageChat>()
//                   .WithMany(wc => wc.Messages)
//                   .HasForeignKey(cm => cm.WorkChatId)
//                   .OnDelete(DeleteBehavior.Cascade);

//            builder.HasOne<Member>()
//                   .WithMany()
//                   .HasForeignKey(cm => cm.SenderId);
//            //.OnDelete(DeleteBehavior.Restrict);

//            // Настройка навигационных свойств
//            //builder.Navigation(cm => cm.SenderId).AutoInclude();
//        }
//    }
//}
