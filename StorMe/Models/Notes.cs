using System;
using System.Collections.Generic;

namespace StorMe.Models
{
    public partial class Notes
    {
        public int NoteId { get; set; }
        public string Label { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
