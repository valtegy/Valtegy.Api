using Valtegy.Domain.Repositories;
using Valtegy.Repository.Context;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage;

namespace Valtegy.Repository.Repositories
{
    public class UsersRepository : IDataRepository<Domain.Entities.Users>
    {
        readonly UsersDbContext _dbContext;

        public UsersRepository(UsersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Domain.Entities.Users entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(object id)
        {
            var entity = _dbContext.Users.FirstOrDefault(x => x.Id == (int)id);
            entity.LockoutEnabled = true;
            entity.LockoutEnd = DateTimeOffset.Now;
            _dbContext.SaveChanges();
        }

        public IQueryable<Domain.Entities.Users> Get()
        {
            return _dbContext.Users.AsQueryable();
        }

        public Domain.Entities.Users Get(object id)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Id == (int)id);
        }

        public void Update(Domain.Entities.Users dbEntity, Domain.Entities.Users model)
        {
            dbEntity.UserName = model.UserName;
            dbEntity.NormalizedUserName = model.NormalizedUserName;
            dbEntity.Email = model.Email;
            dbEntity.NormalizedEmail = model.NormalizedEmail;
            dbEntity.EmailConfirmed = model.EmailConfirmed;
            dbEntity.PasswordHash = model.PasswordHash;
            dbEntity.SecurityStamp = model.SecurityStamp;
            dbEntity.ConcurrencyStamp = model.ConcurrencyStamp;
            dbEntity.PhoneNumber = model.PhoneNumber;
            dbEntity.PhoneNumberConfirmed = model.PhoneNumberConfirmed;
            dbEntity.TwoFactorEnabled = model.TwoFactorEnabled;
            dbEntity.LockoutEnd = model.LockoutEnd;
            dbEntity.LockoutEnabled = model.LockoutEnabled;
            dbEntity.AccessFailedCount = model.AccessFailedCount;
            dbEntity.FirstName = model.FirstName;
            dbEntity.MiddleName = model.MiddleName;
            dbEntity.LastName1 = model.LastName1;
            dbEntity.LastName2 = model.LastName2;
            dbEntity.BirthdayDate = model.BirthdayDate;

            _dbContext.SaveChanges();
        }

        Task<Domain.Entities.Users> IDataRepository<Domain.Entities.Users>.AddAsync(Domain.Entities.Users entity)
        {
            throw new NotImplementedException();
        }

        Task IDataRepository<Domain.Entities.Users>.AddRangeAsync(List<Domain.Entities.Users> entities)
        {
            throw new NotImplementedException();
        }

        IDbContextTransaction IDataRepository<Domain.Entities.Users>.BeginTransaction()
        {
            throw new NotImplementedException();
        }

        IQueryable<Domain.Entities.Users> IDataRepository<Domain.Entities.Users>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Domain.Entities.Users> IDataRepository<Domain.Entities.Users>.UpdateAsync(Domain.Entities.Users entity)
        {
            throw new NotImplementedException();
        }

        Task IDataRepository<Domain.Entities.Users>.UpdateRangeAsync(List<Domain.Entities.Users> entities)
        {
            throw new NotImplementedException();
        }
    }
}
