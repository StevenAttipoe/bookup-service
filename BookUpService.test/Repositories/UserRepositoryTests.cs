using bookup_service.Models;
using bookup_service.Repositories;
using Xunit;
using Moq;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BookUpService.test
{

    public class UserRepositoryTests
    {
        [Fact]
        public void CreateUser_Should_Add_User_To_DbSet_And_SaveChanges()
        {
            // Arrange
            var user = new User(0, "John Doe", "john.doe@mail.com", "password");

            var configurationMock = new Mock<IConfiguration>();

            var dbContextMock = new Mock<ApplicationDbContext>(configurationMock.Object);

            var dbSetMock = new Mock<DbSet<User>>();
            dbContextMock.Setup(db => db.Set<User>()).Returns(dbSetMock.Object);

            var userRepository = new UserRepository(dbContextMock.Object);

            // Act
            userRepository.CreateUser(user);

            // Assert
            dbSetMock.Verify(dbSet => dbSet.Add(user), Times.Once);
            dbContextMock.Verify(dbContext => dbContext.SaveChanges(), Times.Once);
        }

    }
}

