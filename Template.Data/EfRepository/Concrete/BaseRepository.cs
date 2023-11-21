using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Template.Base.Entities.Abstract;
using Template.Data.EfRepository.Abstaract;
using Template.Data.Utils;

namespace Template.Data.EfRepository.Concrete
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public BaseRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public virtual async Task<ServiceResponse<IEnumerable<TEntity>>> GetAllAsync()
        {
            try
            {
                using (var _context = _dbContextFactory.CreateDbContext())
                {
                    var data = _context.Set<TEntity>().AsEnumerable();
                    return ServiceResponse<IEnumerable<TEntity>>.Succeed(data);
                }
            }
            catch (Exception ex)
            {
                return ServiceResponse<IEnumerable<TEntity>>.Failed(ex.Message);
            }
           
        }

        public virtual async Task<ServiceResponse<TEntity>> GetById(string id)
        {
            try
            {
                using (var _context = _dbContextFactory.CreateDbContext())
                {
                    var data = _context.Set<TEntity>().SingleOrDefault(x => x.Id.Equals(id));
                    if (data == null)
                        return ServiceResponse<TEntity>.Failed("Given Id is incorrect");

                    return ServiceResponse<TEntity>.Succeed(data);
                }

            }
            catch (Exception ex)
            {
                return ServiceResponse<TEntity>.Failed(ex.Message);
            }


        }

        public virtual async Task<ServiceResponse<TEntity>> Add(TEntity entity)
        {
            try
            {
                using (var _context = _dbContextFactory.CreateDbContext())
                {
                    //var guid = Guid.NewGuid();

                    //var data = _context.Set<TEntity>().SingleOrDefault(x => x.Id.Equals(guid));
                    //if (data != null)
                    //    return ServiceResponse<TEntity>.Failed("Given Id is incorrect");
                    _context.Set<TEntity>().Add(entity);
                    _context.SaveChanges();
                    return ServiceResponse<TEntity>.Succeed(entity);
                }
           
            }
            catch (Exception ex)
            {
                return ServiceResponse<TEntity>.Failed(ex.Message);
            }
        }

    }
}
