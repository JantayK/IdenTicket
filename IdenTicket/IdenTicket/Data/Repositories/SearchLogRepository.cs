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
    public class SearchLogRepository : IRepository<SearchLog>
    {
        private readonly ApplicationDbContext _context;

        public SearchLogRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Получение всей истории
        /// </summary>
        public IEnumerable<SearchLog> GetAll()
        {
            return _context.SearchLogs.Include(sl => sl.Customer).ToList();
        }

        /// <summary>
        /// Получение истории пользователя
        /// </summary>
        public IEnumerable<SearchLog> GetByCustomerId(string id)
        {
            return _context.SearchLogs.Where(sl => sl.CustomerId == id && !sl.IsDeleted).ToList();
        }

        /// <summary>
        /// Получение одной записи истории по id
        /// </summary>
        /// <param name="id">Идентификатор</param>
        public SearchLog GetById(int id)
        {
            return _context.SearchLogs.Find(id);
        }

        /// <summary>
        /// Создание записи истории
        /// </summary>
        public void Create(SearchLog item)
        {
            _context.SearchLogs.Add(item);
            _context.SaveChanges();
        }

        /// <summary>
        /// Обновление записи истории
        /// </summary>
        /// <param name="item"></param>
        public void Update(SearchLog item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>
        /// Удаление записи истории
        /// </summary>
        public void Delete(int id)
        {
            SearchLog searchLog = _context.SearchLogs.FirstOrDefault(sl => sl.Id == id);
            if (searchLog != null)
            {
                _context.SearchLogs.Remove(searchLog);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Удаление записи истории с проверкой по id пользователя
        /// </summary>
        public void Delete(int id, string userId)
        {
            SearchLog searchLog = _context.SearchLogs.FirstOrDefault(sl => sl.Id == id && sl.CustomerId == userId);
            if (searchLog != null)
            {
                searchLog.IsDeleted = true;
                _context.SearchLogs.Update(searchLog);
                _context.SaveChanges();
            }
        }
    }
}
