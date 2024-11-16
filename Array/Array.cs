using System.Collections;

namespace DataStructures.Arrray
{
    public class Array : ICloneable, IEnumerable
    {
        protected Object[] InnerArray { get; set; }

        // it's readonly
        public int Length => InnerArray.Length;
        public Array(int defaultSize=16)
        {
            InnerArray = new object[defaultSize]; //fixed size
        }

        // this(sourceArray.Length) gonna call the constructor method  
        public Array(params Object[] sourceArray) : this(sourceArray.Length)
        {
            /*
            for(int i = 0; i<sourceArray.Length; i++)
            {
                InnerArray[i] = sourceArray[i];
            }
            */
            System.Array.Copy(sourceArray, InnerArray, sourceArray.Length);

        }

        public Object GetValue(int index)
        {
            // same !(index >= 0 && index < InnerArray.Length)
            if(index<0 || index >= InnerArray.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            return InnerArray[index];

        }

        public virtual void SetValue(Object value, int index)
        {
            if(index<0 || index >=  InnerArray.Length) 
                throw new ArgumentOutOfRangeException();
            if(value == null) 
                throw new ArgumentNullException();

            InnerArray[index] = value;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
        
        public IEnumerator GetEnumerator()
        {
            return InnerArray.GetEnumerator();
        }
        
        /*
        public IEnumerator GetEnumerator()
        {
            return new CustomArrayEnumerator(InnerArray);
        }
        */
    }
}
