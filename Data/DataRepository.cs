using Dapper;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Clase generica para crear repositorios
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class DataRepository<TModel> : IDisposable, IDataRepository<TModel> where TModel : class
    {
        /// <summary>
        /// Conexion actual
        /// </summary>
        public IConnection Connections { get; }

        /// <summary>
        /// Instancia un nuevo repositorio a partir de una conexion dada
        /// </summary>
        /// <param name="connection"></param>
        public DataRepository(IConnection connection) => Connections = connection;

        /// <summary>
        /// Instancia un nuevo repositorio con la conexion por default
        /// </summary>
        public DataRepository()
        {
            Connections = new Connection();
        }

        #region [Insert]

        /// <summary>
        /// Inserta un nuevo modelo de forma asincrona retornando el id generado
        /// </summary>
        /// <typeparam name="Tkey">tipo de dato del key</typeparam>
        /// <param name="model">modelo</param>
        /// <param name="transaction">transaccion</param>
        /// <returns>el valor de la llave</returns>
        public async Task<Tkey> InsertKeyAsync<Tkey>(TModel model, IDbTransaction transaction = null)
        {
            try
            {
                Tkey id = await Connections.DBConnection.InsertAsync<Tkey, TModel>(model, transaction);
                return id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Inserta un nuevo modelo  retornando el id generado
        /// </summary>
        /// <typeparam name="Tkey">tipo de dato del key</typeparam>
        /// <param name="model">modelo</param>
        /// <param name="transaction">transaccion</param>
        /// <returns>el valor de la llave</returns>
        public Tkey InsertKey<Tkey>(TModel model, IDbTransaction transaction = null)
        {
            try
            {
                Tkey id = Connections.DBConnection.Insert<Tkey, TModel>(model, transaction);
                return id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion [Insert]

        #region [Update]

        /// <summary>
        /// Actualiza el modelo en la base de datos actual
        /// </summary>
        /// <param name="model">modelo</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>numero de filas afectadas</returns>

        public int Update(TModel model, IDbTransaction transaction = null)
        {
            try
            {
                return Connections.DBConnection.Update(model, transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Actualiza el modelo en la base de datos actual
        /// </summary>
        /// <param name="model">modelo</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>numero de filas afectadas</returns>

        public async Task<int> UpdateAsync(TModel model, IDbTransaction transaction = null)
        {
            try
            {
                return await Connections.DBConnection.UpdateAsync(model, transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion [Update]

        #region [Delete]

        /// <summary>
        /// elimina el modelo en la base de datos actual
        /// </summary>
        /// <param name="model">modelo</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>numero de filas afectadas</returns>

        public int Delete(TModel model, IDbTransaction transaction = null)
        {
            try
            {
                return Connections.DBConnection.Delete(model, transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Elimina el modelo en la base de datos actual
        /// </summary>
        /// <param name="model">modelo</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>numero de filas afectadas</returns>

        public async Task<int> DeleteAsync(TModel model, IDbTransaction transaction = null)
        {
            try
            {
                return await Connections.DBConnection.DeleteAsync(model, transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Elimina el modelo en la base de datos actual
        /// </summary>
        /// <param name="id">id del objeto</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>numero de filas afectadas</returns>

        public int Delete(object id, IDbTransaction transaction = null)
        {
            try
            {
                return Connections.DBConnection.Delete(id, transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Elimina el modelo en la base de datos actual
        /// </summary>
        /// <param name="id">id del objeto</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>numero de filas afectadas</returns>

        public async Task<int> DeleteAsync(object id, IDbTransaction transaction = null)
        {
            try
            {
                return await Connections.DBConnection.DeleteAsync(id, transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion [Delete]

        #region [Get]

        /// <summary>
        /// Obtiene el modelo de la base de datos por id
        /// </summary>
        /// <param name="id">id del objeto</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>TModel</returns>

        public TModel Get(object id, IDbTransaction transaction = null)
        {
            try
            {
                return Connections.DBConnection.Get<TModel>(id, transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///  Obtiene el modelo de la base de datos por id
        /// </summary>
        /// <param name="id">id del objeto</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>TModel</returns>

        public async Task<TModel> GetAsync(object id, IDbTransaction transaction = null)
        {
            try
            {
                return await Connections.DBConnection.GetAsync<TModel>(id, transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion [Get]

        #region [GetList]

        /// <summary>
        /// Obtiene un listado de registros de la base de datos por un filtro
        /// </summary>
        /// <param name="where">filtro del objeto</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>Listado TModel</returns>

        public List<TModel> GetList(object where, IDbTransaction transaction = null)
        {
            try
            {
                var query = Connections.DBConnection.GetList<TModel>(where, transaction).ToList();
                return query ?? new List<TModel>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///  Obtiene un listado de registros de la base de datos por un filtro
        /// </summary>
        /// <param name="where">id del objeto</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>Listado TModel</returns>

        public async Task<List<TModel>> GetListAsync(object where, IDbTransaction transaction = null)
        {
            try
            {
                var query = await Connections.DBConnection.GetListAsync<TModel>(where, transaction);
                return query.ToList() ?? new List<TModel>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene un listado de registros de la base de datos por un filtro
        /// </summary>
        /// <param name="filter">filtro sql</param>
        /// <param name="parameters">filtro del objeto</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>Listado TModel</returns>

        public List<TModel> GetList(string filter, object parameters, IDbTransaction transaction = null)
        {
            try
            {
                var query = Connections.DBConnection.GetList<TModel>(conditions: filter, parameters: parameters, transaction: transaction).ToList();
                return query ?? new List<TModel>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///  Obtiene un listado de registros de la base de datos por un filtro
        /// </summary>
        /// <param name="filter">filtro sql</param>
        /// <param name="parameters">filtro del objeto</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>Listado TModel</returns>

        public async Task<List<TModel>> GetListAsync(string filter, object parameters, IDbTransaction transaction = null)
        {
            try
            {
                var query = await Connections.DBConnection.GetListAsync<TModel>(conditions: filter, parameters: parameters, transaction: transaction);
                return query.ToList() ?? new List<TModel>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene un listado de registros de la base de datos
        /// </summary>
        /// <returns>Listado TModel</returns>

        public List<TModel> GetList()
        {
            try
            {
                var query = Connections.DBConnection.GetList<TModel>().ToList();
                return query ?? new List<TModel>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///  Obtiene un listado de registros de la base de datos
        /// </summary>
        /// <returns>Listado TModel</returns>

        public async Task<List<TModel>> GetListAsync()
        {
            try
            {
                var query = await Connections.DBConnection.GetListAsync<TModel>();
                return query.ToList() ?? new List<TModel>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion [GetList]

        #region [Count]

        /// <summary>
        /// Consulta la cantidad de registros de la entidad por un filtro
        /// </summary>
        /// <param name="filter">filtro sql</param>
        /// <param name="parameters">filtro</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>numero de registros encontrados</returns>

        public int Count(string filter, object parameters, IDbTransaction transaction = null)
        {
            try
            {
                return Connections.DBConnection.RecordCount<TModel>(conditions: filter, parameters: parameters, transaction: transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta la cantidad de registros de la entidad por un filtro
        /// </summary>
        /// <param name="filter">filtro sql</param>
        /// <param name="parameters">filtro</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>numero de registros encontrados</returns>

        public async Task<int> CountAsync(string filter, object parameters, IDbTransaction transaction = null)
        {
            try
            {
                int count = await Connections.DBConnection.RecordCountAsync<TModel>(conditions: filter, parameters: parameters, transaction: transaction);
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta la cantidad de registros de la entidad por un filtro
        /// </summary>
        /// <param name="where">filtro</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>numero de registros encontrados</returns>

        public int Count(object where, IDbTransaction transaction = null)
        {
            try
            {
                return Connections.DBConnection.RecordCount<TModel>(whereConditions: where, transaction: transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta la cantidad de registros de la entidad por un filtro
        /// </summary>
        /// <param name="where">filtro</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>numero de registros encontrados</returns>

        public async Task<int> CountAsync(object where, IDbTransaction transaction = null)
        {
            try
            {
                int count = await Connections.DBConnection.RecordCountAsync<TModel>(whereConditions: where, transaction: transaction);
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta la cantidad de registros
        /// </summary>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>numero de registros encontrados</returns>

        public int Count(IDbTransaction transaction = null)
        {
            try
            {
                return Connections.DBConnection.RecordCount<TModel>(whereConditions: null, transaction: transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta la cantidad de registros
        /// </summary>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>numero de registros encontrados</returns>

        public async Task<int> CountAsync(IDbTransaction transaction = null)
        {
            try
            {
                int count = await Connections.DBConnection.RecordCountAsync<TModel>(whereConditions: null, transaction: transaction);
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion [Count]

        #region [PageList]

        /// <summary>
        /// Consulta un listado de registros de manera paginada
        /// </summary>
        /// <param name="orderBy">ordernamiento sql</param>
        /// <param name="filter">filtro sql</param>
        /// <param name="parameters">filtro parametros</param>
        /// <param name="pageNumber">numero de pagina</param>
        /// <param name="rowsPerPage">registros por pagina</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>Listado de registros por pagina</returns>
        public PageList<TModel> PageList(string orderBy, string filter, object parameters, int pageNumber = 0, int rowsPerPage = 15, IDbTransaction transaction = null)
        {
            try
            {
                var query = Connections.DBConnection.GetListPaged<TModel>(orderby: orderBy, conditions: filter, parameters: parameters, pageNumber: pageNumber, rowsPerPage: rowsPerPage, transaction: transaction).ToList();
                var count = Count(filter: filter, parameters: parameters, transaction: transaction);

                var pageList = new PageList<TModel>()
                {
                    Records = query ?? new List<TModel>(),
                    TotalRecords = count
                };

                return pageList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta un listado de registros de manera paginada
        /// </summary>
        /// <param name="orderBy">ordernamiento sql</param>
        /// <param name="filter">filtro sql</param>
        /// <param name="parameters">filtro parametros</param>
        /// <param name="pageNumber">numero de pagina</param>
        /// <param name="rowsPerPage">registros por pagina</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>Listado de registros por pagina</returns>
        public async Task<PageList<TModel>> PageListAsync(string orderBy, string filter, object parameters, int pageNumber = 0, int rowsPerPage = 15, IDbTransaction transaction = null)
        {
            try
            {
                var query = await Connections.DBConnection.GetListPagedAsync<TModel>(orderby: orderBy, conditions: filter, parameters: parameters, pageNumber: pageNumber, rowsPerPage: rowsPerPage, transaction: transaction);
                var count = await CountAsync(filter: filter, parameters: parameters, transaction: transaction);
                var pageList = new PageList<TModel>()
                {
                    Records = query.ToList() ?? new List<TModel>(),
                    TotalRecords = count
                };

                return pageList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion [PageList]

        #region [RowsAfected]

        /// <summary>
        /// Ejecuta un query en la base de datos
        /// </summary>
        /// <param name="parameters">parametros</param>
        /// <param name="query">sql query</param>
        /// <param name="transaction"></param>
        /// <returns>retorna el numero de filas afectadas</returns>
        public int RowsAfected(object parameters, string query, CommandType commandType = CommandType.Text, IDbTransaction transaction = null)
        {
            try
            {
                return Connections.DBConnection.Execute(sql: query, param: parameters, transaction: transaction, commandType: commandType);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Ejecuta un query en la base de datos
        /// </summary>
        /// <param name="parameters">parametros</param>
        /// <param name="query">sql query</param>
        /// <param name="transaction"></param>
        /// <returns>retorna el numero de filas afectadas</returns>
        public async Task<int> RowsAfectedAsync(object parameters, string query, CommandType commandType = CommandType.Text, IDbTransaction transaction = null)
        {
            try
            {
                int rowsAffected = await Connections.DBConnection.ExecuteAsync(sql: query, param: parameters, transaction: transaction, commandType: commandType);
                return rowsAffected;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion [RowsAfected]

        #region [Scalar]

        /// <summary>
        /// Obtiene el valor del primer resultado de un query
        /// </summary>
        /// <param name="parameters">parametros</param>
        /// <param name="query">sql query</param>
        /// <param name="transaction"></param>
        /// <returns>retorna el numero de filas afectadas</returns>
        public dynamic Scalar(object parameters, string query, CommandType commandType = CommandType.Text, IDbTransaction transaction = null)
        {
            try
            {
                return Connections.DBConnection.ExecuteScalar(sql: query, param: parameters, transaction: transaction, commandType: commandType);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene el valor del primer resultado de un query
        /// </summary>
        /// <param name="parameters">parametros</param>
        /// <param name="query">sql query</param>
        /// <param name="transaction"></param>
        /// <returns>retorna el numero de filas afectadas</returns>
        public async Task<dynamic> ScalarAsync(object parameters, string query, CommandType commandType = CommandType.Text, IDbTransaction transaction = null)
        {
            try
            {
                var result = await Connections.DBConnection.ExecuteScalarAsync(sql: query, param: parameters, transaction: transaction, commandType: commandType);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion [Scalar]

        #region [Dispose]

        private bool disposedValue = false; // Para detectar llamadas redundantes

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: elimine el estado administrado (objetos administrados).
                    if (Connections != null)
                        Connections.Dispose();
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                disposedValue = true;
            }
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~DataRepository() {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            GC.SuppressFinalize(this);
        }

        #endregion [Dispose]
    }

    /// <summary>
    /// Clase generica para crear repositorios
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IDataRepository<TModel> : IDisposable where TModel : class
    {
        /// <summary>
        /// Conexion actual
        /// </summary>
        IConnection Connections { get; }

        #region [Insert]

        /// <summary>
        /// Inserta un nuevo modelo de forma asincrona retornando el id generado
        /// </summary>
        /// <typeparam name="Tkey">tipo de dato del key</typeparam>
        /// <param name="model">modelo</param>
        /// <param name="transaction">transaccion</param>
        /// <returns>el valor de la llave</returns>
        Task<Tkey> InsertKeyAsync<Tkey>(TModel model, IDbTransaction transaction = null);

        /// <summary>
        /// Inserta un nuevo modelo  retornando el id generado
        /// </summary>
        /// <typeparam name="Tkey">tipo de dato del key</typeparam>
        /// <param name="model">modelo</param>
        /// <param name="transaction">transaccion</param>
        /// <returns>el valor de la llave</returns>
        Tkey InsertKey<Tkey>(TModel model, IDbTransaction transaction = null);

        #endregion [Insert]

        #region [Update]

        /// <summary>
        /// Actualiza el modelo en la base de datos actual
        /// </summary>
        /// <param name="model">modelo</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>numero de filas afectadas</returns>

        int Update(TModel model, IDbTransaction transaction = null);

        /// <summary>
        /// Actualiza el modelo en la base de datos actual
        /// </summary>
        /// <param name="model">modelo</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>numero de filas afectadas</returns>

        Task<int> UpdateAsync(TModel model, IDbTransaction transaction = null);

        #endregion [Update]

        #region [Delete]

        /// <summary>
        /// elimina el modelo en la base de datos actual
        /// </summary>
        /// <param name="model">modelo</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>numero de filas afectadas</returns>

        int Delete(TModel model, IDbTransaction transaction = null);

        /// <summary>
        /// Elimina el modelo en la base de datos actual
        /// </summary>
        /// <param name="model">modelo</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>numero de filas afectadas</returns>

        Task<int> DeleteAsync(TModel model, IDbTransaction transaction = null);

        /// <summary>
        /// Elimina el modelo en la base de datos actual
        /// </summary>
        /// <param name="id">id del objeto</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>numero de filas afectadas</returns>

        int Delete(object id, IDbTransaction transaction = null);

        /// <summary>
        /// Elimina el modelo en la base de datos actual
        /// </summary>
        /// <param name="id">id del objeto</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>numero de filas afectadas</returns>

        Task<int> DeleteAsync(object id, IDbTransaction transaction = null);

        #endregion [Delete]

        #region [Get]

        /// <summary>
        /// Obtiene el modelo de la base de datos por id
        /// </summary>
        /// <param name="id">id del objeto</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>TModel</returns>

        TModel Get(object id, IDbTransaction transaction = null);

        /// <summary>
        ///  Obtiene el modelo de la base de datos por id
        /// </summary>
        /// <param name="id">id del objeto</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>TModel</returns>

        Task<TModel> GetAsync(object id, IDbTransaction transaction = null);

        #endregion [Get]

        #region [GetList]

        /// <summary>
        /// Obtiene un listado de registros de la base de datos por un filtro
        /// </summary>
        /// <param name="where">filtro del objeto</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>Listado TModel</returns>

        List<TModel> GetList(object where, IDbTransaction transaction = null);

        /// <summary>
        ///  Obtiene un listado de registros de la base de datos por un filtro
        /// </summary>
        /// <param name="where">id del objeto</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>Listado TModel</returns>

        Task<List<TModel>> GetListAsync(object where, IDbTransaction transaction = null);

        /// <summary>
        /// Obtiene un listado de registros de la base de datos por un filtro
        /// </summary>
        /// <param name="filter">filtro sql</param>
        /// <param name="parameters">filtro del objeto</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>Listado TModel</returns>

        List<TModel> GetList(string filter, object parameters, IDbTransaction transaction = null);

        /// <summary>
        ///  Obtiene un listado de registros de la base de datos por un filtro
        /// </summary>
        /// <param name="filter">filtro sql</param>
        /// <param name="parameters">filtro del objeto</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>Listado TModel</returns>

        Task<List<TModel>> GetListAsync(string filter, object parameters, IDbTransaction transaction = null);

        /// <summary>
        /// Obtiene un listado de registros de la base de datos
        /// </summary>
        /// <returns>Listado TModel</returns>

        List<TModel> GetList();

        /// <summary>
        ///  Obtiene un listado de registros de la base de datos
        /// </summary>
        /// <returns>Listado TModel</returns>

        Task<List<TModel>> GetListAsync();

        #endregion [GetList]

        #region [Count]

        /// <summary>
        /// Consulta la cantidad de registros de la entidad por un filtro
        /// </summary>
        /// <param name="filter">filtro sql</param>
        /// <param name="parameters">filtro</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>numero de registros encontrados</returns>

        int Count(string filter, object parameters, IDbTransaction transaction = null);

        /// <summary>
        /// Consulta la cantidad de registros de la entidad por un filtro
        /// </summary>
        /// <param name="filter">filtro sql</param>
        /// <param name="parameters">filtro</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>numero de registros encontrados</returns>

        Task<int> CountAsync(string filter, object parameters, IDbTransaction transaction = null);

        /// <summary>
        /// Consulta la cantidad de registros de la entidad por un filtro
        /// </summary>
        /// <param name="where">filtro</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>numero de registros encontrados</returns>

        int Count(object where, IDbTransaction transaction = null);

        /// <summary>
        /// Consulta la cantidad de registros de la entidad por un filtro
        /// </summary>
        /// <param name="where">filtro</param>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>numero de registros encontrados</returns>

        Task<int> CountAsync(object where, IDbTransaction transaction = null);

        /// <summary>
        /// Consulta la cantidad de registros
        /// </summary>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>numero de registros encontrados</returns>

        int Count(IDbTransaction transaction = null);

        /// <summary>
        /// Consulta la cantidad de registros
        /// </summary>
        /// <param name="transaction">transaccion de base de datos</param>
        /// <returns>numero de registros encontrados</returns>

        Task<int> CountAsync(IDbTransaction transaction = null);

        #endregion [Count]

        #region [PageList]

        /// <summary>
        /// Consulta un listado de registros de manera paginada
        /// </summary>
        /// <param name="orderBy">ordernamiento sql</param>
        /// <param name="filter">filtro sql</param>
        /// <param name="parameters">filtro parametros</param>
        /// <param name="pageNumber">numero de pagina</param>
        /// <param name="rowsPerPage">registros por pagina</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>Listado de registros por pagina</returns>
        PageList<TModel> PageList(string orderBy, string filter, object parameters, int pageNumber = 0, int rowsPerPage = 15, IDbTransaction transaction = null);

        /// <summary>
        /// Consulta un listado de registros de manera paginada
        /// </summary>
        /// <param name="orderBy">ordernamiento sql</param>
        /// <param name="filter">filtro sql</param>
        /// <param name="parameters">filtro parametros</param>
        /// <param name="pageNumber">numero de pagina</param>
        /// <param name="rowsPerPage">registros por pagina</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>Listado de registros por pagina</returns>
        Task<PageList<TModel>> PageListAsync(string orderBy, string filter, object parameters, int pageNumber = 0, int rowsPerPage = 15, IDbTransaction transaction = null);

        #endregion [PageList]

        #region [RowsAfected]

        /// <summary>
        /// Ejecuta un query en la base de datos
        /// </summary>
        /// <param name="parameters">parametros</param>
        /// <param name="query">sql query</param>
        /// <param name="transaction"></param>
        /// <returns>retorna el numero de filas afectadas</returns>
        int RowsAfected(object parameters, string query, CommandType commandType = CommandType.Text, IDbTransaction transaction = null);

        /// <summary>
        /// Ejecuta un query en la base de datos
        /// </summary>
        /// <param name="parameters">parametros</param>
        /// <param name="query">sql query</param>
        /// <param name="transaction"></param>
        /// <returns>retorna el numero de filas afectadas</returns>
        Task<int> RowsAfectedAsync(object parameters, string query, CommandType commandType = CommandType.Text, IDbTransaction transaction = null);

        #endregion [RowsAfected]

        #region [Scalar]

        /// <summary>
        /// Obtiene el valor del primer resultado de un query
        /// </summary>
        /// <param name="parameters">parametros</param>
        /// <param name="query">sql query</param>
        /// <param name="transaction"></param>
        /// <returns>retorna el numero de filas afectadas</returns>
        dynamic Scalar(object parameters, string query, CommandType commandType = CommandType.Text, IDbTransaction transaction = null);

        /// <summary>
        /// Obtiene el valor del primer resultado de un query
        /// </summary>
        /// <param name="parameters">parametros</param>
        /// <param name="query">sql query</param>
        /// <param name="transaction"></param>
        /// <returns>retorna el numero de filas afectadas</returns>
        Task<dynamic> ScalarAsync(object parameters, string query, CommandType commandType = CommandType.Text, IDbTransaction transaction = null);

        #endregion [Scalar]
    }
}