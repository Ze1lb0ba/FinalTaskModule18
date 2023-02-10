using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

class Resiver
{
    string _setting;
    List<string> _data;

    public Resiver(Setting setting, UserData user)
    {
        _setting = setting.StorageFolder;
        _data = user.userURLs;
    }

    public async void DownLoad()
    {
        var videos = new YoutubeClient();
        int i = 1;
        foreach (var item in _data)
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine("Скачивание начато, файл {0}/{1}.", i, _data.Count);                
                var streamManifest = await videos.Videos.Streams.GetManifestAsync(item);
                var video = await videos.Videos.GetAsync(item);
                var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
                var title = EnterDataByUser.RemoveInvalidChars(video.Title);
                await videos.Videos.Streams.DownloadAsync(streamInfo, $"{_setting}\\{title}.{streamInfo.Container}");
                Console.WriteLine("Скачивание окончено.");
                Console.WriteLine("");
                i++;
            }
            catch
            {
                Console.WriteLine("Вы указали неверную ссылку на видео.");
                Console.WriteLine("");
                i++;
            }
        }
    }

    public async void Description()
    {
        foreach (var item in _data)
        {
            var videos = new YoutubeClient();
            try
            {
                Console.WriteLine("");
                Console.WriteLine("Отправлен запрос на получение описания к видео.");                
                var video = await videos.Videos.GetAsync(item);
                var title = video.Title;
                Console.WriteLine();
                Console.WriteLine("Описание видео получено.");
                Console.WriteLine(title);
            }
            catch
            {
                Console.WriteLine("");
                Console.WriteLine("Вы указали неверную ссылку на видео.");               
            }
        }
    }

    public async void DownLoadAudio()
    {
        var videos = new YoutubeClient();
        int i = 1;
        foreach (var item in _data)
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine("Скачивание начато, файл {0}/{1}.", i, _data.Count);
                var streamManifest = await videos.Videos.Streams.GetManifestAsync(item);
                var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();
                var video = await videos.Videos.GetAsync(item);
                var title = video.Title;
                await videos.Videos.Streams.DownloadAsync(streamInfo, $"{_setting}\\{title}.{streamInfo.Container}");
                Console.WriteLine("Скачивание аудиодорожки завершено.");
                i++;
            }
            catch
            {
                Console.WriteLine("");
                Console.WriteLine("Вы указали неверную ссылку на видео.");
                i++;
            }
        }
    }
}
