using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Devs.Domain.Entities
{
    public class Framework :Entity
    {
        public Framework()
        {

        }

        public Framework(int id, int languageId, string name)
        {
            Id = id;
            Name = name;
            LanguageId = languageId;
        }

        
        public string Name { get; set; }
        public int LanguageId { get; set; }
        public virtual Language? Language { get; set;}

        
    }
}
