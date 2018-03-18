using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIProject.Models
{
    class Positions:BindableBase
    {
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }

    }
}
