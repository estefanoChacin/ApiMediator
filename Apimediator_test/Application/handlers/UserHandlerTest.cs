using Moq;
using ApiMediator.Domain.Interfaces;
using ApiMediator.Infrastructure.Model;
using ApiMediator.Application.Command;
using ApiMediator.Application.Handlers;

namespace Apimediator_test.Application.handlers
{
    public class UserHandlerTest
    {
        [Fact]
        public async Task UserCreateHandlerTest()
        {
            //Arranque
            var mockRepository = new Mock<IDBRepository<UserModel>>();
            var createuserCommand = new UserCreateCommand()
            {
                UserName = "TestUser",
                Password = "12345",
                Email = "test@gmail.com",
                ProductLastFour = "1234"
            };
            mockRepository.Setup(e => e.CreateAsync(It.IsAny<UserModel>())).ReturnsAsync(It.IsAny<UserModel>());
            var handler = new UserCreateHandler(mockRepository.Object);
            var result = await handler.Handle(createuserCommand, CancellationToken.None);
            Assert.NotNull(result.Data);
            Assert.True(result.Status);
        }

        [Fact]
        public async Task UserCreateHandlerTest_Excepcion()
        {
            //Arranque
            var mockRepository = new Mock<IDBRepository<UserModel>>();
            var createuserCommand = new UserCreateCommand()
            {
                UserName = "TestUser",
                Password = "12345",
                Email = "test@gmail.com",
                ProductLastFour = "1234"
            };

            mockRepository.Setup(e => e.CreateAsync(It.IsAny<UserModel>())).Callback(() => throw new Exception("Error creating user."));
            var handler = new UserCreateHandler(mockRepository.Object);
            var exception = await Assert.ThrowsAsync<Exception>(() => handler.Handle(createuserCommand, CancellationToken.None));
            Assert.Equal("Error creating user: Error creating user.", exception.Message);
        }

        [Fact]
        public async Task UserByIdHandlerTest()
        {
            var mockRepository = new Mock<IDBRepository<UserModel>>();
            var userId = "12345";
            var user = new UserModel
            {
                Id = userId,
                UserName = "TestUser",
                Password = "12345",
                Email = ""
            };
            mockRepository.Setup(e => e.GetByIdAsync(userId)).ReturnsAsync(user);
            var handler = new UserByIdHandler(mockRepository.Object);
            var result = await handler.Handle(new UserByIdCommand(){UserId = userId}, CancellationToken.None);
            Assert.NotNull(result.Data);
            Assert.True(result.Status);
            Assert.Equal(userId, result.Data?.Id);
        }
        

        [Fact]
        public async Task UserByIdHandlerTest_Exception()
        {
            var mockRepository = new Mock<IDBRepository<UserModel>>();
            var userId = "12345";
            var user = new UserModel
            {
                Id = userId,
                UserName = "TestUser",
                Password = "12345",
                Email = ""
            };
            mockRepository.Setup(e => e.GetByIdAsync(userId)).Callback( () => throw new Exception("Error retrieving user."));
            var handler = new UserByIdHandler(mockRepository.Object);
            var excepcion = await Assert.ThrowsAsync<Exception>(() => handler.Handle(new UserByIdCommand(){UserId = userId}, CancellationToken.None));
        }
    }
}