

using ValueAndReferenceTypes;

var p1 = new RefType();

p1.X = 10; p1.Y = 20;

var p2 = p1;
p2.X = 30;

// i write ValueAndReferenceTypes.ValueType because of it's confusing with the System.ValueType
var p3 = new ValueAndReferenceTypes.ValueType();
p3.X = 10; p3.Y = 20;
var p4 = p3;

Console.WriteLine($"P1: {p1.X} {p1.Y} ");
Console.WriteLine($"P1: {p2.X} {p2.Y} ");

Console.WriteLine($"P1: {p3.X} {p3.Y} ");
Console.WriteLine($"P1: {p4.X} {p4.Y} ");
Console.ReadKey();
