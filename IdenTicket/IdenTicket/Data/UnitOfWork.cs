using IdenTicket.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdenTicket.Data
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationDbContext _context;

        private TicketRepository _ticketRepository;
        private FlightRepository _flightRepository;
        private FlightLegRepository _flightLegRepository;
        private SearchLogRepository _searchLogRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public TicketRepository Tickets
        {
            get
            {
                if (_ticketRepository == null)
                    _ticketRepository = new TicketRepository(_context);
                return _ticketRepository;
            }
        }

        public FlightRepository Flights
        {
            get
            {
                if (_flightRepository == null)
                    _flightRepository = new FlightRepository(_context);
                return _flightRepository;
            }
        }

        public FlightLegRepository FlightLegs
        {
            get
            {
                if (_flightLegRepository == null)
                    _flightLegRepository = new FlightLegRepository(_context);
                return _flightLegRepository;
            }
        }

        public SearchLogRepository SearchLogs
        {
            get
            {
                if (_searchLogRepository == null)
                    _searchLogRepository = new SearchLogRepository(_context);
                return _searchLogRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
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
