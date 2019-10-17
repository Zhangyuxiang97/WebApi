using StudentSys.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.DAL
{
    public class ScoreService:BaseService<Score>
    {
        public ScoreService() : base(new StudentContext())
        {

        }

        public async Task ChangeScore(Guid scoreId, int result)
        {
            var score = new Score() { Id = scoreId };
            _db.Entry(score).State = EntityState.Unchanged;
            await SaveAsync(false);
        }
    }
}
