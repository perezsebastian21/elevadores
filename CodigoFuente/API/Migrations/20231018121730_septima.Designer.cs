﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using API.DataSchema;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231018121730_septima")]
    partial class septima
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API.DataSchema.EJ_Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdUsuario"));

                    b.Property<bool?>("Activo")
                        .HasColumnType("boolean");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.HasKey("IdUsuario");

                    b.ToTable("EJ_Usuarios");
                });

            modelBuilder.Entity("API.DataSchema.EV_Administracion", b =>
                {
                    b.Property<int>("IdAdministracion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdAdministracion"));

                    b.Property<bool>("Activo")
                        .HasColumnType("boolean");

                    b.Property<int?>("Altura")
                        .HasColumnType("integer");

                    b.Property<string>("Dto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaAct")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("boolean");

                    b.Property<int?>("IdCalle")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdAdministracion");

                    b.ToTable("EV_Administracion");
                });

            modelBuilder.Entity("API.DataSchema.EV_Conservadora", b =>
                {
                    b.Property<int>("IdConservadora")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdConservadora"));

                    b.Property<bool>("Activo")
                        .HasColumnType("boolean");

                    b.Property<int?>("Altura")
                        .HasColumnType("integer");

                    b.Property<int?>("CantOpe")
                        .HasColumnType("integer");

                    b.Property<string>("Dto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Expediente")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaAct")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("boolean");

                    b.Property<int?>("IdCalle")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("IniActa")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdConservadora");

                    b.ToTable("EV_Conservadora");
                });

            modelBuilder.Entity("API.DataSchema.EV_RepTecnico", b =>
                {
                    b.Property<int>("IdRepTecnico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdRepTecnico"));

                    b.Property<bool>("Activo")
                        .HasColumnType("boolean");

                    b.Property<int?>("Altura")
                        .HasColumnType("integer");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaAct")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("boolean");

                    b.Property<int?>("IdCalle")
                        .HasColumnType("integer");

                    b.Property<string>("MatMuni")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MatProf")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdRepTecnico");

                    b.ToTable("EV_RepTecnico");
                });

            modelBuilder.Entity("API.DataSchema.EV_Seguro", b =>
                {
                    b.Property<int>("IdSeguro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdSeguro"));

                    b.Property<int?>("Altura")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("FechaAct")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("IdCalle")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdSeguro");

                    b.ToTable("EV_Seguro");
                });

            modelBuilder.Entity("API.DataSchema.EV_TipoEquipamiento", b =>
                {
                    b.Property<int>("IdTipoEquipamiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdTipoEquipamiento"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaAct")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("IdTipoEquipamiento");

                    b.ToTable("EV_TipoEquipamiento");
                });

            modelBuilder.Entity("API.DataSchema.EV_TipoObra", b =>
                {
                    b.Property<int>("IdTipoObra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdTipoObra"));

                    b.Property<bool>("Activo")
                        .HasColumnType("boolean");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaAct")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("IdTipoObra");

                    b.ToTable("EV_TipoObra");
                });

            modelBuilder.Entity("API.DataSchema.EV_Velocidades", b =>
                {
                    b.Property<int>("IdVelocidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdVelocidad"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaAct")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("IdVelocidad");

                    b.ToTable("EV_Velocidades");
                });
#pragma warning restore 612, 618
        }
    }
}
