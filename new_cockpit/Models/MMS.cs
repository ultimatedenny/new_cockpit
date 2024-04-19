using new_cockpit.Interface;

namespace new_cockpit.Models
{
    public class MMS : IData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public string Target { get; set; }
    }
}