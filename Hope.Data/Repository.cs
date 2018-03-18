using Hope.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hope.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly HopeContext _context;
        private DbSet<T> _entities;

        public Repository(HopeContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Entities
        /// </summary>
        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }

        public DbSet<T> Table
        {
            get
            {
                return Entities;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                Entities.Remove(entity);

                _context.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                //throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
                throw dbEx;
            }
        }

        public void Delete(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                foreach (var entity in entities)
                    Entities.Remove(entity);

                _context.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                //throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
                throw dbEx;
            }
        }

        public T GetById(object id)
        {
            //see some suggested performance optimization (not tested)
            //http://stackoverflow.com/questions/11686225/dbset-find-method-ridiculously-slow-compared-to-singleordefault-on-id/11688189#comment34876113_11688189
            return Entities.Find(id);
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                Entities.Add(entity);

                _context.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                throw dbEx;
                //throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
            }
        }

        public void Insert(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                foreach (var entity in entities)
                    Entities.Add(entity);

                _context.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                //throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);

                throw dbEx;
            }
        }

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                _context.SaveChanges();
            }
            catch (Exception dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                //throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
                throw dbEx;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return Entities.AsEnumerable();
            }
            catch (Exception dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                //throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
                throw dbEx;
            }
        }
    }
}
