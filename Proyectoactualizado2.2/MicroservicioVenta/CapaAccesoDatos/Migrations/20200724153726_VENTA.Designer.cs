﻿// <auto-generated />
using System;
using CapaAccesoDatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CapaAccesoDatos.Migrations
{
    [DbContext(typeof(DatoDbContext))]
    [Migration("20200724153726_VENTA")]
    partial class VENTA
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CapaDeDominio.Entity.Venta", b =>
                {
                    b.Property<int>("VentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaVenta")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_carrito")
                        .HasColumnType("int");

                    b.Property<int>("Id_cliente")
                        .HasColumnType("int");

                    b.Property<int>("Monto")
                        .HasColumnType("int");

                    b.HasKey("VentaId");

                    b.ToTable("Ventas");
                });
#pragma warning restore 612, 618
        }
    }
}
