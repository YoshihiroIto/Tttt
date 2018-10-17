﻿using System.IO;
using System.Threading.Tasks;
using Tttt.Foundation.Interface;
using Utf8Json;

namespace Tttt.Foundation
{
    public class LocalStorage
    {
        private readonly ILogger _logger;

        public LocalStorage(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<T> ReadAsync<T>(string path)
        {
            try
            {
                if (File.Exists(path) == false)
                {
                    _logger.Info($"Read:Not Found: {path}");
                    return default;
                }

                _logger.Info($"Read: {path}");

                using (var s = new FileStream(path, FileMode.Open, FileAccess.Read))
                    return await JsonSerializer.DeserializeAsync<T>(s).ConfigureAwait(false);
            }
            catch (System.Exception e)
            {
                _logger.Info($"Read:exception: {path}: {e.Message}");
                return default;
            }
        }

        public async Task WriteAsync<T>(T target, string path)
        {
            try
            {
                _logger.Info($"Write: {path}");

                SetupDir(path);

                using (var s = new FileStream(path, FileMode.Create, FileAccess.Write))
                    await JsonSerializer.SerializeAsync(s, target).ConfigureAwait(false);
            }
            catch (System.Exception e)
            {
                _logger.Info($"Write:exception: {path}: {e.Message}");
            }
        }

        private static void SetupDir(string path)
        {
            var dir = Path.GetDirectoryName(path);
            if (dir == null)
                return;

            Directory.CreateDirectory(dir);
        }
    }
}