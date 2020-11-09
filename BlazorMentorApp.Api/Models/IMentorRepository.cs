using BlazorMentorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMentorApp.Api.Models
{
    public interface IMentorRepository
    {
        Task<IEnumerable<Mentors>> Search(string name);
        Task<IEnumerable<Mentors>> GetMentors();
        Task<Mentors> GetMentor(int mentorId);
        Task<Mentors> GetMentorByEmail(string email);
        Task<Mentors> AddMentors(Mentors mentors);
        Task<Mentors> UpdateMentors(Mentors mentors);
        Task<Mentors> DeleteMentor(int mentorId);

    }
}
                         