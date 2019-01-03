using CaveBase.Library.DTO;
using CaveBase.Library.Models;
using CaveBase.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaveBase.WebAPI.Repositories
{
    public class ClubRepository
    {
        private CaveServiceContext database;

        public ClubRepository(CaveServiceContext context)
        {
            database = context;
        }

        public List<Club> All()
        {
            return database.Clubs.ToList();
        }

        public List<ClubBasic> AllBasic()
        {
            return database.Clubs.Select
                (c => new ClubBasic
                {
                    Id = c.Id,
                    Name = c.Name,
                    City = c.City
                }
                )
                .ToList();
        }

        public Club GetById(int id)
        {
            return database.Clubs.FirstOrDefault(c => c.Id == id);
        }

        public async Task<Club> Update(Club club)
        {
            try
            {
                database.Entry(club).State = EntityState.Modified;
                await database.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClubExists(club.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return club;
        }

        public async Task<Club> Add(Club club)
        {
            database.Clubs.Add(club);
            await database.SaveChangesAsync();
            return club;
        }

        public async Task<Club> Delete(int id)
        {
            Club club = await database.Clubs.FindAsync(id);
            if (club == null) return null;

            database.Clubs.Remove(club);
            await database.SaveChangesAsync();
            return club;
        }

        private bool ClubExists(int id)
        {
            return database.Clubs.Any(c => c.Id == id);
        }
    }
}
