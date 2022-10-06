using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Devs.Domain.Entities
{
    public class Language :Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Framework> Frameworks { get; set; }
        public Language()
        {
                
        }

        public Language(int id,string name):this()
        {
            Id = id;
            Name = name;
        }
    }
}
