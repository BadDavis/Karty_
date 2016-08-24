using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karty__Idz_na_ryby
{
    class Player
    {
        private string name;
        public string Name { get { return name; } }
        private Random random;
        private Deck cards;
        private TextBox textBoxOnForm;

        public Player(string name, Random random, TextBox textBoxOnForm)
        {
            this.name = name;
            this.textBoxOnForm = textBoxOnForm;
            this.random = random;
            this.cards = new Deck(new Card[] { });
            textBoxOnForm.Text += name + " dołączył do gry " + Environment.NewLine;
        }

        public IEnumerable<Values> PullOutBooks()
        {
            List<Values> books = new List<Values>();
            for (int i = 0; i <= 13; i++)
            {
                Values value = (Values)i;
                int howMany = 0;
                for (int card = 0; card < cards.Count; card++)
                {
                    if (cards.Peek(card).Values==value)
                    {
                        howMany++;
                    }
                }
                if (howMany==4)
                {
                    books.Add(value);
                    for (int card = 0; card < cards.Count; card++)
                    {
                        cards.Deal(card);
                    }
                }
            }
            return books;
        }

        public Values GetRandomValue()
        {
            Card randomCard = cards.Peek(random.Next(cards.Count));
            return randomCard.Values;
        }

        public Deck DoYouhaveAny(Values value)
        {
            //przeciwnik sprawdza czy mam karty o okreslonej wartosci, wyciagane za pomoca Deck.PullOutValues()
            Deck cardsiHave = cards.PullOutValues(value);
            textBoxOnForm.Text += Name + " ma " + cardsiHave.Count + " " + Card.Plural(value, cardsiHave.Count) + Environment.NewLine;
            return cardsiHave;
        }

        public void  AskForACard(List<Player> players, int myIndex, Deck stock)
        {
            //tu jest przeciazana metoda, wybierz z zestawu losowa wartosc przy uzyciu getrandomvalue(), i zazadaj jej za pomoca askforacard()
            if (cards.Count > 0)
            {
                cards.Add(stock.Deal());
            }
            Values randomValue = GetRandomValue();
            AskForACard(players, myIndex, stock, randomValue);
        }

        public void AskForACard(List<Player> players, int myIndex, Deck stock, Values value)
        {
            textBoxOnForm.Text += Name + " pyta, czy ktoś ma " + Card.Plural(value, 1) + Environment.NewLine;

            int totalCardsGiven = 0;
            for (int i = 0; i < players.Count; i++)
            {
                if (i != myIndex)
                {
                    Player player = players[i];
                    Deck CardsGiven = player.DoYouhaveAny(value);
                    totalCardsGiven += CardsGiven.Count;
                    while (CardsGiven.Count>0)
                    {
                        cards.Add(CardsGiven.Deal());
                    }
                }
            }
            if (totalCardsGiven == 0)
            {
                textBoxOnForm.Text += Name + " pobrał kartę z kupki. " + Environment.NewLine;
                cards.Add(stock.Deal());
            }
        } 

        public int CardCount { get { return cards.Count; } }

        public void TakeCard(Card card) { cards.Add(card); }
        public IEnumerable<string> GetCardnames() { return cards.GetCardNames(); }
        public Card Peek(int cardNumber) { return cards.Peek(cardNumber); }
        public void Sorthand() { cards.SortbyValue(); }
    }
}
