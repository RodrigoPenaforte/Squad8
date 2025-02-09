﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mulher_Presente.Data;

namespace Mulher_Presente.Migrations
{
    [DbContext(typeof(MulherContext))]
    partial class MulherContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mulher_Presente.Models.Parceiros", b =>
                {
                    b.Property<int>("id_parceiro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Especilidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_parceiro");

                    b.ToTable("Parceiros");
                });

            modelBuilder.Entity("Mulher_Presente.Models.Vitima", b =>
                {
                    b.Property<int>("id_vitima")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Parceirosid_parceiro")
                        .HasColumnType("int");

                    b.Property<string>("apelido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_vitima");

                    b.HasIndex("Parceirosid_parceiro");

                    b.ToTable("Vitima");
                });

            modelBuilder.Entity("Mulher_Presente.Models.Vitima", b =>
                {
                    b.HasOne("Mulher_Presente.Models.Parceiros", "Parceiros")
                        .WithMany()
                        .HasForeignKey("Parceirosid_parceiro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parceiros");
                });
#pragma warning restore 612, 618
        }
    }
}
