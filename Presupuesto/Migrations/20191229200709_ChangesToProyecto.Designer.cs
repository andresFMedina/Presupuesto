﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Presupuesto.Models;

namespace Presupuesto.Migrations
{
    [DbContext(typeof(PresupuestoContext))]
    [Migration("20191229200709_ChangesToProyecto")]
    partial class ChangesToProyecto
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0-preview3.19554.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Presupuesto.Models.AnalisisUnitario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clasificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grupo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProyectoId")
                        .HasColumnType("int");

                    b.Property<string>("Unidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ValorUnitario")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProyectoId");

                    b.ToTable("AnalisisUnitario");
                });

            modelBuilder.Entity("Presupuesto.Models.Capitulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("ProyectoId")
                        .HasColumnType("int");

                    b.Property<int>("Subtotal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProyectoId");

                    b.ToTable("Capitulo");
                });

            modelBuilder.Entity("Presupuesto.Models.CostoIndirecto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Porcentaje")
                        .HasColumnType("real");

                    b.Property<int?>("ProyectoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProyectoId");

                    b.ToTable("CostoIndirecto");
                });

            modelBuilder.Entity("Presupuesto.Models.Detalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AnalisisUnitarioId")
                        .HasColumnType("int");

                    b.Property<int?>("AnalisisUnitarioId2")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Desperdicio")
                        .HasColumnType("real");

                    b.Property<string>("DetalleDe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grupo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<int?>("ItemId2")
                        .HasColumnType("int");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<float>("Rendimiento")
                        .HasColumnType("real");

                    b.Property<string>("Unidad")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnalisisUnitarioId");

                    b.HasIndex("AnalisisUnitarioId2");

                    b.HasIndex("ItemId");

                    b.HasIndex("ItemId2");

                    b.ToTable("Detalle");
                });

            modelBuilder.Entity("Presupuesto.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Actividad")
                        .HasColumnType("int");

                    b.Property<int>("Aporte")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int?>("CapituloId")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Frente")
                        .HasColumnType("int");

                    b.Property<int?>("NumeroCapitulo")
                        .HasColumnType("int");

                    b.Property<int>("ProyectoId")
                        .HasColumnType("int");

                    b.Property<string>("Unidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ValorUnitario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CapituloId");

                    b.HasIndex("ProyectoId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("Presupuesto.Models.Proyecto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comentarios")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contratante")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fecha_Modificacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fecha_Presentacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre_Obra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Porcentaje_Menor")
                        .HasColumnType("real");

                    b.Property<string>("Proponente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Proyecto");
                });

            modelBuilder.Entity("Presupuesto.Models.RecursoBasico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clasificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grupo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Precio")
                        .HasColumnType("bigint");

                    b.Property<string>("Unidad")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RecursoBasico");
                });

            modelBuilder.Entity("Presupuesto.Models.AnalisisUnitario", b =>
                {
                    b.HasOne("Presupuesto.Models.Proyecto", "Proyecto")
                        .WithMany()
                        .HasForeignKey("ProyectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Presupuesto.Models.Capitulo", b =>
                {
                    b.HasOne("Presupuesto.Models.Proyecto", "Proyecto")
                        .WithMany()
                        .HasForeignKey("ProyectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Presupuesto.Models.CostoIndirecto", b =>
                {
                    b.HasOne("Presupuesto.Models.Proyecto", "Proyecto")
                        .WithMany()
                        .HasForeignKey("ProyectoId");
                });

            modelBuilder.Entity("Presupuesto.Models.Detalle", b =>
                {
                    b.HasOne("Presupuesto.Models.AnalisisUnitario", "AnalisisUnitario")
                        .WithMany()
                        .HasForeignKey("AnalisisUnitarioId");

                    b.HasOne("Presupuesto.Models.AnalisisUnitario", null)
                        .WithMany("Detalles")
                        .HasForeignKey("AnalisisUnitarioId2");

                    b.HasOne("Presupuesto.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.HasOne("Presupuesto.Models.Item", null)
                        .WithMany("Detalles")
                        .HasForeignKey("ItemId2");
                });

            modelBuilder.Entity("Presupuesto.Models.Item", b =>
                {
                    b.HasOne("Presupuesto.Models.Capitulo", "capitulo")
                        .WithMany()
                        .HasForeignKey("CapituloId");

                    b.HasOne("Presupuesto.Models.Proyecto", "Proyecto")
                        .WithMany()
                        .HasForeignKey("ProyectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
