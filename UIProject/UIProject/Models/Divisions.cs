using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIProject.Models
{
    class Divisions:BindableBase
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

        private ObservableCollection<Positions> _Locations;

        public ObservableCollection<Positions> Locations
        {
            get { return _Locations; }
            set
            {
                _Locations = value;
                OnPropertyChanged("Locations");
            }
        }


    }
}
