using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        public CardRepository()
        {
            this.cardsByName = new Dictionary<string, ICard>();
        }
        private Dictionary<string, ICard> cardsByName;
        public int Count => this.cardsByName.Count;

        public IReadOnlyCollection<ICard> Cards 
            => this.cardsByName.Values.ToList().AsReadOnly();

        public void Add(ICard card)
        {
            if(card==null)
            {
                throw new ArgumentException("Card cannot be null!");
            }
            if(this.cardsByName.ContainsKey(card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            cardsByName.Add(card.Name, card);
        }

        public ICard Find(string name)
        {
            ICard card = null;
            if(cardsByName.ContainsKey(name))
            {
                card = cardsByName[name];
            }

            return card;
        }

        public bool Remove(ICard card)
        {
            if(card==null)
            {
                throw new ArgumentException("Card cannot be null!");
            }
            return cardsByName.Remove(card.Name);
        }
    }
}
