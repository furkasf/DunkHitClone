using GenericPoolSystem.PoolData;
using UnityEngine;

namespace Assets.Scripts.GenericPoolSystem.PoolData
{
    [CreateAssetMenu(menuName = "PoolData/CD_StarDusk", fileName = "CD_StarDusk")]
    public class CD_StarDusk : CD_AbstractPool<string>
    {
        private CD_StarDusk()
        {
            Key = "StarDusk";
            InitialSize = 15;
            IsExtensible = true;
        }
    }
}