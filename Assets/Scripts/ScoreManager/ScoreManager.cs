using Assets.Scripts;
using GameCore;
using NaughtyAttributes;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Ball;

namespace ScoreManager
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private GameObject scoreTextParent;
        [SerializeField] private TMP_Text baseScore;
        [SerializeField] private TMP_Text popScore;
        [SerializeField] private TMP_Text ComboText;

        //task re adjust score inrease and combo funtion and signals and test it

        [ShowNonSerializedField]
        private ScoreData _scoreData;

        private void Awake()
        {
            GetScoreData();
        }

        private void GetScoreData() => _scoreData = Resources.Load<ScoreData>("Data/ScoreData");

        private void OnEnable()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            ScoreSignals.onResetTimer += OnResetTimer;
            ScoreSignals.onResetDatas += OnResetDatas;
            ScoreSignals.onUpdateScore += OnUpdateScore;
            ScoreSignals.onGetScore += OnGetScore;
        }

        private void UnSubscribe()
        {
            ScoreSignals.onResetTimer -= OnResetTimer;
            ScoreSignals.onResetDatas -= OnResetDatas;
            ScoreSignals.onUpdateScore -= OnUpdateScore;
            ScoreSignals.onGetScore -= OnGetScore;
        }

        private void OnDisable()
        {
            UnSubscribe();
        }

        private void Update()
        {
            if (CoreGameSignals.onGetGameState() == GameState.Play)
            {
                UpdateTimer();
            }
        }

        private void UpdateTimer()
        {
            slider.value -= Time.deltaTime;
            if (slider.value <= 0)
            {
                slider.value = slider.maxValue;
                BallSignals.onResetBall();
                UISignals.OnOpenStartGamePanel();
            }
        }

        private void OnResetTimer()
        {
            slider.maxValue -= 0.2f;
            slider.value = slider.maxValue;
        }

        //called by ball
        [Button]
        private void OnUpdateScore()
        {
            //increase base score
            _scoreData.GameScore = 1 + _scoreData.ComboScore;
            _scoreData.ComboScore++;

            //replace texts
            baseScore.text = _scoreData.GameScore.ToString();
            string extra = (_scoreData.ComboScore >= 2) ? "X" + _scoreData.ComboScore : "";
            ComboText.text = _scoreData.ScoreWoWs[Random.Range(0, 3)] + " " + extra;
            popScore.text = (_scoreData.ComboScore > 1) ? (1 * _scoreData.ComboScore).ToString() : "1";
            popScore.gameObject.SetActive(true);
            scoreTextParent.transform.DOPunchScale(new Vector3(0.3f, 0.3f, 1), 0.3f, 2).SetEase(Ease.InSine);
        }

        private int OnGetScore() => _scoreData.GameScore;

        private void OnResetDatas()
        {
            _scoreData.ComboScore = 0;
            _scoreData.ComboScore = 0;
            baseScore.text = "0";
            ComboText.text = "";
        }
    }
}