using BlazorMentorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Components;


namespace BlazorMentorApp.Web.Services
{
    public class MentorService : IMentorService
    {
        private readonly HttpClient httpClient;

        public MentorService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Mentors> GetMentor(int id)
        {
            return await httpClient.GetJsonAsync<Mentors>($"api/mentors/{id}");
        }

        public async Task<IEnumerable<Mentors>> GetMentors()
        {
            return await httpClient.GetJsonAsync<Mentors[]>("api/mentors");
        }
    }
}
