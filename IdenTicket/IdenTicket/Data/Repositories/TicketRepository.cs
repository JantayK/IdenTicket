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
    /// Репозиторий Билета
    /// </summary>
    public class TicketRepository : IRepository<Ticket>
    {
        private readonly ApplicationDbContext _context;

        public TicketRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Получение всех билетов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Ticket> GetAll()
        {
            return _context.Tickets.ToList();
        }

        /// <summary>
        /// Получение одного билета по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Ticket GetById(int id)
        {
            return _context.Tickets.Find(id);
        }

        /// <summary>
        /// Создание билета
        /// </summary>
        /// <param name="item"></param>
        public void Create(Ticket item)
        {
            _context.Tickets.Add(item);
        }

        /// <summary>
        /// Обновление
        /// </summary>
        /// <param name="item"></param>
        public void Update(Ticket item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

       /// <summary>
       /// Удаление билета
       /// </summary>
       /// <param name="id"></param>
        public void Delete(int id)
        {
            Ticket ticket = _context.Tickets.Find(id);
            if(ticket != null)
            {
                _context.Tickets.Remove(ticket);
            }    
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
