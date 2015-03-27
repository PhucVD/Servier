using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Servier.Repository.Interface;
using Servier.Data;

namespace Servier.Repository
{
    /// <summary>
    /// The implementation of IUnitOfWork
    /// </summary>
    public sealed class UnitOfWork : IUnitOfWork
    {
        #region Fields

        private ServierEntities context;
        private GenericRepository<Region> regionRepository;
        private GenericRepository<Sector> sectorRepository;

        #endregion

        #region Properties

        public ServierEntities Context { get { return this.context; } }

        public GenericRepository<Region> RegionRepository { 
            get 
            {
                return regionRepository ?? (regionRepository = new GenericRepository<Region>(context));
            }
        }

        public GenericRepository<Sector> SectorRepository
        {
            get 
            {
                return sectorRepository ?? (sectorRepository = new GenericRepository<Sector>(context));
            }
        }

        #endregion

        #region Constructor

        public UnitOfWork()
        {
            context = new ServierEntities();
        }

        public UnitOfWork(ServierEntities context)
        {
            this.context = context;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public int Save()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (context != null)
                {
                    context.Dispose();
                    context = null;
                }
            }
        }

        #endregion

    }
}
