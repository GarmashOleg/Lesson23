using System;
using System.Threading.Tasks;

namespace Async_await
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PrintNumbsAsync();
            PrintNumbs();

            Console.WriteLine("Check Async func");
        }

        public async static void PrintNumbsAsync()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine($" From async method {i}");
                }
            });
        }

        public static void PrintNumbs()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine($" From usual method {i}");
            }
        }
    }
}
