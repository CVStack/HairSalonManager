﻿using HairSalonManager.Model.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HairSalonManager.ViewModel
{
    class MenuViewModel
    {        
        private ReadOnlyCollection<ButtonCommandViewModel> _menuCommands;

        public ReadOnlyCollection<ButtonCommandViewModel> MenuCommands
        {
            get
            {
                if (_menuCommands == null)
                {
                    List<ButtonCommandViewModel> list = this.CreateCommands();
                    _menuCommands = new ReadOnlyCollection<ButtonCommandViewModel>(list);
                }
                return _menuCommands;

            }
          
        }
       
        private List<ButtonCommandViewModel> CreateCommands()
        {
            return new List<ButtonCommandViewModel>()
            {
                new ButtonCommandViewModel("메인",new Command(GoMainWindowPage),"red"),
                new ButtonCommandViewModel("미용사",new Command(GoStylistPage),"yellow"),
                new ButtonCommandViewModel("결제",new Command(GoPayPage),"blue"),
                new ButtonCommandViewModel("서비스",new Command(GoServicePage),"blue"),
                new ButtonCommandViewModel("전체 일정",new Command(GoSchedulePage),"blue"),
                new ButtonCommandViewModel("설정",new Command(GoSettingPage),"blue")
            };
        }

        #region Navigator xaml
        private void GoSettingPage(object obj)
        {
            
        }

        private void GoSchedulePage(object obj)
        {
            
        }

        private void GoServicePage(object obj)
        {
            
        }

        private void GoPayPage(object obj)
        {
            //NavigationServiceProvider.Navigate("/PayPage.xaml");
        }

        private void GoStylistPage(object obj)
        {
            //NavigationServiceProvider.Navigate("/StylistPage.xaml");
        }

        private void GoMainWindowPage(object o)
        {
            NavigationServiceProvider.Navigate("/MainPage.xaml");
        }
        #endregion
    }
}
