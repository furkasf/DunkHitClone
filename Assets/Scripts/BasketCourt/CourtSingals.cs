using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketCourt
{
    public static class CourtSingals
    {
        public static Func<int> onApplyDirectionForce;
        public static Action onSpawnHoof;
    }
}
