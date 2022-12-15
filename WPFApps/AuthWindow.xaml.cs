using System.Linq;
using System.Windows;
using System.Windows.Media;
using UsersApp.EntityFrameworkCore;
using UsersApp.EntityFrameworkCore.Entities;

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void OnAuthButtonClick(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            

            if (login.Length < 5)
            {
                //ToolTip свойство которое выводит подску при наведении мышки на обЪект
                textBoxLogin.ToolTip = "это поле введено не корректно!";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if (pass.Length < 5)
            {
                passBox.ToolTip = "это поле введено не корректно!";
                passBox.Background = Brushes.DarkRed;
            }
            

            //Если все проверки прошли успешно то очищаем поля от всплывающих подсказок
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;

                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;

                User authUser = null!;
                using(ApplicationContext context= new ApplicationContext()) 
                {
                    //поиск юзера в базе данных
                    authUser = context.Users.Where(b => b.Login == login && b.Pass == pass).FirstOrDefault();
                }

                if (authUser != null)
                { 
                    MessageBox.Show("Авторизация прошла успешно!"); 
                }
                else 
                { 
                    MessageBox.Show("Ошибка Авторизации!"); 
                }
               
            }
        }
    }
}
