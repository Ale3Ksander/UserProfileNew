using Microsoft.AspNetCore.Mvc;
using UserProfiles.Domain.Common.Data.DataContext;
using UserProfiles.Domain.Data;
using UserProfiles.Web.Api.Models;

namespace UserProfiles.Web.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly UnitOfWork<UserProfileDataContext> _unitOfWork;

        public BaseController(UnitOfWork<UserProfileDataContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected new IActionResult Ok()
        {
            _unitOfWork.Commit(false);
            return base.Ok(new ApiResponse());
        }

        protected IActionResult Ok<T>(T result) where T : class
        {
            _unitOfWork.Commit(false);
            return base.Ok(result);
        }
    }
}