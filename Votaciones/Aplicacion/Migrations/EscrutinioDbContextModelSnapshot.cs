﻿// <auto-generated />
using Aplicacion.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aplicacion.Migrations
{
    [DbContext(typeof(EscrutinioDbContext))]
    partial class EscrutinioDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CantidadVotaciones")
                        .HasColumnType("int");

                    b.Property<int>("CantidadVotantesJRV")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<bool>("FirmaPresidente")
                        .HasColumnType("bit");

                    b.Property<bool>("FirmaSecretario")
                        .HasColumnType("bit");

                    b.Property<string>("Imagen")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("VotosBlancos")
                        .HasColumnType("int");

                    b.Property<int>("VotosNulos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Acta");
                });
#pragma warning restore 612, 618
        }
    }
}
