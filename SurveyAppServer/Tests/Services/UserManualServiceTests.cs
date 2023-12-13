using BLL.Exceptions;
using BLL.Services;
using Domain.Models.Surveys;
using Domain;
using Moq;

namespace Tests.Services
{
    [TestFixture]
    public class UserManualServiceTests
    {
        private Mock<IUserManualRepository> _mockUserManualRepo;
        private UserManualService _service;

        [SetUp]
        public void Setup()
        {
            _mockUserManualRepo = new Mock<IUserManualRepository>();
            _service = new UserManualService(_mockUserManualRepo.Object);
        }

        [Test]
        public async Task CreateUserManualAsync_CreatesAndReturnsUserManual()
        {
            // Arrange
            var newUserManual = new UserManual();
            _mockUserManualRepo.Setup(repo => repo.CreateAsync(newUserManual)).ReturnsAsync(newUserManual);

            // Act
            var result = await _service.CreateUserManualAsync(newUserManual);

            // Assert
            Assert.AreEqual(newUserManual, result);
        }

        [Test]
        public async Task GetUserManualAsync_ReturnsUserManual_WhenExists()
        {
            // Arrange
            var userManualId = 1;
            var expectedUserManual = new UserManual { UserManualId = userManualId };
            _mockUserManualRepo.Setup(repo => repo.GetByIdAsync(userManualId)).ReturnsAsync(expectedUserManual);

            // Act
            var result = await _service.GetUserManualAsync(userManualId);

            // Assert
            Assert.AreEqual(expectedUserManual, result);
        }

        [Test]
        public void GetUserManualAsync_ThrowsEntityNotFoundException_WhenUserManualDoesNotExist()
        {
            // Arrange
            var userManualId = 1;
            _mockUserManualRepo.Setup(repo => repo.GetByIdAsync(userManualId)).ReturnsAsync((UserManual)null);

            // Act & Assert
            Assert.ThrowsAsync<EntityNotFoundException>(async () => await _service.GetUserManualAsync(userManualId));
        }

        [Test]
        public async Task UpdateUserManualAsync_UpdatesUserManual()
        {
            // Arrange
            var userManual = new UserManual();
            _mockUserManualRepo.Setup(repo => repo.UpdateAsync(userManual)).Returns(Task.CompletedTask);

            // Act
            await _service.UpdateUserManualAsync(userManual);

            // Assert
            _mockUserManualRepo.Verify(repo => repo.UpdateAsync(userManual), Times.Once);
        }

        [Test]
        public async Task DeleteUserManualAsync_DeletesUserManual()
        {
            // Arrange
            var userManualId = 1;
            _mockUserManualRepo.Setup(repo => repo.DeleteAsync(userManualId)).Returns(Task.CompletedTask);

            // Act
            await _service.DeleteUserManualAsync(userManualId);

            // Assert
            _mockUserManualRepo.Verify(repo => repo.DeleteAsync(userManualId), Times.Once);
        }

        [Test]
        public async Task GetUserManualBySurveyIdAsync_ReturnsUserManual_WhenExists()
        {
            // Arrange
            var surveyId = 1;
            var expectedUserManual = new UserManual { SurveyId = surveyId };
            _mockUserManualRepo.Setup(repo => repo.GetBySurveyIdAsync(surveyId)).ReturnsAsync(expectedUserManual);

            // Act
            var result = await _service.GetUserManualBySurveyIdAsync(surveyId);

            // Assert
            Assert.AreEqual(expectedUserManual, result);
        }

        [Test]
        public void GetUserManualBySurveyIdAsync_ThrowsEntityNotFoundException_WhenUserManualDoesNotExist()
        {
            // Arrange
            var surveyId = 1;
            _mockUserManualRepo.Setup(repo => repo.GetBySurveyIdAsync(surveyId)).ReturnsAsync((UserManual)null);

            // Act & Assert
            Assert.ThrowsAsync<EntityNotFoundException>(async () => await _service.GetUserManualBySurveyIdAsync(surveyId));
        }
    }
}
