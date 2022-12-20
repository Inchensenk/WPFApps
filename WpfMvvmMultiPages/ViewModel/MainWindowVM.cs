using CommunityToolkit.Mvvm.Input;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfMvvmMultiPages.ViewModel
{
    class MainWindowVM : ViewModelBase
    {
        private Page Welcome = null!;
        private Page Main = null!;
        private Page Exit = null!;
        private Page Test= null!;

        private Page _currentPage = null!;
        public Page CurrentPage { get; set; } = null!;

        private double _frameOpacity;
        public double FrameOpacity { get;set; }

        public MainWindowVM()
        {
            Welcome = new Pages.WelcomePage();
            Main = new Pages.MainPage();
            Exit = new Pages.ExitPage();
            Test = new Pages.TestPage();

            //Анимация перехода(может быть от 0 до 1)
            FrameOpacity = 1;

            CurrentPage = Welcome;
        }

        public ICommand bMenuMain_Click
        {
            get
            {
                return new RelayCommand(() => SlowOpacity(Main));
            }
        }

        public ICommand bMenuExit_Click
        {
            get
            {
                return new RelayCommand(() => SlowOpacity(Exit));
            }
        }

        public ICommand bMenuTest_Click
        {
            get
            {
                return new RelayCommand(() => SlowOpacity(Test));
            }
        }

        /// <summary>
        /// Анимация перехода между страницами
        /// </summary>
        /// <param name="page"></param>
        private async void SlowOpacity(Page page)
        {
            await Task.Factory.StartNew(() =>
            {
                //плавно исчезает элемент
                for (double i = 1.0; i < 0.0; i-=0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(50);
                }

                //меняем страницу
                CurrentPage= page;

                //плавно появляется элемент
                for (double i = 0.0; i < 1.1; i+=0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(50);
                }
            });
        }
    }
}
