using Games_Report__CodeFirst_.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Games_Report__CodeFirst_
{
    class GameInfoService : IGameInfoService
    {
        private readonly GameStorageContext _context;

        public GameInfoService()
        {
            _context = new GameStorageContext();
            _context.Database.EnsureCreated();
        }

        public IEnumerable<GameInfo> Get()
        {
            return _context.GameInfos.ToList();
        }

        public IEnumerable<GameInfo> GetGamesAfterDate(DateTime date)
        {
            return _context.GameInfos.Where(_ => _.ReleaseDate > date).ToList();
        }

        public IEnumerable<GameInfo> GetGamesSomeCreator(string creator)
        {
            return _context.GameInfos.Where(_ => _.Creator == creator).ToList();
        }

        public IEnumerable<GameInfo> GetGamesSomeStyle(string style)
        {
            return _context.GameInfos.Where(_ => _.Style == style).ToList();
        }
    }
}
