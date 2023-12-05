

namespace BASICA
{
    public interface IMakeImg : IIMage
    {
        string DirBase { get; set; }
        string Directory { get; set; }
        string Path { get; }
        string Extension { get; set; }
        string Prefix { get; set; }
        void ResetPrefix();
        void ChangPrefix();
        void SplitData(string Data);
    }
}
