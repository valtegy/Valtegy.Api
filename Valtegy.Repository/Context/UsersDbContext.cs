using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Valtegy.Repository.Context
{
    public class UsersDbContext : IdentityDbContext<Domain.Entities.Users, IdentityRole<Guid>, Guid>
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
        }
    }
}
