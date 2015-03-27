using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Servier.Data;

namespace Servier.Repository.Repository
{
    public class BudgetRepository: GenericRepository<Budget>
    {
        public BudgetRepository(ServierEntities context)
            : base(context)
        { 
            
        }

        public override Budget GetById(int id)
        {
            return base.GetById(id);
        }

        public void GetBudgetInfo()
        {
            this.dbSet.Include(x => x.BudgetDetails);
        }
    }
}
