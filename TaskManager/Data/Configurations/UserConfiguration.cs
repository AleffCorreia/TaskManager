using Microsoft.EntityFrameworkCore;
using System;
using TaskManager.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskManager.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("Users");

            builder
                .HasKey(u => u.Id);

            builder
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder
                .HasIndex(u => u.Email)
                .IsUnique();

            builder
                .Property(u => u.CreatedAt);

            builder
                .HasMany(u => u.Tasks)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
