using DataStructures.Stack;

string message = "Selam";

// default Stack type will be LinkedListStack you can check out he ctor method
var stackDef = new DataStructures.Stack.Stack<char>();
var linkedListStack = new DataStructures.Stack.Stack<char>(DataStructures.Stack.StackType.LinkedList);
var arrayStack = new DataStructures.Stack.Stack<char>(DataStructures.Stack.StackType.Array);

List<DataStructures.Stack.Stack<char>> list = new List<DataStructures.Stack.Stack<char>>{
    stackDef,
    linkedListStack,
    arrayStack
};

foreach (var item in list)
{
    for (int i = 0; i < message.Length; i++)
    {
        item.Push(message[i]);
    }

    var n = item.Count;

    for (int i = 0; i < n; i++)
    {
        Console.WriteLine(item.Pop());
    }
    Console.WriteLine("**************************************");
}

Console.ReadKey(); 
