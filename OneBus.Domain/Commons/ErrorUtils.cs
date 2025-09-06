namespace OneBus.Domain.Commons
{
    public static class ErrorUtils
    {
        /// <summary>
        /// {Campo} já existe.
        /// </summary>
        /// <returns></returns>
        public static Error AlreadyExists(string field)
        {
            return new Error($"{field} já existe.", field);
        }

        /// <summary>
        /// Registro não encontrado.
        /// </summary>
        /// <returns></returns>
        public static Error EntityNotFound(string field = "id")
        {
            return new Error("Registro não encontrado.", field);
        }

        /// <summary>
        /// Valor inválido.
        /// </summary>
        /// <returns></returns>
        public static Error InvalidParameter(string field = "id")
        {
            return new Error("Valor inválido.", field);
        }

        /// <summary>
        /// Id da rota e Id do corpo estão diferentes.
        /// </summary>
        /// <returns></returns>
        public static Error IdConflict()
        {
            return new Error("Id da rota e Id do corpo estão diferentes.", "ids");
        }
    }
}
