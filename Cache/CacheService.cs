using StackExchange.Redis;
using Newtonsoft.Json;

namespace RedisCacheDemo.Cache
{
    public class CacheService : ICacheService
    {
        private IDatabase _dataBase;
        public CacheService()
        {
            ConfigureRedis();
        }
        private void ConfigureRedis()
        {
            _dataBase = ConnectionHelper.Connection.GetDatabase();
        }
        public T GetData<T>(string key)
        {
            var value = _dataBase.StringGet(key);
            if (!string.IsNullOrEmpty(value))
                return JsonConvert.DeserializeObject<T>(value);

            return default;
        }
        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            TimeSpan expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);
            var isSet = _dataBase.StringSet(key, JsonConvert.SerializeObject(value), expiryTime);
            return isSet;
        }
        public object RemoveData(string key)
        {
            bool _isKeyExist = _dataBase.KeyExists(key);
            if (_isKeyExist == true)
                return _dataBase.KeyDelete(key);

            return false;
        }
    }
}

