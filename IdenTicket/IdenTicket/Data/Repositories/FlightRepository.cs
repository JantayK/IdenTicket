using IdenTicket.Interfaces;
using IdenTicket.Models;
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
            context = _context;
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
