using Raylib_cs;
using static starry.Starry;

namespace starry;

/// <summary>
/// it's a 3d model
/// </summary>
public class Model : IAsset {
    internal Raylib_cs.Model rlModel;

    public unsafe void load(string path) {
        rlModel = Raylib.LoadModel(path);
    }
    public void cleanup() => Raylib.UnloadModel(rlModel);
}