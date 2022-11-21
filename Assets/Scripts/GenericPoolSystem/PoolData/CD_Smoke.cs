using UnityEngine;

namespace GenericPoolSystem.PoolData
{
    [CreateAssetMenu(menuName = "PoolData/CD_Smoke", fileName = "CD_Smoke")]
    public class CD_Smoke : CD_AbstractPool<string>
    {
        private CD_Smoke()
        {
            Key = "Smoke";
            InitialSize = 15;
            IsExtensible = false;
        }
    }
}