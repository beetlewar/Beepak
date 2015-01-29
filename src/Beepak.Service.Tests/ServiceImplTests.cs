using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beepak.Data;
using Beepak.Utils;
using NUnit.Framework;
using Rhino.Mocks;

namespace Beepak.Service.Tests
{
    [TestFixture]
    public class ServiceImplTests
    {
        [Test]
        [ExpectedException(typeof(EmptyStringException))]
        public void Register_EmptyLogin_ThrowsException()
        {
            new ServiceImpl().Register(" ", "1", "1", "123@mail.ru", "Moscow");
        }

        [Test]
        [ExpectedException(typeof(EmptyStringException))]
        public void Register_EmptyPassword_ThrowsException()
        {
            new ServiceImpl().Register("1", "  ", "1", "123@mail.ru", "Moscow");
        }

        [Test]
        [ExpectedException(typeof(EmptyStringException))]
        public void Register_EmptyPasswordRpt_ThrowsException()
        {
            new ServiceImpl().Register("1", "1", "   ", "123@mail.ru", "Moscow");
        }

        [Test]
        [ExpectedException(typeof(EmptyStringException))]
        public void Register_EmptyMail_ThrowsException()
        {
            new ServiceImpl().Register("1", "2", "2", "  ", "Moscow");
        }

        [Test]
        [ExpectedException(typeof(EmptyStringException))]
        public void Register_EmptyCity_ThrowsException()
        {
            new ServiceImpl().Register("1", "2", "2", "123@mail.ru", "     ");
        }

        [Test]
        [ExpectedException(typeof(DifferentPasswordsException))]
        public void Register_DifferentPasswords_ThrowsException()
        {
            new ServiceImpl().Register("1", "a", "A", "123@mail.ru", "Moscow");
        }

        [Test]
        public void Register_MockRepositoryFactory_CreatesUsersRepository()
        {
            var mock = MockRepository.GenerateMock<IRepositoryFactory>();
            mock.Expect(r => r.CreateRepository<User>()).Return(MockRepository.GenerateStub<IRepository<User>>());
            new ServiceImpl(mock).Register("1", "a", "a", "1@mail.ru", "m");

            mock.VerifyAllExpectations();
        }

        [Test]
        public void Register_MockUsersRepository_AddsUser()
        {
            var user = new User()
            {
                Login = "3",
                Password = "b",
                Email = "2@mail.ru",
                City = "d",
            };

            var mock = MockRepository.GenerateMock<IRepository<User>>();
            mock.Expect(r => r.Add(user));

            var repFac = MockRepository.GenerateStub<IRepositoryFactory>();
            repFac.Stub(r => r.CreateRepository<User>()).Return(mock);

            new ServiceImpl(repFac).Register("3", "b", "b", "2@mail.ru", "d");

            mock.VerifyAllExpectations();
        }

        [Test]
        public void Register_StubUserRepository_ReturnsExpectedUser()
        {
            var repFac = MockRepository.GenerateStub<IRepositoryFactory>();
            repFac.Stub(r => r.CreateRepository<User>()).Return(MockRepository.GenerateStub<IRepository<User>>());

            var user = new User()
            {
                Login = "3",
                Password = "b",
                Email = "2@mail.ru",
                City = "d",
            };
            Assert.AreEqual(user, new ServiceImpl(repFac).Register("3", "b", "b", "2@mail.ru", "d"));
        }

        [Test]
        public void Register_MockUserRepository_Disposes()
        {
            var user = new User()
            {
                Login = "3",
                Password = "b",
                Email = "2@mail.ru",
                City = "d",
            };

            var mock = MockRepository.GenerateMock<IRepository<User>>();
            mock.Expect(r => r.Dispose());

            var repFac = MockRepository.GenerateStub<IRepositoryFactory>();
            repFac.Stub(r => r.CreateRepository<User>()).Return(mock);

            new ServiceImpl(repFac).Register("3", "b", "b", "2@mail.ru", "d");

            mock.VerifyAllExpectations();
        }
    }
}
