using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdenTicket.Interfaces
{
    /// <summary>
    /// Интерфейс Репозитория
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
            where T : class
    {
        /// <summary>
        /// Получение всех обьектов
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Получение одного обьекта
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(int id);

        /// <summary>
        /// Создание обьекта
        /// </summary>
        /// <param name="item"></param>
        void Create(T item);

        /// <summary>
        /// Обновление обьекта
        /// </summary>
        /// <param name="item"></param>
        void Update(T item);

        /// <summary>
        /// Удаление обьекта
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
