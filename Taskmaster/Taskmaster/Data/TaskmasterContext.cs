using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Taskmaster.Models;

namespace Taskmaster.Data
{
    public class TaskmasterContext : IdentityDbContext
    {
        public TaskmasterContext(DbContextOptions<TaskmasterContext> options) : base(options) { }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Attachment> Attachment { get; set; }
        public DbSet<Communication> Communication { get; set; }
        public DbSet<CommunicationAttachmentPair> CommunicationAttachmentPair { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<SkillTaskPair> SkillTaskPair { get; set; }
        public DbSet<SkillUserPair> SkillUserPair { get; set; }
        public DbSet<Task> Task { get; set; }
        public DbSet<TaskAttachmentPair> TaskAttachmentPair { get; set; }
        public DbSet<User> User { get; set; }
    }
}
