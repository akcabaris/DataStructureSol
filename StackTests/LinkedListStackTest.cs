using DataStructures.Stack.Contracts;

namespace StackTests
{
    public class LinkedListStackTest
    {
        private readonly IStack<char> _stack;


        public LinkedListStackTest()
        {
            _stack = new DataStructures.Stack.LinkedListStack<char>(new char[] {'s','e','l','a','m'});
        }

        [Fact]
        public void Count_Test()
        {
            var count = _stack.Count;
            Assert.Equal(5, count);
        }

        [Fact]
        public void Pop_Test()
        {
            var pop = _stack.Pop();

            Assert.Equal('m', pop);

            Assert.Collection(_stack,
                item => Assert.Equal(item, 'a'),
                item => Assert.Equal(item, 'l'),
                item => Assert.Equal(item, 'e'),
                item => Assert.Equal(item, 's')
                );
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
