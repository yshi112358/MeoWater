using UniRx;

namespace Game.Player
{
    public interface IInputEventProvider
    {
        IReadOnlyReactiveProperty<float> Move { get; }
    }
}
