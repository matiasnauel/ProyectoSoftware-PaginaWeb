﻿// <auto-generated />
using System;
using DATOS;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DATOS.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DOMINIO.ENTIDADES.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserRoleUsuarioId")
                        .HasColumnType("int");

                    b.HasKey("RoleId");

                    b.HasIndex("UserRoleUsuarioId");

                    b.ToTable("role");
                });

            modelBuilder.Entity("DOMINIO.ENTIDADES.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserRoleUsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("gmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("uid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserRoleUsuarioId");

                    b.ToTable("user");
                });

            modelBuilder.Entity("DOMINIO.ENTIDADES.UsuarioRoles", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("DOMINIO.ENTIDADES.Role", b =>
                {
                    b.HasOne("DOMINIO.ENTIDADES.UsuarioRoles", "UserRole")
                        .WithMany("Role")
                        .HasForeignKey("UserRoleUsuarioId");
                });

            modelBuilder.Entity("DOMINIO.ENTIDADES.Usuario", b =>
                {
                    b.HasOne("DOMINIO.ENTIDADES.UsuarioRoles", "UserRole")
                        .WithMany("User")
                        .HasForeignKey("UserRoleUsuarioId");
                });
#pragma warning restore 612, 618
        }
    }
}
