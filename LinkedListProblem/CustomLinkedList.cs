// See https://aka.ms/new-console-template for more information
using System.Collections;

class CustomLinkedList<T> : IEnumerable
{
    private LinkedList<T> list;

    public CustomLinkedList(T[] input)
    {

        list = new LinkedList<T>();
        var hashSet = new HashSet<T>(input);
        var stack = new Stack<T>(hashSet);
        // if we just write stack.Count in the for loop. it's gonna change during the for loop working. that's why it should keep in the variable
        int n = stack.Count;
        for(int i=0; i<n; i++)
        {
            list.AddLast(stack.Pop());
        }
    }

    public IEnumerator GetEnumerator()
    {
        return list.GetEnumerator();
    }
}