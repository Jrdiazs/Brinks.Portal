using Entity;
using System;
using System.Data;
using System.Linq;

namespace Data.Repository
{
    /// <summary>
    /// Acceso a datos a la tabla ControlsLanguage
    /// </summary>
    public class ControlsLanguageData : DataRepository<ControlsLanguage>, IControlsLanguageData, IDisposable
    {
        public ControlsLanguageData()
        {
        }

        public ControlsLanguageData(IConnection connection) : base(connection)
        {
        }

        /// <summary>
        /// Consulta un mensaje de control por nombre, id de formulario, y lenguaje id
        /// </summary>
        /// <param name="name">nombre del control</param>
        /// <param name="formId">id del formulario</param>
        /// <param name="languageId">id de lenguaje</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>ControlsLanguage</returns>
        public ControlsLanguage ControlFindByKey(string name, int formId, int languageId, IDbTransaction transaction = null)
        {
            try
            {
                return GetList("WHERE ControlName = @controlName AND FormId= @form AND LanguageId = @language", new
                {
                    controlName = name,
                    form = formId,
                    language = languageId
                }, transaction: transaction).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Acceso a datos a la tabla ControlsLanguage
    /// </summary>
    public interface IControlsLanguageData : IDataRepository<ControlsLanguage>, IDisposable
    {
        /// <summary>
        /// Consulta un mensaje de control por nombre, id de formulario, y lenguaje id
        /// </summary>
        /// <param name="name">nombre del control</param>
        /// <param name="formId">id del formulario</param>
        /// <param name="languageId">id de lenguaje</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>ControlsLanguage</returns>
        ControlsLanguage ControlFindByKey(string name, int formId, int languageId, IDbTransaction transaction = null);
    }
}