using System;

namespace GameCore
{
    public static class CoreGameSignals
    {
        public static Action onReset;
        public static Action onPlay;
        public static Action<GameState> onSetGameState;
        public static Func<GameState> onGetGameState;
    }
}