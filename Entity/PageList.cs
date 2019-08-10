using System.Collections.Generic;

namespace Entity
{
    /// <summary>
    /// Objeto para retornar un objeto paginado
    /// </summary>
    /// <typeparam name="T">Tipo de objeto entidad</typeparam>
    public class PageList<T> where T : class
    {
        /// <summary>
        /// Listado de registros
        /// </summary>
        public List<T> Records { get; set; } = new List<T>();

        /// <summary>
        /// Total de registros
        /// </summary>
        public int TotalRecords { get; set; } = 0;
    }
}