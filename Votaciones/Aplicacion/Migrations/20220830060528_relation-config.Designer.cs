﻿// <auto-generated />
using System;
using Aplicacion.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aplicacion.Migrations
{
    [DbContext(typeof(EscrutinioDbContext))]
    [Migration("20220830060528_relation-config")]
    partial class relationconfig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Aplicacion.Dominio.Entidades.Escrutinio.Acta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ActaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CantidadVotaciones")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime>("Creado")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreadoPor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<bool>("FirmaPresidente")
                        .HasColumnType("bit");

                    b.Property<bool>("FirmaSecretario")
                        .HasColumnType("bit");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("JRVId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modificado")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModificadoPor")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PapeletaId")
                        .HasColumnType("int");

                    b.Property<int>("VotosBlancos")
                        .HasColumnType("int");

                    b.Property<int>("VotosNulos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JRVId", "PapeletaId")
                        .IsUnique();

                    b.ToTable("Actas");
                });

            modelBuilder.Entity("Aplicacion.Dominio.Entidades.Escrutinio.Candidato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CandidatoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime>("Creado")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreadoPor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("Modificado")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModificadoPor")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("OrganizacionPolitica")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("PapeletaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PapeletaId");

                    b.ToTable("Candidatos");
                });

            modelBuilder.Entity("Aplicacion.Dominio.Entidades.Escrutinio.DetalleActa", b =>
                {
                    b.Property<int>("ActaId")
                        .HasColumnType("int");

                    b.Property<int>("CandidatoId")
                        .HasColumnType("int");

                    b.Property<int>("CantidadVotos")
                        .HasColumnType("int");

                    b.Property<DateTime>("Creado")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreadoPor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Modificado")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModificadoPor")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ActaId", "CandidatoId");

                    b.HasIndex("CandidatoId");

                    b.ToTable("Detalles_Acta", (string)null);
                });

            modelBuilder.Entity("Aplicacion.Dominio.Entidades.Escrutinio.JRV", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("JRVId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CantidadVotantes")
                        .HasColumnType("int");

                    b.Property<string>("Canton")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Circunscripcion")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Creado")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreadoPor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DireccionRecinto")
                        .HasMaxLength(300)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("Modificado")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModificadoPor")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Parroquia")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Provincia")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Recinto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TipoParroquia")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ZonaElectoral")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("JRVs");
                });

            modelBuilder.Entity("Aplicacion.Dominio.Entidades.Escrutinio.JRVPapeleta", b =>
                {
                    b.Property<int>("JRVId")
                        .HasColumnType("int");

                    b.Property<int>("PapeletaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Creado")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreadoPor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Modificado")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModificadoPor")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("JRVId", "PapeletaId");

                    b.HasIndex("PapeletaId");

                    b.ToTable("JRVs_Papeletas", (string)null);
                });

            modelBuilder.Entity("Aplicacion.Dominio.Entidades.Escrutinio.Papeleta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PapeletaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime>("Creado")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreadoPor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Dignidad")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("FechaEleccion")
                        .HasColumnType("date");

                    b.Property<DateTime>("Modificado")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModificadoPor")
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Papeletas");
                });

            modelBuilder.Entity("Aplicacion.Dominio.Entidades.Escrutinio.Acta", b =>
                {
                    b.HasOne("Aplicacion.Dominio.Entidades.Escrutinio.JRVPapeleta", "JRVPapeleta")
                        .WithOne("Acta")
                        .HasForeignKey("Aplicacion.Dominio.Entidades.Escrutinio.Acta", "JRVId", "PapeletaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ActasJRVs_Papeletas");

                    b.Navigation("JRVPapeleta");
                });

            modelBuilder.Entity("Aplicacion.Dominio.Entidades.Escrutinio.Candidato", b =>
                {
                    b.HasOne("Aplicacion.Dominio.Entidades.Escrutinio.Papeleta", "Papeleta")
                        .WithMany("Candidatos")
                        .HasForeignKey("PapeletaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_CandidatosPapeletas");

                    b.Navigation("Papeleta");
                });

            modelBuilder.Entity("Aplicacion.Dominio.Entidades.Escrutinio.DetalleActa", b =>
                {
                    b.HasOne("Aplicacion.Dominio.Entidades.Escrutinio.Acta", "Acta")
                        .WithMany("DetalleActas")
                        .HasForeignKey("ActaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_DetallesActasActas");

                    b.HasOne("Aplicacion.Dominio.Entidades.Escrutinio.Candidato", "Candidato")
                        .WithMany("DetalleActas")
                        .HasForeignKey("CandidatoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_DetallesActasCandidatos");

                    b.Navigation("Acta");

                    b.Navigation("Candidato");
                });

            modelBuilder.Entity("Aplicacion.Dominio.Entidades.Escrutinio.JRVPapeleta", b =>
                {
                    b.HasOne("Aplicacion.Dominio.Entidades.Escrutinio.JRV", "JRV")
                        .WithMany("JRVPapeletas")
                        .HasForeignKey("JRVId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_JRVs_PapeletasJRVs");

                    b.HasOne("Aplicacion.Dominio.Entidades.Escrutinio.Papeleta", "Papeleta")
                        .WithMany("JRVPapeletas")
                        .HasForeignKey("PapeletaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_JRVs_PapeletasPapeletas");

                    b.Navigation("JRV");

                    b.Navigation("Papeleta");
                });

            modelBuilder.Entity("Aplicacion.Dominio.Entidades.Escrutinio.Acta", b =>
                {
                    b.Navigation("DetalleActas");
                });

            modelBuilder.Entity("Aplicacion.Dominio.Entidades.Escrutinio.Candidato", b =>
                {
                    b.Navigation("DetalleActas");
                });

            modelBuilder.Entity("Aplicacion.Dominio.Entidades.Escrutinio.JRV", b =>
                {
                    b.Navigation("JRVPapeletas");
                });

            modelBuilder.Entity("Aplicacion.Dominio.Entidades.Escrutinio.JRVPapeleta", b =>
                {
                    b.Navigation("Acta")
                        .IsRequired();
                });

            modelBuilder.Entity("Aplicacion.Dominio.Entidades.Escrutinio.Papeleta", b =>
                {
                    b.Navigation("Candidatos");

                    b.Navigation("JRVPapeletas");
                });
#pragma warning restore 612, 618
        }
    }
}