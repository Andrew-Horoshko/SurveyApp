using BLL.Exceptions;
using BLL.Services;
using Domain.Models.Surveys;
using Domain.Models.Users;
using Domain;
using Moq;

namespace Tests.Services
{
    [TestFixture]
    public class SurveyServiceTests
    {
        private Mock<ISurveyRepository> _mockSurveyRepo;
        private Mock<IUserRepository> _mockUserRepo;
        private Mock<ISurveyAttemptRepository> _mockSurveyAttemptRepo;
        private SurveyService _service;

        [SetUp]
        public void Setup()
        {
            _mockSurveyRepo = new Mock<ISurveyRepository>();
            _mockUserRepo = new Mock<IUserRepository>();
            _mockSurveyAttemptRepo = new Mock<ISurveyAttemptRepository>();
            _service = new SurveyService(_mockSurveyRepo.Object, _mockUserRepo.Object, _mockSurveyAttemptRepo.Object);
        }

        [Test]
        public async Task CreateSurveyAsync_CreatesAndReturnsSurvey()
        {
            // Arrange
            var newSurvey = new Survey();
            _mockSurveyRepo.Setup(repo => repo.CreateAsync(newSurvey)).ReturnsAsync(newSurvey);

            // Act
            var result = await _service.CreateSurveyAsync(newSurvey);

            // Assert
            Assert.AreEqual(newSurvey, result);
        }

        [Test]
        public async Task GetSurveyAsync_ReturnsSurvey_WhenExists()
        {
            // Arrange
            var surveyId = 1;
            var expectedSurvey = new Survey { SurveyId = surveyId };
            _mockSurveyRepo.Setup(repo => repo.GetByIdAsync(surveyId)).ReturnsAsync(expectedSurvey);

            // Act
            var result = await _service.GetSurveyAsync(surveyId);

            // Assert
            Assert.AreEqual(expectedSurvey, result);
        }

        [Test]
        public void GetSurveyAsync_ThrowsEntityNotFoundException_WhenSurveyDoesNotExist()
        {
            // Arrange
            var surveyId = 1;
            _mockSurveyRepo.Setup(repo => repo.GetByIdAsync(surveyId)).ReturnsAsync((Survey)null);

            // Act & Assert
            Assert.ThrowsAsync<EntityNotFoundException>(async () => await _service.GetSurveyAsync(surveyId));
        }

        [Test]
        public async Task UpdateSurveyAsync_UpdatesSurvey()
        {
            // Arrange
            var survey = new Survey();
            _mockSurveyRepo.Setup(repo => repo.UpdateAsync(survey)).Returns(Task.CompletedTask);

            // Act
            await _service.UpdateSurveyAsync(survey);

            // Assert
            _mockSurveyRepo.Verify(repo => repo.UpdateAsync(survey), Times.Once);
        }

        [Test]
        public async Task DeleteSurveyAsync_DeletesSurvey()
        {
            // Arrange
            var surveyId = 1;
            _mockSurveyRepo.Setup(repo => repo.DeleteAsync(surveyId)).Returns(Task.CompletedTask);

            // Act
            await _service.DeleteSurveyAsync(surveyId);

            // Assert
            _mockSurveyRepo.Verify(repo => repo.DeleteAsync(surveyId), Times.Once);
        }

        [Test]
        public async Task GetAllSurveysAsync_ReturnsAllSurveys()
        {
            // Arrange
            var surveys = new List<Survey> { new Survey(), new Survey() };
            _mockSurveyRepo.Setup(repo => repo.GetAll()).ReturnsAsync(surveys);

            // Act
            var result = await _service.GetAllSurveysAsync();

            // Assert
            Assert.AreEqual(surveys, result);
        }

        [Test]
        public async Task GetUserSurveysAsync_ReturnsUserSurveys_WhenUserExists()
        {
            // Arrange
            var userId = 1;
            var surveys = new List<Survey> { new Survey(), new Survey() };
            var user = new User { UserId = userId, AccessibleSurveys = surveys };
            _mockUserRepo.Setup(repo => repo.GetByIdIncludeSurveysAsync(userId)).ReturnsAsync(user);

            // Act
            var result = await _service.GetUserSurveysAsync(userId);

            // Assert
            Assert.AreEqual(surveys, result);
        }

        [Test]
        public void GetUserSurveysAsync_ThrowsEntityNotFoundException_WhenUserDoesNotExist()
        {
            // Arrange
            var userId = 1;
            _mockUserRepo.Setup(repo => repo.GetByIdIncludeSurveysAsync(userId)).ReturnsAsync((User)null);

            // Act & Assert
            Assert.ThrowsAsync<EntityNotFoundException>(async () => await _service.GetUserSurveysAsync(userId));
        }
    }
}
