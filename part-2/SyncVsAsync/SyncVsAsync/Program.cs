// See https://aka.ms/new-console-template for more information
using System.Diagnostics;


static void LongRunningSync()
{
    Console.WriteLine("eşzamanlı işlem başladı");
    Thread.Sleep(3000);
    Console.WriteLine("eşzamanlı işlem bitti");
}

static async Task LongRunningAsync()
{
    Console.WriteLine("asenkron işlem başladı");
    await Task.Delay(3000);
    Console.WriteLine("asenkron işlem bitti.");
}


var stopwatch = Stopwatch.StartNew();
LongRunningSync();
stopwatch.Stop();
Console.WriteLine($"eşzamanlı işlem süresi: {stopwatch.ElapsedMilliseconds} ms\n");

stopwatch.Restart();
await LongRunningAsync();
stopwatch.Stop();
Console.WriteLine($"asenkron işlem süresi: {stopwatch.ElapsedMilliseconds} ms");