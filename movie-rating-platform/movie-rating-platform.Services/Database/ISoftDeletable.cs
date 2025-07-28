using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movie_rating_platform.Services.Database
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
        DateTime? DeletionTime { get; set; }

        void Undo();
    }
}
