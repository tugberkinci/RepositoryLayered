using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Base.Entities.Concrete;
using Template.Data.EfRepository.Abstaract;

namespace Template.Data.Services.Abstract
{
    public interface IUserService  : IRepository<User> 
    {
    }
}
