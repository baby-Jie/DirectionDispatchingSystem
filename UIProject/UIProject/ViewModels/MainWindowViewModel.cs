using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using UIProject.Models;
using UIProject.Views;

namespace UIProject.ViewModels
{
    class MainWindowViewModel:BindableBase
    {
        #region Views
        private UserControl _ShowMainView = new LogInView();

        public UserControl ShowMainView
        {
            get
            {
                if (_ShowMainView is LogInView)
                {
                    _ShowMainView = new LogInView();
                    var datacontext = new LogInViewModel();
                    datacontext.LogInEvent += LogSuccessfully;
                    _ShowMainView.DataContext = datacontext;


                }
                return _ShowMainView;
            }
            set
            {
                _ShowMainView = value;
                OnPropertyChanged("ShowMainView");
            }
        }

     


        #endregion


        #region Properties
        private string titleString = "森林防火综合指挥车载终端";
        public string TitleString
        {
            get { return titleString; }
            set { titleString = value; }
        }


        private bool _IsBarVisible = false;

        public bool IsBarVisible
        {
            get { return _IsBarVisible; }
            set
            {
                _IsBarVisible = value;
                OnPropertyChanged("IsBarVisible");
            }
        }

        private ObservableCollection<ToolBarItem> toolBarList;
        public ObservableCollection<ToolBarItem> ToolBarList
        {
            get
            {
                if (null == toolBarList)
                {
                    toolBarList = new ObservableCollection<ToolBarItem>();
                    toolBarList.Add(new ToolBarItem() { IConName = "Car", UserViewType = typeof(CarView), UserViewModelType = typeof(CarViewModel) });
                    toolBarList.Add(new ToolBarItem() { IConName = "Camera", UserViewType = typeof(VideoView), UserViewModelType = typeof(VideoViewModel) });
                    toolBarList.Add(new ToolBarItem() { IConName = "Phone", UserViewType = typeof(UsersView), UserViewModelType = typeof(UsersViewModel) });
                    toolBarList.Add(new ToolBarItem() { IConName = "CalendarText", UserViewType = typeof(ConferenceView), UserViewModelType = typeof(ConferenceViewModel) });
                    toolBarList.Add(new ToolBarItem() { IConName = "FlagTriangle", UserViewType=typeof(AlarmRecordsView), UserViewModelType = typeof(AlarmRecordsViewModel) });
                    toolBarList.Add(new ToolBarItem() { IConName = "Settings", UserViewType=typeof(SettingView), UserViewModelType=typeof(SettingViewModel) });
                }
                return toolBarList;
            }
        }


        private int? _SelectedIndex;

        public int? SelectedIndex
        {
            get { return _SelectedIndex; }
            set
            {
                _SelectedIndex = value;
                OnPropertyChanged("SelectedIndex");
            }
        }


        #endregion

        #region Functions
        void LogSuccessfully()
        {
            IsBarVisible = true;
            SelectedIndex = 0;

        }
        #endregion

        #region Command
        private DelegateCommand<ToolBarItem> _ChangeViewCommand;

        public DelegateCommand<ToolBarItem> ChangeViewCommand
        {
            get
            {
                if (null == _ChangeViewCommand)
                    _ChangeViewCommand = new DelegateCommand<ToolBarItem>((item) => 
                    {
                        ShowMainView = null; 
                        item.UserView = Activator.CreateInstance(item.UserViewType) as UserControl;
                        item.UserViewModel = Activator.CreateInstance(item.UserViewModelType) as BindableBase;
                        item.UserView.DataContext = item.UserViewModel;
                        ShowMainView = item.UserView;
                    });
                return _ChangeViewCommand;
            }
            set
            {
                _ChangeViewCommand = value;

            }
        }

        #endregion



    }
}
