namespace OneBus.Domain.Commons
{
    public static class ErrorUtils
    {
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
