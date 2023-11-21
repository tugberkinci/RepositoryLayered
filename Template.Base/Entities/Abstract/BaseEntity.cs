using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Base.Entities.Abstract
{
    public class BaseEntity : IBaseEntity
    {

        [Key]
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; } = DateTime.Now;
    }
}
