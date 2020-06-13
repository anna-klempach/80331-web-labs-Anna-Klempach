using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebLabs_Klempach.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public byte[] UserImage { get; set; }
        public string ImageMimeType { get; set; }
    }
}
