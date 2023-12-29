﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingApp.Services.Order.API.Infrastructure.Persistence.Context;

#nullable disable

namespace ShoppingApp.Services.Order.API.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(OrderContext))]
    [Migration("20231229130354_AddOrderStatus")]
    partial class AddOrderStatus
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("OrderSchema")
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("orderseq")
                .IncrementsBy(10);

            modelBuilder.Entity("ShoppingApp.Services.Order.API.Domain.AggregatesModel.Order.Entities.OrderAggregateRoot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "orderseq");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int")
                        .HasColumnName("OrderStatusId");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int")
                        .HasColumnName("PaymentMethod");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("decimal(6,2)")
                        .HasColumnName("TotalPrice");

                    b.Property<string>("_createdBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime>("_createdDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<string>("_lastModifiedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LastModifiedBy");

                    b.Property<DateTime?>("_lastModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("LastModifiedDate");

                    b.HasKey("Id");

                    b.ToTable("Orders", "OrderSchema");
                });

            modelBuilder.Entity("ShoppingApp.Services.Order.API.Domain.AggregatesModel.Order.Entities.OrderAggregateRoot", b =>
                {
                    b.OwnsOne("ShoppingApp.Services.Order.API.Domain.AggregatesModel.Order.ValueObjects.AddressValueObject", "BillingAddress", b1 =>
                        {
                            b1.Property<int>("OrderAggregateRootId")
                                .HasColumnType("int");

                            b1.Property<string>("AddressLine")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("AddressLine");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Country");

                            b1.Property<string>("EmailAddress")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("EmailAddress");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("LastName");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("State");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("ZipCode");

                            b1.HasKey("OrderAggregateRootId");

                            b1.ToTable("Orders", "OrderSchema");

                            b1.WithOwner()
                                .HasForeignKey("OrderAggregateRootId");
                        });

                    b.OwnsOne("ShoppingApp.Services.Order.API.Domain.AggregatesModel.Order.ValueObjects.CustomerValueObject", "Customer", b1 =>
                        {
                            b1.Property<int>("OrderAggregateRootId")
                                .HasColumnType("int");

                            b1.Property<string>("UserName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("UserName");

                            b1.HasKey("OrderAggregateRootId");

                            b1.ToTable("Orders", "OrderSchema");

                            b1.WithOwner()
                                .HasForeignKey("OrderAggregateRootId");
                        });

                    b.OwnsOne("ShoppingApp.Services.Order.API.Domain.AggregatesModel.Payment.PaymentCardValueObject", "PaymentCard", b1 =>
                        {
                            b1.Property<int>("OrderAggregateRootId")
                                .HasColumnType("int");

                            b1.Property<string>("CardName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("CardName");

                            b1.Property<string>("CardNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("CardNumber");

                            b1.Property<string>("CardVerificationValue")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("CardVerificationValue");

                            b1.Property<string>("Expiration")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Expiration");

                            b1.HasKey("OrderAggregateRootId");

                            b1.ToTable("Orders", "OrderSchema");

                            b1.WithOwner()
                                .HasForeignKey("OrderAggregateRootId");
                        });

                    b.Navigation("BillingAddress")
                        .IsRequired();

                    b.Navigation("Customer")
                        .IsRequired();

                    b.Navigation("PaymentCard")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
