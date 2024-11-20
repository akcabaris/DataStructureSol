using LinkedList.DoublyLinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListTests
{
    public class DoublyLinkedListTests
    {
        private DoublyLinkedList<char> _list;

        public DoublyLinkedListTests()
        {
            _list = new DoublyLinkedList<char>(new char[] { 'a', 'z' });
        }

        [Theory]
        [InlineData('f')]
        [InlineData('e')]
        [InlineData('r')]
        public void AddFirst_Test(char value)
        {
            _list.AddFirst(value);

            Assert.Equal(value, _list.Head.Value);
            Assert.Equal('z', _list.Tail.Value);

            /*
             // not gonna work beacuse getEnumerator method isn't implemented.
            Assert.Collection(_list,
                item => Assert.Equal(value, item),
                );
               
            */
        }
        [Theory]
        [InlineData('f')]
        public void AddLast(char value)
        {
            _list.AddLast(value);

            Assert.Equal(value, _list.Tail.Value);

            Assert.Collection(_list,
                item => Assert.Equal('a', item), // O(1)
                item => Assert.Equal('z', item), // O(n) 
                item => Assert.Equal(value, item) // O(1)
                );

        }
        [Theory]
        [InlineData('f')]
        public void AddBefore_Test(char value)
        {
            _list.AddBefore(_list.Head.Next, value);

            Assert.Equal(value, _list.Head.Next.Value);

            Assert.Collection(_list,
                item => Assert.Equal('a', item),
                item => Assert.Equal(value, item),
                item => Assert.Equal('z', item)
                );

        }
        [Theory]
        [InlineData('f')]
        public void AddAfter_Test(char value)
        {
            //a,value,z
            _list.AddAfter(_list.Head, value);

            Assert.Equal(value, _list.Head.Next.Value);

            Assert.Collection(_list,
                item => Assert.Equal(item, _list.Head.Value),
                item => Assert.Equal(item, value),
                item => Assert.Equal(item,_list.Head.Next.Next.Value)
                );

        }
        [Fact]
        public void Count_Test()
        {
            var count = _list.Count;

            Assert.Equal(2, count);
        }

        [Fact]
        public void RemoveFirst_Test()
        {
            // a,z  => z
            _list.RemoveFirst();

            Assert.Collection(_list, item => Assert.Equal(item, 'z'));
        }

        [Fact]
        public void RemoveLast_Exception_Test()
        {
            // a,z  => z
            var r1 = _list.RemoveLast();
            var r2 = _list.RemoveLast();


            Assert.Equal(r1, 'z');
            Assert.Equal(r2, 'a');
            Assert.Throws<Exception>(() => _list.RemoveLast());
        }


        [Fact]
        public void ToList_Test()
        {
            var list = _list.ToList();

            Assert.Collection(list,
                item => Assert.Equal(item, _list.Head.Value),
                item => Assert.Equal(item, _list.Head.Next.Value)
                );
        }


    }
}
