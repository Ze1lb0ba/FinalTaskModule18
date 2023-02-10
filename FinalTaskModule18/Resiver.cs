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
        foreach (var item in _data)
        {
            try
            {
                Console.WriteLine("Скачивание начато.");
                var videos = new YoutubeClient();
                var streamManifest = await videos.Videos.Streams.GetManifestAsync(item);
                var video = await videos.Videos.GetAsync(item);
                var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
                var title = video.Title;
                await videos.Videos.Streams.DownloadAsync(streamInfo, $"{_setting}\\{title}.{streamInfo.Container}");
                Console.WriteLine("Скачивание окончено.");
                _data.Remove(item);
            }
            catch
            {
                Console.WriteLine("Вы указали неверную ссылку на видео.");
                EnterDataByUser.URLSet();
            }
        }
    }

    public async void Description()
    {
        foreach (var item in _data)
        {
            try
            {
                Console.WriteLine("Отправлен запрос на получение описания к видео.");
                var videos = new YoutubeClient();
                var video = await videos.Videos.GetAsync(item);
                var title = video.Title;
                Console.WriteLine();
                Console.WriteLine("Описание видео получено.");
                Console.WriteLine(title);
                _data.Remove(item);
            }
            catch
            {
                Console.WriteLine("Вы указали неверную ссылку на видео.");
                EnterDataByUser.URLSet();
            }
        }
    }

    public async void DownLoadAudio()
    {
        foreach (var item in _data)
        {
            try
            {
                Console.WriteLine("Скачивание аудиодорожки начато.");
                var videos = new YoutubeClient();
                var streamManifest = await videos.Videos.Streams.GetManifestAsync(item);
                var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();
                var video = await videos.Videos.GetAsync(item);
                var title = video.Title;
                await videos.Videos.Streams.DownloadAsync(streamInfo, $"{_setting}\\{title}.{streamInfo.Container}");
                Console.WriteLine("Скачивание аудиодорожки завершено.");
                _data.Remove(item);
            }
            catch
            {
                Console.WriteLine("Вы указали неверную ссылку на видео.");
                EnterDataByUser.URLSet();
            }
        }
    }
}
