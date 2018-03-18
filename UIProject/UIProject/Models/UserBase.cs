using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIProject.Models
{
    class UserBase:BindableBase
    {
        public string Name { get; set; }
        public int Level { get; set; }

        public int Id { get; set; }

        public int ParentId { get; set; }

    }
}
