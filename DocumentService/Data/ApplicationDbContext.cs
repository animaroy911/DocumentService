using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DocumentService.Models;

namespace DocumentService.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DocumentService.Models.HandyMember> HandyMember { get; set; }
        public DbSet<MemberService> MemberService { get; set; }
        public DbSet<JobType> JobType { get; set; }
        public DbSet<DocumentService.Models.Segment> Segment { get; set; }
        public DbSet<DocumentService.Models.Book> Book { get; set; }
    }
}
