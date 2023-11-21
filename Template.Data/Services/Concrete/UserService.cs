using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Base.Entities.Concrete;
using Template.Data.EfRepository.Abstaract;
using Template.Data.EfRepository.Concrete;
using Template.Data.Services.Abstract;

namespace Template.Data.Services.Concrete
{
    public class UserService : BaseRepository<User>, IUserService
    {
        
        public UserService(
            IDbContextFactory<ApplicationDbContext> dbContextFactory
            ) 
            : base(
                  dbContextFactory
                  )
        {

        }
    }
}
