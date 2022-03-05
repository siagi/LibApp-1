using LibApp.Data;
using LibApp.Interfaces;
using LibApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibApp.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;
        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _context.Genre.ToList();
        }

        public Genre GetGenre(int id)
        {
            return _context.Genre.FirstOrDefault(x => x.Id == id);
        }
    }
}
