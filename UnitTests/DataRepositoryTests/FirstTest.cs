﻿using System;
using System.Data.Entity;
using System.Linq;
using DataRepository.DataAccess.GenericRepository;
using DataRepository.DataAccess.UnitOfWork;
using DataRepository.Models;
using NUnit.Framework;
using DataRepository.DataAccess;

namespace UnitTests.DataRepositoryTests
{
    [TestFixture]
    public class FirstTest
    {
        private IUnitOfWork _uow;

        [SetUp]
        public void SetUp() {
            Database.SetInitializer<MineContext>(new MineDbInitializer());
            _uow = new UnitOfWork(new MineContext());
        }

        [TearDown]
        public void TearDown() {
            _uow.Dispose();
        }

        [Test]
        public void TestGetting() {
           var doorRepo = _uow.GetRepository<Door>();
           Door door = doorRepo.Find(1);
                
           Assert.AreEqual(door.Id, 1);
           Assert.AreEqual(door.DoorStateId, 1);
           Assert.AreEqual(door.DoorStateId, 1); 
        }

        [Test]
        public void TestAdding() {
            var door = new Door { DoorStateId = 2, DoorTypeId = 2, Number = 1, 
            Date = DateTime.Now};

            var doorRepo = _uow.GetRepository<Door>();
            doorRepo.Add(door);
            _uow.Commit();

            var result = doorRepo.FindFirstBy(el => el.DoorTypeId == 2);

            Assert.AreNotEqual(result, null);
        }

        [Test]
        public void TestDeleting() {
            var doorRepo = _uow.GetRepository<Door>();
           
            var door = new Door { DoorStateId = 2, DoorTypeId = 2, Number = 3, 
            Date = DateTime.Now};
            doorRepo.Add(door);
            _uow.Commit();

            doorRepo.Delete(door);
            _uow.Commit();

            var result = doorRepo.FindFirstBy(el => el.Number == 3);
            Assert.AreEqual(result, null);
        }
    }
}
