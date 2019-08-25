using System;

namespace Entity
{
    public class UserSession
    {
        /// <summary>
        /// Id del Usuario
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id politica de ingreso
        /// </summary>
        public Guid PoliceId { get; set; }

        /// <summary>
        /// Direccion ip
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// Fecha de Ingreso
        /// </summary>
        public DateTime DateOfAdmission { get; set; }

        /// <summary>
        /// Id lenguaje Usuario
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// Id de session actual
        /// </summary>
        public Guid SesionId { get; set; }
    }
}