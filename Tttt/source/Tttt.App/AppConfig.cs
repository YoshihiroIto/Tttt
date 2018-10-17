using Tttt.Foundation.Interface;

namespace Tttt.App
{
    /// <summary>
    /// アプリケーション用コンフィグ
    /// </summary>
    public class AppConfig
    {
        public void Load(IRepository<AppConfig> repos)
            => CopyFrom(repos.LoadAsync().Result);

        public void Save(IRepository<AppConfig> repos)
            => repos.SaveAsync(this).Wait();

        private void CopyFrom(AppConfig src)
        {
        }
    }
}