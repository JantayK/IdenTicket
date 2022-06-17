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
    /// <summary>
    /// Репозиторий рейса
    /// </summary>
    public class FlightRepository : IRepository<Flight>
    {
        private readonly ApplicationDbContext _context;
        public FlightRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получение всех рейсов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Flight> GetAll()
        {
            return _context.Flights.ToList();
        }

        /// <summary>
        /// Получение рейса по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Flight GetById(int id)
        {
            return _context.Flights.Find(id);
        }

        public IEnumerable<Flight> Search(SearchViewModel model)
        {
            List<Flight> result;

            switch (model.FlightType)
            {
                case FlightType.DirectOneWay:
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
                                ((fl.ArriveAirport.Name.Contains(model.DestinationAirport)
                                    || fl.ArriveAirport.IATA == model.DestinationAirport)
                                && fl.DepartAirport.Name.Contains(model.DepartureAirport)
                                    || fl.DepartAirport.IATA == model.DepartureAirport)
                                && fl.DepartDate.Date == model.DepartDate.Date))
                        .ToList();
                    break;
                case FlightType.DirectWithReturn:
                    if (!model.ReturnDate.HasValue)
                        throw new ArgumentNullException("Дата возврата не может быть пустой");
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
                            .Any(fl => fl.Direction == Direction.Forth
                                && (fl.DepartAirport.Name.Contains(model.DepartureAirport)
                                    || fl.DepartAirport.IATA == model.DepartureAirport)
                                && (fl.ArriveAirport.Name.Contains(model.DestinationAirport)
                                    || fl.ArriveAirport.IATA == model.DestinationAirport)
                                && fl.DepartDate.Date == model.DepartDate.Date)
                            && f.FlightLegs
                                .AsQueryable()
                                .Any(fl => fl.Direction == Direction.Back
                                && fl.ArriveDate.Date == ((DateTime)model.ReturnDate).Date))
                        .ToList();
                    break;
                case FlightType.TransitOneWay:
                case FlightType.TransferOneWay:
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
                                && (fl.DepartAirport.Name.Contains(model.DepartureAirport)
                                    || fl.DepartAirport.IATA == model.DepartureAirport)
                                && fl.DepartDate == model.DepartDate)
                            && f.FlightLegs
                                .AsQueryable()
                                .Where(fl => fl.Direction == Direction.Forth)
                                .OrderByDescending(fl => fl.LegNumber)
                                .Take(1)
                                .Any(fl =>
                                    fl.ArriveAirport.Name.Contains(model.DestinationAirport)
                                    || fl.ArriveAirport.IATA == model.DestinationAirport))
                        .ToList();
                    break;
                case FlightType.TransitWithReturn:
                case FlightType.TransferWithReturn:
                    if (!model.ReturnDate.HasValue)
                        throw new ArgumentNullException("Дата возврата не может быть пустой");
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
                                && (fl.DepartAirport.Name.Contains(model.DepartureAirport)
                                    || fl.DepartAirport.IATA == model.DepartureAirport)
                                && fl.DepartDate.Date == model.DepartDate.Date)
                            && f.FlightLegs
                                .AsQueryable()
                                .Where(fl => fl.Direction == Direction.Forth)
                                .OrderByDescending(fl => fl.LegNumber)
                                .Take(1)
                                .Any(fl =>
                                    fl.ArriveAirport.Name.Contains(model.DestinationAirport)
                                    || fl.ArriveAirport.IATA == model.DestinationAirport)
                            && f.FlightLegs
                                .AsQueryable()
                                .Where(fl => fl.Direction == Direction.Back)
                                .OrderByDescending(fl => fl.LegNumber)
                                .Take(1)
                                .Any(fl => fl.ArriveDate.Date == ((DateTime)model.ReturnDate).Date))
                        .ToList();
                    break;
                default:
                    result = null;
                    break;
            }

            return result;
        }

        /// <summary>
        /// Создание рейса
        /// </summary>
        /// <param name="item"></param>
        public void Create(Flight item)
        {
            _context.Flights.Add(item);
        }

        /// <summary>
        /// Обновление
        /// </summary>
        /// <param name="item"></param>
        public void Update(Flight item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        /// <summary>
        /// Удаление рейса
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            Flight flight = _context.Flights.Find(id);
            if(flight != null)
            {
                _context.Remove(flight);
            }
        }
    }
}
