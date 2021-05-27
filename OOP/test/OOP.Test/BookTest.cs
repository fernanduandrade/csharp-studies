using System;
using Xunit;

namespace OOP.Test
{
    public class BookTest
    {
        [Fact]
        public void BookCalculateStatistics()
        {   
            // Arrange
            Book book = new Book("Teste");
            book.AddGrade(80.0);
            book.AddGrade(70.0);
            book.AddGrade(60.0);

            // Act
            var result = book.GetStatistics();

            // Assert

            Assert.Equal(70.0, result.Average, 1);
            Assert.Equal(80.0, result.Max, 1);
            Assert.Equal(60.0, result.Low, 1);
            Assert.Equal('C', result.Letter);
        }

     
    }
}
