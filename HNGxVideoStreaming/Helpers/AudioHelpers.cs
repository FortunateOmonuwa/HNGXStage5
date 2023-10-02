using NAudio.Wave;

namespace HNGxVideoStreaming.Helpers
{
    public static class AudioHelpers
    {
        public static void ExtractAudioFromVideo(string videoFilePath, string audioOutputPath)
        {
            try
            {
                using (var reader = new MediaFoundationReader(videoFilePath))
                {
                    var pcmStream = WaveFormatConversionStream.CreatePcmStream(reader); // 16 kHz, 16-bit, mono
                    WaveFileWriter.CreateWaveFile(audioOutputPath, pcmStream);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message} {ex.Source} {ex.InnerException}");
            }
        }
        public static async Task<string> ConvertMp3ToWave(string mp3, string wav)
        {
            try
            {
                using (var reader = new AudioFileReader(mp3))
                {
                    using var resampler = new MediaFoundationResampler(reader, new WaveFormat(16000, reader.WaveFormat.Channels));
                    await Task.Run(() =>
                    {
                        WaveFileWriter.CreateWaveFile(wav, resampler);
                    });
                }
                return wav;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message} {ex.Source} {ex.InnerException}");
            }
        }
        public static string ChangeExtensionToMp3(string val) => Path.ChangeExtension(val, "mp3");

        public static string ChangeExtensionToWAV(string val) => Path.ChangeExtension(val, "wav");
     
    }
}
