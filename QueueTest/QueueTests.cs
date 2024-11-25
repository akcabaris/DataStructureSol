using DataStructures.Queue;

namespace QueueTest
{
    public class QueueTests
    {
        private ArrayQueue<int> _queue;

        public QueueTests()
        {
            _queue = new ArrayQueue<int>(new int[] {10,20,30} );
        }


        [Fact]
         public void Count_Test()
        {
            var result = _queue.Count();

            Assert.Equal(3, result );

        }

        [Theory]
        [InlineData(23)]
        [InlineData(44)]
        [InlineData(66)]
        [InlineData(61)]
        [InlineData(55)]
        public void Enqueue(int value)
        {
            _queue.Enqueue(value);

            Assert.Equal(4, _queue.Count);

            Assert.Collection(_queue,
                            item => Assert.Equal(10, item),
                            item => Assert.Equal(20, item),
                            item => Assert.Equal(30, item),
                            item => Assert.Equal(value, item)
            );
        }

        [Fact]
        public void Dequeue()
        {
            //_queue => 10,20,30

            var result = _queue.Dequeue();

            Assert.Equal(10, result);
            Assert.Equal(2, _queue.Count);
            Assert.Collection(_queue,
                item => Assert.Equal(20, item),
                item => Assert.Equal(30, item)
                );
        }

        [Fact]
        public void Peek_Test()
        {

            // 10,20,30
            var peek = _queue.Peek();

            Assert.Equal(10, peek);

        }

        [Fact]
        public void Dequeue_EmptyQueueException_test()
        {
            _queue.Dequeue();
            _queue.Dequeue();
            _queue.Dequeue();

                          
            Assert.Throws<EmptyQueueException>(() => _queue.Dequeue());
        }
    }
}