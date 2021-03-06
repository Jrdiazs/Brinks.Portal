﻿using System;

namespace Entity
{
    /// <summary>
    /// Modelo que identifica si la autenticacion fue exitosa
    /// </summary>
    public class SessionAuthentication
    {
        /// <summary>
        /// Determina si fue autenticado correctamente
        /// </summary>
        public bool IsAuthenticate { get; set; }

        /// <summary>
        /// Usuario de autenticacion
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Politica de inicio de sesion
        /// </summary>
        public Guid PolicyId { get; set; }

        /// <summary>
        /// Tipo de autenticacion
        /// </summary>
        public TypeAutentication TypeAutentication { get; set; } = TypeAutentication.Default;

        /// <summary>
        /// Session Id
        /// </summary>
        public Guid SessionId { get; set; }
    }
}