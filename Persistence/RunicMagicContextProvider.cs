using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    internal class RunicMagicContextProvider : IRunicMagicContextProvider
    {
        private readonly string _connectionString;
        private RunicMagicDbContext? _context;

        public RunicMagicContextProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public RunicMagicDbContext Context
        {
            get
            {
                if (_context == null)
                {
                    if (!Directory.Exists("./db")) Directory.CreateDirectory("./db");

                    _context = CreateContext();
                    _context.Database.EnsureDeleted();
                    _context.Database.EnsureCreated();
                }

                return _context;
            }
        }

        private RunicMagicDbContext CreateContext() => new(
            new DbContextOptionsBuilder<RunicMagicDbContext>()
                .UseSqlite(_connectionString)
                .Options);
    }
}
