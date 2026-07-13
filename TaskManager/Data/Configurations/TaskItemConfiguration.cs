using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Text;
using TaskManager.Enums;
using TaskManager.Models;

namespace TaskManager.Data.Configurations
{
    public class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder) {

            builder
                .ToTable("TaskItems");

            builder
                 .HasKey(t => t.Id);

            builder
                .Property(t => t.CreatedAt);

            builder
                .Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .Property(t => t.Description)
                .HasMaxLength(500);

            builder
                .Property(t => t.Priority)
                .IsRequired()
                .HasDefaultValue(Priority.Medium);

            builder
                .Property(t => t.CompletedAt);

            builder
                .Property(t => t.Status)
                .IsRequired()
                .HasDefaultValue(StatusTask.Pedding);

            builder
                .HasOne(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
