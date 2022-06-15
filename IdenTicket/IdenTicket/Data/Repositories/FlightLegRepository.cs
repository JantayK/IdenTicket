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

        public IEnumerable<FlightLeg> Search(SearchViewModel searchViewModel)
        {
            return new List<FlightLeg>();
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
            if(flightLeg != null)
            {
                _context.FlightLegs.Remove(flightLeg);
            }
        }
    }
}
