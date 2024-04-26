using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace ShoppingFE
{
    internal class Program
    {
        //async Task<int> GetResultFromDatabaseServer()
        //{
        //    Thread.Sleep(10000);
        //    return new Random().Next();
        //}

        void print() { 
        
            for(int i=0;i < 10; i++)
            {
                Console.WriteLine("By "+Thread.CurrentThread.Name+" ",i);
            }
        }
        void printThredSafe() {

            lock (this)
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("By " + Thread.CurrentThread.Name + " ", i);
                    Thread.Sleep(1000);
                }
            }
        }
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Program program = new Program();
            //Thread t1 = new Thread(program.print);
            Thread t1 = new Thread(program.printThredSafe);
            t1.Name = "Thread 1";
            //Thread t2 = new Thread(program.print);
            Thread t2 = new Thread(program.printThredSafe);
            t2.Name = "Thread 2";

            t1.Start();
            t2.Start();
            await Console.Out.WriteLineAsync("After the Thread call");
            //var number = program.GetResultFromDatabaseServer();
            //Console.WriteLine("This is the random number from server " + number);
            //Console.WriteLine("This is the random number from main" + new Random().Next());
            ////var number1 = await program.GetResultFromDatabaseServer();
            //Console.WriteLine(number1);
        }
    }

    
}
