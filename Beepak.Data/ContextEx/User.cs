using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beepak.Data
{
    public partial class User
    {
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
