using System;
using Domain.Entities;

namespace Application.Services
{
	public interface ITokenHandler
	{
        public DTOs.Token CreateAccessToken(AppUser user);
    }
}

