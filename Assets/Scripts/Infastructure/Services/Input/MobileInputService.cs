namespace Infastructure.Services.Input {
    public class MobileInputService : InputService {
        public override bool LeftFireButton => SimpleInputLeftFireButton();
        public override bool RightFireButton => SimpleInputRightFireButton();
    }
}