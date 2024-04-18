namespace Day_8_OOPS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var shapes = new List<Shape>
{
                new Rectangle(),
                new Triangle(),
                new Circle()
            };
            foreach (var shape in shapes)
            {
                shape.Draw();
            }
        }
    }
}
