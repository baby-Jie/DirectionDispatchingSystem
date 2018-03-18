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
    class AlarmRecordsViewModel : BindableBase
    {

        private ObservableCollection<AlarmRecord> alarmRes;

        public ObservableCollection<AlarmRecord> AlarmRes
        {
            get
            {
                if (null == alarmRes)
                {
                    alarmRes = new ObservableCollection<AlarmRecord>();
                    alarmRes.Add(new AlarmRecord() { field = "南京江宁", direction = "西南方向", time = "2018-03-07 14:50:48", approver = "未审核", pan = 306.5, tilt = 13.83, ptzname = "东善桥东善分场林", ImagePath = "/Resources/Images/alarm1.jpg" });
                    alarmRes.Add(new AlarmRecord() { field = "南京江宁", direction = "东南方向", time = "2018-03-07 14:42:11", approver = "未审核", pan = 90.81, tilt = 16.73, ptzname = "秣陵街道牛首林", ImagePath = "/Resources/Images/alarm2.jpg" });
                }
                return alarmRes;
            }
            set { alarmRes = value; }
        }

     


    }
}
