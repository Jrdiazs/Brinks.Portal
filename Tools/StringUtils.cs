using System;
using System.Security.Cryptography;
using System.Text;

namespace Tools.String
{
    /// <summary>
    /// Clase util para manejar strings
    /// </summary>
    public static class StringUtils
    {
        /// <summary>
        /// Lee del web config un valor del app settings
        /// </summary>
        /// <param name="value">nombre de la llave</param>
        /// <param name="valueDefault">valor por default</param>
        /// <returns>valor del app settings</returns>
        public static string ReadKeyConfig(this string value, string valueDefault = "")
        {
            try
            {
                return string.Empty;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lee del web config un valor de un connections string por llave
        /// </summary>
        /// <param name="value">nombre de la llave</param>
        /// <returns>valor de un connections string por llave</returns>
        public static string ReadConnectionsConfig(this string value)
        {
            try
            {
                return string.Empty;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna un string encriptado con SHA1
        /// </summary>
        /// <param name="value">cadena a encriptar</param>
        /// <returns>cadena encriptada</returns>
        public static string SHA1(this string value)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                UTF8Encoding enc = new UTF8Encoding();
                byte[] data = enc.GetBytes(value);
                byte[] result;

                using (SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider())
                {
                    result = sha.ComputeHash(data);

                    for (int i = 0; i < result.Length; i++)
                    {
                        if (result[i] < 16)
                            sb.Append("0");

                        sb.Append(result[i].ToString("x"));
                    }
                }

                return sb.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Encripta una cadena en base 64
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Base64Encode(this string value)
        {
            try
            {
                var plainTextBytes = Encoding.UTF8.GetBytes(value);
                return Convert.ToBase64String(plainTextBytes);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Desenripta una cadena en base 64
        /// </summary>
        /// <param name="value">valor a decodificar</param>
        /// <returns></returns>

        public static string Base64Decode(this string value)
        {
            try
            {
                var base64EncodedBytes = Convert.FromBase64String(value);
                return Encoding.UTF8.GetString(base64EncodedBytes);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}