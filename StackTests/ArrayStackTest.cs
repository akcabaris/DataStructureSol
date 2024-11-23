using DataStructures.Stack.Contracts;

namespace StackTests
{
    public class ArrayStackTest
    {
        private readonly IStack<char> _stack;

        public ArrayStackTest()
        {
            _stack = new DataStructures.Stack.ArrayStack<char>(new char[] {'s','e','l','a','m'});

        }

        [Fact]
        public void  Count_Test()
        {
            //act
            var count = _stack.Count;

            Assert.Equal(5, count);
        }

        [Fact]
        public void Pop_Test()
        {
            var pop = _stack.Pop();

            Assert.Equal('m', pop);

        }

        [Theory]
        [InlineData('m')]
        [InlineData('e')]
        [InlineData('r')]
        [InlineData('h')]
        [InlineData('a')]
        [InlineData('b')]
        [InlineData('a')]
        public void PushTest(char value)
        {
            _stack.Push(value);

            Assert.Equal(value, _stack.Peek());
        }
    }
}