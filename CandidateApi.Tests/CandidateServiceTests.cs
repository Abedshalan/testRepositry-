using Moq;
using Xunit;
using CandidateApi.Application.Interfaces;
using CandidateApi.Application.Services;
using CandidateApi.Domain.Entities;

public class CandidateServiceTests
{
    private readonly Mock<ICandidateRepository> _mockRepo;
    private readonly CandidateService _service;

    public CandidateServiceTests()
    {
        _mockRepo = new Mock<ICandidateRepository>();
        _service = new CandidateService(_mockRepo.Object);
    }

    [Fact]
    public async Task GetCandidateByEmail_ReturnsCandidate_WhenCandidateExists()
    {
        // Arrange
        var email = "test@example.com";
        var candidate = new Candidate { Id = 1, Email = email };
        _mockRepo.Setup(repo => repo.GetByEmail(email))
                 .ReturnsAsync(candidate);

        // Act
        var result = await _service.GetCandidateByEmail(email);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(email, result.Email);
    }
}
