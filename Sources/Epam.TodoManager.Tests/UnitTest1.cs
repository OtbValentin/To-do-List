using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Epam.TodoManager.Infrastructure.EntityMapping;
using Domain = Epam.TodoManager.DomainModel.Entities;
using DB = Epam.TodoManager.DataAccess.EF.Model;
using AutoMapper;

namespace Epam.TodoManager.Tests
{
    [TestClass]
    public class EntityMapperTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            IMapper mapper = EntityMapper.Mapper;


            mapper.Map
        }
    }
}
