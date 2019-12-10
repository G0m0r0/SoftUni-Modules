using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
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

            attackPlayer.Health += InitializeHealth(attackPlayer);
            enemyPlayer.Health += InitializeHealth(enemyPlayer);

            while (!attackPlayer.IsDead&&!enemyPlayer.IsDead)
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

                var enemyPlayerAttackPoints= enemyPlayer.CardRepository
                    .Cards
                    .Select(c => c.DamagePoints)
                    .Sum();

                attackPlayer.TakeDamage(enemyPlayerAttackPoints);
            }
        }

        private int InitializeHealth(IPlayer player)
        {
            var health = player.CardRepository
                .Cards
                .Select(c => c.HealthPoints).Sum();

            return health;
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
