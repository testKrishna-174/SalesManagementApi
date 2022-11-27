using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement_API.Models
{
    public class FileUpload
    {
		public long FileId { get; set; }
		public string FileName { get; set; }
		public string LocalFilePath { get; set; }
		public DateTime UploadedOn { get; set; }
		public long UploadedBy { get; set; }
		public bool IsProcessed { get; set; }
		public string ErrorMessage { get; set; }
		public List<FileUploadStaging> stagingFileDetails { get; set; }
	}
}
