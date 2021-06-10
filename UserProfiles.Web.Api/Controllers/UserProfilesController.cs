using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using UserProfiles.Domain.Common.Data.DataContext;
using UserProfiles.Domain.Data;
using UserProfiles.Domain.UserProfiles;
using UserProfiles.Domain.UserProfiles.Dtos;
using UserProfiles.Domain.UserProfiles.Services;
using UserProfiles.Web.Api.Models;

namespace UserProfiles.Web.Api.Controllers
{
    [ApiController]
    public class UserProfilesController : BaseController
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfilesController(UnitOfWork<UserProfileDataContext> unitOfWork, IUserProfileService userProfileService) : base(unitOfWork)
        {
            _userProfileService = userProfileService;
        }

        [HttpGet]
        [Route(Routes.UserProfilesList)]
        public IActionResult List()
        {
            var result = _userProfileService.List();
            return Ok(new ApiResponse<IEnumerable<UserProfile>>(result));
        }

        [HttpGet]
        [Route(Routes.UserProfilesGet)]
        public IActionResult Get(Guid id)
        {
            var result = _userProfileService.Get(id);
            if (result == null)
                return NotFound();
            return Ok(new ApiResponse<UserProfile>(result));
        }

        [HttpPost]
        [Route(Routes.UserProfilesCreate)]
        public IActionResult Create([FromBody] UserProfileCreateDto model)
        {
             var result = _userProfileService.Create(model);
            return Ok(new ApiResponse<UserProfile>(result));
        }

        [HttpPut]
        [Route(Routes.UserProfilesUpdate)]
        public IActionResult Update([FromBody] UserProfileUpdateDto model)
        {
            _userProfileService.Update(model);
            return Ok(new ApiResponse());
        }

        [HttpDelete]
        [Route(Routes.UserProfilesDelete)]
        public IActionResult Delete(Guid id)
        {
            _userProfileService.Delete(id);
            return Ok(new ApiResponse());
        }
    }
}