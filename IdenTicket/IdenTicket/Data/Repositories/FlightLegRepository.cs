using IdenTicket.Enums;
using IdenTicket.Interfaces;
using IdenTicket.Models;
using IdenTicket.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdenTicket.Data.Repositories
{
    public class FlightLegRepository : IRepository<FlightLeg>
    {
        /// <summary>
        /// Репозиторий частей маршрута
        /// </summary>
        private readonly ApplicationDbContext _context;
        public FlightLegRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получение всех частей маршрута
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FlightLeg> GetAll()
        {
            return _context.FlightLegs.ToList();
        }

        public IEnumerable<Flight> Search(SearchViewModel model)
        {
            List<Flight> result;
            if (model.FlightType == FlightType.TransferWithReturn
                || model.FlightType == FlightType.TransitWithReturn)
            {
                result = _context.Flights
                    .AsQueryable()
                    .Include(f => f.FlightLegs)
                        .ThenInclude(fl => fl.DepartAirport)
                    .Include(f => f.FlightLegs)
                        .ThenInclude(fl => fl.ArriveAirport)
                    .Include(f => f.FlightLegs)
                        .ThenInclude(fl => fl.AirplaneModel)
                    .Include(f => f.FlightLegs)
                        .ThenInclude(fl => fl.AirLine)
                    .Where(f =>
                        f.FlightLegs
                        .AsQueryable()
                        .Any(fl =>
                            fl.Direction == Direction.Forth
                            && fl.LegNumber == 1
                            && (fl.DepartAirport.Name == model.DepartureAirport
                                || fl.DepartAirport.IATA == model.DepartureAirport)
                            && fl.DepartDate == model.DepartDate)
                        && f.FlightLegs
                            .AsQueryable()
                            .Where(fl => fl.Direction == Direction.Forth)
                            .OrderByDescending(fl => fl.LegNumber)
                            .Take(1)
                            .Any(fl =>
                                fl.ArriveAirport.Name == model.DestinationAirport
                                || fl.ArriveAirport.IATA == model.DestinationAirport)
                        && f.FlightLegs
                            .AsQueryable()
                            .Where(fl => fl.Direction == Direction.Back)
                            .OrderByDescending(fl => fl.LegNumber)
                            .Take(1)
                            .Any(fl => fl.ArriveDate == model.ReturnDate))
                    .ToList();
            }

            return result;
        }

        /// <summary>
        /// Получение части маршрута по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FlightLeg GetById(int id)
        {
            return _context.FlightLegs.Find(id);
        }

        /// <summary>
        /// Создание части маршрута
        /// </summary>
        /// <param name="item"></param>
        public void Create(FlightLeg item)
        {
            _context.FlightLegs.Add(item);
        }

        /// <summary>
        /// Обновление
        /// </summary>
        /// <param name="item"></param>
        public void Update(FlightLeg item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        /// <summary>
        /// Удаление части маршрута
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            FlightLeg flightLeg = _context.FlightLegs.Find(id);
            if (flightLeg != null)
            {
                _context.FlightLegs.Remove(flightLeg);
            }
        }
    }
}
