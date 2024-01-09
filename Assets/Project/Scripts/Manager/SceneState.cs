using UniRx;

namespace Game.Manager
{
    public static class SceneState
    {
        public static ReadOnlyReactiveProperty<string> sceneName => _sceneName.ToReadOnlyReactiveProperty();
        private static ReactiveProperty<string> _sceneName = new ReactiveProperty<string>(null);

        public static ReadOnlyReactiveProperty<bool> loadEnd => _loadEnd.ToReadOnlyReactiveProperty();
        private static ReactiveProperty<bool> _loadEnd = new ReactiveProperty<bool>(false);


        public static void SetSceneName(string sceneName)
        {
            _sceneName.Value = sceneName;
        }
        public static void SetLoadEnd(bool loadEnd)
        {
            _loadEnd.Value = loadEnd;
        }
    }
}