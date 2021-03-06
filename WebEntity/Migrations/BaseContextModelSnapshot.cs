﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebEntity.Models;

namespace WebEntity.Migrations
{
    [DbContext(typeof(BaseContext))]
    partial class BaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:.ChequeIdNum", "'ChequeIdNum', '', '1', '1', '1', '2147483647', 'Int32', 'True'")
                .HasAnnotation("Relational:Sequence:.PositionIdNum", "'PositionIdNum', '', '1', '1', '1', '2147483647', 'Int32', 'True'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebEntity.Models.Cheque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("next value for ChequeIdNum");

                    b.Property<DateTime>("Date");

                    b.HasKey("Id");

                    b.ToTable("Cheques");
                });

            modelBuilder.Entity("WebEntity.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("next value for PositionIdNum");

                    b.Property<int?>("ChequeId");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("ChequeId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("WebEntity.Models.Position", b =>
                {
                    b.HasOne("WebEntity.Models.Cheque")
                        .WithMany("Positions")
                        .HasForeignKey("ChequeId");
                });
#pragma warning restore 612, 618
        }
    }
}
