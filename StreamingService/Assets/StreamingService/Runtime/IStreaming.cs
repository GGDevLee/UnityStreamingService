namespace LeeFramework.Streaming
{
    public interface IStreaming
    {
        void Init();

        bool FileExists(string path, bool isRefresh = false);

        string[] GetAllFiles(string path = "");

        string[] GetAllFilesByExt(string searchPattern, string path = "");

        byte[] LoadFile(string path, int offset = 0);

        string LoadText(string path);
    }
}
