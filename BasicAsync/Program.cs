/* Tasks :
    The Task class represents a single operation that does not return a value and that usually executes asynchronously.
    Task object typically executes asynchronously on a thread pool thread rather than synchronously on the main application thread.
*/
using System.IO;

//Old Way of writing syncrionus
// Make sure main thread is not exit until task completed
// File.ReadAllLinesAsync("data.txt")
//             .ContinueWith(t => {
//                 if(t.IsFaulted){
//                     Console.Error.WriteLine(t.Exception);
//                     return;
//                 }
//                     foreach(var item in  t.Result)
//                     {
//                         Console.WriteLine(item);
//                     }            
//             });

//New way of writing async
async Task ReadFile(){
    var lines =  await File.ReadAllLinesAsync("data.txt");

    foreach(var item in lines){
        Console.WriteLine(item);
    }
}

await ReadFile();

Console.ReadKey();