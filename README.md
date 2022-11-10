# StreamingService

**联系作者：419731519（QQ）**

### ============StreamingService介绍============
#### 因为Android不能直接使用文件流的方式读取StreamingAssets下的资源
#### 以至于资源加密后，一般需要解压资源到沙盒路径，再进行读取
#### 而解压资源需要时间，这就影响了玩家体验，而这个插件解决的就是这个问题
#### 资源加密后，也可以直接使用文件流读取资源，以后再也不用解压资源啦！！
#### 觉得我的插件能帮助到你，麻烦帮我点个Star支持一下❤️

</br>

### ================使用方法================
#### 有3种方法可以引用这个插件，我推荐使用第一种
- 1、manifest.json中添加插件路径
```json
{
  "dependencies": {
	"com.leeframework.streaming":"https://e.coding.net/ggdevlee/leeframework/StreamingService.git#1.0.6"
  }
}
```
- 2、拷贝Dll跟Jar包到对应的目录下
- 3、拷贝对应的代码跟Jar包到对应的目录下

</br>

- 引入命名空间
```csharp
using LeeFramework.Streaming;
```

- 二进制加载文件

```csharp
//Application.streamingAssetsPath + "/ab/loginwindow.ab"
byte[] assetBundle = StreamingSvc.instance.LoadFile("ab/loginwindow.ab");
```

- 加载文本

```csharp
//Application.streamingAssetsPath + "/Config.txt"
string txt = StreamingSvc.instance.LoadText("Config.txt");
```

- 获取路径下的全部文件名

```csharp
//默认：Application.streamingAssetsPath
string[] allFilesName = StreamingSvc.instance.GetAllFiles();


//Application.streamingAssetsPath + "/ab"
string[] allFilesName = StreamingSvc.instance.GetAllFiles("ab");
```


- 根据后缀名获取路径下的全部文件名

```csharp
//默认：Application.streamingAssetsPath
string[] allFilesName = StreamingSvc.instance.GetAllFilesByExt("", "*");

//Application.streamingAssetsPath + "/Json"
string[] allFilesName = StreamingSvc.instance.GetAllFilesByExt("Json", ".json");
```

- 是否存在文件

```csharp
//Application.streamingAssetsPath + "/Json/Config.json"
bool res = StreamingSvc.instance.FileExists("Json/Config.json");
```