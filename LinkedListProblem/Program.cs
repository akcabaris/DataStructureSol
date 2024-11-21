var customLinkedList = new CustomLinkedList<char>("wellcome".ToCharArray());
var customLinkedList2 = new CustomLinkedList<int>(new int[] {1,2,3,3,2,4,5});

// m o c l e w
foreach (var item in customLinkedList)
{
    Console.Write($"{item,-2}");
}
Console.WriteLine();

// 5 4 3 2 1
foreach (var item in customLinkedList2)
{
    Console.Write($"{item,-2}");
}

Console.ReadKey();