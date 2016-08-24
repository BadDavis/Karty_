using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karty__Idz_na_ryby
{
    class Card
    {

        public Card(Suits Suit, Values Value)
        {
            Suit = Suits;
            Values = Value;
        }
        public Values Values { get; set; }
        public Suits Suits { get; set; }
        public string Name { get { return names[(int)Values] + " " + suits[(int)Suits]; } }


        private static string[] suits = new string[]
        {
            "pik", "trefl", "karo", "kier"
        };

        private static string[] names = new string[]
        {
            "", " As", "Dwójka", "Trójka", "Czwórka", "Piątka", "Szóstka", "Siódemka",
            "Ósemka", "Dziewiątka", "Dziesiątka", "Walet", "Dama", "Król"
        };


        public override string ToString()
        {
            return Values + Suits.ToString();
        }

        public static bool DoesCardmatch(Card CardoToCheck, Suits Suit)
        {
            if (CardoToCheck.Suits == Suit)
            {
                return true;
            }
            else return false;
        }

        public static bool DoesCardmatch(Card CardToCheck, Values Value)
        {
            if (CardToCheck.Values == Value)
            {
                return true;
            }
            else return false;
        }



        private static string[] names0 = new string[]
        {
            "", "asów", "dwójek", "trójek", "czwórek", "piątek", "szóstek", "siódemek",
            "ósemek", "dziewiątek", "dziesiątek", "waletów", "dam", "króli"
        };

        private static string[] names1 = new string[]
        {
            "", "asa", "dwójkę", "trójkę", "czwórkę", "piątkę", "szóstkę", "siódemkę",
            "ósemkę", "dziewiątkę", "dziesiątkę", "waleta", "damę", "króla"
        };

        private static string[] names2AndMore = new string[]
        {
            "", "asy", "dwójki", "trójki", "czwórki", "piątki", "szóstki", "siódemki",
            "ósemki", "dziewiątki", "dziesiątki", "walety", "damy", "króle"
        };

        public static string Plural(Values value, int count)
        {
            if (count==0)
            {
                return names0[(int)value];
            }
            if (count==1)
            {
                return names1[(int)value];
            }
            return names2AndMore[(int)value];
        }
    }
    public enum Values
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
    }

    public enum Suits
    {
        Spades,
        Clubs,
        Diamonds,
        Hearts,
    }
}
