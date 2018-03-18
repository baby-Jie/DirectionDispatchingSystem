using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIProject.ViewModels
{
    class LogInViewModel:BindableBase
    {
        #region Properties

        #region 用户名
        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set
            {
                _UserName = value;
                OnPropertyChanged("UserName");
            }
        }
        #endregion

        #region 密码
        private string _UserPass;

        public string UserPass
        {
            get { return _UserPass; }
            set
            {
                _UserPass = value;
                OnPropertyChanged("UserPass");
            }
        }

        #endregion

        #region 登录出错信息
        private string _TextError;

        public string TextError
        {
            get { return _TextError; }
            set
            {
                _TextError = value;
                OnPropertyChanged("TextError");
            }
        }

        #endregion
        #endregion

        #region Commands
        private DelegateCommand _LogInCommand;

        public DelegateCommand LogInCommand
        {
            get
            {
                if (null == _LogInCommand)
                    _LogInCommand = new DelegateCommand(() =>
                    {
                        if ( "123" == UserName && "123" == UserPass)
                        {
                            TextError = string.Empty;
                            LogInEvent?.Invoke();
                        }
                        else
                        {
                            TextError = "用户名密码出错";
                        }
                    });

                return _LogInCommand;
            }
            set
            {
                _LogInCommand = value;

            }
        }

        #endregion

        #region Event
        public event Action LogInEvent;
        #endregion

    }
}
