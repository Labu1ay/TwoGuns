namespace Infastructure.Services.Input {
    public abstract class InputService : IInputService{
        protected const string ButtonFireLeftGun = "Left_Gun";
        protected const string ButtonFireRightGun = "Right_Gun";
        
        public abstract bool LeftFireButton { get; }
        public abstract bool RightFireButton { get; }
        
        protected static bool SimpleInputLeftFireButton() => SimpleInput.GetButtonDown(ButtonFireLeftGun);
        protected static bool SimpleInputRightFireButton() => SimpleInput.GetButtonDown(ButtonFireRightGun);
    }
}