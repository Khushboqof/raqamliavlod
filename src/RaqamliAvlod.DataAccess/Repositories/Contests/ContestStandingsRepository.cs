﻿using RaqamliAvlod.DataAccess.DbContexts;
using RaqamliAvlod.DataAccess.Interfaces.Contests;
using RaqamliAvlod.Domain.Entities.Contests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.DataAccess.Repositories.Contests
{
    public class ContestStandingsRepository : IContestStandingsRepository
    {
        private readonly AppDbContext _dbSet;

        public ContestStandingsRepository(AppDbContext context)
        {
            _dbSet = context;
        }
        public async Task<ContestStandings> CreateAsync(ContestStandings entity)
        {
            await _dbSet.ContestStandings.AddAsync(entity);
            await _dbSet.SaveChangesAsync();

            return entity;
        }

        public async Task<ContestStandings?> FindByIdAsync(long id)
        {
            var entity = await _dbSet.ContestStandings.FindAsync(id);

            if (entity is not null)
            {
                return entity;
            }
            else throw new NullReferenceException("Not found entity to remove");
        }

        public async Task<ContestStandings> UpdateAsync(long id, ContestStandings entity)
        {
            var oldEntity = await _dbSet.ContestStandings.FindAsync(id);
            if (oldEntity is not null)
            {
                entity.Id = id;
                _dbSet.ContestStandings.Update(entity);
                await _dbSet.SaveChangesAsync();
                return entity;
            }
            else throw new NullReferenceException("Not found entity to update");
        }
    }
}
