using DataStructures.Arrray;

namespace ArrayTest
{
    public class ArrayTest
    {
        //Theory can get parameter but Fact can't get
        [Theory]
        [InlineData(16)]
        [InlineData(32)]
        [InlineData(64)]
        [InlineData(1128)]
        [InlineData(1256)]
        public void Check_Array_Constuctor(int defaultSize)
        {
            //Arrange / act
            var arr = new DataStructures.Arrray.Array(defaultSize);

            Assert.Equal(defaultSize, arr.Length);
        }


        [Fact]
        public void Check_Array_Constructor_with_params()
        {
            var array = new DataStructures.Arrray.Array(10,20,30);

            // Assert
            Assert.Equal(3, array.Length);
        }

        // GetValues, SetValues
        [Fact]
        public void Get_and_Set_Values_in_Array()
        {
            //by default it will be 16 length due to the defaultSize variable
            var array = new DataStructures.Arrray.Array();

            array.SetValue(10,0);
            array.SetValue(20,1);

            Assert.Equal(10, array.GetValue(0));
            Assert.Equal(20, array.GetValue(1));
            Assert.Null(array.GetValue(2));
        }

        //IClonable
        [Fact]
        public void Array_Clone_Test()
        {  
            //arrange
            var array = new DataStructures.Arrray.Array(1, 2, 3);

            //act
            //normally it's return object, we changed the type with "as"
            var clonedArray = array.Clone() as DataStructures.Arrray.Array;

            //Assert
            //Assert.Equal(array, clonedArray);
            Assert.NotNull(clonedArray);
            Assert.Equal(array.Length, clonedArray.Length);

            //They are different object, it can be check with hashcode
            Assert.NotEqual(array.GetHashCode(), clonedArray.GetHashCode());

        }

        //IEnumerable
        [Fact]
        public void Array_Get_Enumerator_Test()
        {
            //Arrange
            var array = new DataStructures.Arrray.Array(10,20,30);

            //act
            string s = "";
            foreach(var item in array)
            {
                s = s + item;
            }

            //Assert
            Assert.Equal("102030", s);
        }

        [Fact]
        public void Array_Remove()
        {
            string[] kelimeler = new string[3]; // Boyutu 3 olan bir string dizisi  
            kelimeler[0] = "Merhaba";   // 0. indeks
            kelimeler[2] = "C#";
            Assert.Null(kelimeler[1]);
            kelimeler[1] = "";// 2. indeks
            Assert.NotNull(kelimeler[1]);
            // 1. indeksi atadık, bu indeks otomatik olarak null değerinde kalır.

        }
    }   
}