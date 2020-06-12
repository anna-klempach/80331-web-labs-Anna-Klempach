using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab1_Klempach.DAL.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace Lab1_Klempach.Controllers
{
    public class UserImageController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        IWebHostEnvironment _env;

        public UserImageController(UserManager<ApplicationUser> userManager,
            IWebHostEnvironment env)
        {
            _userManager = userManager;
            _env = env;
        }

        public async Task<IActionResult> GetUserImage()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.UserImage != null && user.ImageMimeType != null)
            {
                return File(user.UserImage, user.ImageMimeType);
            }
            else
            {
                var avatarPath = "/Images/avatar.png";
                var extProvider = new FileExtensionContentTypeProvider();
                var mimeType = extProvider.Mappings[".png"];
                return File(_env.WebRootFileProvider
                    .GetFileInfo(avatarPath)
                    .CreateReadStream(),
                    mimeType
                );
            }
        }
    }
}
