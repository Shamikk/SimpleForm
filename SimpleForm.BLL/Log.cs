using System;

namespace SimpleForm.BLL
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime ActionDateTime { get; set; }
        public User User { get; set; }
        public string Action { get; set; }
    }
}
