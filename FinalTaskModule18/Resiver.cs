using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

class Resiver
{
    string _setting;
    string _data;

    public Resiver(Setting setting, UserData user)
    {
        _setting = setting.StorageFolder;
        _data = user.URLOfVideo;
    }

    public async void DownLoad()
    {
        try
        {
            Console.WriteLine("Скачивание начато.");
            var videos = new YoutubeClient();
            var streamManifest = await videos.Videos.Streams.GetManifestAsync(_data);
            var video = await videos.Videos.GetAsync(_data);
            var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
            var title = video.Title;
            await videos.Videos.Streams.DownloadAsync(streamInfo, $"{_setting}\\{title}.{streamInfo.Container}");
            Console.WriteLine("Скачивание окончено.");
        }
        catch
        {
            Console.WriteLine("Вы указали неверную ссылку на видео.");
            EnterDataByUser.URLSet();
        }
    }

    public async void Description()
    {
        try
        {
            Console.WriteLine("Отправлен запрос на получение описания к видео.");
            var videos = new YoutubeClient();
            var video = await videos.Videos.GetAsync(_data);
            var title = video.Title;
            Console.WriteLine();
            Console.WriteLine("Описание видео получено.");
            Console.WriteLine(title);
        }
        catch
        {
            Console.WriteLine("Вы указали неверную ссылку на видео.");
            EnterDataByUser.URLSet();
        }
    }

    public async void DownLoadAudio()
    {
        try
        {
            Console.WriteLine("Скачивание аудиодорожки начато.");
            var videos = new YoutubeClient();
            var streamManifest = await videos.Videos.Streams.GetManifestAsync(_data);
            var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();
            var video = await videos.Videos.GetAsync(_data);
            var title = video.Title;
            await videos.Videos.Streams.DownloadAsync(streamInfo, $"{_setting}\\{title}.{streamInfo.Container}");
            Console.WriteLine("Скачивание аудиодорожки завершено.");
        }
        catch
        {
            Console.WriteLine("Вы указали неверную ссылку на видео.");
            EnterDataByUser.URLSet();
        }
    }
}
