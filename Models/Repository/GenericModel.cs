using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RoleBasedAuthanticationInMvc.Models.Repository
{
   
    public abstract class GenericModel<T> where T:class
    {
        public ProjectDbContext context;
     //   public ApplicationDbContext App_context;

        public GenericModel(ProjectDbContext _context)
        {
            context = _context;
          //  App_context = _App_context;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }
        public void Create(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }
        public virtual T GetById(int ID)
        {
            return context.Set<T>().Find(ID);

        }
        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }
    }
}