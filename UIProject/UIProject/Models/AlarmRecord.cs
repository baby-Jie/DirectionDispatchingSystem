using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIProject.Models
{
    class AlarmRecord:BindableBase
    {
        public string field { get; set; }
        public string direction { get; set; }
        public string time { get; set; }
        public string approver { get; set; }
        public double pan { get; set; }
        public double tilt { get; set; }
        public string ptzname { get; set; }
        public int ptzid { get; set; }
        public int cmsid { get; set; }
        public int detecttype { get; set; }
        public double firelatitude { get; set; }
        public double firelongitude { get; set; }

        public string ImagePath { get; set; }
    }
}
