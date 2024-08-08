﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StoreProcedure.Models;

public partial class PROCEDURContext : DbContext
{
    public PROCEDURContext()
    {
    }

    public PROCEDURContext(DbContextOptions<PROCEDURContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=PC_4176\\MSSQLSERVER01;Initial Catalog=PROCEDUR;Persist Security Info=True; Trust Server Certificate=True; User ID=sasa;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A2B0054F5DC");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasMany(d => d.ChildCategories).WithMany(p => p.ParentCategories)
                .UsingEntity<Dictionary<string, object>>(
                    "CategoryRelation",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("ChildCategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CategoryR__Child__3A81B327"),
                    l => l.HasOne<Category>().WithMany()
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CategoryR__Paren__398D8EEE"),
                    j =>
                    {
                        j.HasKey("ParentCategoryId", "ChildCategoryId").HasName("PK__Category__AEDE147E2617CEC2");
                        j.ToTable("CategoryRelations");
                        j.IndexerProperty<int>("ParentCategoryId").HasColumnName("ParentCategoryID");
                        j.IndexerProperty<int>("ChildCategoryId").HasColumnName("ChildCategoryID");
                    });

            entity.HasMany(d => d.ParentCategories).WithMany(p => p.ChildCategories)
                .UsingEntity<Dictionary<string, object>>(
                    "CategoryRelation",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CategoryR__Paren__398D8EEE"),
                    l => l.HasOne<Category>().WithMany()
                        .HasForeignKey("ChildCategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CategoryR__Child__3A81B327"),
                    j =>
                    {
                        j.HasKey("ParentCategoryId", "ChildCategoryId").HasName("PK__Category__AEDE147E2617CEC2");
                        j.ToTable("CategoryRelations");
                        j.IndexerProperty<int>("ParentCategoryId").HasColumnName("ParentCategoryID");
                        j.IndexerProperty<int>("ChildCategoryId").HasColumnName("ChildCategoryID");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}