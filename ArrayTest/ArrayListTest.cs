
using DataStructures.Arrray;

namespace ArrayTest
{
    public class ArrayListTest
    {
        private ArrayList _arrayList;

        public ArrayListTest()
        {
            _arrayList = new ArrayList();
        }


        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(16)]
        [InlineData(32)]
        [InlineData(64)]
        public void ArrayList_Constructor_Test(int defaultSize)
        {
            var arrayList = new ArrayList(defaultSize);

            Assert.Equal(defaultSize, arrayList.Length);
        }

        [Fact]
        public void ArrayList_Add_Test()
        {
            for(int i =0; i< 65; i++)
            {
                _arrayList.Add(i);
            }
            Assert.Equal(128, _arrayList.Length);
        }

        [Theory]
        [InlineData(32)]
        [InlineData(64)]
        [InlineData(128)]
        [InlineData(256)]
        public void ArrayList_Remove_Test(int len)
        {
            for(int i =0; i < len; i++)
            {
                _arrayList.Add(i);
            }
            Assert.Equal(len, _arrayList.Length);

            for(int i= _arrayList.Length; i>4; i--)
            {
                _arrayList.Remove();
            }
            Assert.Equal(8, _arrayList.Length);
        }

        [Fact]
        public void ForEach_Test()
        {
            _arrayList.Add("a");
            _arrayList.Add("b");
            _arrayList.Add("c");
            _arrayList.Add("d");

            _arrayList.Remove();

            string s = "";
            foreach(var item in _arrayList)
            {
                s += item;
            }



            Assert.Equal("abc", s);

        }

        [Fact]
        public void ArrayList_Constructor_With_IEnumerable_Test()
        {
            //arrange
            var list = new List<int> { 1, 2, 3 };

            //act
            var _arr = new ArrayList(list);

            string s = "";

            foreach(var item in _arr)
            {
                s = s+ item;
            }

            //Assert
            Assert.Equal("123", s);
        }

        [Fact]
        public void IndexOf_Test()
        {
            //arrange
            _arrayList.Add("a");
            _arrayList.Add("b");
            _arrayList.Add("c");

            //act
            var result = _arrayList.IndexOf("c");

            Assert.Equal(2, result);
        }
    }
}
