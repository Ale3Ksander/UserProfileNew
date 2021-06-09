using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserProfiles.Domain.Common.Data.DataContext;
using UserProfiles.Domain.UserProfiles.Services;

namespace UserProfiles.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfilesController : ControllerBase
    {
        //private readonly UserProfileDataContext _context;
        private readonly IUserProfileService _userProfileService;

        public UserProfilesController(/*UserProfileDataContext context,*/ IUserProfileService userProfileService)
        {
            //_context = context;
            _userProfileService = userProfileService;
        }

        [HttpGet]
        public IActionResult List()
        {
            var result = _userProfileService.List();
            return Ok(result);
        }

    }
}