﻿using I3Lab.Works.Domain.BlobFiles;
using I3Lab.Works.Domain.Members;
using I3Lab.Works.Domain.Works;
using I3Lab.Works.Infrastructure.Domain.Works;
using I3Lab.Works.Infrastructure.Domain.Members;
using Microsoft.EntityFrameworkCore;
using I3Lab.Works.Infrastructure.Domain.BlobFiles;
using I3Lab.Works.Domain.Treatment;
using I3Lab.Works.Infrastructure.Domain.Treatments;

namespace I3Lab.Works.Infrastructure.Persistence
{
    public class WorkContext : DbContext
    {
        //public DbSet<Works.Domain.WorkDirectorys.WorkDirectory> WorkDirectories { get; set; }

        //public DbSet<WorkComment> WorkComments { get; set; }

        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Work> Works { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<BlobFile> BlobFiles { get; set; }

        public WorkContext(DbContextOptions<WorkContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("work");

            modelBuilder.ApplyConfiguration(new MemberConfiguration());

            modelBuilder.ApplyConfiguration(new WorkConfiguration());

            modelBuilder.ApplyConfiguration(new BlobFileConfiguration());

            modelBuilder.ApplyConfiguration(new WorkFileConfiguration());


            modelBuilder.Ignore<Treatment>();

            modelBuilder.ApplyConfiguration(new TreatmentConfiguration());
        }
    }
}

            //modelBuilder.ApplyConfiguration(new WorkDirectoryConfiguration());