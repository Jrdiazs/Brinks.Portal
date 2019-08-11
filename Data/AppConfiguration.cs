using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Data
{
    /// <summary>
    /// Clase para obtener valores de las configuraciones del appsettings
    /// </summary>
    public class AppConfiguration : IAppConfiguration
    {
        private readonly IConfigurationRoot _root;

        public AppConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            _root = root;
        }

        /// <summary>
        /// Obtiene una cadena de conexion segun el valor de la llave
        /// </summary>
        /// <param name="value">key name</param>
        /// <returns>connections string</returns>
        public string GetConnectionString(string value)
        {
            try
            {
                return _root.GetConnectionString(value);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene el valor de una AppSettings segun el nombre de la llave
        /// </summary>
        /// <param name="value">key name</param>
        /// <returns></returns>
        public string GetAppSettings(string value)
        {
            try
            {
                return _root.GetSection("AppSettings").GetSection(value).Value;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Clase para obtener valores de las configuraciones del appsettings
    /// </summary>
    public interface IAppConfiguration
    {
        /// <summary>
        /// Obtiene el valor de una AppSettings segun el nombre de la llave
        /// </summary>
        /// <param name="value">key name</param>
        /// <returns></returns>
        string GetAppSettings(string value);

        /// <summary>
        /// Obtiene una cadena de conexion segun el valor de la llave
        /// </summary>
        /// <param name="value">key name</param>
        /// <returns>connections string</returns>
        string GetConnectionString(string value);
    }
}