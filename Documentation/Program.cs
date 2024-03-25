using System.Diagnostics;
using Documentation;

DesserializarPessoas desserializarPessoas = new DesserializarPessoas();
desserializarPessoas.Dessesrializar();
Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();
foreach(int number in GenerateNumber())
{
    Console.WriteLine(number);
}

IEnumerable<int> GenerateNumber()
{
    for(int i = 0; i < 500000; i++)
    {
        if(i%2 == 0)
        yield return i;      
    }
}
stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);


