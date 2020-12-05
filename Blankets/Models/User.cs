using System;
using System.Collections.Generic;
using System.Text;

namespace Blankets.Models
{
    public class User
    {
        public int iD;
        public string UserName1;
        public string Password;
        public User(string UserName, string Password)
        {
            UserName1 = UserName;
            this.Password = Password;
        }
        public User()
        {
            new User("Basic", "Basic");
        }
        public int GetID() {
            return iD;
        }

        public void SetID(int value) {
            iD = value;
        }

        public string GetuserName() {
            return UserName1;
        }

        public void SetuserName(string value) {
            UserName1 = value;
        }
        private String Getpassword() {
            return Password;
        }
        private void Setpassword(string value) {
            Password = value;
        }
    }
}
