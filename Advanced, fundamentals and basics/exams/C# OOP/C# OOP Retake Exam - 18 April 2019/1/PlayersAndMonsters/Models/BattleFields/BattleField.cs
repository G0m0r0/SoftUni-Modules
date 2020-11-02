using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead||enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            if(attackPlayer is Beginner)
            {
                BonusForBegginer(attackPlayer);
            }
            if(enemyPlayer is Beginner)
            {
                BonusForBegginer(enemyPlayer);
            }

            attackPlayer = InitializeHealth(attackPlayer);
            enemyPlayer= InitializeHealth(enemyPlayer);

            while (true)
            {
                var attakerattackPoint = attackPlayer.CardRepository
                    .Cards
                    .Select(c => c.DamagePoints)
                    .Sum();

                enemyPlayer.TakeDamage(attakerattackPoint);

                if(enemyPlayer.IsDead)
                {
                    break;
                }

                var enemyPlayerAttackPoints= this.GetTotalDamagePoints(enemyPlayer.CardRepository);

                attackPlayer.TakeDamage(enemyPlayerAttackPoints);

                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }

        private int GetTotalDamagePoints(ICardRepository cardRepository)
        {
            int total = 0;

            foreach (var card in cardRepository.Cards)
            {
                total += card.DamagePoints;
            }

            return total;
        }

        private IPlayer InitializeHealth(IPlayer player)
        {
            player.Health += player.CardRepository
                .Cards
                .Select(c => c.HealthPoints)
                .Sum();

            return player;
        }

        private void BonusForBegginer(IPlayer player)
        {
            player.Health += 40;

            foreach (var card in player.CardRepository.Cards)
            {
                card.DamagePoints += 30;
            }
        }
    }
}
