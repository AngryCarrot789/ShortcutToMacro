using ShortcutToMacro.Macros;
using ShortcutToMacro.Utilities;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ShortcutToMacro.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<MacroViewModel> Macros { get; set; }

        private MacroViewModel _selectedMacro;
        public MacroViewModel SelectedMacro
        {
            get => _selectedMacro;
            set => RaisePropertyChanged(ref _selectedMacro, value);
        }

        public ICommand AddNewMacroCommand { get; }

        public MainViewModel()
        {
            Macros = new ObservableCollection<MacroViewModel>();

            AddNewMacroCommand = new Command(AddNewMacro);
        }

        public void AddNewMacro()
        {
            MacroViewModel mvm = new MacroViewModel();
            mvm.MacroName = "test101";
            Macros.Add(mvm);
        }
    }
}
