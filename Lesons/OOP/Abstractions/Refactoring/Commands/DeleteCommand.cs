namespace P03_StudentSystem.Commands
{
    public class DeleteCommand : ICommand
    {
        public void Execute(string[] args, StudentsDatabase database)
        {
            var name = args[1];
            // database.Delete()
        }
    }
}
