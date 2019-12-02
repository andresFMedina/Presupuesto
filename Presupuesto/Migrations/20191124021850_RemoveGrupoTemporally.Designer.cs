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
    [Migration("20191124021850_RemoveGrupoTemporally")]
    partial class RemoveGrupoTemporally
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

                    b.Property<int>("ProyectoId")
                        .HasColumnType("int");

                    b.Property<string>("Unidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Valor_Unitario")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProyectoId");

                    b.ToTable("AnalisisUnitario");
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

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<int?>("RecursoBasicoId")
                        .HasColumnType("int");

                    b.Property<int>("Rendimiento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnalisisUnitarioId");

                    b.HasIndex("AnalisisUnitarioId2");

                    b.HasIndex("ItemId");

                    b.HasIndex("RecursoBasicoId");

                    b.ToTable("Detalle");
                });

            modelBuilder.Entity("Presupuesto.Models.Grupo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abreviatura")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre_Grupo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProyectoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProyectoId");

                    b.ToTable("Grupo");
                });

            modelBuilder.Entity("Presupuesto.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Actividad")
                        .HasColumnType("int");

                    b.Property<string>("Aporte")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Frente")
                        .HasColumnType("int");

                    b.Property<int>("ProyectoId")
                        .HasColumnType("int");

                    b.Property<string>("Unidad")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

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

                    b.Property<float>("Desperdicio_Materiales")
                        .HasColumnType("real");

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

                    b.Property<float>("Porcentaje_Prestaciones_Sociales")
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

                    b.Property<int?>("GrupoId")
                        .HasColumnType("int");

                    b.Property<long>("Precio")
                        .HasColumnType("bigint");

                    b.Property<string>("Unidad")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoId");

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

                    b.HasOne("Presupuesto.Models.Item", null)
                        .WithMany("Detalles")
                        .HasForeignKey("ItemId");

                    b.HasOne("Presupuesto.Models.RecursoBasico", "RecursoBasico")
                        .WithMany()
                        .HasForeignKey("RecursoBasicoId");
                });

            modelBuilder.Entity("Presupuesto.Models.Grupo", b =>
                {
                    b.HasOne("Presupuesto.Models.Proyecto", null)
                        .WithMany("Grupos")
                        .HasForeignKey("ProyectoId");
                });

            modelBuilder.Entity("Presupuesto.Models.Item", b =>
                {
                    b.HasOne("Presupuesto.Models.Proyecto", "Proyecto")
                        .WithMany()
                        .HasForeignKey("ProyectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Presupuesto.Models.RecursoBasico", b =>
                {
                    b.HasOne("Presupuesto.Models.Grupo", "Grupo")
                        .WithMany()
                        .HasForeignKey("GrupoId");
                });
#pragma warning restore 612, 618
        }
    }
}
