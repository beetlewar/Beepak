using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beepak.Data.Decl;

namespace Beepak.Data.Context
{
    public partial class User
    {
        [Key]
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string City { get; set; }

        public override bool Equals(object obj)
        {
            var user = obj as User;
            if(user == null)
            {
                return false;
            }
            return
                this.Login == user.Login &&
                this.Password == user.Password &&
                this.Email == user.Email &&
                this.City == user.City;
        }

        public override int GetHashCode()
        {
            return
                this.Login == null ?
                base.GetHashCode() :
                this.Login.GetHashCode();
        }
    }
}
