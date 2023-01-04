using System.ComponentModel.DataAnnotations;

namespace TextingGameMVC.Models
{
    public class tblUser
    {
        public int UserId { get; set; }
    
        public string? UserName { get; set; }

        public string EmailId { get; set; } = null!;
   
        public string? Password { get; set; }
     
        public string? MobileNo { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

    }
}
