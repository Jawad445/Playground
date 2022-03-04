//Work with every type
CalculateAndPrint("this", "that", (x, y) => $"{x} and {y}");
CalculateAndPrint(20.5, 10.3, (x, y) => x + y);
CalculateAndPrint(20, 10, (x, y) => x - y);
CalculateAndPrint(true, false, (x, y) => x && y);

Console.WriteLine("Hello World!");


// Pass delegate into parameter
static void CalculateAndPrint<T>(T x, T y, MathOp<T> f)
{
    var result = f(x, y);
    Console.WriteLine(result);
}

//Generic Implementation of Delegate
delegate T MathOp<T>(T a, T b);