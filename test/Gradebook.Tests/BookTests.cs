using System;
using GradeBook;
using Xunit;

namespace Gradebook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // arrange
            var book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            
            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);
        }

        [Fact]
        public void AreGradesValid()
        {
            //arrange
            var book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            book.AddGrade(100);
            book.AddGrade(0);

            //act
            var result = book.GetStatistics();

            //assert
            //Assert.Equal(102, result.High, 1);
            //Assert.Equal(-8, result.Low, 1);
            Assert.InRange(result.High, 0, 100);
            Assert.InRange(result.Low, 0, 100);
        }
    }
}
