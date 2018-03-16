using FlightSearch.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSearch.DAL
{
    public class FlightContext : DbContext
    {
        public FlightContext(DbContextOptions<FlightContext> options) : base(options) { }
        public DbSet<BookingInfo> BookingInfo { get; set; }
        public DbSet<CityCode> CityCode { get; set; }
        public DbSet<Destination> Destination { get; set; }
        public DbSet<Fare> Fare { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Itinerary> Itinerary { get; set; }
        public DbSet<Origin> Origin { get; set; }
        public DbSet<Inbound> Inbound { get; set; }
        public DbSet<Outbound> Outbound { get; set; }
        public DbSet<PricePerAdult> PricePerAdult { get; set; }
        public DbSet<Restrictions> Restrictions { get; set; }
        public DbSet<Result> Result { get; set; }
        public DbSet<RootObject> RootObject { get; set; }
        public DbSet<Search> Search { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
