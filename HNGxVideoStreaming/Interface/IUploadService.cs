using HNGxVideoStreaming.Models;

namespace HNGxVideoStreaming.Interface
{
    public interface IUploadService
    {
        public Task<Response> UploadChunks(string uploadKeya);
        public Task<Response> UploadComplete(string uploadKey);
        public Task<Response> DeleteVideo(string uploadKey);
        public Task<Response> StartUpload(string fileName);
        public Task<Response> StreamVideo(string uploadKey);
        public Task<Response> GetAll();
    }
}
