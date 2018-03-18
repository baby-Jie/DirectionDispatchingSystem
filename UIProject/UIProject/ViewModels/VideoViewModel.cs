using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIProject.Models;

namespace UIProject.ViewModels
{
    class VideoViewModel:BindableBase
    {
        ObservableCollection<Divisions> divisions;
        public ObservableCollection<Divisions> Divisions
        {
            get
            {
                if (null == divisions)
                {
                    divisions = new ObservableCollection<Models.Divisions>();
                    ObservableCollection<Positions> pos1 = new ObservableCollection<Positions>();
                    ObservableCollection<Positions> pos2 = new ObservableCollection<Positions>();
                    pos1.Add(new Positions() { Name = "江宁指挥中心" });
                    pos1.Add(new Positions() { Name = "六合指挥中心" });

                    pos2.Add(new Positions() { Name = "灌云指挥中心" });
                    pos2.Add(new Positions() { Name = "灌南指挥中心" });

                    divisions.Add(new Models.Divisions() { Name = "南京", Locations = pos1 });
                    divisions.Add(new Models.Divisions() { Name = "连云港", Locations = pos2 });

                }
                return divisions;
            }
        }

        private string _TestName = "123";

        public string TestName
        {
            get { return _TestName; }
            set
            {
                _TestName = value;
                OnPropertyChanged("TestName");
            }
        }

    }
}
