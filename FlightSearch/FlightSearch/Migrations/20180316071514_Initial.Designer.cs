﻿// <auto-generated />
using FlightSearch.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace FlightSearch.Migrations
{
    [DbContext(typeof(FlightContext))]
    [Migration("20180316071514_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FlightSearch.Models.BookingInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Booking_code");

                    b.Property<int>("FlightId");

                    b.Property<int>("Seats_remaining");

                    b.Property<string>("Travel_class");

                    b.HasKey("Id");

                    b.HasIndex("FlightId")
                        .IsUnique();

                    b.ToTable("BookingInfo");
                });

            modelBuilder.Entity("FlightSearch.Models.CityCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Airport");

                    b.Property<string>("Code");

                    b.Property<string>("Country");

                    b.HasKey("Id");

                    b.ToTable("CityCode");
                });

            modelBuilder.Entity("FlightSearch.Models.Destination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Airport");

                    b.Property<int>("FlightId");

                    b.Property<string>("Terminal");

                    b.HasKey("Id");

                    b.HasIndex("FlightId")
                        .IsUnique();

                    b.ToTable("Destination");
                });

            modelBuilder.Entity("FlightSearch.Models.Fare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ResultId");

                    b.Property<string>("Total_price");

                    b.HasKey("Id");

                    b.HasIndex("ResultId")
                        .IsUnique()
                        .HasFilter("[ResultId] IS NOT NULL");

                    b.ToTable("Fare");
                });

            modelBuilder.Entity("FlightSearch.Models.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Aircraft");

                    b.Property<string>("Arrives_at");

                    b.Property<string>("Departs_at");

                    b.Property<string>("Flight_number");

                    b.Property<int?>("InboundId");

                    b.Property<string>("Marketing_airline");

                    b.Property<string>("Operating_airline");

                    b.Property<int?>("OutboundId");

                    b.HasKey("Id");

                    b.HasIndex("InboundId");

                    b.HasIndex("OutboundId");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("FlightSearch.Models.Inbound", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ItineraryId");

                    b.HasKey("Id");

                    b.HasIndex("ItineraryId")
                        .IsUnique();

                    b.ToTable("Inbound");
                });

            modelBuilder.Entity("FlightSearch.Models.Itinerary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ResultId");

                    b.HasKey("Id");

                    b.HasIndex("ResultId");

                    b.ToTable("Itinerary");
                });

            modelBuilder.Entity("FlightSearch.Models.Origin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Airport");

                    b.Property<int>("FlightId");

                    b.Property<string>("Terminal");

                    b.HasKey("Id");

                    b.HasIndex("FlightId")
                        .IsUnique();

                    b.ToTable("Origin");
                });

            modelBuilder.Entity("FlightSearch.Models.Outbound", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ItineraryId");

                    b.HasKey("Id");

                    b.HasIndex("ItineraryId")
                        .IsUnique();

                    b.ToTable("Outbound");
                });

            modelBuilder.Entity("FlightSearch.Models.PricePerAdult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FareId");

                    b.Property<string>("Tax");

                    b.Property<string>("Total_fare");

                    b.HasKey("Id");

                    b.HasIndex("FareId")
                        .IsUnique();

                    b.ToTable("PricePerAdult");
                });

            modelBuilder.Entity("FlightSearch.Models.Restrictions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Change_penalties");

                    b.Property<int>("FareId");

                    b.Property<bool>("Refundable");

                    b.HasKey("Id");

                    b.HasIndex("FareId")
                        .IsUnique();

                    b.ToTable("Restrictions");
                });

            modelBuilder.Entity("FlightSearch.Models.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RootObjectId");

                    b.HasKey("Id");

                    b.HasIndex("RootObjectId");

                    b.ToTable("Result");
                });

            modelBuilder.Entity("FlightSearch.Models.RootObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Currency");

                    b.Property<int>("SearchId");

                    b.HasKey("Id");

                    b.HasIndex("SearchId")
                        .IsUnique();

                    b.ToTable("RootObject");
                });

            modelBuilder.Entity("FlightSearch.Models.Search", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Adults");

                    b.Property<string>("Currency");

                    b.Property<string>("Departure_date");

                    b.Property<string>("Destination");

                    b.Property<string>("Origin");

                    b.Property<string>("Return_date");

                    b.HasKey("Id");

                    b.ToTable("Search");
                });

            modelBuilder.Entity("FlightSearch.Models.BookingInfo", b =>
                {
                    b.HasOne("FlightSearch.Models.Flight", "Flight")
                        .WithOne("Booking_info")
                        .HasForeignKey("FlightSearch.Models.BookingInfo", "FlightId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FlightSearch.Models.Destination", b =>
                {
                    b.HasOne("FlightSearch.Models.Flight", "Flight")
                        .WithOne("Destination")
                        .HasForeignKey("FlightSearch.Models.Destination", "FlightId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FlightSearch.Models.Fare", b =>
                {
                    b.HasOne("FlightSearch.Models.Result", "Result")
                        .WithOne("Fare")
                        .HasForeignKey("FlightSearch.Models.Fare", "ResultId");
                });

            modelBuilder.Entity("FlightSearch.Models.Flight", b =>
                {
                    b.HasOne("FlightSearch.Models.Inbound", "Inbound")
                        .WithMany("Flights")
                        .HasForeignKey("InboundId");

                    b.HasOne("FlightSearch.Models.Outbound", "Outbound")
                        .WithMany("Flights")
                        .HasForeignKey("OutboundId");
                });

            modelBuilder.Entity("FlightSearch.Models.Inbound", b =>
                {
                    b.HasOne("FlightSearch.Models.Itinerary", "Itinerary")
                        .WithOne("Inbound")
                        .HasForeignKey("FlightSearch.Models.Inbound", "ItineraryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FlightSearch.Models.Itinerary", b =>
                {
                    b.HasOne("FlightSearch.Models.Result", "Result")
                        .WithMany("Itineraries")
                        .HasForeignKey("ResultId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FlightSearch.Models.Origin", b =>
                {
                    b.HasOne("FlightSearch.Models.Flight", "Flight")
                        .WithOne("Origin")
                        .HasForeignKey("FlightSearch.Models.Origin", "FlightId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FlightSearch.Models.Outbound", b =>
                {
                    b.HasOne("FlightSearch.Models.Itinerary", "Itinerary")
                        .WithOne("Outbound")
                        .HasForeignKey("FlightSearch.Models.Outbound", "ItineraryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FlightSearch.Models.PricePerAdult", b =>
                {
                    b.HasOne("FlightSearch.Models.Fare", "Fare")
                        .WithOne("Price_per_adult")
                        .HasForeignKey("FlightSearch.Models.PricePerAdult", "FareId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FlightSearch.Models.Restrictions", b =>
                {
                    b.HasOne("FlightSearch.Models.Fare", "Fare")
                        .WithOne("Restrictions")
                        .HasForeignKey("FlightSearch.Models.Restrictions", "FareId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FlightSearch.Models.Result", b =>
                {
                    b.HasOne("FlightSearch.Models.RootObject", "RootObject")
                        .WithMany("Results")
                        .HasForeignKey("RootObjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FlightSearch.Models.RootObject", b =>
                {
                    b.HasOne("FlightSearch.Models.Search", "Search")
                        .WithOne("RootObject")
                        .HasForeignKey("FlightSearch.Models.RootObject", "SearchId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
