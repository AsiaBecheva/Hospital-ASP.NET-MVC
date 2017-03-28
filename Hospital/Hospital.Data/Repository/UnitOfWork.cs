namespace Hospital.Data.Repository
{
    using DatabaseModels;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IRepository<DatabaseModels.Image> Images
        {
            get { return this.GetRepository<DatabaseModels.Image>(); }
        }

        public IRepository<ClinicalResult> ClinicalResults
        {
            get
            {
                return this.GetRepository<ClinicalResult>();
            }
        }

        public IRepository<ClinicalTrial> ClinicalTrials
        {
            get
            {
                return this.GetRepository<ClinicalTrial>();
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Doctor> Doctors
        {
            get
            {
                return this.GetRepository<Doctor>();
            }
        }

        public IRepository<Speciality> Specialities
        {
            get
            {
                return this.GetRepository<Speciality>();
            }
        }

        public DbContext Context
        {
            get
            {
                return this.context;
            }
        }
        
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}

