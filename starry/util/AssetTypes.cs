using System;

namespace starry;

public interface IAsset {
    public void load(string path);
    public void cleanup();
}

public record class Sprite : IAsset {
    public void load(string path)
    {
        throw new NotImplementedException();
    }

    public void cleanup()
    {
        throw new NotImplementedException();
    }
}

/*public record class Font: IAsset {
    internal Raylib_cs.Font rl;

    public unsafe void load(string path)
    {
        Raylib.font
        rl = Raylib.LoadFont(path);
    }

    public void cleanup() => Raylib.UnloadFont(rl);
}*/