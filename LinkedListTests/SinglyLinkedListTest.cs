using DataStructures.LinkedList.SinglyLinkedList;

namespace LinkedListTests
{
    public class SinglyLinkedListTest
    {
        private SinglyLinkedList<int> _list;


        public SinglyLinkedListTest()
        {
            // 8 => 6 because that's how AddFirst work
            _list = new SinglyLinkedList<int>(new int[] {6,8});
        }        


        [Fact]
        public void Count_Test()
        {
            _list.AddFirst(1);

            Assert.Equal(3, _list.Count);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(376537)]
        public void AddFirst_Test(int value)
        {
            _list.AddFirst(value);

            Assert.Equal(value, _list.Head.Value);
            Assert.Collection(_list,
                item => Assert.Equal(item, value),
                item => Assert.Equal(item, 8),
                item => Assert.Equal(item, 6)
                );
        }

        [Fact]
        public void GetEnumerator_Test()
        {
            Assert.Collection(_list,
                item => Assert.Equal(item, 8),
                item => Assert.Equal(item, 6)
                );
        }

        [Fact]
        public void AddLastTest()
        {
            _list.AddLast(4);

            Assert.Collection(_list,
                item => Assert.Equal(item, 8),
                item => Assert.Equal(item, 6),
                item => Assert.Equal(item, 4)
                );
        }
         
        [Theory]
        [InlineData(60)]
        [InlineData(6)]
        [InlineData(10)]
        [InlineData(15)]
        [InlineData(1)]
        [InlineData(9)]
        public void AddBefore_Test(int value)
        {
            _list.AddBefore(_list.Head.Next,value);

            Assert.Collection(_list,
                item => Assert.Equal(8, item),
                item => Assert.Equal(value, item),
                item => Assert.Equal(6, item)
                );
        }


        [Fact]
        public void AddBefeore_ArgumentException_Test()
        {
            // Arrange
            var node = new SinglyLinkedListNode<int>(55);

            //Assert
            Assert.Throws<ArgumentException>(() => _list.AddBefore(node, 25));

        }

        [Theory]
        [InlineData(60)]
        [InlineData(6)]
        [InlineData(10)]
        [InlineData(15)]
        [InlineData(1)]
        [InlineData(9)]
        public void AddAfter_Test(int value)
        {
            _list.AddAfter(_list.Head, value);

            Assert.Collection(_list,
                item => Assert.Equal(8, item),
                item => Assert.Equal(value, item),
                item => Assert.Equal(6, item)
                );
        }

        [Fact]
        public void AddAfter_ArgumentException_Test()
        {
            var node = new SinglyLinkedListNode<int>(51);

            Assert.Throws<ArgumentException>(() => _list.AddAfter(node,55));
        }

        [Fact]
        public void RemoveFirst_Test()
        {
            // 8 6
            _list.RemoveFirst();

            Assert.Collection(_list, item => Assert.Equal(6, item));
        }

        [Fact]
        public void RemoveFirst_Exception_Test()
        {
            _list.RemoveFirst();
            _list.RemoveFirst();

            Assert.Throws<Exception>(() => _list.RemoveFirst());
        }
    }
}