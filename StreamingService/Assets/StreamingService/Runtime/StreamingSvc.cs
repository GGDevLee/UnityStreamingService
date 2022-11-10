namespace LeeFramework.Streaming
{
    public class StreamingSvc : StreamingBase<StreamingSvc>
    {
        /// <summary>
        /// 加载文件
        /// </summary>
        public byte[] LoadFile(string path, int offset = 0)
        {
            return _Streaming.LoadFile(path, offset);
        }

        public string LoadText(string path)
        {
            return _Streaming.LoadText(path);
        }

        /// <summary>
        /// 获取路径下全部文件
        /// </summary>
        public string[] GetAllFiles(string path = "")
        {
            return _Streaming.GetAllFiles(path);
        }

        /// <summary>
        /// 根据后缀获取路径下全部文件
        /// </summary>
        public string[] GetAllFilesByExt(string path = "", string searchPattern = "")
        {
            return _Streaming.GetAllFilesByExt(path, searchPattern);
        }

        /// <summary>
        /// 文件是否存在，有后缀的话需要带后缀
        /// </summary>
        public bool FileExists(string path)
        {
            return _Streaming.FileExists(path);
        }

    }
}
