using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CarRepository;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Persistence.Repositories.CarRepository
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext context;

        public CarRepository(CarBookContext context)
        {
            this.context = context;
        }

        public async Task<List<Car>> GetCarListWithBrand()
        {
            var values = await context.Cars.Include(x=>x.Brand).ToListAsync();
            return values;
        }
    }
}
