using ExampleApi.Data.Models;

namespace ExampleApi.Services.Interfaces
{
    /// <summary>
    /// Crud Service for <see cref="ExampleEntity"/>
    /// </summary>
    public interface IExampleCrudService
    {
        /// <summary>
        /// Creates a new <see cref="ExampleEntity"/>
        /// </summary>
        /// <param name="exampleEntity"></param>
        /// <returns>The created <see cref="ExampleEntity"/></returns>
        Task<ExampleEntity> CreateExampleEntityAsync(ExampleEntity exampleEntity);

        /// <summary>
        /// Deletes an <see cref="ExampleEntity"/>
        /// </summary>
        /// <param name="id">The id of given entity</param>
        /// <returns></returns>
        Task DeleteExampleEntityAsync(Guid id);

        /// <summary>
        /// Reads a <see cref="ExampleEntity"/> by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns><see cref="ExampleEntity"/></returns>
        Task<ExampleEntity> ReadExampleEntityAsync(Guid id);

        /// <summary>
        /// Compares differences and updateds the entity based on its given id
        /// </summary>
        /// <param name="updatedEntity"></param>
        /// <returns>The new <see cref="ExampleEntity"/></returns>
        Task<ExampleEntity> UpdateExampleEntityAsync(ExampleEntity updatedEntity);
    }
}