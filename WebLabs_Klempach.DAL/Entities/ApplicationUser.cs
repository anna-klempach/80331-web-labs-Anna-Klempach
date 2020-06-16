using Microsoft.AspNetCore.Identity;

namespace WebLabs_Klempach.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public byte[] UserImage { get; set; }
        public string ImageMimeType { get; set; }
    }
}
