using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp.EntityFrameworkCore.Entities
{
    /// <summary>
    /// Класс модели User
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }

        public User()
        {

        }

        public User(string login, string email, string pass)
        {
            this.Login = login;
            this.Email = email; 
            this.Pass = pass;
        }

        /*
        /// <summary>
        /// Переопределяем метод ToString для корректного отображения пользователя в списке пользователей
        /// </summary>
        /// <returns>Возвращаем ту информацию о пользователе, которую хотим видеть в списке пользователей</returns>
        public override string ToString()
        {
            return "Пользователь: " + Login + ". Email: " + Email;
        }
        */
    }

  
}
