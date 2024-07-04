using I3Lab.Works.Domain.Members;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace I3Lab.Works.Infrastructure.Domain.Members
//{
//    public class MemberConfiguration : IEntityTypeConfiguration<Member>
//    {
//        public void Configure(EntityTypeBuilder<Member> builder)
//        {
//            builder.HasKey(e => e.Id); 

//            builder.Property(e => e.Login)
//                .IsRequired(); 

//            builder.Property(e => e.Email)
//                .IsRequired(); 

//            builder.OwnsOne(e => e.MemberRole, role =>
//            {
//                role.Property(r => r.Value)
//                         .HasColumnName("Role")
//                         .IsRequired(); 
//            });

//            builder.ComplexProperty(o => o.MemberRole, b =>
//            {
//                b.IsRequired();
//                b.Property(a => a.Value).HasColumnName("Role");
//            });


//            builder.Property(e => e.FirstName)
//                .IsRequired(); 

//            builder.Property(e => e.LastName)
//                .IsRequired(); 
//        }
//    }
//}