using System;
using System.Collections.Generic;
using System.Linq;

var result = GenerateNumbers(10).Where(n => {
                                        return n%2 == 0;
                                    }).Select(n => {
                                            return n * 3; 
                                    });

foreach(var item in result)
{
    Console.WriteLine(item);
}

//Good approach
IEnumerable<int> GenerateNumbers(int maxval)
{
    for(int i=0; i <= maxval; i++)
    {
        yield return i;
    }
}


//Bad way of writing code
// IEnumerable<int> GenerateNumbers(int maxval)
// {
//     var result = new List<int>();
//     for(int i=0; i <= maxval; i++)
//     {
//         result.Add(i);
//     }

//     return result;
// }
