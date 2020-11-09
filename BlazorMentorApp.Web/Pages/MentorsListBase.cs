using BlazorMentorApp.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorMentorApp.Web.Services;

namespace BlazorMentorApp.Web.Pages
{
    public class MentorsListBase : ComponentBase
    {
        [Inject]
        public IMentorService Mentorservice { get; set; }
        public IEnumerable<Mentors> Mentors { get; set; }

        //  protected override Task OnInitializedAsync()
        // {
        //     LoadMentors();
        //     return base.OnInitializedAsync();
        //  }

        protected override async Task OnInitializedAsync()
        {
            Mentors = (await Mentorservice.GetMentors());
           
          //  await Task.Run(LoadMentors);
        }

        /*
        private void LoadMentors()
        {
            Mentors m1 = new Mentors
            {
                MentorsId = 1,
                FirstName = "john",
                LastName = "wick",
                Email = "johnWick@gmail.com",
              //  Gender = Gender.Male,
                Username = "JW",
                PhotoPath = "images/car2.jpeg"
            };

            Mentors m2 = new Mentors
            {
                MentorsId = 1,
                FirstName = "jane",
                LastName = "wick",
                Email = "janeWick@gmail.com",
             //   Gender = Gender.Female,
                Username = "JW",
                PhotoPath = "images/car3.jpeg"
            };

            MentorList = new List<Mentors> { m1, m2 };
               
        }

        */
    }
}
