using System;

namespace ej_filters.api.Models
{
    public class Response
    {
        public object Content { get; set; }
        public int Time { get; set; }
        public DateTime Date { get; set; }
        public Response() { }
    }
}