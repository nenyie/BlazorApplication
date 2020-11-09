using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorMentorApp.Models;

namespace BlazorMentorApp.Web.Services
{
    public interface IMentorService
    {
        Task<IEnumerable<Mentors>> GetMentors();
        Task<Mentors> GetMentor(int id);
    }
}
