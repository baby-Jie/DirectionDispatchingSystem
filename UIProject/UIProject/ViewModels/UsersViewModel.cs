using Microsoft.Practices.Prism.Commands;
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
    class UsersViewModel:BindableBase
    {
        #region Properties
        private string _ButtonContent = "江苏";

        public string ButtonContent
        {
            get { return _ButtonContent; }
            set
            {
                _ButtonContent = value;
                OnPropertyChanged("ButtonContent");
            }
        }

        List<UserBase> _Users;

        private List<UserBase> Users
        {
            get
            {
                if (null == _Users)
                {
                    _Users = new List<UserBase>();

                    _Users.Add(new Orignize() { Name = "江苏", Id = 0,  Level=1, ParentId = -1});
                    _Users.Add(new Orignize() { Name = "南京", Id = 1,  ParentId = 0, Level=2});
                    _Users.Add(new Orignize() { Name = "连云港", Id = 2, ParentId = 0, Level =2});

                    _Users.Add(new PhoneUser() { Name = "张三", Id = 3, ParentId = 1, Status = "在线", Duty= "护林员"});
                    _Users.Add(new PhoneUser() { Name = "李四", Id = 4, ParentId = 1, Status = "在线", Duty = "护林员" });
                    _Users.Add(new PhoneUser() { Name = "王二", Id = 5, ParentId = 2, Status = "在线", Duty = "护林员" });
                    _Users.Add(new PhoneUser() { Name = "王五", Id = 6, ParentId = 2, Status = "在线" , Duty = "护林员" });

                    _Users.Add(new Orignize() { Name = "江宁", Id = 7, ParentId = 1, Level = 3 });
                    _Users.Add(new Orignize() { Name = "六合", Id = 8, ParentId = 1, Level = 3 });

                    _Users.Add(new PhoneUser() { Name = "A", Id = 9, ParentId = 7, Status = "在线", Duty = "护林员" });
                    _Users.Add(new PhoneUser() { Name = "B", Id = 10, ParentId = 8, Status = "在线", Duty = "护林员" });

                }
                return _Users;
            }
        }

        private ObservableCollection<UserBase> _UsersSources;

        public ObservableCollection<UserBase> UsersSources
        {
            get
            {
                if (null == _UsersSources)
                {
                    _UsersSources = new ObservableCollection<UserBase>(Users.Where((item) => { return item.ParentId == 0; }));
                }
                return _UsersSources;
            }
            set
            {
                _UsersSources = value;
                OnPropertyChanged("UsersSources");
            }
        }

        private int _CurrentId;

        public int CurrentId
        {
            get { return _CurrentId; }
            set
            {
                _CurrentId = value;
                OnPropertyChanged("CurrentId");
            }
        }



        #endregion

        #region Command

        private DelegateCommand<UserBase> _SelectionChangedCommand;

        public DelegateCommand<UserBase> SelectionChangedCommand
        {
            get
            {
                if (null == _SelectionChangedCommand)
                    _SelectionChangedCommand = new DelegateCommand<UserBase>((item) => 
                    {
                        if (item is Orignize)
                        {
                            UsersSources = new ObservableCollection<UserBase>(Users.Where((t) => { return t.ParentId == item.Id; }));
                            ButtonContent = item.Name;
                            CurrentId = item.Id;
                        }
                    });
                return _SelectionChangedCommand;
            }
            set
            {
                _SelectionChangedCommand = value;

            }
        }

        private DelegateCommand _LastDivision;

        public DelegateCommand LastDivision
        {
            get
            {
                if (null == _LastDivision)
                    _LastDivision = new DelegateCommand(() => 
                    {
                        if (0 != CurrentId)
                        {
                            UserBase item = Users.Where(t => t.Id == CurrentId).Single();
                            
                           
                            CurrentId = item.ParentId;
                            UserBase parent = Users.Where(t => t.Id == CurrentId).Single();
                            if (null != parent)
                                ButtonContent = parent.Name;
                            UsersSources = new ObservableCollection<UserBase>(Users.Where((t) => { return t.ParentId == CurrentId; }));
                          

                            
                            
                        }
                    });
                return _LastDivision;
            }
            set
            {
                _LastDivision = value;

            }
        }


        #endregion

        #region Function
        #endregion
    }
}
