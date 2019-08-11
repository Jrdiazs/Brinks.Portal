namespace Entity.Request
{
    /// <summary>
    /// Modelo para autenticar
    /// </summary>
    public class Login
    {
        /// <summary>
        /// Nombre de usuario
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Contraseña del usuario
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Ip local del usuario
        /// </summary>
        public string Ip { get; set; }
    }
}