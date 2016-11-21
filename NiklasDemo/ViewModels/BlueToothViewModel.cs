using NiklasDemo.Helpers;
using NiklasDemo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace NiklasDemo.ViewModels
{
    public class BlueToothViewModel : ViewModelBase
    {
        // Datakontextklass för BlueToothView:n. 
        //Ärver av ViewModelBase som innehåller NotifyPropertyChanged eventet som gör att vyn uppdaterar sig när något ändrats.

        private ObservableCollection<Unit> _units;
        private ICommand _addAnotherUnitCommand;

        public ObservableCollection<Unit> Units
        {
            get { return _units; }
            set { _units = value; NotifyPropertyChanged(); } // NotifyPropertyChanged säger till vyn att något har uppdaterats och att den behöver laddas om
        }

        // "event" som binds mot vyn. Typ som ett vanligt Click i vanlig windows form-kodning. Det görs på detta sättet så att man ska slippa codebehind i vyn.
        // en ICommand, eller som i vårat fall en RelayCommand har två properties, Execute och CanExecute.
        // Execute är en Action som kör det du vill ska köras. Funkar smidigt med lambdauttryck. CanExecute är ifall du får lov att köra din action eller inte.
        // Ex: Har du access till databasen för tillfället? Inte? Då får du inte köra.

        public ICommand AddAnotherUnitCommand
        {
            get { return _addAnotherUnitCommand; }
            set { _addAnotherUnitCommand = value; }
        }

        public BlueToothViewModel()
        {
            _units = new ObservableCollection<Unit>();
            AddAnotherUnitCommand = new RelayCommand((whattoexecute) => AddUnit(), (canexecute) => true);

            Units.Add(new Unit() { Name = "Test1", RSSI = "16" });
            Units.Add(new Unit() { Name = "Test2", RSSI = "10" });
            Units.Add(new Unit() { Name = "Test3", RSSI = "15" });
            Units.Add(new Unit() { Name = "Test4", RSSI = "9" });
        }

        private void AddUnit()
        {
            Units.Add(new Unit() { Name = "Added from button", RSSI = new Random().Next(100).ToString() });
        }
    }
}
