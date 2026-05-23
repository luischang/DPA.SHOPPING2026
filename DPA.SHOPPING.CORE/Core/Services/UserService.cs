using DPA.SHOPPING.CORE.Core.DTOs;
using DPA.SHOPPING.CORE.Core.Entities;
using DPA.SHOPPING.CORE.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPA.SHOPPING.CORE.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJWTService _jwtService;

        public UserService(IUserRepository userRepository, IJWTService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<UserListDTO?> SignIn(UserSignInDTO userSignInDTO)
        {
            var user = await _userRepository.SignIn(userSignInDTO.Email, userSignInDTO.Password);
            var token = _jwtService.GenerateJWToken(user);
            if (user == null) return null;

            return new UserListDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = token
            };
        }

        public async Task<int> SignUp(UserSignUpDTO userSignUpDTO)
        {
            var user = new User
            {
                FirstName = userSignUpDTO.FirstName,
                LastName = userSignUpDTO.LastName,
                DateOfBirth = userSignUpDTO.DateOfBirth,
                Country = userSignUpDTO.Country,
                Address = userSignUpDTO.Address,
                Email = userSignUpDTO.Email,
                Password = userSignUpDTO.Password,
                IsActive = true,
                Type = "U"
            };
            // Add LDAP integration here to create user in Active Directory if needed
            // Add Email service integration here to send welcome email if needed


            return await _userRepository.SignUp(user);
        }

    }
}
