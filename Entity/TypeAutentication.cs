namespace Entity
{
    /// <summary>
    /// Tipo de autenticacion
    /// </summary>
    public enum TypeAutentication
    {
        Default = 0,

        /// <summary>
        /// Usuario no encontrado
        /// </summary>
        NotFound = 1,

        /// <summary>
        /// Autenticado Correctamente
        /// </summary>
        Ok = 2,

        /// <summary>
        /// Usuario Inactivo
        /// </summary>
        Inactive = 3,

        /// <summary>
        /// Usuario Bloqueado
        /// </summary>
        Locked = 4,

        /// <summary>
        /// Cambio de contraseña
        /// </summary>
        ChangePw = 5
    }
}