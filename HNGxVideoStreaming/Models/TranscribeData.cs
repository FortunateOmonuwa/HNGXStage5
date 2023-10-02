using System.Text.Json.Serialization;
using TestmeQA.Domain.Common;

namespace HNGxVideoStreaming.Models
{
    public class TranscribeData : BaseEntity
    {
        public string Text { get; set; } = string.Empty;
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public int UploadKeyId { get; set; }

        [JsonIgnore]
        public virtual UploadContext UploadContext { get; set; }
    }
}
