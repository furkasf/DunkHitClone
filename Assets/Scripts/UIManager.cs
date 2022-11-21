using GameCore;
using System;
using TMPro;
using System.Collections;
using UnityEngine;
using ScoreManager;
using UnityEngine.SocialPlatforms.Impl;
using Assets.Scripts.Ball;

namespace Assets.Scripts
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject inGamePanel;
        [SerializeField] private GameObject StartMenuPanel;
        [SerializeField] private TMP_Text endGameScoreText;

        private void Awake()
        {
            Init();
        }

        private void OnEnable()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            UISignals.OnOpenStartGamePanel += OnOpenStartGamePanel;
        }

        private void UnSubscribe()
        {
            UISignals.OnOpenStartGamePanel -= OnOpenStartGamePanel;
        }

        private void OnDisable()
        {
            UnSubscribe();
        }

        public void PlayerClickStartPlayButton()
        {
            
            BallSignals.onActivateBall();
            CoreGameSignals.onSetGameState(GameState.Play);
            StartMenuPanel.SetActive(false);
            inGamePanel.SetActive(true);
        }

        private void OnOpenStartGamePanel()
        {
            CoreGameSignals.onSetGameState(GameState.Menu);
            StartMenuPanel.SetActive(true);
            inGamePanel.SetActive(false);
            WriteGameScore();
        }

        private void WriteGameScore()
        {
            endGameScoreText.text = (ScoreSignals.onGetScore() > 0) ? "hight score : " + ScoreSignals.onGetScore() : "";
            ScoreSignals.onResetDatas();
            BallSignals.onCloseFire();
        }

        private void Init()
        {
            StartMenuPanel.SetActive(true);
            inGamePanel.SetActive(false);
        }
    }

    public enum ScoreWorlds
    {
        WoW = 2,
        CooL = 3,
        AwesomE = 4,
        MindBolwing = 5,
    }

    public static class UISignals
    {
        public static Action OnOpenStartGamePanel;
    }
}
