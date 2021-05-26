using System;
using Xunit;

namespace OOP.Test
{
    public class BookTest
    {
        [Fact]
        public void Test1()
        {   
            // Arrange
            Book book = new Book("Teste");
            book.AddGrade(10.0);
            book.AddGrade(11.0);
            book.AddGrade(12.0);

            // Act
            var result = book.GetStatistics();

            // Assert

            Assert.Equal(11.0, result.Average, 1);
            Assert.Equal(12.0, result.Max, 1);
            Assert.Equal(10.0, result.Low, 1);
        }
    }
}
