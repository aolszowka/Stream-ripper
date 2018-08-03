﻿using System.Collections.ObjectModel;

namespace StreamRipper.Constants
{
    /// <summary>
    /// Pattern constants
    /// </summary>
    public class MetadataPatterns
    {
        public static readonly ReadOnlyCollection<string> MetadataSongPatterns = new ReadOnlyCollection<string>(new[]
        {
            @"StreamTitle='(?<title>[^~]+?) - (?<artist>[^~]+?)'",
            @"StreamTitle='(?<title>.+?)~(?<artist>.+?)~"
        });
    }
}