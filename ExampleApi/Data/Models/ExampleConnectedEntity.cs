namespace ExampleApi.Data.Models
{
    /// <summary>
    /// Example Class for a 1 to n relationship in code-first database
    /// </summary>
    public class ExampleConnectedEntity : BaseEntity
    {
        public string ConnectedName { get; set; } = string.Empty;
        public string ConnectedDescription { get; set; } = string.Empty;

        public Guid ExampleEntityId { get; set; }

        public ExampleEntity ExampleEntity { get; set; } = default!;
    }
}
