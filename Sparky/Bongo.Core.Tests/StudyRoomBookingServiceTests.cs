﻿using Bongo.Core.Services;
using Bongo.DataAccess.Repository.IRepository;
using Bongo.Models.Model;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bongo.Core.Tests
{
    [TestFixture]
    public class StudyRoomBookingServiceTests
    {
        private StudyRoomBooking _request;
        private List<StudyRoom> _availableStudyRoom;
        private Mock<IStudyRoomBookingRepository> _studyRoomBookingRepoMock;
        private Mock<IStudyRoomRepository> _studyRoomRepoMock;
        private StudyRoomBookingService _bookingService;
        [SetUp]
        public void Setup()
        {
            _request = new StudyRoomBooking
            {
                FirstName = "Henok",
                LastName = "Gebrehiwot",
                Email = "hen@gmail.com",
                Date = new DateTime(2022, 1, 1)
            };

            _availableStudyRoom = new List<StudyRoom> {
                new StudyRoom{
                    Id=10,RoomName="Nazreth", RoomNumber="A202"
                }
            };

            _studyRoomBookingRepoMock = new Mock<IStudyRoomBookingRepository>();
            _studyRoomRepoMock = new Mock<IStudyRoomRepository>();
            _studyRoomRepoMock.Setup(x => x.GetAll()).Returns(_availableStudyRoom);
            _bookingService = new StudyRoomBookingService(
                _studyRoomBookingRepoMock.Object,
                _studyRoomRepoMock.Object
                );

        }
        [TestCase]
        public void GetAllBooking_InvokeMethod_CheckIfRepoIsCalled()
        {
            _bookingService.GetAllBooking();
            _studyRoomBookingRepoMock.Verify(x => x.GetAll(null), Times.Once);
        }
        [TestCase]
        public void BookingException_NullRequest_ThrowsException()
        {
            var exception = Assert.Throws<ArgumentNullException>(
                () => _bookingService.BookStudyRoom(null));
            //Assert.AreEqual("Value cannot be null. (Parameter 'request')", exception.Message);    
            Assert.AreEqual("request", exception.ParamName);
        }
    }
}
