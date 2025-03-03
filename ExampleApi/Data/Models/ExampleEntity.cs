namespace ExampleApi.Data.Models
{
    /// <summary>
    /// Example Entity with an 1 to n relationship to <see cref="ExampleConnectedEntity"/>
    /// </summary>
    public class ExampleEntity : BaseEntity
    {
        public string ExampleName { get; set; } = string.Empty;

        public string ExampleDescription { get; set; } = string.Empty;

        public List<ExampleConnectedEntity> ConnectedEntities { get; set; } = new List<ExampleConnectedEntity>();
    }
}
