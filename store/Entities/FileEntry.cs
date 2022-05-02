using System;
using System.Collections.Generic;

namespace store.demoentities
{
    public partial class FileEntry
    {
        public string Id { get; set; } = null!;
        public string? FileName { get; set; }
        public int? Size { get; set; }
        public DateTime? UploadedTime { get; set; }
        public string? FileLocation { get; set; }
        public string? RootFolder { get; set; }
    }
}
