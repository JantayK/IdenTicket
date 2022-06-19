﻿using System;
using System.Collections.Generic;
using System.Linq;
using IdenTicket.Enums;
using IdenTicket.Models;

namespace IdenTicket.Data
{
    /// <summary>
    /// Заполнятель базы данных
    /// </summary>
    public static class DatabaseInitializer
    {
        public static void Seed(this ApplicationDbContext context)
        {
            var rnd = new Random();

            if (!context.Countries.Any())
            {
                var countries = new List<Country>
                {
                    new Country
                    {
                        Name = "Кыргызстан"
                    },
                    new Country
                    {
                        Name = "Россия"
                    },
                    new Country
                    {
                        Name = "Беларусь"
                    },
                    new Country
                    {
                        Name = "Казахстан"
                    },
                    new Country
                    {
                        Name = "Таджикистан"
                    },
                    new Country
                    {
                        Name = "USA"
                    },
                    new Country
                    {
                        Name = "Узбекистан"
                    },
                    new Country
                    {
                        Name = "Украина"
                    },
                    new Country
                    {
                        Name = "Турция"
                    },
                    new Country
                    {
                        Name = "Польша"
                    }
                };

                context.Countries.AddRange(countries);
                context.SaveChanges();
            };

            if (!context.AirplaneModels.Any())
            {
                var airplaneModels = new List<AirplaneModel>
                {
                    new AirplaneModel
                    {
                        Model = "Airbus A319neo"
                    },
                    new AirplaneModel
                    {
                        Model = "Boeing 777"
                    },
                    new AirplaneModel
                    {
                        Model = "Суперджет-100"
                    },
                    new AirplaneModel
                    {
                        Model = "Airbus A350"
                    },
                    new AirplaneModel
                    {
                        Model = "Airbus A350"
                    },
                    new AirplaneModel
                    {
                        Model = "Boeing 747"
                    }
                };

                context.AirplaneModels.AddRange(airplaneModels);
                context.SaveChanges();
            };

            if (!context.AirLines.Any())
            {
                var airlines = new List<AirLine>
                {
                    new AirLine
                    {
                        CountryId = context.Countries.FirstOrDefault(c => c.Name == "Кыргызстан").Id,
                        Name = "Air Manas"
                    },
                    new AirLine
                    {
                        CountryId = context.Countries.FirstOrDefault(c => c.Name == "Казахстан").Id,
                        Name = "Air Astana"
                    },
                    new AirLine
                    {
                        CountryId = context.Countries.FirstOrDefault(c => c.Name == "Россия").Id,
                        Name = "Air Baltic"
                    },
                    new AirLine
                    {
                        CountryId = context.Countries.FirstOrDefault(c => c.Name == "Россия").Id,
                        Name = "Avia Traffic Company"
                    },
                    new AirLine
                    {
                        CountryId = context.Countries.FirstOrDefault(c => c.Name == "Россия").Id,
                        Name = "Аэрофлот"
                    },
                    new AirLine
                    {
                        CountryId = context.Countries.FirstOrDefault(c => c.Name == "Россия").Id,
                        Name = "Газпром Авиа"
                    },
                    new AirLine
                    {
                        CountryId = context.Countries.FirstOrDefault(c => c.Name == "Украина").Id,
                        Name = "МАУ"
                    },
                    new AirLine
                    {
                        CountryId = context.Countries.FirstOrDefault(c => c.Name == "Беларусь").Id,
                        Name = "РубиСтар"
                    },
                    new AirLine
                    {
                        CountryId = context.Countries.FirstOrDefault(c => c.Name == "Таджикистан").Id,
                        Name = "Таджик Эйр"
                    },
                    new AirLine
                    {
                        CountryId = context.Countries.FirstOrDefault(c => c.Name == "Узбекистан").Id,
                        Name = "САР"
                    }
                };
                context.AirLines.AddRange(airlines);
                context.SaveChanges();
            }

            if (!context.Cities.Any())
            {
                var cities = new List<City>
                {
                    new City
                    {
                        CountryId = context.Countries.FirstOrDefault(c => c.Name == "Кыргызстан").Id,
                        Name = "Bishkek"
                    },
                    new City
                    {
                        CountryId = context.Countries.FirstOrDefault(c => c.Name == "Кыргызстан").Id,
                        Name = "Osh"
                    },
                    new City
                    {
                        CountryId = context.Countries.FirstOrDefault(c => c.Name == "Россия").Id,
                        Name = "Moscow"
                    },
                    new City
                    {
                        CountryId = context.Countries.FirstOrDefault(c => c.Name == "Турция").Id,
                        Name = "Istanbul"
                    },
                    new City
                    {
                        CountryId = context.Countries.FirstOrDefault(c => c.Name == "USA").Id,
                        Name = "New York"
                    },
                    new City
                    {
                        CountryId = context.Countries.FirstOrDefault(c => c.Name == "USA").Id,
                        Name = "Miami"
                    },
                    new City
                    {
                        CountryId = context.Countries.FirstOrDefault(c => c.Name == "USA").Id,
                        Name = "Detroit"
                    },
                    new City
                    {
                        CountryId = context.Countries.FirstOrDefault(c => c.Name == "USA").Id,
                        Name = "Los Angeles"
                    },
                    new City
                    {
                        CountryId = context.Countries.FirstOrDefault(c => c.Name == "Казахстан").Id,
                        Name = "Almaty"
                    },
                    new City
                    {
                        CountryId = context.Countries.FirstOrDefault(c => c.Name == "Казахстан").Id,
                        Name = "Nur-Sultan"
                    },
                    new City
                    {
                        CountryId = context.Countries.FirstOrDefault(c => c.Name == "Польша").Id,
                        Name = "Warsaw"
                    },
                    new City
                    {
                        CountryId = context.Countries.FirstOrDefault(c => c.Name == "Польша").Id,
                        Name = "Katowice"
                    },
                    new City
                    {
                        CountryId = context.Countries.FirstOrDefault(c => c.Name == "Украина").Id,
                        Name = "Kyiv"
                    },
                    new City
                    {
                        CountryId = context.Countries.FirstOrDefault(c => c.Name == "Украина").Id,
                        Name = "Kharkiv"
                    },
                };
                context.Cities.AddRange(cities);
                context.SaveChanges();
            }

            if (!context.Airports.Any())
            {
                var airports = new List<Airport>
                {
                    new Airport()
                    {
                        CityId = context.Cities.FirstOrDefault(c => c.Name == "Bishkek").Id,
                        Name = "Manas International Airport",
                        IATA = "FRU"
                    },
                    new Airport()
                    {
                        CityId = context.Cities.FirstOrDefault(c => c.Name == "Osh").Id,
                        Name = "Osh Airport",
                        IATA = "OSS"
                    },
                    new Airport()
                    {
                        CityId = context.Cities.FirstOrDefault(c => c.Name == "Moscow").Id,
                        Name = "Международный Аэропорт Шеремéтьево",
                        IATA = "SVO"
                    },
                    new Airport()
                    {
                        CityId = context.Cities.FirstOrDefault(c => c.Name == "Moscow").Id,
                        Name = "Аэропорт Домодедово",
                        IATA = "DME"
                    },
                    new Airport()
                    {
                        CityId = context.Cities.FirstOrDefault(c => c.Name == "New York").Id,
                        Name = "Международный аэропорт имени Джона Кеннеди",
                        IATA = "JFK"
                    },
                    new Airport()
                    {
                        CityId = context.Cities.FirstOrDefault(c => c.Name == "Miami").Id,
                        Name = "Майами",
                        IATA = "MIA"
                    },
                    new Airport()
                    {
                        CityId = context.Cities.FirstOrDefault(c => c.Name == "Detroit").Id,
                        Name = "Detroit Metropolitan Wayne County Airport",
                        IATA = "DTW"
                    },
                    new Airport()
                    {
                        CityId = context.Cities.FirstOrDefault(c => c.Name == "Los Angeles").Id,
                        Name = "Лос-Анджелес",
                        IATA = "LAX"
                    },
                    new Airport()
                    {
                        CityId = context.Cities.FirstOrDefault(c => c.Name == "Istanbul").Id,
                        Name = "Международный аэропорт имени Ататюрка",
                        IATA = "IST"
                    },
                    new Airport()
                    {
                        CityId = context.Cities.FirstOrDefault(c => c.Name == "Almaty").Id,
                        Name = "Международный Аэропорт Алматы",
                        IATA = "ALA"
                    },
                    new Airport()
                    {
                        CityId = context.Cities.FirstOrDefault(c => c.Name == "Warsaw").Id,
                        Name = "Международный аэропорт Варшава-Модлин",
                        IATA = "WMI"
                    },
                    new Airport()
                    {
                        CityId = context.Cities.FirstOrDefault(c => c.Name == "Katowice").Id,
                        Name = "Международный аэропорт Катовице-Пыжовице",
                        IATA = "KTW"
                    },
                    new Airport()
                    {
                        CityId = context.Cities.FirstOrDefault(c => c.Name == "Kyiv").Id,
                        Name = "Киев Борисполь",
                        IATA = "KBP"
                    },
                    new Airport()
                    {
                        CityId = context.Cities.FirstOrDefault(c => c.Name == "Kharkiv").Id,
                        Name = "Аэропорт Харьков",
                        IATA = "HRK"
                    }
                };
                context.Airports.AddRange(airports);
                context.SaveChanges();
            }
            if(!context.Flights.Any())
            {
                var flights = new List<Flight>
                {
                    new Flight()
                    {
                        FlightType = FlightType.DirectOneWay
                    },
                    new Flight()
                    {
                        FlightType = FlightType.DirectWithReturn
                    },
                    new Flight()
                    {
                        FlightType = FlightType.TransferOneWay
                    },
                    new Flight()
                    {
                        FlightType = FlightType.TransferWithReturn
                    },
                    new Flight()
                    {
                        FlightType = FlightType.TransitOneWay
                    },
                    new Flight()
                    {
                        FlightType = FlightType.TransitWithReturn
                    },
                };
                context.Flights.AddRange(flights);
                context.SaveChanges();
            }
            if(!context.FlightLegs.Any())
            {
                var flightlegs = new List<FlightLeg>
                {
                    new FlightLeg()
                    {
                        FlightId = context.Flights.FirstOrDefault(f => f.FlightType == FlightType.DirectOneWay).Id,
                        Direction = Direction.Forth,
                        LegNumber = 1,
                        AirLineId = context.AirLines.FirstOrDefault(a => a.Name == "Air Astana").Id,
                        AirplaneModelId = context.AirplaneModels.FirstOrDefault(am => am.Model == "Boeing 747").Id,
                        DepartAirportId = context.Airports.FirstOrDefault(d => d.Name == "Manas International Airport").Id,
                        ArriveAirportId = context.Airports.FirstOrDefault(ar => ar.Name == "Международный Аэропорт Алматы").Id,
                        DepartDate = new DateTime(2022, 06, 16).AddSeconds(rnd.Next(1, 86399)),
                        ArriveDate = new DateTime(2022, 06, 16).AddSeconds(rnd.Next(1, 86399)),
                    },
                    new FlightLeg()
                    {
                        FlightId = context.Flights.FirstOrDefault(f => f.FlightType == FlightType.DirectWithReturn).Id,
                        Direction = Direction.Forth,
                        LegNumber = 1,
                        AirLineId = context.AirLines.FirstOrDefault(a => a.Name == "Air Manas").Id,
                        AirplaneModelId = context.AirplaneModels.FirstOrDefault(am => am.Model == "Суперджет-100").Id,
                        DepartAirportId = context.Airports.FirstOrDefault(d => d.Name == "Manas International Airport").Id,
                        ArriveAirportId = context.Airports.FirstOrDefault(ar => ar.Name == "Osh Airport").Id,
                        DepartDate = new DateTime(2022, 06, 19).AddSeconds(rnd.Next(1, 86399)),
                        ArriveDate = new DateTime(2022, 06, 20).AddSeconds(rnd.Next(1, 86399)),
                    },
                    new FlightLeg()
                    {
                        FlightId = context.Flights.FirstOrDefault(f => f.FlightType == FlightType.DirectWithReturn).Id,
                        Direction = Direction.Back,
                        LegNumber = 1,
                        AirLineId = context.AirLines.FirstOrDefault(a => a.Name == "Air Manas").Id,
                        AirplaneModelId = context.AirplaneModels.FirstOrDefault(am => am.Model == "Суперджет-100").Id,
                        DepartAirportId = context.Airports.FirstOrDefault(d => d.Name == "Osh Airport").Id,
                        ArriveAirportId = context.Airports.FirstOrDefault(ar => ar.Name == "Manas International Airport").Id,
                        DepartDate = new DateTime(2022, 09, 1).AddSeconds(rnd.Next(1, 86399)),
                        ArriveDate = new DateTime(2022, 09, 2).AddSeconds(rnd.Next(1, 86399)),
                    },
                    new FlightLeg()
                    {
                        FlightId = context.Flights.FirstOrDefault(f => f.FlightType == FlightType.TransferOneWay).Id,
                        Direction = Direction.Forth,
                        LegNumber = 1,
                        AirLineId = context.AirLines.FirstOrDefault(a => a.Name == "Газпром Авиа").Id,
                        AirplaneModelId = context.AirplaneModels.FirstOrDefault(am => am.Model == "Airbus A350").Id,
                        DepartAirportId = context.Airports.FirstOrDefault(d => d.IATA == "FRU").Id,
                        ArriveAirportId = context.Airports.FirstOrDefault(ar => ar.IATA == "SVO").Id,
                        DepartDate = new DateTime(2022, 06, 17).AddSeconds(rnd.Next(1, 86399)),
                        ArriveDate = new DateTime(2022, 06, 17).AddSeconds(rnd.Next(1, 86399)),
                    },
                    new FlightLeg()
                    {
                        FlightId = context.Flights.FirstOrDefault(f => f.FlightType == FlightType.TransferOneWay).Id,
                        Direction = Direction.Forth,
                        LegNumber = 2,
                        AirLineId = context.AirLines.FirstOrDefault(a => a.Name == "Газпром Авиа").Id,
                        AirplaneModelId = context.AirplaneModels.FirstOrDefault(am => am.Model == "Boeing 747").Id,
                        DepartAirportId = context.Airports.FirstOrDefault(d => d.IATA == "SVO").Id,
                        ArriveAirportId = context.Airports.FirstOrDefault(ar => ar.IATA == "WMI").Id,
                        DepartDate = new DateTime(2022, 06, 18).AddSeconds(rnd.Next(1, 86399)),
                        ArriveDate = new DateTime(2022, 08, 18).AddSeconds(rnd.Next(1, 86399)),
                    },
                    new FlightLeg()
                    {
                        FlightId = context.Flights.FirstOrDefault(f => f.FlightType == FlightType.TransferWithReturn).Id,
                        Direction = Direction.Forth,
                        LegNumber = 1,
                        AirLineId = context.AirLines.FirstOrDefault(a => a.Name == "МАУ").Id,
                        AirplaneModelId = context.AirplaneModels.FirstOrDefault(am => am.Model == "Boeing 777").Id,
                        DepartAirportId = context.Airports.FirstOrDefault(d => d.Name == "Manas International Airport").Id,
                        ArriveAirportId = context.Airports.FirstOrDefault(ar => ar.IATA == "HRK" ).Id,
                        DepartDate = new DateTime(2022, 06, 18).AddSeconds(rnd.Next(1, 86399)),
                        ArriveDate = new DateTime(2022, 06, 18).AddSeconds(rnd.Next(1, 86399)),
                    },
                    new FlightLeg()
                    {
                        FlightId = context.Flights.FirstOrDefault(f => f.FlightType == FlightType.TransferWithReturn).Id,
                        Direction = Direction.Forth,
                        LegNumber = 2,
                        AirLineId = context.AirLines.FirstOrDefault(a => a.Name == "МАУ").Id,
                        AirplaneModelId = context.AirplaneModels.FirstOrDefault(am => am.Model == "Airbus A350").Id,
                        DepartAirportId = context.Airports.FirstOrDefault(ar => ar.IATA == "HRK" ).Id,
                        ArriveAirportId = context.Airports.FirstOrDefault(ar => ar.IATA == "KTW" ).Id,
                        DepartDate = new DateTime(2022, 06, 18).AddSeconds(rnd.Next(1, 86399)),
                        ArriveDate = new DateTime(2022, 06, 18).AddSeconds(rnd.Next(1, 86399)),
                    },
                    new FlightLeg()
                    {
                        FlightId = context.Flights.FirstOrDefault(f => f.FlightType == FlightType.TransferWithReturn).Id,
                        Direction = Direction.Back,
                        LegNumber = 1,
                        AirLineId = context.AirLines.FirstOrDefault(a => a.Name == "Аэрофлот").Id,
                        AirplaneModelId = context.AirplaneModels.FirstOrDefault(am => am.Model == "Airbus A350").Id,
                        DepartAirportId = context.Airports.FirstOrDefault(ar => ar.IATA == "KTW" ).Id,
                        ArriveAirportId = context.Airports.FirstOrDefault(ar => ar.IATA == "SVO" ).Id,
                        DepartDate = new DateTime(2022, 08, 10).AddSeconds(rnd.Next(1, 86399)),
                        ArriveDate = new DateTime(2022, 08, 10).AddSeconds(rnd.Next(1, 86399)),
                    },
                    new FlightLeg()
                    {
                        FlightId = context.Flights.FirstOrDefault(f => f.FlightType == FlightType.TransferWithReturn).Id,
                        Direction = Direction.Back,
                        LegNumber = 2,
                        AirLineId = context.AirLines.FirstOrDefault(a => a.Name == "Аэрофлот").Id,
                        AirplaneModelId = context.AirplaneModels.FirstOrDefault(am => am.Model == "Boeing 777").Id,
                        DepartAirportId = context.Airports.FirstOrDefault(ar => ar.IATA == "SVO" ).Id,
                        ArriveAirportId = context.Airports.FirstOrDefault(ar => ar.IATA == "FRU" ).Id,
                        DepartDate = new DateTime(2022, 08, 11).AddSeconds(rnd.Next(1, 86399)),
                        ArriveDate = new DateTime(2022, 08, 11).AddSeconds(rnd.Next(1, 86399)),
                    },
                    new FlightLeg()
                    {
                        FlightId = context.Flights.FirstOrDefault(f => f.FlightType == FlightType.TransitOneWay).Id,
                        Direction = Direction.Forth,
                        LegNumber = 1,
                        AirLineId = context.AirLines.FirstOrDefault(a => a.Name == "Avia Traffic Company").Id,
                        AirplaneModelId = context.AirplaneModels.FirstOrDefault(am => am.Model == "Airbus A319neo").Id,
                        DepartAirportId = context.Airports.FirstOrDefault(d => d.Name == "Manas International Airport").Id,
                        ArriveAirportId = context.Airports.FirstOrDefault(ar => ar.IATA == "HRK").Id,
                        DepartDate = new DateTime(2022, 08, 17).AddSeconds(rnd.Next(1, 86399)),
                        ArriveDate = new DateTime(2022, 08, 17).AddSeconds(rnd.Next(1, 86399)),
                    },
                    new FlightLeg()
                    {
                        FlightId = context.Flights.FirstOrDefault(f => f.FlightType == FlightType.TransitOneWay).Id,
                        Direction = Direction.Forth,
                        LegNumber = 2,
                        AirLineId = context.AirLines.FirstOrDefault(a => a.Name == "Avia Traffic Company").Id,
                        AirplaneModelId = context.AirplaneModels.FirstOrDefault(am => am.Model == "Airbus A319neo").Id,
                        DepartAirportId = context.Airports.FirstOrDefault(ar => ar.IATA == "HRK").Id,
                        ArriveAirportId = context.Airports.FirstOrDefault(ar => ar.IATA == "WMI").Id,
                        DepartDate = new DateTime(2022, 08, 18).AddSeconds(rnd.Next(1, 86399)),
                        ArriveDate = new DateTime(2022, 08, 18).AddSeconds(rnd.Next(1, 86399)),
                    },
                    new FlightLeg()
                    {
                        FlightId = context.Flights.FirstOrDefault(f => f.FlightType == FlightType.TransitWithReturn).Id,
                        Direction = Direction.Forth,
                        LegNumber = 1,
                        AirLineId = context.AirLines.FirstOrDefault(a => a.Name == "Air Astana").Id,
                        AirplaneModelId = context.AirplaneModels.FirstOrDefault(am => am.Model == "Суперджет-100").Id,
                        DepartAirportId = context.Airports.FirstOrDefault(d => d.Name == "Manas International Airport").Id,
                        ArriveAirportId = context.Airports.FirstOrDefault(ar => ar.Name == "Международный Аэропорт Алматы").Id,
                        DepartDate = new DateTime(2022, 06, 20).AddSeconds(rnd.Next(1, 86399)),
                        ArriveDate = new DateTime(2022, 06, 20).AddSeconds(rnd.Next(1, 86399)),
                    },
                    new FlightLeg()
                    {
                        FlightId = context.Flights.FirstOrDefault(f => f.FlightType == FlightType.TransitWithReturn).Id,
                        Direction = Direction.Forth,
                        LegNumber = 2,
                        AirLineId = context.AirLines.FirstOrDefault(a => a.Name == "Air Astana").Id,
                        AirplaneModelId = context.AirplaneModels.FirstOrDefault(am => am.Model == "Суперджет-100").Id,
                        DepartAirportId = context.Airports.FirstOrDefault(d => d.Name == "Международный Аэропорт Алматы").Id,
                        ArriveAirportId = context.Airports.FirstOrDefault(ar => ar.Name == "Аэропорт Домодедово").Id,
                        DepartDate = new DateTime(2022, 06, 20).AddSeconds(rnd.Next(1, 86399)),
                        ArriveDate = new DateTime(2022, 06, 20).AddSeconds(rnd.Next(1, 86399)),
                    },
                    new FlightLeg()
                    {
                        FlightId = context.Flights.FirstOrDefault(f => f.FlightType == FlightType.TransitWithReturn).Id,
                        Direction = Direction.Back,
                        LegNumber = 1,
                        AirLineId = context.AirLines.FirstOrDefault(a => a.Name == "Air Astana").Id,
                        AirplaneModelId = context.AirplaneModels.FirstOrDefault(am => am.Model == "Суперджет-100").Id,
                        DepartAirportId = context.Airports.FirstOrDefault(d => d.Name == "Аэропорт Домодедово").Id,
                        ArriveAirportId = context.Airports.FirstOrDefault(ar => ar.Name == "Международный Аэропорт Алматы").Id,
                        DepartDate = new DateTime(2022, 10, 20).AddSeconds(rnd.Next(1, 86399)),
                        ArriveDate = new DateTime(2022, 10, 20).AddSeconds(rnd.Next(1, 86399)),
                    },
                    new FlightLeg()
                    {
                        FlightId = context.Flights.FirstOrDefault(f => f.FlightType == FlightType.TransitWithReturn).Id,
                        Direction = Direction.Back,
                        LegNumber = 2,
                        AirLineId = context.AirLines.FirstOrDefault(a => a.Name == "Air Astana").Id,
                        AirplaneModelId = context.AirplaneModels.FirstOrDefault(am => am.Model == "Суперджет-100").Id,
                        DepartAirportId = context.Airports.FirstOrDefault(d => d.Name == "Международный Аэропорт Алматы").Id,
                        ArriveAirportId = context.Airports.FirstOrDefault(ar => ar.IATA == "FRU").Id,
                        DepartDate = new DateTime(2022, 10, 21).AddSeconds(rnd.Next(1, 86399)),
                        ArriveDate = new DateTime(2022, 10, 21).AddSeconds(rnd.Next(1, 86399)),
                    },
                };
                context.FlightLegs.AddRange(flightlegs);
                context.SaveChanges();
            }
        }
    }
}