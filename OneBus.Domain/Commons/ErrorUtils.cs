namespace OneBus.Domain.Commons
{
    public static class ErrorUtils
    {
        /// <summary>
        /// Entidade não encontrada.
        /// </summary>
        /// <returns></returns>
        public static Error EntityNotFound()
        {
            return new Error("Entidade não encontrada.", "id");
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
