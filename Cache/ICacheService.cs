namespace RedisCacheDemo.Cache
{
    public interface ICacheService
    {
        /// <summary>
        /// Obter dados usando a chave
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T GetData<T>(string key);

        /// <summary>
        /// Definir dados com valor e tempo de expiração da chave
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expirationTime"></param>
        /// <returns></returns>
        bool SetData<T>(string key, T value, DateTimeOffset expirationTime);

        /// <summary>
        /// Remover dados
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        object RemoveData(string key);
    }
}
