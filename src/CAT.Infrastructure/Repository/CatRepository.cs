﻿using CAT.Domain.Entities;
using CAT.Domain.Primitives;
using CAT.Domain.Repository;
using CAT.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CAT.Infrastructure.Repository
{
    public class CatRepository : GenericRepository<Cat>, ICatRepository
    {
        public CatRepository(CatDbContext context) : base(context)
        {
        }

        public async Task<List<Cat>> GetCats()
        {
            return await this.GetAll().ToListAsync();
        }

        public async Task<Cat> GetCatById(int id)
        {
            return await this.GetById(id);
        }

    }
}
