using CommunityToolkit.Mvvm.Input;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfMvvmMultiPages.ViewModel
{
    class TestPageVM : ViewModelBase
    {
        public ICommand Test_Click
        {
            get
            {
                return new RelayCommand(() => MessageBox.Show("Test"));
            }
        }
    }
}
