using System;
using UnityEngine;

namespace ScoreManager
{
    [CreateAssetMenu(fileName = "ScoreData", menuName = "ScoreData")]
    public class ScoreData : ScriptableObject
    {
        public String[] ScoreWoWs;
        public int ComboScore;
        public int GameScore;
    }
}