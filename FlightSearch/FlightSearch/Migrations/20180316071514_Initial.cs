using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FlightSearch.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CityCode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Airport = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Search",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adults = table.Column<int>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    Departure_date = table.Column<string>(nullable: true),
                    Destination = table.Column<string>(nullable: true),
                    Origin = table.Column<string>(nullable: true),
                    Return_date = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Search", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootObject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Currency = table.Column<string>(nullable: true),
                    SearchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootObject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootObject_Search_SearchId",
                        column: x => x.SearchId,
                        principalTable: "Search",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RootObjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Result_RootObject_RootObjectId",
                        column: x => x.RootObjectId,
                        principalTable: "RootObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fare",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ResultId = table.Column<int>(nullable: true),
                    Total_price = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fare_Result_ResultId",
                        column: x => x.ResultId,
                        principalTable: "Result",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Itinerary",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ResultId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itinerary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Itinerary_Result_ResultId",
                        column: x => x.ResultId,
                        principalTable: "Result",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PricePerAdult",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FareId = table.Column<int>(nullable: false),
                    Tax = table.Column<string>(nullable: true),
                    Total_fare = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PricePerAdult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PricePerAdult_Fare_FareId",
                        column: x => x.FareId,
                        principalTable: "Fare",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restrictions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Change_penalties = table.Column<bool>(nullable: false),
                    FareId = table.Column<int>(nullable: false),
                    Refundable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restrictions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restrictions_Fare_FareId",
                        column: x => x.FareId,
                        principalTable: "Fare",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inbound",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItineraryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inbound", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inbound_Itinerary_ItineraryId",
                        column: x => x.ItineraryId,
                        principalTable: "Itinerary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Outbound",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItineraryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outbound", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Outbound_Itinerary_ItineraryId",
                        column: x => x.ItineraryId,
                        principalTable: "Itinerary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Aircraft = table.Column<string>(nullable: true),
                    Arrives_at = table.Column<string>(nullable: true),
                    Departs_at = table.Column<string>(nullable: true),
                    Flight_number = table.Column<string>(nullable: true),
                    InboundId = table.Column<int>(nullable: true),
                    Marketing_airline = table.Column<string>(nullable: true),
                    Operating_airline = table.Column<string>(nullable: true),
                    OutboundId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flight_Inbound_InboundId",
                        column: x => x.InboundId,
                        principalTable: "Inbound",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Outbound_OutboundId",
                        column: x => x.OutboundId,
                        principalTable: "Outbound",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookingInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Booking_code = table.Column<string>(nullable: true),
                    FlightId = table.Column<int>(nullable: false),
                    Seats_remaining = table.Column<int>(nullable: false),
                    Travel_class = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingInfo_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Destination",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Airport = table.Column<string>(nullable: true),
                    FlightId = table.Column<int>(nullable: false),
                    Terminal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Destination_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Origin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Airport = table.Column<string>(nullable: true),
                    FlightId = table.Column<int>(nullable: false),
                    Terminal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Origin_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingInfo_FlightId",
                table: "BookingInfo",
                column: "FlightId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Destination_FlightId",
                table: "Destination",
                column: "FlightId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fare_ResultId",
                table: "Fare",
                column: "ResultId",
                unique: true,
                filter: "[ResultId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_InboundId",
                table: "Flight",
                column: "InboundId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_OutboundId",
                table: "Flight",
                column: "OutboundId");

            migrationBuilder.CreateIndex(
                name: "IX_Inbound_ItineraryId",
                table: "Inbound",
                column: "ItineraryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Itinerary_ResultId",
                table: "Itinerary",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Origin_FlightId",
                table: "Origin",
                column: "FlightId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Outbound_ItineraryId",
                table: "Outbound",
                column: "ItineraryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PricePerAdult_FareId",
                table: "PricePerAdult",
                column: "FareId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restrictions_FareId",
                table: "Restrictions",
                column: "FareId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Result_RootObjectId",
                table: "Result",
                column: "RootObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RootObject_SearchId",
                table: "RootObject",
                column: "SearchId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingInfo");

            migrationBuilder.DropTable(
                name: "CityCode");

            migrationBuilder.DropTable(
                name: "Destination");

            migrationBuilder.DropTable(
                name: "Origin");

            migrationBuilder.DropTable(
                name: "PricePerAdult");

            migrationBuilder.DropTable(
                name: "Restrictions");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Fare");

            migrationBuilder.DropTable(
                name: "Inbound");

            migrationBuilder.DropTable(
                name: "Outbound");

            migrationBuilder.DropTable(
                name: "Itinerary");

            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropTable(
                name: "RootObject");

            migrationBuilder.DropTable(
                name: "Search");
        }
    }
}
