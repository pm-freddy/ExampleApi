using ExampleApi.Data;
using ExampleApi.Data.Models;
using ExampleApi.Services;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest.UnitTests
{
    [TestFixture]
    public class ExampleCrudServiceTests
    {
        private ExampleDbContext _dbContext;
        private ExampleCrudService _sut;

        private List<ExampleEntity> _examples = [
            new ExampleEntity(){
                Id = Guid.Parse("3ec32418-45d8-4906-a659-300c5d26b2ca"),
                ExampleName = "TestEntity1"
            },
            new ExampleEntity(){
                Id = Guid.Parse("10f7d6de-dc24-4d72-98f9-e566705cc9de"),
                ExampleName = "TestEntity2"
            }
        ];

        [SetUp]
        public async Task SetupAsync()
        {
            // using an in-memory database for a test mock isn't best practice, especially when dealt with big data. In this example case it is okay to work with it
            var options = new DbContextOptionsBuilder<ExampleDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _dbContext = new ExampleDbContext(options);

            await _dbContext.Database.EnsureCreatedAsync();

            await SeedDatabaseAsync();

            _sut = new ExampleCrudService(_dbContext);
        }

        private async Task SeedDatabaseAsync()
        {
            foreach (var example in _examples)
            {
                await _dbContext.Examples.AddAsync(example);
            }

            await _dbContext.SaveChangesAsync();
        }

        [Test]
        public async Task CreateExampleEntityAsync_ShouldAddEntity()
        {

            var newEntity = new ExampleEntity { Id = Guid.NewGuid(), ExampleName = "NewEntity" };

            var result = await _sut.CreateExampleEntityAsync(newEntity);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Id, Is.EqualTo(newEntity.Id));
            });

            var storedEntity = await _dbContext.Examples.FindAsync(newEntity.Id);

            Assert.That(storedEntity, Is.Not.Null);
        }

        [Test]
        public async Task CreateExampleEntityAsync_ShouldReadEntity()
        {
            foreach(var example in _examples)
            {
                var result = await _sut.ReadExampleEntityAsync(example.Id);
                
                Assert.That(result, Is.Not.Null);

            }
        }

        [Test]
        public void ReadExampleEntityAsync_ShouldThrowException_WhenEntityNotFound()
        {
            var nonExistingId = Guid.NewGuid();

            Assert.ThrowsAsync<KeyNotFoundException>(async () => await _sut.ReadExampleEntityAsync(nonExistingId));
        }

        [Test]
        public async Task CreateExampleEntityAsync_ShouldDeleteEntity()
        {

            foreach (var example in _examples)
            {
                await _sut.DeleteExampleEntityAsync(example.Id);

                var storedEntity = await _dbContext.Examples.FindAsync(example.Id);
                Assert.That(storedEntity, Is.Null);
            }
        }

        [Test]
        public void DeleteExampleEntityAsync_ShouldThrowException_WhenEntityNotFound()
        {
            var nonExistingId = Guid.NewGuid();

            Assert.ThrowsAsync<KeyNotFoundException>(async () => await _sut.DeleteExampleEntityAsync(nonExistingId));
        }

        [Test]
        public async Task CreateExampleEntityAsync_ShouldUpdateEntity()
        {
            foreach (var example in _examples)
            {
                var updatedEntity = new ExampleEntity { Id = example.Id, ExampleName = "UpdatedEntity" };

                var result = await _sut.UpdateExampleEntityAsync(updatedEntity);

                Assert.Multiple(() =>
                {
                    Assert.That(result, Is.Not.Null);
                    Assert.That(result.ExampleName, Is.EqualTo(updatedEntity.ExampleName));
                });


                var storedEntity = await _dbContext.Examples.FindAsync(example.Id);
                Assert.That(storedEntity.ExampleName, Is.EqualTo(updatedEntity.ExampleName));
            }

        }

        [TearDown]
        public async Task CleanupAsync()
        {
            await _dbContext.Database.EnsureDeletedAsync();
            await _dbContext.DisposeAsync();
        }
    }
}