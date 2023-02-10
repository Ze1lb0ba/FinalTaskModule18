class DownLoadComand : IComand
{
    Resiver resiver;
    public DownLoadComand(Resiver r)
    {
        resiver = r;
    }

    public void DownLoadVideo()
    {
        resiver.DownLoad();
    }

    public void ShowDescription()
    {
        resiver.Description();
    }

    public void DownLoadAudioFile()
    {
        resiver.DownLoadAudio();
    }
}
