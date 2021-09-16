using Games_Report__CodeFirst_.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Games_Report__CodeFirst_
{
    interface IGameInfoService
    {
        public IEnumerable<GameInfo> Get();

        public IEnumerable<GameInfo> GetGamesAfterDate(DateTime date);

        public IEnumerable<GameInfo> GetGamesSomeStyle(string style);

        public IEnumerable<GameInfo> GetGamesSomeCreator(string creator);
    }
}
