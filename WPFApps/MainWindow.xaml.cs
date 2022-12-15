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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UsersApp.EntityFrameworkCore;
using UsersApp.EntityFrameworkCore.Entities;

namespace WPFApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();

            List<User> users = db.Users.ToList();
            string str = "";
            foreach (User user in users) 
            {
                str += "Login: " + user.Login + " | ";
            }

            exampleText.Text = str;
        }

        private void OnRegButtonClick(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim(); 
            string pass2 = passBox2.Password.Trim(); 
            string email = textBoxEmail.Text.Trim();

            if (login.Length<5)
            {
                //ToolTip свойство которое выводит подску при наведении мышки на обЪект
                textBoxLogin.ToolTip = "это поле введено не корректно!";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if(pass.Length<5)
            {
                passBox.ToolTip = "это поле введено не корректно!";
                passBox.Background = Brushes.DarkRed;
            }
            else if (pass!= pass2)
            {
                passBox2.ToolTip = "это поле введено не корректно!";
                passBox2.Background = Brushes.DarkRed;
            }
            else if (email.Length<5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "это поле введено не корректно!";
                textBoxEmail.Background = Brushes.DarkRed;
            }

            //Если все проверки прошли успешно то очищаем поля от всплывающих подсказок
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;

                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;

                passBox2.ToolTip = "";
                passBox2.Background = Brushes.Transparent;

                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("Регистрация прошла успешно!");

                //Создаем новый объект на основе класса модели
                User user = new User(login, email, pass);
                //добавляем объект в базу данных
                db.Users.Add(user);
                //сохраняем изменения
                db.SaveChanges();
            }
        }
    }
}
