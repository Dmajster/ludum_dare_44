using XInputDotNetPure;

namespace Assets.Scripts.Player
{
    public class PlayerJoystickInput : IPlayerInput
    {
        public float Horizontal => GamePad.GetState(CurrentPlayerIndex).ThumbSticks.Left.X;
        public float Vertical => GamePad.GetState(CurrentPlayerIndex).ThumbSticks.Left.Y;
        public bool Jumping => GamePad.GetState(CurrentPlayerIndex).Buttons.A == ButtonState.Pressed;

        public readonly PlayerIndex CurrentPlayerIndex;

        public PlayerJoystickInput(PlayerIndex playerIndex)
        {
            CurrentPlayerIndex = playerIndex;
        }
    }
}
