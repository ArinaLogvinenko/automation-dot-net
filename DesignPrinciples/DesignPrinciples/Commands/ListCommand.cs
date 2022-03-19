namespace DesignPrinciples.Commands
{
    public class ListCommand : ICommand
    {
        public void Execute()
        {
            CarGarage.GetInstance().GetCarList();
        }
    }
}
