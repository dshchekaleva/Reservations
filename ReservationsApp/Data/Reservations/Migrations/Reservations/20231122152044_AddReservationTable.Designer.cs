﻿// <auto-generated />
using System;
using ReservationsApp.Data.Reservations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ReservationsApp.Migrations.Reservations
{
[DbContext(typeof(ReservationsContext))]
[Migration("20231122152044_AddReservationTable")]
partial class AddReservationTable
{
/// <inheritdoc />
protected override void BuildTargetModel(ModelBuilder modelBuilder)
{
#pragma warning disable 612, 618
modelBuilder
.HasAnnotation("ProductVersion", "8.0.0")
.HasAnnotation("Relational:MaxIdentifierLength", 128);

SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

modelBuilder.Entity("ReservationsApp.Data.Reservations.Reservation", b =>
{
b.Property<Guid>("Id")
.ValueGeneratedOnAdd()
.HasColumnType("uniqueidentifier");

b.Property<int>("ReservationLength")
.ValueGeneratedOnAdd()
.HasColumnType("int")
.HasDefaultValue(1);

b.Property<DateTime>("ReservationStart")
.HasColumnType("datetime2");

b.Property<string>("UserId")
.IsRequired()
.HasColumnType("nvarchar(max)");

b.HasKey("Id");

b.ToTable("Reservations");
});
#pragma warning restore 612, 618
}
}
}
