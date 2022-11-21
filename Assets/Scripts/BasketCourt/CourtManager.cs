using BasketCourt;
using GenericPoolSystem;
using NaughtyAttributes;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Assets.Scripts.BasketCourt
{
    public class CourtManager : MonoBehaviour
    {
        [SerializeField] private float max = 3.2f;
        [SerializeField] private float min = -1.5f;

        [ReorderableList]
        [SerializeField] private GameObject[] courts;

        [SerializeField] private CourtDirection direction;

        private void OnEnable()
        {
            CourtSingals.onApplyDirectionForce += OnApplyDirectionForce;
            CourtSingals.onSpawnHoof += OnSpawnHoof;
        }

        private void OnDisable()
        {
            CourtSingals.onApplyDirectionForce -= OnApplyDirectionForce;
            CourtSingals.onSpawnHoof -= OnSpawnHoof;
        }

        private void OnSpawnHoof()
        {
            if (direction == CourtDirection.Left)
            {
                courts[(int)direction].gameObject.SetActive(false);
                ActivateParticule(courts[(int)direction].gameObject.transform);
                direction = CourtDirection.Right;
                courts[(int)direction].gameObject.SetActive(true);
                RandomSpawnHoof(courts[(int)direction].gameObject.transform);
            }
            else
            {
                courts[(int)direction].gameObject.SetActive(false);
                ActivateParticule(courts[(int)direction].gameObject.transform);
                direction = CourtDirection.Left;
                courts[(int)direction].gameObject.SetActive(true);
                RandomSpawnHoof(courts[(int)direction].gameObject.transform);
            }
        }

        private int OnApplyDirectionForce()
        {
            if (direction == CourtDirection.Left)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        private void ActivateParticule(Transform target)
        {
            GameObject obj = PoolSignals.onGetObjectFormPool("StarDusk");
            obj.transform.position = target.position;
        }

        private void RandomSpawnHoof(Transform hoof)
        {
            hoof.position = new Vector3(hoof.position.x, Random.Range(min, max), hoof.position.z);
        }
    }

    public enum CourtDirection
    {
        Left,
        Right
    }
}