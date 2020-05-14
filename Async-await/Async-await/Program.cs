using System;
using System.Threading.Tasks;

namespace Async_await
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            await PrintNumbsAsync();
            PrintNumbs();

            Console.WriteLine("Check Async func");
        }

        public async static Task PrintNumbsAsync()
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
