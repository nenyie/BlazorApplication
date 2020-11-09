                                                                                   using System;
using System.ComponentModel.DataAnnotations;
namespace BlazorMentorApp.Models
{
    public class Mentors
    {
        public int MentorsId { get; set; }

        [Required]
        [MinLength(4)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        
        public string Email { get; set; }
       // public Gender Gender { get; set; }
        public string PhotoPath { get; set; }
       // public Qualification Qualification { get; set; }                                                                                                                       
    }
}
