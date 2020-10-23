namespace BattleCards2.Controllers
{
    using BattleCards2.Services;
    using BattleCards2.ViewModels.Cards;
    using SUS.HTTP;
    using SUS.MvcFramework;
    public class CardsController : Controller
    {
        private readonly ICardService cardService;

        public CardsController(ICardService cardService)
        {
            this.cardService = cardService;
        }
        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(InputCardModel card)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (card.Name.Length < 5 || card.Name.Length > 15)
            {
                return this.Error("Card name should be between 5 and 15!");
            }

            if (string.IsNullOrEmpty(card.Image))
            {
                return this.Error("Image is required!");
            }

            if (string.IsNullOrEmpty(card.Keyword))
            {
                return this.Error("Image is required!");
            }

            if (card.Attack < 0)
            {
                return this.Error("Attack can not be negative!");
            }

            if(card.Health<0)
            {
                return this.Error("Health can not be negative!");
            }

            if (string.IsNullOrEmpty(card.Description)|| card.Description.Length > 200)
            {
                return this.Error("Description can not be over 200 characters!");
            }

            var userId = this.GetUserId();
            int cardId=cardService.AddCard(card,userId);

            cardService.AddCardToCollection(userId, cardId);

            return this.Redirect("/Cards/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var cards = this.cardService.GetAll();

            return this.View(cards);
        }

        public HttpResponse AddToCollection(int cardId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            this.cardService.AddCardToCollection(userId, cardId);
            return this.Redirect("/Cards/All");
        }

        public HttpResponse Collection()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            var cardsInPrivateCollection = this.cardService.GetAllCardsInColletion(userId);

            return this.View(cardsInPrivateCollection);
        }

        public HttpResponse RemoveFromCollection(int cardId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = GetUserId();
            cardService.RemoveFromCollection(cardId,userId);

            return this.Redirect("/Cards/Collection");
        }

        public HttpResponse RemoveFromEntireCollection(int cardId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            if (!cardService.RemoveFromEntireCollection(cardId,userId))
            {
                return this.Error("You dont have rights to delete this card!");
            }

            return this.Redirect("/Cards/All");
        }
    }
}
