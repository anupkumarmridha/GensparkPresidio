using System.Text;

namespace MovieBookingModelLibery
{
    public class Movie
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Genre { get; private set; }
        public int Duration { get; private set; }
        private List<Screening> _screenings;

        public IReadOnlyList<Screening> Screenings => _screenings;

        public Movie(string title, string genre, int duration)
        {
            Id = 0;
            Title = title;
            Genre = genre;
            Duration = duration;
            _screenings = new List<Screening>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Movie ID: {Id}");
            sb.AppendLine($"Title: {Title}");
            sb.AppendLine($"Genre: {Genre}");
            sb.AppendLine($"Duration: {Duration} minutes");

            if (Screenings.Count > 0)
            {
                sb.AppendLine("Screenings:");
                foreach (var screening in Screenings)
                {
                    sb.AppendLine($"- Start Time: {screening.StartTime}, Available Seats: {screening.AvailableSeats}");
                }
            }
            else
            {
                sb.AppendLine("No screenings available.");
            }

            return sb.ToString();
        }

        public void AddScreening(Screening screening)
        {
            _screenings.Add(screening);
        }
        public void SetTitle(string title)
        {
            Title = title;
        }

        public void SetGenre(string genre)
        {
            Genre = genre;
        }

        public void SetDuration(int duration)
        {
            Duration = duration;
        }
        public void SetId(int id)
        {
            Id = id;
        }
    }
}
