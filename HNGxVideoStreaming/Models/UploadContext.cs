using System.ComponentModel.DataAnnotations;
using TestmeQA.Domain.Common;

namespace HNGxVideoStreaming.Models
{
    public class UploadContext : BaseEntity
    {
        public string UploadKey { get; set; }
        public string FileName { get; set; }
        public int CurrentId { get; set; }
        public bool IsUploading { get; set; } = false;
        public virtual ICollection<TranscribeData> TranscribedData { get; set; }
    }
}
