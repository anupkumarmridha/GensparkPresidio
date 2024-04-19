namespace Day_8_OOPS
{
    internal class Program
    {
        void UnderstandingJaggedArray()
        {
            string[][] posts = new string[4][];
            for (int i = 0; i < posts.Length; i++)
            {
                Console.WriteLine("Please enter the number of columns");
                int count = Convert.ToInt32(Console.ReadLine());
                posts[i] = new string[count];
                for (int j = 0; j < count; j++)
                {
                    Console.WriteLine($"Please enter the post {i + 1} value");
                    posts[i][j] = Console.ReadLine();
                }
            }
            Console.WriteLine("Posts");
            for (int i = 0; i < posts.Length; i++)
            {
                for (int j = 0; j < posts[i].Length; j++)
                    Console.Write(posts[i][j] + " ");
                Console.WriteLine("---------------------");
            }
        }
        static void Main(string[] args)
        {
            //var shapes = new List<Shape>
            //{
            //    new Rectangle(),
            //    new Triangle(),
            //    new Circle()
            //};
            //foreach (var shape in shapes)
            //{
            //    shape.Draw();
            //}
            //Student student = new Student() { Name = "Ramu", Id = 101 };
            //student[0] = "C";
            //student[1] = "Java";
            //student[2] = "C#";
            //Console.WriteLine(student);

            Student[] students = new Student[3];
            students[0] = new Student() { Name = "Ramu", Id = 101 };
            students[0][0] = "C";
            students[0][1] = "Java";
            students[0][2] = "C#";
            Console.WriteLine(students[0]["Java"]);
        }
    }
}
