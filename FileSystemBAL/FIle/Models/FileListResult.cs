using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemBAL.FIle.Models
{
    public class FileListResult
    {
        public int inRecordCount { get; set; }
        public int inRownumber { get; set; }
        public int inStoreFileDetailsId { get; set; }
        public Guid unStoreFileDetailsId { get; set; }
        public string stFileName { get; set; }

    }
}
