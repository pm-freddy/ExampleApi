using ExampleApi.Data;
using ExampleApi.Data.Models;
using ExampleApi.Data.Models.Interfaces;
using ExampleApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExampleApi.Services
{
    public class ExampleCrudService : IExampleCrudService
    {
        private readonly ExampleDbContext _dbContext;

        public ExampleCrudService(ExampleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ExampleEntity> CreateExampleEntityAsync(ExampleEntity exampleEntity)
        {
            try
            {

                var savedEntity = await _dbContext.Examples.AddAsync(exampleEntity);

                //TODO: Add Exception Handling

                await _dbContext.SaveChangesAsync();

                return savedEntity.Entity;
            }
            catch (Exception ex)
            {

                throw new Exception("Exception handling needs to be added");

            }
        }

        public async Task DeleteExampleEntityAsync(Guid id)
        {
            try
            {

                var entity = await ReadExampleEntityAndCheckNullAsync(id);

                _dbContext.Examples.Remove(entity);

                await _dbContext.SaveChangesAsync();

                // can do a return of a boolean or something else, to confirm the deletion
            }
            catch (Exception ex)
            {
                throw new Exception("Exception handling needs to be added");
            }

        }

        public async Task<ExampleEntity> ReadExampleEntityAsync(Guid id)
        {
            try
            {
                return await ReadExampleEntityAndCheckNullAsync(id);
            }
            catch (Exception ex)
            {

                throw new Exception("Exception handling needs to be added");

            }
        }

        // I used the generic method in this case to showcase the use of it
        public async Task<ExampleEntity> UpdateExampleEntityAsync(ExampleEntity updatedEntity)
        {
            try
            {

                var existingEntity = await ReadEntityAndCheckNullAsync<ExampleEntity>(updatedEntity.Id) as ExampleEntity;

                if (existingEntity is null)
                {
                    throw new ArgumentNullException(nameof(ExampleEntity));
                }

                if (_dbContext.Entry(existingEntity).CurrentValues != _dbContext.Entry(updatedEntity).CurrentValues)
                {
                    _dbContext.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
                    await _dbContext.SaveChangesAsync();
                }

                return existingEntity;
            }
            catch (Exception ex)
            {

                throw new Exception("Exception handling needs to be added");

            }
        }

        //Should be made generic and put in common library or DbContext Class, see example generic method below
        private async Task<ExampleEntity> ReadExampleEntityAndCheckNullAsync(Guid id)
        {
            var entity = await _dbContext.Examples.FirstOrDefaultAsync(e => e.Id == id);

            if (entity is null)
            {
                throw new KeyNotFoundException($"Entity with ID {id} not found.");
            }

            return entity;
        }

        //Example generic method for upper method
        private async Task<IBaseEntity> ReadEntityAndCheckNullAsync<TEntity>(Guid id)
            where TEntity : BaseEntity
        {
            var entity = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(entity => entity.Id == id);

            if (entity is null)
            {
                throw new Exception("Throw a null exepction here or handle the exception");
            }

            return entity;
        }
    }
}
