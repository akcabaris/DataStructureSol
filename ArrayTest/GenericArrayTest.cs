using DataStructures;
using DataStructures.Arrray.Generic;
using System.Collections.Generic;

namespace ArrayTest
{
    public class GenericArrayTest
    {
        private Array<Char> _array;
        public GenericArrayTest()
        {
            _array = new Array<Char>(new List<char> { 's', 'a', 'm', 'u' });
        }

        [Theory]
        [InlineData(16)]
        [InlineData(32)]
        [InlineData(64)]
        [InlineData(128)]
        [InlineData(256)]
        public void DefaultSize_Test(int defaultSize)
        {
            //arrange
            var arr = new Array<Char>(defaultSize);
             
            //assert
            Assert.Equal(defaultSize, arr.Length);
        }

        [Fact]
        public void Params_Test()
        {
            //arrange
            var arr = new Array<int>(1, 2, 3, 4, 5, 6);

            //assert
            Assert.Equal(6, arr.Length);
        }

        [Fact]
        public void GetValue_Test()
        {
            var c = _array.GetValue(0);

            Assert.Equal('s', c);
            Assert.IsType<Char>(c);
            Assert.True(c is char);
            Assert.IsType(typeof(char), c);
        }

        [Theory]
        [InlineData('C')]
        public void SetValue_Test(char character)
        {
            if(_array.GetValue(3) != 'C')
            {
                _array.SetValue(character, 3);

                Assert.Equal(character, _array.GetValue(3));
            }
        }
        [Fact]
        public void Enumerator_Should_Iterate_Over_Added_Items()
        {
            // Arrange
            var array = new DataStructures.Arrray.Generic.Array<int>();
            array.Add(10);
            array.Add(20);
            array.Add(30);

            var expectedItems = new List<int> { 10, 20, 30 };
            var actualItems = new List<int>();

            // Act
            foreach (var item in array)
            {
                actualItems.Add(item);
            }

            // Assert
            Assert.Equal(expectedItems, actualItems);
        }

        [Fact]
        public void Enumerator_Should_Not_Iterate_Over_Unused_Slots()
        {
            var array = new Array<int>(7);

            array.Add(1);
            array.Add(2);

            int count=0;

            foreach(var item in array)
            {
                count++;
            }
            Assert.Equal(2, count);


        }

        [Fact]
        public void Enumerator_Should_Handle_Empty_Array()
        {
            var array = new Array<int>(10);

            Assert.Empty(array);

        }

        [Fact]
        public void Add_Double_Remove_Half_Test()
        {
            var _arr = new Array<int>(8);

            Assert.Equal(8, _arr.Length);

            for(int i=0; i<9; i++)
            {
                _arr.Add(i);
            }
            Assert.Equal(16, _arr.Length);

            for (int i = 0; i < 5; i++)
            {
                _arr.Remove();
            }
            Assert.Equal(8, _arr.Length);
        }

    }
}
