﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using API.DataSchema;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EV_AdministracionEV_Conservadora", b =>
                {
                    b.Property<int>("EV_AdministracionIdAdministracion")
                        .HasColumnType("integer");

                    b.Property<int>("EV_ConservadoraIdConservadora")
                        .HasColumnType("integer");

                    b.HasKey("EV_AdministracionIdAdministracion", "EV_ConservadoraIdConservadora");

                    b.HasIndex("EV_ConservadoraIdConservadora");

                    b.ToTable("EV_AdministracionEV_Conservadora");
                });

            modelBuilder.Entity("EV_ConservadoraEV_RepTecnico", b =>
                {
                    b.Property<int>("EV_ConservadoraIdConservadora")
                        .HasColumnType("integer");

                    b.Property<int>("EV_RepTecnicoIdRepTecnico")
                        .HasColumnType("integer");

                    b.HasKey("EV_ConservadoraIdConservadora", "EV_RepTecnicoIdRepTecnico");

                    b.HasIndex("EV_RepTecnicoIdRepTecnico");

                    b.ToTable("EV_ConservadoraEV_RepTecnico");
                });

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
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaAct")
                        .HasColumnType("timestamp without time zone");

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

            modelBuilder.Entity("API.DataSchema.EV_Calle", b =>
                {
                    b.Property<int>("IdCalle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdCalle"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdCalle");

                    b.ToTable("EV_Calle");
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
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Expediente")
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaAct")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("boolean");

                    b.Property<int?>("IdCalle")
                        .HasColumnType("integer");

                    b.Property<int?>("IdSeguro")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("IniAct")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefono")
                        .HasColumnType("text");

                    b.HasKey("IdConservadora");

                    b.HasIndex("IdSeguro");

                    b.ToTable("EV_Conservadora");
                });

            modelBuilder.Entity("API.DataSchema.EV_Maquina", b =>
                {
                    b.Property<int>("IdMaquina")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdMaquina"));

                    b.Property<bool>("Activo")
                        .HasColumnType("boolean");

                    b.Property<string>("CapacidadCarga")
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaAct")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("FechaFabricacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("FechaLib")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("boolean");

                    b.Property<int?>("IdConservadora")
                        .HasColumnType("integer");

                    b.Property<int?>("IdObra")
                        .HasColumnType("integer");

                    b.Property<int?>("IdRepTecnico")
                        .HasColumnType("integer");

                    b.Property<int?>("IdTipoEquipamiento")
                        .HasColumnType("integer");

                    b.Property<int?>("IdVelocidad")
                        .HasColumnType("integer");

                    b.Property<int?>("IdVelocidadXMaquina")
                        .HasColumnType("integer");

                    b.Property<int?>("Libro")
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

                    b.HasIndex("IdConservadora");

                    b.HasIndex("IdObra");

                    b.HasIndex("IdRepTecnico");

                    b.HasIndex("IdTipoEquipamiento");

                    b.HasIndex("IdVelocidad");

                    b.ToTable("EV_Maquina");
                });

            modelBuilder.Entity("API.DataSchema.EV_Obra", b =>
                {
                    b.Property<int>("IdObra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdObra"));

                    b.Property<bool>("Activo")
                        .HasColumnType("boolean");

                    b.Property<int?>("Altura")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Expediente")
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaAct")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("FechaAdm")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("FechaCons")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("FechaIns")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("boolean");

                    b.Property<int?>("IdAdministracion")
                        .HasColumnType("integer");

                    b.Property<int?>("IdCalle")
                        .HasColumnType("integer");

                    b.Property<int?>("IdCons")
                        .HasColumnType("integer");

                    b.Property<int?>("IdTipoObra")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.Property<string>("Observaciones")
                        .HasColumnType("text");

                    b.Property<string>("Telefono")
                        .HasColumnType("text");

                    b.HasKey("IdObra");

                    b.HasIndex("IdAdministracion");

                    b.HasIndex("IdTipoObra");

                    b.ToTable("EV_Obra");
                });

            modelBuilder.Entity("API.DataSchema.EV_Persona", b =>
                {
                    b.Property<int>("IdPersona")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdPersona"));

                    b.Property<bool?>("Activo")
                        .HasColumnType("boolean");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NroLegajo")
                        .HasColumnType("integer");

                    b.HasKey("IdPersona");

                    b.ToTable("EV_Persona");
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
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaAct")
                        .HasColumnType("timestamp without time zone");

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

            modelBuilder.Entity("API.DataSchema.EV_Seguro", b =>
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
                        .HasColumnType("timestamp without time zone");

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

            modelBuilder.Entity("API.DataSchema.EV_TipoEquipamiento", b =>
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
                        .HasColumnType("timestamp without time zone");

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
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("IdTipoObra");

                    b.ToTable("EV_TipoObra");
                });

            modelBuilder.Entity("API.DataSchema.EV_Velocidades", b =>
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
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("IdVelocidad");

                    b.ToTable("EV_Velocidades");
                });

            modelBuilder.Entity("EV_AdministracionEV_Conservadora", b =>
                {
                    b.HasOne("API.DataSchema.EV_Administracion", null)
                        .WithMany()
                        .HasForeignKey("EV_AdministracionIdAdministracion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.DataSchema.EV_Conservadora", null)
                        .WithMany()
                        .HasForeignKey("EV_ConservadoraIdConservadora")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EV_ConservadoraEV_RepTecnico", b =>
                {
                    b.HasOne("API.DataSchema.EV_Conservadora", null)
                        .WithMany()
                        .HasForeignKey("EV_ConservadoraIdConservadora")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.DataSchema.EV_RepTecnico", null)
                        .WithMany()
                        .HasForeignKey("EV_RepTecnicoIdRepTecnico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.DataSchema.EV_Conservadora", b =>
                {
                    b.HasOne("API.DataSchema.EV_Seguro", "EV_Seguro")
                        .WithMany("EV_Conservadora")
                        .HasForeignKey("IdSeguro");

                    b.Navigation("EV_Seguro");
                });

            modelBuilder.Entity("API.DataSchema.EV_Maquina", b =>
                {
                    b.HasOne("API.DataSchema.EV_Conservadora", "EV_Conservadora")
                        .WithMany("EV_Maquina")
                        .HasForeignKey("IdConservadora");

                    b.HasOne("API.DataSchema.EV_Obra", "EV_Obra")
                        .WithMany("EV_Maquina")
                        .HasForeignKey("IdObra");

                    b.HasOne("API.DataSchema.EV_RepTecnico", "EV_RepTecnico")
                        .WithMany("EV_Maquina")
                        .HasForeignKey("IdRepTecnico");

                    b.HasOne("API.DataSchema.EV_TipoEquipamiento", "EV_TipoEquipamiento")
                        .WithMany("EV_Maquina")
                        .HasForeignKey("IdTipoEquipamiento");

                    b.HasOne("API.DataSchema.EV_Velocidades", "EV_Velocidades")
                        .WithMany("EV_Maquina")
                        .HasForeignKey("IdVelocidad");

                    b.Navigation("EV_Conservadora");

                    b.Navigation("EV_Obra");

                    b.Navigation("EV_RepTecnico");

                    b.Navigation("EV_TipoEquipamiento");

                    b.Navigation("EV_Velocidades");
                });

            modelBuilder.Entity("API.DataSchema.EV_Obra", b =>
                {
                    b.HasOne("API.DataSchema.EV_Administracion", "EV_Administracion")
                        .WithMany("EV_Obra")
                        .HasForeignKey("IdAdministracion");

                    b.HasOne("API.DataSchema.EV_TipoObra", "EV_TipoObra")
                        .WithMany("EV_Obra")
                        .HasForeignKey("IdTipoObra");

                    b.Navigation("EV_Administracion");

                    b.Navigation("EV_TipoObra");
                });

            modelBuilder.Entity("API.DataSchema.EV_Administracion", b =>
                {
                    b.Navigation("EV_Obra");
                });

            modelBuilder.Entity("API.DataSchema.EV_Conservadora", b =>
                {
                    b.Navigation("EV_Maquina");
                });

            modelBuilder.Entity("API.DataSchema.EV_Obra", b =>
                {
                    b.Navigation("EV_Maquina");
                });

            modelBuilder.Entity("API.DataSchema.EV_RepTecnico", b =>
                {
                    b.Navigation("EV_Maquina");
                });

            modelBuilder.Entity("API.DataSchema.EV_Seguro", b =>
                {
                    b.Navigation("EV_Conservadora");
                });

            modelBuilder.Entity("API.DataSchema.EV_TipoEquipamiento", b =>
                {
                    b.Navigation("EV_Maquina");
                });

            modelBuilder.Entity("API.DataSchema.EV_TipoObra", b =>
                {
                    b.Navigation("EV_Obra");
                });

            modelBuilder.Entity("API.DataSchema.EV_Velocidades", b =>
                {
                    b.Navigation("EV_Maquina");
                });
#pragma warning restore 612, 618
        }
    }
}
