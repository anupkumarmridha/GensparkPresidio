using SampleEFApp.Model;

namespace SampleEFApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            dbEmployeeTrackerContext context = new dbEmployeeTrackerContext();
            Area area = new Area();
            area.Area1 = "POPO";
            area.Zipcode = "44332";
            context.Areas.Add(area);
            context.SaveChanges();
            var areas = context.Areas.ToList();
            
            area = areas.SingleOrDefault(a => a.Area1 == "POPO");
            area.Zipcode = "00000";
            context.Areas.Update(area);
            context.SaveChanges();

            area = areas.SingleOrDefault(a => a.Area1 == "POPO");
            context.Areas.Remove(area);
            context.SaveChanges();
            areas = context.Areas.ToList();
            foreach (var a in areas)
            {
                Console.WriteLine(a.Area1 + " " + a.Zipcode);
            }

        }
    }
}
