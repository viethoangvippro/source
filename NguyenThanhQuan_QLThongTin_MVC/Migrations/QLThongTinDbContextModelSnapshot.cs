﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NguyenThanhQuan_QLThongTin_MVC.Data;

#nullable disable

namespace NguyenThanhQuan_QLThongTin_MVC.Migrations
{
    [DbContext(typeof(QLThongTinDbContext))]
    partial class QLThongTinDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NguyenThanhQuan_QLThongTin_MVC.Models.Huyen", b =>
                {
                    b.Property<int>("IdHuyen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdHuyen"), 1L, 1);

                    b.Property<int>("IdTinh")
                        .HasColumnType("int");

                    b.Property<string>("TenHuyen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdHuyen");

                    b.HasIndex("IdTinh");

                    b.ToTable("Huyen", (string)null);
                });

            modelBuilder.Entity("NguyenThanhQuan_QLThongTin_MVC.Models.Tinh", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("TenTinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tinh", (string)null);
                });

            modelBuilder.Entity("NguyenThanhQuan_QLThongTin_MVC.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("NguyenThanhQuan_QLThongTin_MVC.Models.Huyen", b =>
                {
                    b.HasOne("NguyenThanhQuan_QLThongTin_MVC.Models.Tinh", "Tinh")
                        .WithMany("Huyens")
                        .HasForeignKey("IdTinh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tinh");
                });

            modelBuilder.Entity("NguyenThanhQuan_QLThongTin_MVC.Models.Tinh", b =>
                {
                    b.Navigation("Huyens");
                });
#pragma warning restore 612, 618
        }
    }
}
