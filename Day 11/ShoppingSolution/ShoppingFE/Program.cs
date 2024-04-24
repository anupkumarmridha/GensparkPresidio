namespace ShoppingFE
{
    internal class Program
    {
        //public delegate int calcDel(int n1, int n2);//creating a type that refferes to a method
        //void Calculate(calcDel cal)
        //{
        //    int n1 = 10, n2 = 20;
        //    int result = cal(n1, n2);
        //    Console.WriteLine($"The sum of {n1} and {n2} is {result}");
        //}
        //public int Add(int num1, int num2)
        //{
        //    return (num1 + num2);
        //}
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello, World!");
        //    Program program = new Program();
        //    calcDel c1 = new calcDel(program.Add);
        //    program.Calculate(c1);

        //}

        //public delegate int calcDel(int n1, int n2);//creating a type that refferes to a method
        //public delegate float calcDelFloat(float n1, float n2);//creating a type that refferes to a method
        public delegate T calcDel<T>(T n1, T n2);//creating a generic  type that refferes to a method
        void Calculate(calcDel<int> cal, int n1, int n2)
        {

            int result = cal(n1, n2);
            Console.WriteLine($"The sum of {n1} and {n2} is {result}");
        }
        void Calculate(Func<int, int, int> cal)
        {
            int n1 = 10, n2 = 20;
            int result = cal(n1, n2);
            Console.WriteLine($"The sum of {n1} and {n2} is {result}");
        }
        //public int Add(int num1, int num2)
        //{
        //    return (num1 + num2);
        //}
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Program program = new Program();
            //calcDel c1 = new calcDel(program.Add);
            //calcDel<int> c1 = new calcDel<int>(program.Add);//Generic type instantiation
            //calcDel<int> c1 = delegate (int num1, int num2)//You can do if you are alwayts going to use teh ref to use the method
            //{
            //    return (num1 + num2);
            //};
            int n1 = 10, n2 = 20;
            calcDel<int> c1 = (int num1, int num2) => (num1 + num2);
            program.Calculate(c1, n1, n2);

            Func<int, int, int> c2=(num1, num2)=> (num1 + num2);
            program.Calculate(c2);

            int[] numbers = { 89, 78, 23, 546, 787, 98, 11, 3 };
            //select * from numbers where num>80
            // var another = from n in numbers where n > 80 select n;
            var another = numbers.Where(n => n > 80);
            foreach (int n in another)
                Console.WriteLine(n);

        }
    }
}
