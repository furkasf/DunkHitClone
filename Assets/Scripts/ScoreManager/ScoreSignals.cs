using System;


namespace ScoreManager
{
    public static class ScoreSignals
    {
        public static Action onResetTimer;
        public static Action onUpdateScore;
        public static Action onResetDatas;
        public static Func<int> onGetScore;
    }
}
