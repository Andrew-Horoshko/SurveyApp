using BLL.Exceptions;
using BLL.Services;
using Domain;
using Domain.Models.Answers;
using Domain.Models.Questions;
using Microsoft.Extensions.Logging;
using Moq;

namespace Tests.Services
{
        [TestFixture]
        public class QuestionBaseServiceTests
        {
            private Mock<IBaseQuestionRepository> _mockRepo;
            private Mock<ILogger<BaseQuestionService>> _mockLogger;
            private BaseQuestionService _service;

            [SetUp]
            public void Setup()
            {
                _mockRepo = new Mock<IBaseQuestionRepository>();
                _mockLogger = new Mock<ILogger<BaseQuestionService>>();
                _service = new BaseQuestionService(_mockRepo.Object, _mockLogger.Object);
            }

            [Test]
            public async Task GetQuestionAnswersAsync_ReturnsAnswers_WhenQuestionExists()
            {
                var questionId = 1;
                var expectedAnswers = new List<Answer> { new Answer(), new Answer() };
                var question = new SingleChoiceQuestion { Answers = expectedAnswers };
                _mockRepo.Setup(repo => repo.GetByIdIncludeAnswersAsync(questionId)).ReturnsAsync(question);

                var result = await _service.GetQuestionAnswersAsync(questionId);

                Assert.AreEqual(expectedAnswers, result);
            }

            [Test]
            public void GetQuestionAnswersAsync_ThrowsEntityNotFoundException_WhenQuestionDoesNotExist()
            {
                _mockRepo.Setup(repo => repo.GetByIdIncludeAnswersAsync(It.IsAny<int>())).ReturnsAsync((BaseQuestion)null);

                Assert.ThrowsAsync<EntityNotFoundException>(async () => await _service.GetQuestionAnswersAsync(1));
            }

            [Test]
            public void GetQuestionDescriptionAsync_ThrowsEntityNotFoundException_WhenQuestionDoesNotExist()
            {
                _mockRepo.Setup(repo => repo.GetByIdIncludeAnswersAsync(It.IsAny<int>())).ReturnsAsync((BaseQuestion)null);

                Assert.ThrowsAsync<EntityNotFoundException>(async () => await _service.GetQuestionDescriptionAsync(1));
            }
        }
    }