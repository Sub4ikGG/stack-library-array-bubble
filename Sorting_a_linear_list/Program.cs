using StackUtils;

class Program
{
    static void Main(string[] args)
    {
        for (int i = 300; i <= 3000; i += 300)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            Stack<int> stack = new Stack<int>();
            SUtils.FillByRandom(ref stack, i); // Заполняем ранд. значениями

            SUtils.Sort(ref stack); // Сортируем stack

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            Console.WriteLine($"Кол-во эл.: {i} Время сортировки: {elapsedMs} Количество операций: {SUtils.GetNOP()}");
            SUtils.ClearNOP();
        }
    }

}