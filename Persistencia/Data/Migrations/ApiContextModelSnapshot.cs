﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia;

#nullable disable

namespace Persistencia.Data.Migrations
{
    [DbContext(typeof(ApiContext))]
    partial class ApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb3_general_ci")
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb3");

            modelBuilder.Entity("Dominio.Entities.CategoriaPersona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("NombreCategoria")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("categoriapersona", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("IdDepartamentoFk")
                        .HasColumnType("int");

                    b.Property<string>("NombreCiudad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdDepartamentoFk" }, "IdDepartamentofk_idx");

                    b.ToTable("ciudad", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.ContactoPersona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<int>("IdPersonaFk")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoContactoFk")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Descripcion" }, "Descripcion_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "IdPersonaFk" }, "IdPersona_idx");

                    b.HasIndex(new[] { "IdTipoContactoFk" }, "IdTipoContactoFk_idx");

                    b.ToTable("contactopersona", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Contrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("FechaContrato")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdEmpleadoFk")
                        .HasColumnType("int");

                    b.Property<int>("IdEstadoFk")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdCliente" }, "IdClienteFk_idx");

                    b.HasIndex(new[] { "IdEmpleadoFk" }, "IdEmpleadoFk_idx");

                    b.HasIndex(new[] { "IdEstadoFk" }, "IdEstadoFk_idx");

                    b.ToTable("contrato", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("IdPaisFk")
                        .HasColumnType("int");

                    b.Property<string>("NombreDep")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdPaisFk" }, "IdPaisFk_idx");

                    b.ToTable("departamento", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.DireccionPersona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("IdPersonaFk")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoDireccionFk")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdPersonaFk" }, "IdPersonaFk_idx");

                    b.HasIndex(new[] { "IdTipoDireccionFk" }, "IdTipoDireccionFk_idx");

                    b.ToTable("direccionpersona", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("estado", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("NombrePais")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("pais", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Apellido2")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<int>("IdCategoriaPersonaFk")
                        .HasColumnType("int");

                    b.Property<int>("IdCiudaFk")
                        .HasColumnType("int");

                    b.Property<int?>("IdPersonaU")
                        .HasColumnType("int")
                        .HasColumnName("idPersonaU");

                    b.Property<int>("IdTipoPersonaFk")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Nombre2")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdCategoriaPersonaFk" }, "IdCategoriaPersonaFk_idx");

                    b.HasIndex(new[] { "IdCiudaFk" }, "IdCiudadFk_idx");

                    b.HasIndex(new[] { "IdTipoPersonaFk" }, "IdTipoPersonaFk_idx");

                    b.HasIndex(new[] { "IdPersonaU" }, "idPersonaU_UNIQUE")
                        .IsUnique();

                    b.ToTable("persona", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Programacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("IdContratoFk")
                        .HasColumnType("int");

                    b.Property<int>("IdEmpleadoFk")
                        .HasColumnType("int");

                    b.Property<int>("IdTurnoFk")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdContratoFk" }, "IdContratoFk_idx");

                    b.HasIndex(new[] { "IdEmpleadoFk" }, "IdEmpleadoFk_idx")
                        .HasDatabaseName("IdEmpleadoFk_idx1");

                    b.HasIndex(new[] { "IdTurnoFk" }, "IdTurnoFk_idx");

                    b.ToTable("programacion", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime");

                    b.Property<int>("IdUsuarioFk")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Revoked")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdUsuarioFk" }, "IdUsuario_idx");

                    b.ToTable("refreshtoken", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Nombre")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("rol", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.RolUsuario", b =>
                {
                    b.Property<int>("IdUsuarioFk")
                        .HasColumnType("int");

                    b.Property<int>("IdRolFk")
                        .HasColumnType("int");

                    b.HasKey("IdUsuarioFk", "IdRolFk");

                    b.HasIndex("IdRolFk");

                    b.ToTable("RolUsuario", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.TipoContacto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("tipocontacto", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.TipoDireccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("tipodireccion", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.TipoPersona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("tipopersona", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Turno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("HoraFinal")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("HoraInicio")
                        .HasColumnType("datetime");

                    b.Property<string>("NombreTurno")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("turno", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("usuario", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Ciudad", b =>
                {
                    b.HasOne("Dominio.Entities.Departamento", "IdDepartamentoFkNavigation")
                        .WithMany("Ciudades")
                        .HasForeignKey("IdDepartamentoFk")
                        .IsRequired()
                        .HasConstraintName("IdDepartamentofk");

                    b.Navigation("IdDepartamentoFkNavigation");
                });

            modelBuilder.Entity("Dominio.Entities.ContactoPersona", b =>
                {
                    b.HasOne("Dominio.Entities.Persona", "IdPersonaFkNavigation")
                        .WithMany("ContactoPersonas")
                        .HasForeignKey("IdPersonaFk")
                        .IsRequired()
                        .HasConstraintName("IdPersona");

                    b.HasOne("Dominio.Entities.TipoContacto", "IdTipoContactoFkNavigation")
                        .WithMany("ContactoPersonas")
                        .HasForeignKey("IdTipoContactoFk")
                        .IsRequired()
                        .HasConstraintName("IdTipoContactoFk");

                    b.Navigation("IdPersonaFkNavigation");

                    b.Navigation("IdTipoContactoFkNavigation");
                });

            modelBuilder.Entity("Dominio.Entities.Contrato", b =>
                {
                    b.HasOne("Dominio.Entities.Persona", "IdClienteNavigation")
                        .WithMany("ContratoIdClienteNavigations")
                        .HasForeignKey("IdCliente")
                        .IsRequired()
                        .HasConstraintName("IdClienteFk");

                    b.HasOne("Dominio.Entities.Persona", "IdEmpleadoFkNavigation")
                        .WithMany("ContratoIdEmpleadoFkNavigations")
                        .HasForeignKey("IdEmpleadoFk")
                        .IsRequired()
                        .HasConstraintName("IdEmpleadoFk");

                    b.HasOne("Dominio.Entities.Estado", "IdEstadoFkNavigation")
                        .WithMany("Contratos")
                        .HasForeignKey("IdEstadoFk")
                        .IsRequired()
                        .HasConstraintName("IdEstadoFk");

                    b.Navigation("IdClienteNavigation");

                    b.Navigation("IdEmpleadoFkNavigation");

                    b.Navigation("IdEstadoFkNavigation");
                });

            modelBuilder.Entity("Dominio.Entities.Departamento", b =>
                {
                    b.HasOne("Dominio.Entities.Pais", "IdPaisFkNavigation")
                        .WithMany("Departamentos")
                        .HasForeignKey("IdPaisFk")
                        .IsRequired()
                        .HasConstraintName("IdPaisFk");

                    b.Navigation("IdPaisFkNavigation");
                });

            modelBuilder.Entity("Dominio.Entities.DireccionPersona", b =>
                {
                    b.HasOne("Dominio.Entities.Persona", "IdPersonaFkNavigation")
                        .WithMany("DireccionPersonas")
                        .HasForeignKey("IdPersonaFk")
                        .IsRequired()
                        .HasConstraintName("IdPersonaFk");

                    b.HasOne("Dominio.Entities.TipoDireccion", "IdTipoDireccionFkNavigation")
                        .WithMany("DireccionPersonas")
                        .HasForeignKey("IdTipoDireccionFk")
                        .IsRequired()
                        .HasConstraintName("IdTipoDireccionFk");

                    b.Navigation("IdPersonaFkNavigation");

                    b.Navigation("IdTipoDireccionFkNavigation");
                });

            modelBuilder.Entity("Dominio.Entities.Persona", b =>
                {
                    b.HasOne("Dominio.Entities.CategoriaPersona", "IdCategoriaPersonaFkNavigation")
                        .WithMany("Personas")
                        .HasForeignKey("IdCategoriaPersonaFk")
                        .IsRequired()
                        .HasConstraintName("IdCategoriaPersonaFk");

                    b.HasOne("Dominio.Entities.Ciudad", "IdCiudaFkNavigation")
                        .WithMany("Personas")
                        .HasForeignKey("IdCiudaFk")
                        .IsRequired()
                        .HasConstraintName("IdCiudadFk");

                    b.HasOne("Dominio.Entities.TipoPersona", "IdTipoPersonaFkNavigation")
                        .WithMany("Personas")
                        .HasForeignKey("IdTipoPersonaFk")
                        .IsRequired()
                        .HasConstraintName("IdTipoPersonaFk");

                    b.Navigation("IdCategoriaPersonaFkNavigation");

                    b.Navigation("IdCiudaFkNavigation");

                    b.Navigation("IdTipoPersonaFkNavigation");
                });

            modelBuilder.Entity("Dominio.Entities.Programacion", b =>
                {
                    b.HasOne("Dominio.Entities.Contrato", "IdContratoFkNavigation")
                        .WithMany("Programacions")
                        .HasForeignKey("IdContratoFk")
                        .IsRequired()
                        .HasConstraintName("IdContratoFk");

                    b.HasOne("Dominio.Entities.Persona", "IdEmpleadoFkNavigation")
                        .WithMany("Programaciones")
                        .HasForeignKey("IdEmpleadoFk")
                        .IsRequired()
                        .HasConstraintName("IdEmpleado");

                    b.HasOne("Dominio.Entities.Turno", "IdTurnoFkNavigation")
                        .WithMany("Programaciones")
                        .HasForeignKey("IdTurnoFk")
                        .IsRequired()
                        .HasConstraintName("IdTurnoFk");

                    b.Navigation("IdContratoFkNavigation");

                    b.Navigation("IdEmpleadoFkNavigation");

                    b.Navigation("IdTurnoFkNavigation");
                });

            modelBuilder.Entity("Dominio.Entities.RefreshToken", b =>
                {
                    b.HasOne("Dominio.Entities.Usuario", "IdUsuarioFkNavigation")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("IdUsuarioFk")
                        .IsRequired()
                        .HasConstraintName("IdUsuarioFK");

                    b.Navigation("IdUsuarioFkNavigation");
                });

            modelBuilder.Entity("Dominio.Entities.RolUsuario", b =>
                {
                    b.HasOne("Dominio.Entities.Rol", "Rol")
                        .WithMany("RolesUsuarios")
                        .HasForeignKey("IdRolFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.Usuario", "Usuario")
                        .WithMany("RolesUsuarios")
                        .HasForeignKey("IdUsuarioFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Dominio.Entities.CategoriaPersona", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Dominio.Entities.Ciudad", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Dominio.Entities.Contrato", b =>
                {
                    b.Navigation("Programacions");
                });

            modelBuilder.Entity("Dominio.Entities.Departamento", b =>
                {
                    b.Navigation("Ciudades");
                });

            modelBuilder.Entity("Dominio.Entities.Estado", b =>
                {
                    b.Navigation("Contratos");
                });

            modelBuilder.Entity("Dominio.Entities.Pais", b =>
                {
                    b.Navigation("Departamentos");
                });

            modelBuilder.Entity("Dominio.Entities.Persona", b =>
                {
                    b.Navigation("ContactoPersonas");

                    b.Navigation("ContratoIdClienteNavigations");

                    b.Navigation("ContratoIdEmpleadoFkNavigations");

                    b.Navigation("DireccionPersonas");

                    b.Navigation("Programaciones");
                });

            modelBuilder.Entity("Dominio.Entities.Rol", b =>
                {
                    b.Navigation("RolesUsuarios");
                });

            modelBuilder.Entity("Dominio.Entities.TipoContacto", b =>
                {
                    b.Navigation("ContactoPersonas");
                });

            modelBuilder.Entity("Dominio.Entities.TipoDireccion", b =>
                {
                    b.Navigation("DireccionPersonas");
                });

            modelBuilder.Entity("Dominio.Entities.TipoPersona", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Dominio.Entities.Turno", b =>
                {
                    b.Navigation("Programaciones");
                });

            modelBuilder.Entity("Dominio.Entities.Usuario", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("RolesUsuarios");
                });
#pragma warning restore 612, 618
        }
    }
}