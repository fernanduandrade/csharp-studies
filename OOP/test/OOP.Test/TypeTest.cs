using System;
using Xunit;

namespace OOP.Test
{
    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTest
    {
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log;
            log = ReturnMessage;
            var result = log("Oi");
            Assert.Equal("Oi", result);
        }

        string ReturnMessage(string message)
        {
            return message;
        }

        [Fact]
        public void TestGetInt()
        {
            int x = GetInt();
            SetInt(ref x);
            Assert.Equal(42, x);
        }

        [Fact]
        public void StringBehavior()
        {
            string name = "Fernando";
            string upper = MakeUpperCase(name);

            Assert.Equal("Fernando", name);
            Assert.Equal("FERNANDO", upper);
        }

        private string MakeUpperCase(string name)
        {
            return name.ToUpper();
        }

        [Fact] 
        public void TestSetBookName()
        {
            InMemoryBook book1 = GetBook("Fernando");
            GetBookSetName(ref book1, "Andrade");

            Assert.Equal("Fernando", book1.Name);
        }
        [Fact]
        public void TestTypeObject()
        {
            InMemoryBook book01 = GetBook("teste");
            InMemoryBook book02 = GetBook("teste02");

            Assert.Equal(typeof(InMemoryBook), book01.GetType());
        }

        [Fact]
        public void TestValueReference()
        {
            InMemoryBook book1 = GetBook("fernnado");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(object.ReferenceEquals(book1, book2));
        }
        public void GetBookSetName(ref InMemoryBook book, string name)
        {
            InMemoryBook bookTest = new InMemoryBook(name);
        }
        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }

        private void SetInt(ref int z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }
    }
}