using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DB = Epam.TodoManager.DataAccess.EF.Model;
using Domain = Epam.TodoManager.DomainModel.Entities;
using AutoMapper;
using Epam.TodoManager.Infrastructure.EntityMapping;

namespace Epam.TodoManager.Tests
{
    [TestClass]
    public class User
    {
        [TestMethod]
        public void DomainUserToDbUserIdMap()
        {
            IMapper mapper = EntityMapper.Mapper;

            Domain.User domain = new Domain.User(23, default(int), string.Empty, string.Empty,
               new Domain.UserProfile(default(int), string.Empty, default(DateTime)));

            DB.User db = mapper.Map<DB.User>(domain);

            Assert.AreEqual(true, AreUsersEqual(db, domain));
        }

        [TestMethod]
        public void DomainUserToDbUserEmailMap()
        {
            IMapper mapper = EntityMapper.Mapper;

            Domain.User domain = new Domain.User(default(int), default(int), "email@email.com", string.Empty,
                new Domain.UserProfile(default(int), string.Empty, default(DateTime)));

            DB.User db = mapper.Map<DB.User>(domain);

            Assert.AreEqual(true, AreUsersEqual(db, domain));
        }

        [TestMethod]
        public void DomainUserToDbUserPasswordMap()
        {
            IMapper mapper = EntityMapper.Mapper;

            Domain.User domain = new Domain.User(default(int), default(int), string.Empty, "password12390D",
                new Domain.UserProfile(default(int), string.Empty, default(DateTime)));

            DB.User db = mapper.Map<DB.User>(domain);

            Assert.AreEqual(true, AreUsersEqual(db, domain));
        }

        [TestMethod]
        public void DomainUserToDbUserNameMap()
        {
            IMapper mapper = EntityMapper.Mapper;

            Domain.User domain = new Domain.User(23, default(int), string.Empty, string.Empty,
                new Domain.UserProfile(default(int), "Patrick", default(DateTime)));

            DB.User db = mapper.Map<DB.User>(domain);

            Assert.AreEqual(true, AreUsersEqual(db, domain));
        }

        [TestMethod]
        public void DomainUserToDbUserRegisterDateMap()
        {
            IMapper mapper = EntityMapper.Mapper;

            Domain.User domain = new Domain.User(23, default(int), string.Empty, string.Empty,
                new Domain.UserProfile(default(int), string.Empty, DateTime.Now));

            DB.User db = mapper.Map<DB.User>(domain);

            Assert.AreEqual(true, AreUsersEqual(db, domain));
        }

        [TestMethod]
        public void DomainUserToDbUserProfileIdMap()
        {
            IMapper mapper = EntityMapper.Mapper;

            Domain.User domain = new Domain.User(23, default(int), string.Empty, string.Empty,
                new Domain.UserProfile(938, string.Empty, default(DateTime)));

            DB.User db = mapper.Map<DB.User>(domain);

            Assert.AreEqual(true, AreUsersEqual(db, domain));
        }

        [TestMethod]
        public void DbUserToDomainUserIdMap()
        {
            IMapper mapper = EntityMapper.Mapper;

            DB.User db = new DB.User() { Id = 13 };
            Domain.User domain = mapper.Map<Domain.User>(db);

            Assert.AreEqual(true, AreUsersEqual(db, domain));
        }

        [TestMethod]
        public void DbUserToDomainUserEmailMap()
        {
            IMapper mapper = EntityMapper.Mapper;

            DB.User db = new DB.User() { Email = "iessfe@ggmail.com"};
            Domain.User domain = mapper.Map<Domain.User>(db);

            Assert.AreEqual(true, AreUsersEqual(db, domain));
        }

        [TestMethod]
        public void DbUserToDomainUserPasswordMap()
        {
            IMapper mapper = EntityMapper.Mapper;

            DB.User db = new DB.User() { PasswordHash = "H_SD1123u8@__@!!90SjkSD" };
            Domain.User domain = mapper.Map<Domain.User>(db);

            Assert.AreEqual(true, AreUsersEqual(db, domain));
        }

        [TestMethod]
        public void DbUserToDomainUserNameMap()
        {
            IMapper mapper = EntityMapper.Mapper;

            DB.User db = new DB.User();
            db.Profile.Name = "Patrick";
            Domain.User domain = mapper.Map<Domain.User>(db);

            Assert.AreEqual(true, AreUsersEqual(db, domain));
        }

        [TestMethod]
        public void DbUserToDomainUserRegisterDateMap()
        {
            IMapper mapper = EntityMapper.Mapper;

            DB.User db = new DB.User();
            db.Profile.RegisterDate = DateTime.Now;

            Domain.User domain = mapper.Map<Domain.User>(db);

            Assert.AreEqual(true, AreUsersEqual(db, domain));
        }

        [TestMethod]
        public void DbUserToDomainUserProfileIdMap()
        {
            IMapper mapper = EntityMapper.Mapper;

            DB.User db = new DB.User();
            db.Profile.Id = 149;
            Domain.User domain = mapper.Map<Domain.User>(db);

            Assert.AreEqual(true, AreUsersEqual(db, domain));
        }

        private bool AreUsersEqual(DB.User db, Domain.User domain)
        {
            return (db.Id == domain.Id) && (db.Email == domain.Email) &&
                (db.PasswordHash == domain.PasswordHash) && (db.Profile.Id == domain.Profile.Id) &&
                (db.Profile.Name == domain.Profile.Name) && (db.Profile.RegisterDate == domain.Profile.RegisterDate);

        }
    }
}
