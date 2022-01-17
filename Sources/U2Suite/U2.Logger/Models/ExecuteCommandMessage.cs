namespace U2.Logger
{
    public enum CommandToExecute
    {
        ClearTextInputs,
        SaveQso,
        RefreshLog,
    }

    public sealed class ExecuteCommandMessage
    {
        public ExecuteCommandMessage(CommandToExecute commandToExecute, 
            object? commandParameters = null)
        {
            CommandToExecute = commandToExecute;
            CommandParameters = commandParameters;
        }

        public CommandToExecute CommandToExecute { get; }
        public object? CommandParameters { get; }
    }
}
