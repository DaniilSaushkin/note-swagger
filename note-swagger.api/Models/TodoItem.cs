namespace note_swagger.api.DTO
{
    /// <summary>
    /// Model of item
    /// </summary>
    public sealed class TodoItem
    {
        /// <summary>
        /// Identifier of item
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Name of item
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Description of item
        /// </summary>
        public string? Description { get; set; }
    }
}
