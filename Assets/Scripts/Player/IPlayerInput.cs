namespace Assets.Scripts.Player
{
    public interface IPlayerInput
    {
        float Horizontal { get; }
        float Vertical { get; }
        bool Jumping { get; }
    }
}