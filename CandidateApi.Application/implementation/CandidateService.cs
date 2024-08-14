using CandidateApi.Domain.Entities;
using CandidateApi.Application.Interface;
using CandidateApi.Application.Interfaces;

namespace CandidateApi.Application.Services
{
    public class CandidateService: ICandidateService
    {
        private readonly IRepository<Candidate> _repository;

        public CandidateService( IRepository<Candidate> repository)
        {
            _repository = repository;
        }

        public async Task<Candidate> GetCandidateByEmail(string email)
        {
            return (await _repository.FindAsync(c => c.Email == email))!.FirstOrDefault()!;
        }


        public async Task AddOrUpdateCandidateAsync(Candidate candidate)
        {
            var existingCandidate = (await _repository.FindAsync(c => c.Email == candidate.Email)).FirstOrDefault();

            if (existingCandidate == null)
            {
                await _repository.AddAsync(candidate);
            }
            else
            {
                candidate.Id = existingCandidate.Id;
                _repository.UpdateEntityValues(existingCandidate, candidate);

            }

            await _repository.SaveChangesAsync();
        }

    }
}
