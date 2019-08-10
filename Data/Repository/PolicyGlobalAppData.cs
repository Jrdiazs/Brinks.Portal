using Dapper;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.Repository
{
    /// <summary>
    /// Acceso a datos a la tabla PolicyGlobalApp
    /// </summary>
    public class PolicyGlobalAppData : DataRepository<PolicyGlobalApp>, IPolicyGlobalAppData, IDisposable
    {
        public PolicyGlobalAppData()
        {
        }

        public PolicyGlobalAppData(IConnection connection) : base(connection)
        {
        }

        /// <summary>
        /// Obtiene la politica global de la aplicacion para los usuario que no tienen politica y cliente asignado
        /// </summary>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>PolicyView</returns>

        public PolicyView PolicyGetGlobal(IDbTransaction transaction = null)
        {
            try
            {
                Guid id = Guid.Empty;
                return PolicyViewsFind(policyId: id, transaction: transaction).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene la politica por id
        /// </summary>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>PolicyView</returns>

        public PolicyView PolicyFindById(Guid id, IDbTransaction transaction = null)
        {
            try
            {
                return PolicyViewsFind(policyId: id, transaction: transaction).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta en una vista los datos de la tabla PolicyGlobalApp y PolicyThird
        /// </summary>
        /// <param name="policyId">politica id</param>
        /// <param name="thirdId">id del tercero</param>
        /// <param name="thirdTypeId">id tipo tercero</param>
        /// <param name="transaction">transaccion sql server</param>
        /// <returns>List PolicyView</returns>
        public List<PolicyView> PolicyViewsFind(Guid? policyId = null, Guid? thirdId = null, int? thirdTypeId = null, IDbTransaction transaction = null)
        {
            try
            {
                var query = Connections.DBConnection.Query<PolicyView, Third, ThirdType, DocumentType, PolicyView>(sql: "SP_PolicyFind",
                    map: (p, t, tp, d) => { p.Third = t; p.Third.ThirdType = tp; p.Third.Document = d; return p; },
                    splitOn: "split", transaction: transaction, commandType: CommandType.StoredProcedure).ToList();

                return query ?? new List<PolicyView>();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Acceso a datos a la tabla PolicyGlobalApp
    /// </summary>
    public interface IPolicyGlobalAppData : IDataRepository<PolicyGlobalApp>, IDisposable
    {
        /// <summary>
        /// Consulta en una vista los datos de la tabla PolicyGlobalApp y PolicyThird
        /// </summary>
        /// <param name="policyId">politica id</param>
        /// <param name="thirdId">id del tercero</param>
        /// <param name="thirdTypeId">id tipo tercero</param>
        /// <param name="transaction">transaccion sql server</param>
        /// <returns>List PolicyView</returns>
        List<PolicyView> PolicyViewsFind(Guid? policyId = null, Guid? thirdId = null, int? thirdTypeId = null, IDbTransaction transaction = null);

        /// <summary>
        /// Obtiene la politica global de la aplicacion para los usuario que no tienen politica y cliente asignado
        /// </summary>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>PolicyView</returns>
        PolicyView PolicyGetGlobal(IDbTransaction transaction = null);

        /// <summary>
        /// Obtiene la politica por id
        /// </summary>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>PolicyView</returns>

        PolicyView PolicyFindById(Guid id, IDbTransaction transaction = null);
    }
}