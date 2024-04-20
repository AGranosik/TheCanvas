namespace backend.Logic
{
    public static class PathExtensions
    {
        private const string _imagesFolder = "Images";
        public static string GetImagesPath(Guid session)
        {
            var directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            var imagesPath = Path.Combine(directoryPath, _imagesFolder, session.ToString());
            Directory.CreateDirectory(imagesPath);

            return imagesPath.ToString();
        }
    }
}
