using System;

namespace Servier.Repository.Interface
{
    /// <summary>
    /// Interface for Unit of Work
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        int Save();
    }
}
