using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace UIProject.Models
{
    class ToolBarItem
    {
        public string IConName { get; set; }
        public UserControl UserView { get; set; }
        public BindableBase UserViewModel { get; set; }
        public Type UserViewType { get; set; }
        public Type UserViewModelType { get; set; }


    }
}
