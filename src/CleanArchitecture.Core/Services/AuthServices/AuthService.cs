using CleanArchitecture.Core.Domain.Entities;
using CleanArchitecture.Core.Domain.Models.Auth;
using CleanArchitecture.Core.Interfaces.AuthServices;
using CleanArchitecture.Core.Interfaces.CookieServices;
using CleanArchitecture.Core.Interfaces.TokenService;
using CleanArchitecture.Shared.Common.Exceptions;
using CleanArchitecture.Shared.CrossCuttingConcerns.Dtos.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CleanArchitecture.Core.Services.AuthServices
{
    public class AuthService(
        UserManager<ApplicationUser> _userManager,
        ITokenService _tokenService, 
        IHttpContextAccessor _httpContextAccessor,
        ICookieService _cookieService) : IAuthService
    {
        public async Task<ApiResult<UserProfileResponse>> GetProfile(CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);;
            if (userId == null) throw UserException.UserUnauthorizedException();

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) throw UserException.UserUnauthorizedException();

            var roles = await _userManager.GetRolesAsync(user);
            if (roles == null) throw UserException.InternalServerException();

            var respnse = new UserProfileResponse
            {
                UserName = user.UserName!,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Avatar = user.Avatar,
                Role = roles.FirstOrDefault()!
            };

            return new ApiSuccessResult<UserProfileResponse>(respnse);
        }

        public bool Logout()
        {
            try
            {
                _ = _cookieService.Get();
                _cookieService.Delete();

                return true;
            }
            catch 
            {
                throw UserException.InternalServerException();
            }
        }

        public async Task<ApiResult<string>> RefreshToken()
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier); ;
            if (userId == null) throw UserException.UserUnauthorizedException();

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) throw UserException.InternalServerException();

            var accessToken = _tokenService.GenerateToken(user);
            _cookieService.Set(accessToken);

            return new ApiSuccessResult<string>(accessToken);
        }

        public async Task<ApiResult<UserSignInResponse>> SignIn(UserSignInRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) throw UserException.UserUnauthorizedException();

            var isValidPassword = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!isValidPassword) throw UserException.UserUnauthorizedException();

            var token = _tokenService.GenerateToken(user);
            _cookieService.Set(token);

            var response = new UserSignInResponse
            {
                UserName = user.UserName!,
                Email = user.Email,
                FirstName = user.FirstName,
                Token = token
            };

            return new ApiSuccessResult<UserSignInResponse>(response);
        }

        public async Task<ApiResult<UserSignUpResponse>> SignUp(UserSignUpRequest request, CancellationToken cancellatoinToken)
        {
            var isUserNameExists = await _userManager.FindByNameAsync(request.UserName) != null;
            if (isUserNameExists) throw UserException.UserAlreadyExistsException("User Name");

            var isEmailExists = await _userManager.FindByEmailAsync(request.Email) != null;
            if (isEmailExists) throw UserException.UserAlreadyExistsException("Email");

            //using var transaction = await _unitOfWork.BeginTransactionAsync(cancellatoinToken);
            //try
            //{
            //    var user = await _userManager.CreateAsync(new ApplicationUser
            //    {
            //        UserName = request.UserName,
            //        Email = request.Email,
            //        FirstName = request.FirstName,
            //        LastName = request.LastName,
            //        SecurityStamp = Guid.NewGuid().ToString()
            //    }, request.Password);

            //    await transaction.CommitAsync();
            //}
            //catch
            //{
            //    throw UserException.InternalServerException();
            //}

            var user = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Create user failed: {errors}");
            }

            var response = new UserSignUpResponse
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                //Role  = request.Role // TODO: Add enum role when signup
            };

            return new ApiSuccessResult<UserSignUpResponse>(response);
        }
    }
}
