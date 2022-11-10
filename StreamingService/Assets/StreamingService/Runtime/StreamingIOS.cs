using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace LeeFramework.Streaming
{
    public class StreamingIOS : IStreaming
    {
        public string rootPath => Application.streamingAssetsPath;

        public void Init()
        {
        }

        public bool FileExists(string path, bool isRefresh = false)
        {
            return File.Exists(Application.streamingAssetsPath + "/" + path);
        }

        public string[] GetAllFiles(string path = "")
        {
            List<string> allFiles = new List<string>();
            SearchAllFiles(allFiles, Application.streamingAssetsPath + "/" + path);
            return allFiles.ToArray();
        }

        public string[] GetAllFilesByExt(string searchPattern, string path = "")
        {
            List<string> allFiles = new List<string>();
            SearchAllFilesByExt(allFiles, Application.streamingAssetsPath + "/" + path, searchPattern);
            return allFiles.ToArray();
        }

        public byte[] LoadFile(string path, int offset = 0)
        {
            byte[] data = null;
            using (FileStream fs = File.OpenRead(Application.streamingAssetsPath + "/" + path))
            {
                long len = fs.Length;
                data = new byte[len];
                fs.Seek(offset, SeekOrigin.Begin);
                fs.Read(data, 0, (int)len - offset);
            }

            return data;
        }

        public string LoadText(string path)
        {
            string allStr = string.Empty;
            using (FileStream fs = File.OpenRead(Application.streamingAssetsPath + "/" + path))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    allStr = reader.ReadToEnd();
                }
            }

            return allStr;
        }

        private void SearchAllFiles(List<string> files, string dir)
        {
            string[] fls = Directory.GetFiles(dir);
            foreach (string fl in fls)
            {
                files.Add(fl.Replace(Application.streamingAssetsPath + "/", ""));
            }

            string[] subDirs = Directory.GetDirectories(dir);

            foreach (string subDir in subDirs)
            {
                SearchAllFiles(files, subDir);
            }
        }

        private void SearchAllFilesByExt(List<string> files, string dir, string ext)
        {
            string[] fls = Directory.GetFiles(dir, ext);
            foreach (string fl in fls)
            {
                files.Add(fl.Replace(Application.streamingAssetsPath + "/", ""));
            }

            string[] subDirs = Directory.GetDirectories(dir);

            foreach (string subDir in subDirs)
            {
                SearchAllFilesByExt(files, subDir, ext);
            }
        }
    }
}
