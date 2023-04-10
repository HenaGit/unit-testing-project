using Bongo.DataAccess.Repository;
using Bongo.Models.Model;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bongo.DataAccess.Tests
{
    [TestFixture]
    public class StudyRoomBookingRepositoryTests
    {
        private StudyRoomBooking studyRoomBooking_One;
        private StudyRoomBooking studyRoomBooking_Two;
        public StudyRoomBookingRepositoryTests()
        {
            studyRoomBooking_One = new StudyRoomBooking()
            {
                FirstName = "Henok1",
                LastName = "Gebrehiwot1",
                Date = new DateTime(2023, 6, 6),
                Email = "henok1@gmail.coom",
                BookingId = 11,
                StudyRoomId = 1
            };

            studyRoomBooking_Two = new StudyRoomBooking
            {
                FirstName = "Henok2",
                LastName = "Gebrehiwot2",
                Date = new DateTime(2023, 7, 7),
                Email = "henok2@gmail.coom",
                BookingId = 22,
                StudyRoomId = 2
            };
        }
        [Test]
        public void SaveBooking_Booking_One_CheckTheValuesFromDatabase()
        {
            //arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "temp_Bongo").Options;

            //act
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new StudyRoomBookingRepository(context);
                repository.Book(studyRoomBooking_Two);
            }

            //assert
            using (var context = new ApplicationDbContext(options))
            {
                var bookingFromDb = context.StudyRoomBookings.FirstOrDefault(u => u.BookingId == 22);
                Assert.AreEqual(studyRoomBooking_Two.BookingId, bookingFromDb.BookingId);
                Assert.AreEqual(studyRoomBooking_Two.FirstName, bookingFromDb.FirstName);
                Assert.AreEqual(studyRoomBooking_Two.LastName, bookingFromDb.LastName);
                Assert.AreEqual(studyRoomBooking_Two.Email, bookingFromDb.Email);
                Assert.AreEqual(studyRoomBooking_Two.Date, bookingFromDb.Date);
            }
        }
    }
}
