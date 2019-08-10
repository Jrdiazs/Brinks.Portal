using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Controls
{
    /// <summary>
    /// Extension para los controles
    /// </summary>
    public static class ControlsTools
    {
        /// <summary>
        /// Crea una excepcion a partir de un control agregando el mensaje a una nueva excepcion
        /// </summary>
        /// <param name="control">control</param>
        /// <param name="values">valores del mensaje</param>
        /// <returns>Exception</returns>
        public static Exception CreateException(this ControlsLanguage control, params object [] values)
        {
            try
            {
                string msg = string.Format(control.ControlDescription, values);
                return new Exception(msg);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
