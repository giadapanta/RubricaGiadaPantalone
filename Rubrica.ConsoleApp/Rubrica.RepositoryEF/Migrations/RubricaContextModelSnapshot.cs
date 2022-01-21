﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rubrica.RepositoryEF;

#nullable disable

namespace Rubrica.RepositoryEF.Migrations
{
    [DbContext(typeof(RubricaContext))]
    partial class RubricaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Rubrica.Core.Entities.Contatto", b =>
                {
                    b.Property<int>("ContattoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContattoID"), 1L, 1);

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContattoID");

                    b.ToTable("Contatto", (string)null);
                });

            modelBuilder.Entity("Rubrica.Core.Entities.Indirizzo", b =>
                {
                    b.Property<int>("IndirizzoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IndirizzoID"), 1L, 1);

                    b.Property<int>("Cap")
                        .HasMaxLength(5)
                        .HasColumnType("int")
                        .IsFixedLength();

                    b.Property<string>("Citta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContattoID")
                        .HasColumnType("int");

                    b.Property<string>("Nazione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipologia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Via")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IndirizzoID");

                    b.HasIndex("ContattoID");

                    b.ToTable("Indirizzo", (string)null);
                });

            modelBuilder.Entity("Rubrica.Core.Entities.Indirizzo", b =>
                {
                    b.HasOne("Rubrica.Core.Entities.Contatto", "Contatto")
                        .WithMany("Indirizzi")
                        .HasForeignKey("ContattoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contatto");
                });

            modelBuilder.Entity("Rubrica.Core.Entities.Contatto", b =>
                {
                    b.Navigation("Indirizzi");
                });
#pragma warning restore 612, 618
        }
    }
}
