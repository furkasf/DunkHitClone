using NaughtyAttributes;
using UnityEngine;

namespace Assets.Scripts.Ball
{
    public class BallManager : MonoBehaviour
    {
        [SerializeField] private BallPhysicsController physicsController;
        [SerializeField] private BallMoveController moveController;

        [ShowNonSerializedField] private BallData _ballData;

        private void Awake()
        {
            init();
        }

        private void OnEnable()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            BallSignals.onResetBall += OnResetBall;
            BallSignals.onActivateBall += OnActivateBall;
            BallSignals.onCloseFire += OnCloseFire;
        }

        private void UnSubscribe()
        {
            BallSignals.onResetBall -= OnResetBall;
            BallSignals.onActivateBall -= OnActivateBall;
            BallSignals.onCloseFire -= OnCloseFire;

        }

        private void OnDisable()
        {
            UnSubscribe();
        }

        private void GetBallData() => _ballData = Resources.Load<BallData>("Data/BallData");

        public void SetOutHoof(bool outHoof) => moveController.SetOutHoof(outHoof);

        public void SetInHoof(bool inHoof) => moveController.SetInHoof(inHoof);

        public void CheakIsScore() => moveController.CheackIsScore();

        private void OnResetBall() => moveController.ResetBall();

        private void OnActivateBall() => moveController.ActivateBall();

        public void OnCloseFire() => moveController.CloseFireParticule();

        private void init()
        {
            GetBallData();
            moveController.SetBallData(ref _ballData);
        }
    }
}