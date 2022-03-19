namespace DesignPrinciples
{
    public class Invoker
    {
        private ICommand command;

        public void ExecuteCommand(ICommand command)
        {
            if (command == null)
            {
                return;
            }

            this.command = command;
            this.command.Execute();
        }
    }
}
