using ReactiveUI;
using System;
using System.Text;
using Task2.Models;

namespace LivingBeingsApp
{
    public class MainViewModel : ReactiveObject
    {
        private LivingBeing _currentBeing;
        private string _currentState;
        private string _actionLog;
        private bool _isPantherSelected;
        private bool _isDogSelected;
        private bool _isTurtleSelected;

        public MainViewModel()
        {
            CurrentBeing = new Panther();
            CurrentState = "Ready";
            ActionLog = "Action log:\n";
            IsPantherSelected = true;
        }
        
        public LivingBeing CurrentBeing
        {
            get => _currentBeing;
            private set
            {
                this.RaiseAndSetIfChanged(ref _currentBeing, value);
                this.RaisePropertyChanged(nameof(CurrentBeingType)); 
                this.RaisePropertyChanged(nameof(CurrentSpeed));
            }
        }
        
        public string CurrentState
        {
            get => _currentState;
            private set => this.RaiseAndSetIfChanged(ref _currentState, value);
        }
        
        public string ActionLog
        {
            get => _actionLog;
            private set => this.RaiseAndSetIfChanged(ref _actionLog, value);
        }
        
        public bool IsPantherSelected
        {
            get => _isPantherSelected;
            set
            {
                this.RaiseAndSetIfChanged(ref _isPantherSelected, value);
                if (value) SelectPanther();
            }
        }
        
        public bool IsDogSelected
        {
            get => _isDogSelected;
            set
            {
                this.RaiseAndSetIfChanged(ref _isDogSelected, value);
                if (value) SelectDog();
            }
        }
        
        public bool IsTurtleSelected
        {
            get => _isTurtleSelected;
            set
            {
                this.RaiseAndSetIfChanged(ref _isTurtleSelected, value);
                if (value) SelectTurtle();
            }
        }
        
        public int CurrentSpeed => CurrentBeing.Speed;
        
        public string CurrentBeingType => CurrentBeing.GetType().Name;
        
        public void Move()
        {
            CurrentBeing.Move();
            CurrentState = $"{CurrentBeingType} is moving. Speed: {CurrentSpeed}";
            LogAction($"{CurrentBeingType} moved. Speed: {CurrentSpeed}");
            this.RaisePropertyChanged(nameof(CurrentSpeed)); // Уведомляем об изменении скорости
        }
        
        public void Stop()
        {
            CurrentBeing.Stop();
            CurrentState = $"{CurrentBeingType} is stopping. Speed: {CurrentSpeed}";
            LogAction($"{CurrentBeingType} stopped. Speed: {CurrentSpeed}");
            this.RaisePropertyChanged(nameof(CurrentSpeed)); // Уведомляем об изменении скорости
        }
        
        public void MakeSound()
        {
            if (CurrentBeing is Panther panther)
            {
                panther.MakeSound();
                CurrentState = "Panther roared!";
                LogAction("Panther roared!");
            }
            else if (CurrentBeing is Dog dog)
            {
                dog.MakeSound();
                CurrentState = "Dog barked!";
                LogAction("Dog barked!");
            }
            else
            {
                CurrentState = "This being cannot make sound.";
                LogAction("This being cannot make sound.");
            }
        }
        
        public void ClimbTree()
        {
            if (CurrentBeing is Panther panther)
            {
                panther.ClimbTree();
                CurrentState = "Panther climbed the tree!";
                LogAction("Panther climbed the tree!");
            }
            else
            {
                CurrentState = "This being cannot climb trees.";
                LogAction("This being cannot climb trees.");
            }
        }
        
        public void SelectPanther()
        {
            CurrentBeing = new Panther();
            CurrentState = "Panther is ready!";
            LogAction("Panther selected.");
        }
        
        public void SelectDog()
        {
            CurrentBeing = new Dog();
            CurrentState = "Dog is ready!";
            LogAction("Dog selected.");
        }
        
        public void SelectTurtle()
        {
            CurrentBeing = new Turtle();
            CurrentState = "Turtle is ready!";
            LogAction("Turtle selected.");
        }
        
        private void LogAction(string action)
        {
            ActionLog += $"{DateTime.Now:HH:mm:ss} - {action}\n";
        }
    }
}