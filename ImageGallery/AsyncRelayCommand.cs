using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageGallery
{
    /// <summary>
    /// Command, dessen Ausführung und CanExecute-Logik durch Actions weitergegeben wird.
    /// </summary>
    public class AsyncRelayCommand
    {
        /*/// <summary>
        /// ctor
        /// </summary>
        /// <param name="executeAction">Command-Action</param>
        /// <param name="name">Der Name des Commands</param>
        public AsyncRelayCommand(Func<Task> executeAction, [CallerMemberName] string name = null)
            : this(executeAction, null, name)
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="executeAction">Command-Action</param>
        /// <param name="canExecuteAction">Prüfroutine, ob der Command verfügbar ist</param>
        /// <param name="name">Der Name des Commands</param>
        public AsyncRelayCommand(Func<Task> executeAction, Func<bool> canExecuteAction, [CallerMemberName] string name = null)
            : this(name)
        {
            if (executeAction == null)
            {
                throw new ArgumentNullException(nameof(executeAction), "The parameter must not be null.");
            }

            _ExecuteAction = executeAction;
            _CanExecuteAction = canExecuteAction;
        }

        private readonly Func<bool> _CanExecuteAction;
        private readonly Func<Task> _ExecuteAction;

        /// <summary>
        /// Gibt an, ob der Command ausführbar ist
        /// </summary>
        /// <param name="parameter">Command-Parameter</param>
        /// <returns>true, wenn Execute aufgerufen werden darf, sonst false.</returns>
        public bool CanExecute(object parameter)
        {
            return _CanExecuteAction == null || _CanExecuteAction();
        }

        /// <summary>
        /// Führt den Command aus.
        /// </summary>
        /// <param name="parameter">Command-Parameter</param>
        public void Execute(object parameter)
        {
            this.ExecuteAsync(parameter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public Task ExecuteAsync(object parameter)
        {
            CommandExecutingInternal?.Invoke(this, new CommandExecutingEventArgs(parameter));
            EventHandler<CommandExecutedEventArgs> executed = this.ExecutedInternal + CommandExecutedInternal;
            Task result = _ExecuteAction();
            if (executed != null)
            {
                result.ContinueWith(t => executed(this, new CommandExecutedEventArgs(null, t.Exception)), TaskScheduler.FromCurrentSynchronizationContext());
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        public override Type OwnerType => _ExecuteAction.Target?.GetType() ?? _ExecuteAction.Method.DeclaringType;

        /// <summary>
        /// 
        /// </summary>
        protected override bool HasCanExecuteAction => _CanExecuteAction != null;
    }

    /// <summary>
    /// Command, dessen Ausführung und CanExecute-Logik durch Actions weitergegeben wird.
    /// </summary>
    /// <typeparam name="TParameter">Typ des Command-Parameter</typeparam>
    public class AsyncRelayCommand<TParameter> : AbstractRelayCommand, IAsyncCommand
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="executeAction">Command-Action</param>
        /// <param name="name"></param>
        public AsyncRelayCommand(Func<TParameter, Task> executeAction, [CallerMemberName] string name = null)
            : this(executeAction, null, name)
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="executeAction">Command-Action</param>
        /// <param name="canExecuteAction">CanExecute-Prüfroutine</param>
        /// <param name="name"></param>
        public AsyncRelayCommand(Func<TParameter, Task> executeAction, Func<TParameter, bool> canExecuteAction, [CallerMemberName] string name = null)
            : base(name)
        {
            if (executeAction == null)
            {
                throw new ArgumentNullException(nameof(executeAction), "The parameter must not be null.");
            }

            _ExecuteAction = executeAction;
            _CanExecuteAction = canExecuteAction;
        }

        private readonly Func<TParameter, bool> _CanExecuteAction;
        private readonly Func<TParameter, Task> _ExecuteAction;

        /// <summary>
        /// Gibt an, ob der Command ausführbar ist
        /// </summary>
        /// <param name="parameter">Command-Parameter</param>
        /// <returns>true, wenn Execute aufgerufen werden darf, sonst false.</returns>
        public override bool CanExecute(object parameter)
        {
            return _CanExecuteAction == null || _CanExecuteAction((TParameter)parameter);
        }

        /// <summary>
        /// Führt den Command aus.
        /// </summary>
        /// <param name="parameter">Command-Parameter</param>
        public override void Execute(object parameter)
        {
            this.ExecuteAsync(parameter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public Task ExecuteAsync(object parameter)
        {
            CommandExecutingInternal?.Invoke(this, new CommandExecutingEventArgs(parameter));
            EventHandler<CommandExecutedEventArgs> executed = this.ExecutedInternal + CommandExecutedInternal;
            Task result = _ExecuteAction((TParameter)parameter);
            if (executed != null)
            {
                result.ContinueWith(t => executed(this, new CommandExecutedEventArgs(parameter, t.Exception)), TaskScheduler.FromCurrentSynchronizationContext());
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        public override Type OwnerType => _ExecuteAction.Target?.GetType() ?? _ExecuteAction.Method.DeclaringType;

        /// <summary>
        /// 
        /// </summary>
        protected override bool HasCanExecuteAction => _CanExecuteAction != null;
        */
    }
}
 