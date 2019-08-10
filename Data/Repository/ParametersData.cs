using Entity;
using System;
using System.Data;
using System.Linq;

namespace Data.Repository
{
    /// <summary>
    /// Acceso a datos de la tabla parametros
    /// </summary>
    public class ParametersData : DataRepository<ParametersApp>, IDisposable, IParametersData
    {
        public ParametersData()
        {
        }

        public ParametersData(IConnection connection) : base(connection)
        {
        }

        /// <summary>
        /// Obtiene un parametro por nombre de la llave
        /// </summary>
        /// <param name="nameKey">nombre de la llave</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>ParametersApp</returns>
        public ParametersApp ParameterFindByKey(string nameKey, IDbTransaction transaction = null)
        {
            try
            {
                return GetList("WHERE ParameterKey= @ParameterKey", new { ParameterKey = nameKey }, transaction).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene el valor especifico de un parametro segun el tipo de dato T
        /// </summary>
        /// <typeparam name="T">int,string,guid,decimal,boolean,long,datetime,byte[]</typeparam>
        /// <param name="nameKey">nombre de la llave del parametro</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>T</returns>
        public T ValueFindByKey<T>(string nameKey, IDbTransaction transaction = null)
        {
            try
            {
                T value = default(T);

                var parameter = ParameterFindByKey(nameKey);
                if (null == parameter) return value;

                if (typeof(T) == typeof(int) || typeof(T) == typeof(int?))
                {
                    value = (T)Convert.ChangeType(parameter.ParameterInt, typeof(T));
                }
                else if (typeof(T) == typeof(string))
                {
                    value = (T)Convert.ChangeType(parameter.ParameterString, typeof(T));
                }
                else if (typeof(T) == typeof(Guid) || typeof(T) == typeof(Guid?))
                {
                    value = (T)Convert.ChangeType(parameter.ParameterGuid, typeof(T));
                }
                else if (typeof(T) == typeof(DateTime) || typeof(T) == typeof(DateTime?))
                {
                    value = (T)Convert.ChangeType(parameter.ParameterDatetime, typeof(T));
                }
                else if (typeof(T) == typeof(long) || typeof(T) == typeof(long?))
                {
                    value = (T)Convert.ChangeType(parameter.ParameterBigInt, typeof(T));
                }
                else if (typeof(T) == typeof(bool) || typeof(T) == typeof(bool?))
                {
                    value = (T)Convert.ChangeType(parameter.ParameterBoolean, typeof(T));
                }
                else if (typeof(T) == typeof(decimal) || typeof(T) == typeof(decimal?))
                {
                    value = (T)Convert.ChangeType(parameter.ParameterDecimal, typeof(T));
                }
                else if (typeof(T) == typeof(byte[]))
                {
                    value = (T)Convert.ChangeType(parameter.ParameterArray, typeof(T));
                }
                else throw new Exception("Tipo de dato no definido");

                return value;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Acceso a datos de la tabla parametros
    /// </summary>
    public interface IParametersData : IDataRepository<ParametersApp>, IDisposable
    {
        /// <summary>
        /// Obtiene un parametro por nombre de la llave
        /// </summary>
        /// <param name="nameKey">nombre de la llave</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>ParametersApp</returns>
        ParametersApp ParameterFindByKey(string nameKey, IDbTransaction transaction = null);

        /// <summary>
        /// Obtiene el valor especifico de un parametro segun el tipo de dato T
        /// </summary>
        /// <typeparam name="T">int,string,guid,decimal,boolean,long,datetime,byte[]</typeparam>
        /// <param name="nameKey">nombre de la llave del parametro</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>T</returns>
        T ValueFindByKey<T>(string nameKey, IDbTransaction transaction = null);
    }
}