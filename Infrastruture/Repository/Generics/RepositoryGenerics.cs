using Domain.Interfaces.Generics;
using Infrastruture.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Infrastruture.Repository.Generics
{
    public class RepositoryGenerics<T> : IGeneric<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryGenerics()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task Add(T Objecto)
        {
           using (var data = new ContextBase(_OptionsBuilder)) 
            {
                await data.Set<T>().AddAsync(Objecto);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T Objecto)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                data.Set<T>().Remove(Objecto);
                await data.SaveChangesAsync();
            }
        }

      

        public async Task<T> GetTEntityById(int Id)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
              return  await data.Set<T>().FindAsync(Id);
              
            }
        }

        public async Task<List<T>> List()
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.Set<T>().AsNoTracking().ToListAsync();
            }
        }

        public async Task Update(T Objecto)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                data.Set<T>().Update(Objecto);
                await data.SaveChangesAsync();
            }
        }

        #region Disposed
        bool disposed = false;

        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true); 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) 
        {
            if (disposing)
                return;
            if(disposing)
            {
                handle.Dispose();
            }

            disposed = true;
        }

        #endregion
    }
}
