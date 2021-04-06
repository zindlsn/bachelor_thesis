using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ImageGallery.MVVM
{
    /// <summary>
    /// https://codereview.stackexchange.com/questions/132004/asynccommand-using-mvvm-and-wpf
    /// Alternativ: https://johnthiriet.com/mvvm-going-async-with-async-command/
    /// </summary>
    public abstract class CommandBase : ICommand
    {
        private readonly Func<bool> _canExecute;

        public CommandBase()
        {

        }

        public CommandBase(Func<bool> canExecute)
        {
            if (canExecute == null) throw new ArgumentNullException(nameof(canExecute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public abstract void Execute(object parameter);

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }


    public class AsyncCommand : CommandBase, INotifyPropertyChanged
    {
        private readonly Func<CancellationToken, Task> _action;

        private CancellationTokenSource _cancellationTokenSource;

        private bool _isRunning;
        public bool IsRunning
        {
            get { return _isRunning; }
            set
            {
                _isRunning = value;
                OnPropertyChanged();
            }
        }

      //  private ICommand _cancelCommand;
      //  public ICommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand(Cancel));

        public AsyncCommand(Func<CancellationToken, Task> action, object canLoadPictures)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            _action = action;
        }

        public AsyncCommand(Func<CancellationToken, Task> action, Func<bool> canExecute) : base(canExecute)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            _action = action;
        }

        private void Cancel()
        {
            _cancellationTokenSource?.Cancel();
        }

        public override async void Execute(object parameter)
        {
            IsRunning = true;
            try
            {
                using (var tokenSource = new CancellationTokenSource())
                {
                    _cancellationTokenSource = tokenSource;

                    await ExecuteAsync(tokenSource.Token);
                }
            }
            finally
            {
                _cancellationTokenSource = null;
                IsRunning = false;
            }
        }

        private Task ExecuteAsync(CancellationToken cancellationToken)
        {
            return _action(cancellationToken);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
