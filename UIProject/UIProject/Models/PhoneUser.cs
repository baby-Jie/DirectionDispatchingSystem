using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIProject.Models
{
    class PhoneUser:UserBase
    {
        private string _Status;

        public string Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
                OnPropertyChanged("Status");
            }
        }

        public string Sip_Id { get; set; }

        public string Duty { get; set; }
    }
}
