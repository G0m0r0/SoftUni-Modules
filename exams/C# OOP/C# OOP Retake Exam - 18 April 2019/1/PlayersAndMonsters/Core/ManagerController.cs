namespace PlayersAndMonsters.Core
{
    using System;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private IPlayerRepository playerRepository;
        private ICardRepository cardRepository;

        private ICardFactory cardFactory;
        private IPlayerFactory playerfactory;

        private IBattleField battlefield;

        public ManagerController(IPlayerRepository playerRepository, IPlayerFactory playerfactory, ICardFactory cardFactory, ICardRepository cardRepository, IBattleField battlefield)
        {
            this.playerRepository = playerRepository;
            this.cardRepository = cardRepository;
            this.cardFactory = cardFactory;
            this.playerfactory = playerfactory;
            this.battlefield = battlefield;
        }

        public string AddPlayer(string type, string username)
        {
            var player = this.playerfactory.CreatePlayer(type, username);

            this.playerRepository.Add(player);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayer,type,username);
        }

        public string AddCard(string type, string name)
        {
            var card = this.cardFactory.CreateCard(type, name);

            this.cardRepository.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var user = this.playerRepository.Find(username);
            var card = this.cardRepository.Find(cardName);

            user.CardRepository.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, username, cardName);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attacker = this.playerRepository.Find(attackUser);
            var enemy = this.playerRepository.Find(enemyUser);

            this.battlefield.Fight(attacker, enemy);

            return string.Format(ConstantMessages.FightInfo, attacker.Health, enemy.Health);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var player in playerRepository.Players)
            {
                sb.AppendLine(string.Format(ConstantMessages.PlayerReportInfo,player.Username,player.Health,player.CardRepository.Count));
                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(string.Format(ConstantMessages.CardReportInfo, card.Name, card.DamagePoints));
                }
                sb.AppendLine(string.Format(ConstantMessages.DefaultReportSeparator));
            }

            return sb.ToString().TrimEnd();
        }
    }
}
