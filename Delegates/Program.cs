Console.WriteLine("Hello, World!");

MathOp func = Add;
Console.WriteLine(func(10, 12));
func = Subtract;
Console.WriteLine(func(10, 8));

// Pass methord as a parameter
CalculateAndPrint(12, 2, Add); //Subtract
            
//Inline function pass
CalculateAndPrint(12, 2, (x, y) => x-y );


static int Add(int a, int b) => a + b;
static int Subtract(int a, int b) => a - b;

        // Pass delegate into parameter
static void CalculateAndPrint(int x, int y, MathOp f)
{
    var result = f(x, y);
    Console.WriteLine(result);
}

//Basic Implementation of Delegate
delegate int MathOp(int a, int b);