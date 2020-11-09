using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using BlazorMentorApp.Web.Services;
using BlazorMentorApp.Models;

namespace BlazorMentorApp.Web.Pages
{
    public class MentorsDetailsBase : ComponentBase
    {    

        [inject]
        public IMentorService MentorService { get; set; }

        public Mentors Mentors { get; set; } = new Mentors();

       [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
           Mentors =  await MentorService.GetMentor(int.Parse(Id));
        }
    }
}
