using RentalCRM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using RentalCRM.ViewModel;

namespace RentalCRM.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly RentalCRMContext db;
        public UserRepository(RentalCRMContext _db)
        {
            db = _db;
        }

        public async Task<List<UserViewModel>> List()
        {
            if (db != null)
            {
                try
                {
                    return await (from user in db.Users
                                  from branch in db.Branch
                                  from role in db.UserRole
                                  where user.BranchId == branch.BranchId && user.RoleId == role.RoleId
                                  select new UserViewModel
                                  {
                                      UserId = user.UserId,
                                      Active = user.Active,
                                      Address = user.Address,
                                      BranchId = branch.BranchId,
                                      BranchName = branch.BranchName,
                                      CateId = user.CateId,
                                      Description = user.Description,
                                      Email = user.Email,
                                      Fullname = user.Fullname,
                                      Password = user.Password,
                                      Phone = user.Phone,
                                      Photo = user.Photo,
                                      RoleId = user.RoleId,
                                      RoleName = role.RoleName,
                                      StatusName = user.Active == 1 ? "Còn hiệu lực" : "Không còn hiệu lực",
                                      Username = user.Username,
                                      WardId = user.WardId
                                  }).ToListAsync();
                }
                catch
                {

                }
            }
            return null;
        }

        public async Task<List<Users>> Search(string keyword)
        {
            if (db != null)
            {
                try
                {
                    return await db.Users
                    .Where(u => u.Active == 1 && (u.Fullname.Contains(keyword) || u.Username.Contains(keyword)))
                    .ToListAsync();
                }
                catch { }
            }
            return null;
        }

        public async Task<List<Users>> ListPaging(int pageIndex, int pageSize)
        {
            if (db != null)
            {
                try
                {
                    return await db.Users
                    .Where(u => u.Active == 1)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
                }
                catch { }
            }
            return null;
        }

        public async Task<Users> Detail(int userId)
        {
            if (db != null)
            {
                try
                {
                    return await db.Users
                    .FirstOrDefaultAsync(u => u.Active == 1 && u.UserId == userId);
                }
                catch (Exception ex)
                {

                }
            }
            return null;
        }

        public async Task<Users> Add(Users model)
        {
            if (db != null)
            {
                try
                {
                    await db.AddAsync(model);
                    await db.SaveChangesAsync();

                    return model;
                }
                catch { }
            }
            return null;
        }
        public async Task Update(Users model)
        {
            if (db != null)
            {
                try
                {
                    db.Attach(model);

                    db.Entry(model).Property(u => u.Address).IsModified = true;
                    db.Entry(model).Property(u => u.BranchId).IsModified = true;
                    db.Entry(model).Property(u => u.CateId).IsModified = true;
                    db.Entry(model).Property(u => u.Description).IsModified = true;
                    db.Entry(model).Property(u => u.Email).IsModified = true;
                    db.Entry(model).Property(u => u.Fullname).IsModified = true;
                    db.Entry(model).Property(u => u.Password).IsModified = true;
                    db.Entry(model).Property(u => u.Phone).IsModified = true;
                    db.Entry(model).Property(u => u.Photo).IsModified = true;
                    db.Entry(model).Property(u => u.RoleId).IsModified = true;
                    db.Entry(model).Property(u => u.WardId).IsModified = true;

                    await db.SaveChangesAsync();
                }
                catch { }
            }
        }

        public async Task Delete(Users model)
        {
            if (db != null)
            {
                try
                {
                    db.Attach(model);
                    db.Entry(model).Property(u => u.Active).IsModified = true;

                    await db.SaveChangesAsync();
                }
                catch { }
            }
        }

        public async Task<int> DeletePermanently(int? userId)
        {
            if (db != null)
            {
                try
                {
                    var user = await db.Users
                          .FirstOrDefaultAsync(u => u.UserId == userId);
                    if (user != null)
                    {
                        db.Remove(user);
                        return await db.SaveChangesAsync();
                    }
                    return 0;
                }
                catch (Exception ex)
                {

                }
            }
            return 0;
        }

        public int Count()
        {
            return db.Users.Count();
        }
    }
}
