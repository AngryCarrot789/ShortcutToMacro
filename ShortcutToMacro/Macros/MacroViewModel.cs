using KeyDownTester.Keys;
using ShortcutToMacro.Keyboard;
using ShortcutToMacro.Keys.Controls;
using ShortcutToMacro.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ShortcutToMacro.Macros
{
    public class MacroViewModel : BaseViewModel
    {
        private string _macroName;
        public string MacroName
        {
            get => _macroName;
            set => RaisePropertyChanged(ref _macroName, value);
        }

        private bool _ctrl;
        public bool CTRL
        {
            get => _ctrl;
            set => RaisePropertyChanged(ref _ctrl, value);
        }

        private bool _alt;
        public bool ALT
        {
            get => _alt;
            set => RaisePropertyChanged(ref _alt, value);
        }

        private bool _shift;
        public bool Shift
        {
            get => _shift;
            set => RaisePropertyChanged(ref _shift, value);
        }

        private KeyState _state;
        public KeyState State
        {
            get => _state;
            set => RaisePropertyChanged(ref _state, value);
        }

        private string _key;
        public string Key
        {
            get => _key;
            set => RaisePropertyChanged(ref _key, value);
        }

        private int _delay;
        public int Delay
        {
            get => _delay;
            set => RaisePropertyChanged(ref _delay, value);
        }

        public ObservableCollection<KeyViewModel> Keys { get; set; }

        private KeyViewModel _selectedKey;
        public KeyViewModel SelectedKey
        {
            get => _selectedKey;
            set => RaisePropertyChanged(ref _selectedKey, value);
        }

        public GlobalHotkey Hotkey { get; set; }

        public ICommand ClearKeyListCommand { get; }
        public ICommand AddKeyCommand { get; }
        public ICommand AddDelayCommand { get; }
        public ICommand AddModifierCommand { get; }
        public ICommand RemoveSelectedKeyCommand { get; }

        public ICommand SetMacroActivatorKeysCommand { get; }
        public ICommand SetMacroEmulatorKeysCommand { get; }

        public MacroViewModel()
        {
            Keys = new ObservableCollection<KeyViewModel>();
            ClearKeyListCommand          = new Command(ClearKeysList);
            AddKeyCommand                = new Command(AddKey);
            AddDelayCommand              = new Command(AddDelay);
            AddModifierCommand           = new CommandParam<string>(AddModifier);
            SetMacroActivatorKeysCommand = new Command(SetMacroActivatorKeys);
            SetMacroEmulatorKeysCommand  = new Command(SetMacroEmulatorKeys);
            CTRL = false;
            ALT = false;
            Shift = false;
            State = KeyState.Down;
            Key = "A";
            Delay = 50;
        }

        public void ClearKeysList()
        {
            Keys.Clear();
        }

        public void AddKey()
        {
            AddKey(Key, State);
        }

        public void AddDelay()
        {
            AddKey(Key, KeyState.None);
        }

        public void AddModifier(string modifier)
        {
            switch (modifier)
            {
                case "CTRL":  AddKey(System.Windows.Input.Key.LeftCtrl, State); break;
                case "ALT":   AddKey(System.Windows.Input.Key.LeftAlt, State); break;
                case "Shift": AddKey(System.Windows.Input.Key.LeftShift, State); break;
            }
        }

        public void SetMacroActivatorKeys()
        {

        }

        public void SetMacroEmulatorKeys()
        {

        }

        public void AddKey(string possibleKey, KeyState state)
        {
            if (!string.IsNullOrEmpty(possibleKey))
            {
                if (Enum.TryParse(possibleKey, out Key key))
                {
                    AddKey(key, state);
                }
            }
        }

        public void AddKey(Key key, KeyState state)
        {
            KeyViewModel kvm = new KeyViewModel();

            if (state == KeyState.None)
                kvm.SetAsDelay(Delay);
            else
                kvm.SetAsKey(key, state);

            Keys.Add(kvm);
        }
    }
}
