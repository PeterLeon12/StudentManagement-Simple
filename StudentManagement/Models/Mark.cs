using System;

namespace StudentManagement.Models
{
    public class Mark
    {
        public int Value { get; set; }
        public DateTime DateTimeGiven { get; set; }
        public string Subject { get; set; }

        public Mark(int value, string subject)
        {
            Value = value;
            DateTimeGiven = DateTime.Now;
            Subject = subject;
        }
    }
}
