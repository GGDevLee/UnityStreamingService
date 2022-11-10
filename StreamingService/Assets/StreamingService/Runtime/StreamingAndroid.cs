using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace LeeFramework.Streaming
{
    public class StreamingAndroid : IStreaming
    {
        private AndroidJavaClass _MainJava = null;
        private AndroidJavaObject _MainJavaObj = null;
        private AndroidJavaObject _JavaObj = null;
        private string[] _AllFileName;

        public string rootPath => Application.streamingAssetsPath;

        public void Init()
        {
            _MainJava = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            _MainJavaObj = _MainJava.GetStatic<AndroidJavaObject>("currentActivity");
            _JavaObj = new AndroidJavaObject("com.nightgame.streaming.AssetsMgr");
            _JavaObj.Call("init", _MainJavaObj);
            RefreshAllFiles();
        }

        public bool FileExists(string path, bool isRefresh = false)
        {
            if (isRefresh)
            {
                RefreshAllFiles();
            }
            string fileName = Path.GetFileName(path);

            for (int i = 0; i < _AllFileName.Length; i++)
            {
                if (_AllFileName[i] == fileName)
                {
                    return true;
                }
            }
            return false;
        }

        public void RefreshAllFiles(string path = "")
        {
            _AllFileName = GetAllFiles(path);
        }

        public string[] GetAllFiles(string path = "")
        {
            return _JavaObj.Call<string[]>("getAllFiles", path);
        }

        public string[] GetAllFilesByExt(string searchPattern, string path = "")
        {
            RefreshAllFiles(path);

            if (string.IsNullOrEmpty(searchPattern))
            {
                return GetAllFiles(path);
            }

            List<string> rtn = new List<string>();

            foreach (string item in _AllFileName)
            {
                if (item != null && item.EndsWith(searchPattern))
                {
                    rtn.Add(item);
                }
            }

            return rtn.ToArray();
        }

        public byte[] LoadFile(string path, int offset = 0)
        {
            return _JavaObj.Call<byte[]>("load", path, offset);
        }

        public string LoadText(string path)
        {
            return Encoding.UTF8.GetString(LoadFile(path));
        }
    }
}