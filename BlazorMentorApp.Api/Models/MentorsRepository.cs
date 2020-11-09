using BlazorMentorApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMentorApp.Api.Models
{
    public class MentorsRepository : IMentorRepository
    {
        private readonly AppDbContext appDbContext;

        public MentorsRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Mentors> AddMentors(Mentors mentors)
        {
            var result = await appDbContext.Mentors.AddAsync(mentors);
            await appDbContext.SaveChangesAsync();
             return result.Entity;
        }

        public async Task<Mentors> DeleteMentor(int mentorId)
        {
            var result = await appDbContext.Mentors.FirstOrDefaultAsync(e => e.MentorsId == mentorId);
            if(result != null)
            {
                appDbContext.Mentors.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Mentors>> GetMentors()
        {
            return await appDbContext.Mentors.ToListAsync();
        }

        public Task<Mentors> GetMentor(int mentorId)
        {
            return appDbContext.Mentors.FirstOrDefaultAsync(e => e.MentorsId == mentorId);
        }

        public async Task<Mentors> UpdateMentors(Mentors mentors)
        {
            var result = await appDbContext.Mentors.FirstOrDefaultAsync(e => e.MentorsId == mentors.MentorsId);
            if(result != null)
            {                                                                                    
                result.FirstName = mentors.FirstName;
                result.LastName = mentors.LastName;
                result.Email = mentors.Email;        
                result.PhotoPath = mentors.PhotoPath;
              //  result.Gender = mentors.Gender;
                result.Username = mentors.Username;
              //  result.Qualification = mentors.Qualification;

                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
        }

        public async Task<Mentors> GetMentorByEmail(string email)
        {
            return await appDbContext.Mentors.FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<IEnumerable<Mentors>> Search(string name)
        {
            IQueryable<Mentors> query = appDbContext.Mentors;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name) || e.LastName.Contains(name));
            }

            return await query.ToListAsync();
        }
    }
}
