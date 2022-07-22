using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_TDPC.Models
{
    public class MusicModel
    {
        public List<SongAndArtistModel> Songs { get; set; } = new List<SongAndArtistModel>();

        public class SongAndArtistModel
        {
            public string SongName { get; set; }
            public string ArtistName { get; set; }
        }
    }
}
