using ValueAndReferenceTypes;
using ValueType = ValueAndReferenceTypes.ValueType;

namespace ValueAndReferenceTypesTests
{
    public class ValAndRefTypesTest
    {
        // Fact ifadesi test metot'u oldu?unu gösterir
        [Fact]
        public void RefTypeTest()
        {
            //Arrange
            var p1 = new RefType() { 
                X = 10,
                Y= 20
            };
            var p2 = p1;
            var p3 = new RefType()
            {
                X = 30,
                Y = 20
            };

            //Act
            p1.X = 30;
            //Assert
            Assert.Equal(p1.X, p2.X);
            Assert.NotEqual(p1,p3);

        }
        [Fact]
        public void ValueTypeTest()
        {
            //Arrange
            var p1 = new ValueAndReferenceTypes.ValueType()
            {
                X = 10,
                Y = 20
            };
            var p2 = p1;

            //Act
            p1.X = 300;
            //Assert
            Assert.NotEqual(p1.X, p2.X);

        }

        [Fact]
        public void RecordTypeTest()
        {
            //arrange
            var p1 = new RecordType()
            {
                X = 10,
                Y = 20
            };

            var p2 = new RecordType()
            {
                X = 10,
                Y = 20
            };

            //Record value's can't change expect "with"
            //act
            var p3 = p2 with { X = 20 };

            //assert
            Assert.Equal(p1, p2);
            Assert.NotEqual(p2, p3);
        }

        [Fact]
        public void SwapByValTest()
        {
            //arrange
            int a = 10; int b = 25;

            // it's struct type, not the class, class type will be reference, bottom of this test
            ValueAndReferenceTypes.ValueType valIns = new ValueAndReferenceTypes.ValueType();

            //act
            valIns.Swap(a, b);

            //assert
            Assert.Equal(10,a);
            Assert.Equal(25,b);
            //it didn't swapped because they are value type, not the reference
        }

        [Fact]
        public void SwapByRef()
        {
            //arrange
            int a = 10; int b = 25;
            RefType refInst = new RefType();

            //act
            refInst.Swap(ref a, ref b);
            //assert
            Assert.Equal(25, a);
            Assert.Equal(10, b);
        }

        [Fact]
        public void CheckOutKeyword()
        {
            //arrange
            RefType instance = new RefType();
            int z = 11;
            //act
            instance.CheckOut(out z);
            //assert
            Assert.Equal(500, z);
        }
    }
}