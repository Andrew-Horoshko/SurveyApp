using BLL.Exceptions;
using BLL.Services;
using Domain.Models.Surveys;
using Domain;
using Moq;
namespace Tests.Services
{
    [TestFixture]
    public class SurveyRatingServiceTests
    {
        private Mock<ISurveyRatingRepository> _mockSurveyRatingRepo;
        private Mock<ISurveyRepository> _mockSurveyRepo;
        private SurveyRatingService _service;

        [SetUp]
        public void Setup()
        {
            _mockSurveyRatingRepo = new Mock<ISurveyRatingRepository>();
            _mockSurveyRepo = new Mock<ISurveyRepository>();
            _service = new SurveyRatingService(_mockSurveyRatingRepo.Object, _mockSurveyRepo.Object);
        }

        [Test]
        public async Task CreateSurveyRatingAsync_ReturnsNewSurveyRating_AndUpdatesAverage()
        {
            // Arrange
            var surveyRating = new SurveyRating { SurveyId = 1, Mark = SurveyMarks.VeryGood };
            _mockSurveyRatingRepo.Setup(repo => repo.CreateAsync(surveyRating)).ReturnsAsync(surveyRating);
            _mockSurveyRatingRepo.Setup(repo => repo.GetBySurveyIdAsync(surveyRating.SurveyId)).ReturnsAsync(new List<SurveyRating> { surveyRating });
            var survey = new Survey { SurveyId = 1 };
            _mockSurveyRepo.Setup(repo => repo.GetByIdAsync(surveyRating.SurveyId)).ReturnsAsync(survey);
            _mockSurveyRepo.Setup(repo => repo.UpdateAsync(survey)).Returns(Task.CompletedTask);

            // Act
            var result = await _service.CreateSurveyRatingAsync(surveyRating);

            // Assert
            Assert.AreEqual(surveyRating, result);
            _mockSurveyRepo.Verify(repo => repo.UpdateAsync(It.IsAny<Survey>()), Times.Once);
        }

        [Test]
        public async Task GetSurveyRatingAsync_ReturnsSurveyRating_WhenExists()
        {
            // Arrange
            var surveyRatingId = 1;
            var surveyRating = new SurveyRating { SurveyRatingId = surveyRatingId };
            _mockSurveyRatingRepo.Setup(repo => repo.GetByIdAsync(surveyRatingId)).ReturnsAsync(surveyRating);

            // Act
            var result = await _service.GetSurveyRatingAsync(surveyRatingId);

            // Assert
            Assert.AreEqual(surveyRating, result);
        }

        [Test]
        public void GetSurveyRatingAsync_ThrowsEntityNotFoundException_WhenRatingDoesNotExist()
        {
            // Arrange
            _mockSurveyRatingRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((SurveyRating)null);

            // Act & Assert
            Assert.ThrowsAsync<EntityNotFoundException>(async () => await _service.GetSurveyRatingAsync(1));
        }

        [Test]
        public async Task UpdateSurveyRatingAsync_UpdatesRating_AndUpdatesAverage()
        {
            // Arrange
            var surveyRating = new SurveyRating { SurveyId = 1, Mark = SurveyMarks.Good };
            _mockSurveyRatingRepo.Setup(repo => repo.UpdateAsync(surveyRating)).Returns(Task.CompletedTask);
            _mockSurveyRatingRepo.Setup(repo => repo.GetBySurveyIdAsync(surveyRating.SurveyId)).ReturnsAsync(new List<SurveyRating> { surveyRating });
            var survey = new Survey { SurveyId = 1 };
            _mockSurveyRepo.Setup(repo => repo.GetByIdAsync(surveyRating.SurveyId)).ReturnsAsync(survey);
            _mockSurveyRepo.Setup(repo => repo.UpdateAsync(survey)).Returns(Task.CompletedTask);

            // Act
            await _service.UpdateSurveyRatingAsync(surveyRating);

            // Assert
            _mockSurveyRepo.Verify(repo => repo.UpdateAsync(It.IsAny<Survey>()), Times.Once);
        }

        [Test]
        public async Task GetAllSurveyRatingsAsync_ReturnsAllRatings()
        {
            // Arrange
            var surveyRatings = new List<SurveyRating> { new SurveyRating(), new SurveyRating() };
            _mockSurveyRatingRepo.Setup(repo => repo.GetAll()).ReturnsAsync(surveyRatings);

            // Act
            var result = await _service.GetAllSurveyRatingsAsync();

            // Assert
            Assert.AreEqual(surveyRatings, result);
        }
    }
}
