package com.nightgame.streaming;

import android.content.Context;
import android.content.res.AssetManager;
import android.util.Log;

import java.io.IOException;
import java.io.InputStream;

public class AssetsMgr
{
    private AssetManager _AssetMgr;
    private Context _Context;

    public void init(Context context)
    {
        _Context = context;
        _AssetMgr = _Context.getAssets();
    }


    public AssetManager getAssetMgr()
    {
        return _AssetMgr;
    }

    public String[] getAllFiles() throws IOException
    {
        return getAllFiles("");
    }

    public String[] getAllFiles(String path) throws IOException
    {
        return _AssetMgr.list(path);
    }

    public byte[] load(String path) throws IOException
    {
        return load(path, 0);
    }

    public byte[] load(String path, int offset) throws IOException
    {
        InputStream inputStream = _AssetMgr.open(path);

        try
        {
            int len = inputStream.available();
            byte buf[] = new byte[len];
            inputStream.reset();
            inputStream.skip(offset);
            inputStream.read(buf, 0, len - offset);
            inputStream.close();
            return buf;
        }
        catch (IOException e)
        {
            Log.e("Unity", e.getMessage());
        }

        return null;
    }
}
