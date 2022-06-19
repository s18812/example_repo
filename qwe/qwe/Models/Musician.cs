using System.Collections.Generic;

namespace qwe.Models
{
    public class Musician
    {
        public int IdMusician { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public virtual ICollection<MusicianTrack> MusiciansTrack { get; set; }

    }
}