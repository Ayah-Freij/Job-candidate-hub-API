using Job_candidate_hub_API.Features.Candidates.Models;
using Job_candidate_hub_API.Features.Candidates.Repositories;
using Job_candidate_hub_API.Features.Candidates.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_candidate_hub_API_Tests.Features.Candidates.Services
{
    public class CandidateServiceTests
    {
        private readonly Mock<ICandidatesRepository> _candidateRepositoryMock;
        private readonly CandidatesServices _candidateService;

        public CandidateServiceTests()
        {
            _candidateRepositoryMock = new Mock<ICandidatesRepository>();
            _candidateService = new CandidatesServices(_candidateRepositoryMock.Object);
        }
        [Fact]
        public async Task CreateOrUpdateCandidateAsync_CreatesCandidate_WhenCandidateDoesNotExist()
        {        
            // Arrange

            var candidate = new Candidate
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                FreeTextComment = "Test Comment"
            };
            _candidateRepositoryMock.Setup(repo => repo.GetCandidateByEmailAsync(candidate.Email))
               .ReturnsAsync((Candidate)null);

            // Act
            var result = await _candidateService.CreateOrUpdateCandidateAsync(candidate);
            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(candidate, result.Candidate);
            Assert.Null(result.ErrorMessage);
            Assert.Equal(201, result.StatusCode);

            _candidateRepositoryMock.Verify(repo => repo.CreateCandidateAsync(candidate), Times.Once);
            _candidateRepositoryMock.Verify(repo => repo.UpdateCandidateAsync(It.IsAny<Candidate>()), Times.Never);
      

        }
        [Fact]
        public async Task CreateOrUpdateCandidateAsync_UpdatesCandidate_WhenCandidateExists()
        {
            // Arrange
            var existingCandidate = new Candidate
            {
               
                FirstName = "Jane",
                LastName = "Doe",
                Email = "jane.doe@example.com",
                FreeTextComment = "Existing Comment"
            };

            _candidateRepositoryMock.Setup(repo => repo.GetCandidateByEmailAsync(existingCandidate.Email))
                .ReturnsAsync(existingCandidate);

            // Act
            var result = await _candidateService.CreateOrUpdateCandidateAsync(existingCandidate);

            // Assert
            Assert.True(result.IsSuccess, "The update operation should succeed.");
            Assert.Equal(existingCandidate, result.Candidate);
            Assert.Null(result.ErrorMessage);
            Assert.Equal(200, result.StatusCode);
            _candidateRepositoryMock.Verify(repo => repo.CreateCandidateAsync(It.IsAny<Candidate>()), Times.Never);
            _candidateRepositoryMock.Verify(repo => repo.UpdateCandidateAsync(existingCandidate), Times.Once);
        }
    }

}
