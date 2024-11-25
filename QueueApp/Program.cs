// it's System.Queue
//var _queue = new Queue<ToDo>();

using DataStructures.Queue;

var _queue = new ArrayQueue<ToDo>();
//var _queue = new Queue<ToDo>();
_queue.Enqueue(new ToDo()
{
    Time = 2,
    Describe = "go to somewhere."
});

var fqueue = Array.CreateInstance(typeof(ToDo), 25);

_queue.Enqueue(new ToDo()
{
    Time = 1,
    Describe = "eat food."
});

_queue.Enqueue(new ToDo()
{
    Time = 3,
    Describe = "go to exam."
});

var result = _queue.Dequeue();

Console.WriteLine(result + " --- Done");

Console.WriteLine("Foreach------------------");

foreach (var item in _queue)
{
    Console.WriteLine(item);
}

Console.ReadKey();
