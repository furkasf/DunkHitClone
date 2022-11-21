using UnityEngine;

namespace Assets.Scripts.Ball
{
    [CreateAssetMenu(fileName = "BallData", menuName = "BallData")]
    public class BallData : ScriptableObject
    {
        [SerializeField] private float linearSpeed;
        [SerializeField] private float jumptSpeed;
        [SerializeField] private float leftSpawn = 3;
        [SerializeField] private float rightSpawn = -3;
        [SerializeField] private float maxVelocity = 2.5f;
        public Vector3 StartPosition;

        public float LeftSpawn
        {
            get => leftSpawn;
            private set {
                if(leftSpawn == value) return;
                else
                {
                    leftSpawn = value;
                }
            } 
        }

        public  float RightSpawn
        {
            get => rightSpawn;
            private set => rightSpawn = value;
        }

        public float LinearSpeed
        {
            get => linearSpeed;
            private set => linearSpeed = value;
        }

        public float JumptSpeed
        { 
            get => jumptSpeed;
            private set => jumptSpeed = value; 
        }

        public float MaxVelocity
        {
            get => maxVelocity;
            private set => maxVelocity = value;
        }

    }
}