using System;

namespace ClassStructures
{
    public class NameChangeEventArgs : EventArgs
    {
        public string OldFirstName { get; set; }
        public string OldLastName { get; set; }
        public string NewFirstName { get; set; }
        public string NewLastName { get; set; }
    }
}