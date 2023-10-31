using System;

namespace AguasApp.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
