using Assets.Scripts.Ball;
using BasketCourt;
using GameCore;
using GenericPoolSystem;
using NaughtyAttributes;
using ScoreManager;
using UnityEngine;

public class BallMoveController : MonoBehaviour
{
    [SerializeField] private ForceMode linearMode;
    [SerializeField] private GameObject firePartical;

    [ShowNonSerializedField] private Rigidbody _rigidBody;
    [ShowNonSerializedField] private BallData _ballData;
    [ShowNonSerializedField] private bool _isInHoof;
    [ShowNonSerializedField] private bool _isOutHoof = true;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void SetBallData(ref BallData data) => _ballData = data;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            EmmitPartical();
            _rigidBody.AddForce(Vector3.up * _ballData.JumptSpeed, ForceMode.Impulse);
        }
        MoveFirePartical();
    }

    private void FixedUpdate()
    {
        if (CoreGameSignals.onGetGameState() != GameState.Play) return;
        _rigidBody.AddForce((Vector3.left * _ballData.LinearSpeed) * CourtSingals.onApplyDirectionForce(), linearMode);
        ApplyVelocityLimit();
    }

    private void OnBecameVisible()
    {
        if(ScoreSignals.onGetScore() > 3)
        {
            firePartical.SetActive(true);
        }
    }

    private void OnBecameInvisible()
    {
        firePartical.SetActive(false);
        TeleportBall();
    }

    private void TeleportBall()
    {
        if (transform.position.x > 0)
        {
            transform.position = new Vector3(_ballData.LeftSpawn, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(_ballData.RightSpawn, transform.position.y, transform.position.z);
        }
    }

    private void ApplyVelocityLimit()
    {
        _rigidBody.velocity = Vector3.ClampMagnitude(_rigidBody.velocity, _ballData.MaxVelocity);
    }

    public void SetInHoof(bool inHoof) => _isInHoof = inHoof;

    public void SetOutHoof(bool outHoof) => _isOutHoof = outHoof;

    public void CheackIsScore()
    {
        if (_isInHoof && _isOutHoof)
        {
            CourtSingals.onSpawnHoof();
            _isInHoof = false;
            ScoreSignals.onResetTimer();
            ScoreSignals.onUpdateScore();
        }
        else
        {
            _isOutHoof = true;
        }
    }

    private void MoveFirePartical()
    {
        firePartical.transform.position = transform.position;
    }

    public void ResetBall()
    {
        _rigidBody.isKinematic = true;
        firePartical.SetActive(false);
        transform.position = _ballData.StartPosition;
    }

    public void ActivateBall() => _rigidBody.isKinematic = false;
    
    public void CloseFireParticule() => firePartical.SetActive(false);

    private void EmmitPartical()
    {   
        if (ScoreSignals.onGetScore() < 5)
        {
            GameObject partical = PoolSignals.onGetObjectFormPool("Smoke");
            partical.transform.position = transform.position;
        }
        else
        {
            if (!firePartical.active)
            {
                firePartical.SetActive(true);
            }
        }
    }
}