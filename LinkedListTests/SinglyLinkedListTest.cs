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
    }
}