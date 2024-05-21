﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using rsAPIElevador.DataSchema;

#nullable disable

namespace rsAPIElevador.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231024135728_doce")]
    partial class doce
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", true)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("rsAPIElevador.DataSchema.EJ_Usuario", b =>
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

            modelBuilder.Entity("rsAPIElevador.DataSchema.EV_Administracion", b =>
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
                        .HasColumnType("text");

                    b.Property<string>("Email")
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
                        .HasColumnType("text");

                    b.HasKey("IdAdministracion");

                    b.ToTable("EV_Administracion");
                });

            modelBuilder.Entity("rsAPIElevador.DataSchema.EV_Conservadora", b =>
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
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Expediente")
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaAct")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("boolean");

                    b.Property<int?>("IdCalle")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("IniAct")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefono")
                        .HasColumnType("text");

                    b.HasKey("IdConservadora");

                    b.ToTable("EV_Conservadora");
                });

            modelBuilder.Entity("rsAPIElevador.DataSchema.EV_Maquina", b =>
                {
                    b.Property<int>("IdMaquina")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdMaquina"));

                    b.Property<bool>("Activo")
                        .HasColumnType("boolean");

                    b.Property<string>("CapacidadCarga")
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaFabricacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("boolean");

                    b.Property<int?>("IdTipoEquipamiento")
                        .HasColumnType("integer");

                    b.Property<int?>("IdVelocidadXMaquina")
                        .HasColumnType("integer");

                    b.Property<int?>("Metros")
                        .HasColumnType("integer");

                    b.Property<string>("Modelo")
                        .HasColumnType("text");

                    b.Property<string>("NroSerie")
                        .HasColumnType("text");

                    b.Property<string>("Observaciones")
                        .HasColumnType("text");

                    b.Property<int?>("Paradas")
                        .HasColumnType("integer");

                    b.HasKey("IdMaquina");

                    b.HasIndex("IdTipoEquipamiento");

                    b.ToTable("EV_Maquina");
                });

            modelBuilder.Entity("rsAPIElevador.DataSchema.EV_Obra", b =>
                {
                    b.Property<int>("IdObra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdObra"));

                    b.Property<bool>("Activo")
                        .HasColumnType("boolean");

                    b.Property<int?>("Altura")
                        .HasColumnType("integer");

                    b.Property<string>("Expediente")
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaAct")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FechaIns")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FechaLibro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("boolean");

                    b.Property<int?>("IdAdministacion")
                        .HasColumnType("integer");

                    b.Property<int?>("IdCalle")
                        .HasColumnType("integer");

                    b.Property<int?>("IdTipoObra")
                        .HasColumnType("integer");

                    b.Property<int?>("Libro")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Observaciones")
                        .HasColumnType("text");

                    b.HasKey("IdObra");

                    b.HasIndex("IdAdministacion");

                    b.HasIndex("IdTipoObra");

                    b.ToTable("EV_Obra");
                });

            modelBuilder.Entity("rsAPIElevador.DataSchema.EV_RepTecnico", b =>
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
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaAct")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("boolean");

                    b.Property<int?>("IdCalle")
                        .HasColumnType("integer");

                    b.Property<string>("MatMuni")
                        .HasColumnType("text");

                    b.Property<string>("MatProf")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefono")
                        .HasColumnType("text");

                    b.HasKey("IdRepTecnico");

                    b.ToTable("EV_RepTecnico");
                });

            modelBuilder.Entity("rsAPIElevador.DataSchema.EV_Seguro", b =>
                {
                    b.Property<int>("IdSeguro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdSeguro"));

                    b.Property<bool>("Activo")
                        .HasColumnType("boolean");

                    b.Property<int?>("Altura")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("FechaAct")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("boolean");

                    b.Property<int?>("IdCalle")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdSeguro");

                    b.ToTable("EV_Seguro");
                });

            modelBuilder.Entity("rsAPIElevador.DataSchema.EV_TipoEquipamiento", b =>
                {
                    b.Property<int>("IdTipoEquipamiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdTipoEquipamiento"));

                    b.Property<bool>("Activo")
                        .HasColumnType("boolean");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaAct")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("IdTipoEquipamiento");

                    b.ToTable("EV_TipoEquipamiento");
                });

            modelBuilder.Entity("rsAPIElevador.DataSchema.EV_TipoObra", b =>
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

            modelBuilder.Entity("rsAPIElevador.DataSchema.EV_Velocidades", b =>
                {
                    b.Property<int>("IdVelocidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdVelocidad"));

                    b.Property<bool>("Activo")
                        .HasColumnType("boolean");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaAct")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("IdVelocidad");

                    b.ToTable("EV_Velocidades");
                });

            modelBuilder.Entity("rsAPIElevador.DataSchema.EV_Maquina", b =>
                {
                    b.HasOne("rsAPIElevador.DataSchema.EV_TipoEquipamiento", "EV_TipoEquipamiento")
                        .WithMany("EV_Maquina")
                        .HasForeignKey("IdTipoEquipamiento");

                    b.Navigation("EV_TipoEquipamiento");
                });

            modelBuilder.Entity("rsAPIElevador.DataSchema.EV_Obra", b =>
                {
                    b.HasOne("rsAPIElevador.DataSchema.EV_Administracion", "EV_Administracion")
                        .WithMany("EV_Obra")
                        .HasForeignKey("IdAdministacion");

                    b.HasOne("rsAPIElevador.DataSchema.EV_TipoObra", "EV_TipoObra")
                        .WithMany("EV_Obra")
                        .HasForeignKey("IdTipoObra");

                    b.Navigation("EV_Administracion");

                    b.Navigation("EV_TipoObra");
                });

            modelBuilder.Entity("rsAPIElevador.DataSchema.EV_Administracion", b =>
                {
                    b.Navigation("EV_Obra");
                });

            modelBuilder.Entity("rsAPIElevador.DataSchema.EV_TipoEquipamiento", b =>
                {
                    b.Navigation("EV_Maquina");
                });

            modelBuilder.Entity("rsAPIElevador.DataSchema.EV_TipoObra", b =>
                {
                    b.Navigation("EV_Obra");
                });
#pragma warning restore 612, 618
        }
    }
}
