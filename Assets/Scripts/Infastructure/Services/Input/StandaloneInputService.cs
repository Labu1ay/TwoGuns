using UnityEngine;

namespace Infastructure.Services.Input {
    public class StandaloneInputService : InputService {
        private static KeyCode _leftGunKeyboard = KeyCode.LeftControl;
        private static KeyCode _rightGunKeyboard = KeyCode.RightControl;
        
        public override bool LeftFireButton {
            get {
                bool fire = SimpleInputLeftFireButton();

                if (fire == false)
                    fire = KeyboardLeftFireButton();

                return fire;
            }
        }

        public override bool RightFireButton {
            get {
                bool fire = SimpleInputRightFireButton();
                
                if (fire == false)
                    fire = KeyboardRightFireButton();

                return fire;
            }
        }

        private static bool KeyboardLeftFireButton() => UnityEngine.Input.GetKeyDown(_leftGunKeyboard);
        private static bool KeyboardRightFireButton() => UnityEngine.Input.GetKeyDown(_rightGunKeyboard);
    }
}