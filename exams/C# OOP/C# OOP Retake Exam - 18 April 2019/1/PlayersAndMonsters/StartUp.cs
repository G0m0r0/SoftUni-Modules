namespace PlayersAndMonsters
{
    using Core;
    using Core.Contracts;
    using Core.Factories;
    using Core.Factories.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using IO;
    using IO.Contracts;
    using Models.BattleFields;
    using Models.BattleFields.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IPlayerRepository playerRepository = new PlayerRepository();
            IPlayerFactory playerFactory = new PlayerFactory();

            ICardFactory cardFactory = new CardFactory();
            ICardRepository cardRepository = new CardRepository();

            IBattleField battlefield = new BattleField();

            IManagerController managerController = new ManagerController(
                playerRepository,
                playerFactory,
                cardFactory,
                cardRepository,      
                battlefield);

            IEngine engine = new Engine(
                reader,
                writer,
                managerController);

            engine.Run();
        }
    }
}