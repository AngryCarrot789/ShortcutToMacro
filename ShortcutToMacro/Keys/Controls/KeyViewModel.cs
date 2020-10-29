using ShortcutToMacro.Keyboard;
using ShortcutToMacro.Utilities;
using System.Windows.Input;

namespace ShortcutToMacro.Keys.Controls
{
    public class KeyViewModel : BaseViewModel
    {
        private string _keyReadable;
        public string KeyReadable
        {
            get => _keyReadable;
            set => RaisePropertyChanged(ref _keyReadable, value);
        }

        public void SetAsKey(Key key, KeyState state)
        {
            KeyReadable = $"Key: {key} ({(int)key})";
            State = state;
        }

        public void SetAsDelay(int delay)
        {
            KeyReadable = $"Delay: {delay} ms";
            State = KeyState.None;
        }

        private KeyState _state;
        public KeyState State
        {
            get => _state;
            set => RaisePropertyChanged(ref _state, value);
        }
    }
}
