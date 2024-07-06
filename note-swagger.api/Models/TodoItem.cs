namespace note_swagger.api.DTO
{
    /// <summary>
    /// Модель пункта задачи.
    /// </summary>
    public sealed class TodoItem
    {
        /// <summary>
        /// Идентификатор пункта.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Наименование пункта.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Описание задачи.
        /// </summary>
        public string? Description { get; set; }
    }
}
