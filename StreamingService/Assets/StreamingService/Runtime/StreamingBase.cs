namespace LeeFramework.Streaming
{
    public class StreamingBase<T> where T : new()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        protected const StreamingMode _DefaultMode = StreamingMode.Android;
        protected StreamingMode _Mode = StreamingMode.Android;
#elif UNITY_IOS && !UNITY_EDITOR
        protected const StreamingMode _DefaultMode = StreamingMode.IOS;
        protected StreamingMode _Mode = StreamingMode.IOS;
#else
        protected const StreamingMode _DefaultMode = StreamingMode.Editor;
        protected StreamingMode _Mode = StreamingMode.Editor;
#endif
        public StreamingMode mode => _Mode;


        protected static IStreaming _Streaming;
        private static T _Instance;
        public static T instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new T();
                    switch (_DefaultMode)
                    {
                        case StreamingMode.Editor:
                            _Streaming = new StreamingEditor();
                            _Streaming.Init();
                            break;
                        case StreamingMode.Android:
                            _Streaming = new StreamingAndroid();
                            _Streaming.Init();
                            break;
                        case StreamingMode.IOS:
                            _Streaming = new StreamingIOS();
                            _Streaming.Init();
                            break;
                    }
                }
                return _Instance;
            }
        }

        public virtual void Init(StreamingMode mode = _DefaultMode)
        {
            _Mode = mode;

            switch (_Mode)
            {
                case StreamingMode.Editor:
                    _Streaming = new StreamingEditor();
                    _Streaming.Init();
                    break;
                case StreamingMode.Android:
                    _Streaming = new StreamingAndroid();
                    _Streaming.Init();
                    break;
                case StreamingMode.IOS:
                    _Streaming = new StreamingIOS();
                    _Streaming.Init();
                    break;
            }
        }

        public StreamingMode GetMode()
        {
            return _Mode;
        }
    }
}
