namespace BattleCards2.Services
{
    using BattleCards2.ViewModels.Cards;
    using System.Collections.Generic;

    public interface ICardService
    {
        int AddCard(InputCardModel card,string userId);

        IEnumerable<CardViewModel> GetAll();

        void AddCardToCollection(string userId,int cardId);

        IEnumerable<CardViewModel> GetAllCardsInColletion(string userId);

        void RemoveFromCollection(int cardId,string userId);

        bool RemoveFromEntireCollection(int cardId,string userId);
    }
}
