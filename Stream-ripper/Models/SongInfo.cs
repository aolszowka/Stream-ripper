﻿using System.IO;

namespace StreamRipper.Models
{
    public class SongInfo
    {
        public SongMetadata SongMetadata { get; set; }
        
        public MemoryStream Stream { get; set; }
    }
}