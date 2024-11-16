namespace ValueAndReferenceTypes
{
    public struct ValueType
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void Swap(int a, int b)
        {
            var temp = a;
            a = b; b = temp;
        }
    
    }
}
