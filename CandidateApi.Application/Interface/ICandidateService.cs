using System;
using CandidateApi.Domain.Entities;

namespace CandidateApi.Application.Interface
{
	public interface ICandidateService
	{
        Task AddOrUpdateCandidateAsync(Candidate candidate);
        Task<Candidate> GetCandidateByEmail(string email);
    }
}

