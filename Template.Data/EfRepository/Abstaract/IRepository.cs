using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Base.Entities.Abstract;
using Template.Data.Utils;

namespace Template.Data.EfRepository.Abstaract
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<ServiceResponse<IEnumerable<T>>> GetAllAsync();
        Task<ServiceResponse<T>> GetById(string id);
        Task<ServiceResponse<T>> Add(T entity);
    }
}
