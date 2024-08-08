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
    }

}
