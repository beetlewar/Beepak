using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;
using Beepak.Data;
using Beepak.Data.Context;
using Beepak.Data.ContextRepository;
using Beepak.Data.Decl;
using Beepak.Utils;

namespace Beepak.Service
{
    public class ServiceImpl : IService
    {
        private readonly IRepositoryFactory _repFactory;

        internal ServiceImpl(IRepositoryFactory repFactory)
        {
            this._repFactory = repFactory ?? new ContextRepositoryFactory();
        }

        public ServiceImpl() : this(null)
        {
        }

        public User Register(
            string login,
            string password,
            string passwordRpt,
            string mail,
            string city)
        {
            login.BPThrowIfStringIsEmpty("login");
            password.BPThrowIfStringIsEmpty("password");
            passwordRpt.BPThrowIfStringIsEmpty("passwordRpt");
            mail.BPThrowIfStringIsEmpty("mail");
            city.BPThrowIfStringIsEmpty("city");

            if(password != passwordRpt)
            {
                throw new DifferentPasswordsException(password, passwordRpt);
            }

            var user = new User()
            {
                Login = login,
                Password = password,
                Email = mail,
                City = city,
            };
            using (var rep = this._repFactory.CreateRepository<User>())
            {
                rep.Add(user);
            }
            return user;
        }

        public User Logon(
            string login, 
            string password)
        {
            login.BPThrowIfStringIsEmpty("login");
            password.BPThrowIfStringIsEmpty("password");

            using (var rep = this._repFactory.CreateRepository<User>())
            {
                var upLogin = login.ToUpper();
                var user = rep.QueryAll().FirstOrDefault(u => u.Login.ToUpper() == upLogin);
                if(user == null)
                {
                    throw new LoginAbsentException(login);
                }
                if(user.Password != password)
                {
                    throw new PasswordFailedException(login, password);
                }
                return user;
            }
        }
    }
}
