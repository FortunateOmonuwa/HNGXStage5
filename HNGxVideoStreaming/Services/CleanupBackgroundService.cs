using HNGxVideoStreaming.Data;
using HNGxVideoStreaming.Models;

namespace HNGxVideoStreaming.BackgroundServices
{
    public class CleanupBackgroundService : IHostedService, IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private Timer _timer;

        public CleanupBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
           
            _timer = new Timer(Cleanup, null, TimeSpan.Zero, TimeSpan.FromMinutes(30));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            try
            {
                _timer?.Change(Timeout.Infinite, 0);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message} {ex.Source} {ex.InnerException}");
            }
            
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
        private void DeleteTemporaryChunkFiles(UploadContext uploadContext)
        {
            try
            {
                var fileName = uploadContext.UploadKey;
                string tempPath = Path.GetTempPath();
                string newPath = Path.Combine(tempPath, fileName);
                string[] filePaths = Directory.GetFiles(tempPath).Where(p => p.Contains(fileName)).OrderBy(p => Int32.Parse(p.Replace(fileName, "$").Split('$')[1])).ToArray();

            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message} {ex.Source} {ex.InnerException}");
            }

        }

        private void Cleanup(object state)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<VideoSteamApiDbContext>();

                  
                    var thresholdTime = DateTime.UtcNow.AddMinutes(-30);
                    var uploadContextsToDelete = dbContext.UploadContexts
                        .Where(u => u.IsUploading && u.UpdatedDate < thresholdTime)
                        .ToList();

                    foreach (var uploadContext in uploadContextsToDelete)
                    {
                        
                        DeleteTemporaryChunkFiles(uploadContext);

                        
                        dbContext.UploadContexts.Remove(uploadContext);
                    }

                   
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message} {ex.Source} {ex.InnerException}");
            }
            
        }

    
    }
}
