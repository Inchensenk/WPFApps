using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UsersApp.EntityFrameworkCore;
using UsersApp.EntityFrameworkCore.Entities;

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для UserPageWindow.xaml
    /// </summary>
    public partial class UserPageWindow : Window
    {
        public UserPageWindow()
        {
            InitializeComponent();

            /*Подключение к БД и выборка всех данных из БД*/
            ApplicationContext db= new ApplicationContext();

            //список пользователей в базе данных
            List<User> users = db.Users.ToList();

            //обращаемся к listView объекту во вьюхе 
            listOfUsers.ItemsSource= users;
        }
    }
}
