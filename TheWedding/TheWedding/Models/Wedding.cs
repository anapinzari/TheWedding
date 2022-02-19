using System;

namespace TheWedding.Models
{
    class Wedding
    {
        private MarriedPerson _bride;
        private MarriedPerson _groom;
        private Godparent _godmother;
        private Godparent _godfather;
        private Guest[] _guests;

        public MarriedPerson Bride
        {
            get
            {
                return _bride;
            }
            set
            {
                if (value == null) throw new Exception("The wedding must have a bride. It cannot be empty.");
                _bride = value;
            }
        }
        public MarriedPerson Groom
        {
            get
            {
                return _groom;
            }
            set
            {
                if (value == null) throw new Exception("The wedding must have a groom. It cannot be empty.");
                _groom = value;
            }
        }
        public Godparent Godmother
        {
            get
            {
                return _godmother;
            }
            set
            {
                if (value == null) throw new Exception("The wedding must have a godmother. It cannot be empty.");
                _godmother = value;
            }
        }
        public Godparent Godfather
        {
            get
            {
                return _godfather;
            }
            set
            {
                if (value == null) throw new Exception("The wedding must have a godfather. It cannot be empty.");
                _godfather = value;
            }
        }
        public Guest[] Guests
        {
            get
            {
                return _guests;
            }
            set
            {
                if (value == null || value.Length == 0) throw new Exception("The wedding must have guests. It cannot be empty.");
                _guests = value;
            }
        }

        public Wedding(MarriedPerson bride, MarriedPerson groom, Godparent godmother, Godparent godfather, Guest[] guests)
        {
        }

        public bool isSuccessful()
        {
            double monetaryGiftFromGodparents = GetMonetaryGiftFromGodParents();
            int expectedAmountByTheCoupleFromGodparents, expectedAmountByTheCoupleFromGuests;
            GetExpectedAmount(out expectedAmountByTheCoupleFromGodparents, out expectedAmountByTheCoupleFromGuests);
            double percentageOfGuestsWhoLivedUpToExceptations = GetPercentageOfGuestsWhoLivedUpToExceptations(expectedAmountByTheCoupleFromGuests);
            double seventyFivePercentOfTheGodparentsAmount = GetSeventyFivePercentOfTheGodparentsAmount(expectedAmountByTheCoupleFromGodparents);
            return percentageOfGuestsWhoLivedUpToExceptations >= 80
                && monetaryGiftFromGodparents >= seventyFivePercentOfTheGodparentsAmount;
        }

        private double GetSeventyFivePercentOfTheGodparentsAmount(int expectedAmountByTheCoupleFromGodparents)
        {
            double seventyFivePercentOfTheGodparentsAmount = (75 * expectedAmountByTheCoupleFromGodparents) / 100;
            return seventyFivePercentOfTheGodparentsAmount;
        }

        private double GetMonetaryGiftFromGodParents()
        {
            int godparentsMonetaryGifts = GetSumOfTheGodparentsMonetaryGifts();
            return godparentsMonetaryGifts / 2;
        }

        private void GetExpectedAmount(out int expectedAmountByTheCoupleFromGodparents, out int expectedAmountByTheCoupleFromGuests)
        {
            expectedAmountByTheCoupleFromGodparents = GetExpectedAmountByTheCoupleFromGodParents();
            expectedAmountByTheCoupleFromGuests = GetExpectedAmountByTheCoupleFromGuests();
        }

        private double GetPercentageOfGuestsWhoLivedUpToExceptations(int expectedAmountByTheCoupleFromGuests)
        {
            int numberOfGuestsWhoLivedUpToExpectations = GetNumberOfGuestsWhoLivedUpToExpectations(expectedAmountByTheCoupleFromGuests);
            double percentageOfGuestsWhoLivedUpToExpectations = (numberOfGuestsWhoLivedUpToExpectations * 100) / Guests.Length;
            return percentageOfGuestsWhoLivedUpToExpectations;
        }

        private int GetNumberOfGuestsWhoLivedUpToExpectations(int expectedAmountByTheCoupleFromGuests)
        {
            int numberOfGuestsWhoLivedUpToExpectations = 0;
            for (int i = 0; i < Guests.Length; i++)
            {
                if (Guests[i].MonetaryGift >= expectedAmountByTheCoupleFromGuests)
                {
                    numberOfGuestsWhoLivedUpToExpectations++;
                }
            }
            return numberOfGuestsWhoLivedUpToExpectations;
        }

        private int GetExpectedAmountByTheCoupleFromGuests()
        {
            return (Bride.ExpectedAmountFromGuests + Groom.ExpectedAmountFromGuests) / 2;
        }

        private int GetExpectedAmountByTheCoupleFromGodParents()
        {
            return (Bride.ExpectedAmountFromGodparents + Groom.ExpectedAmountFromGodparents) / 2;
        }

        private int GetSumOfTheGodparentsMonetaryGifts()
        {
            return Godfather.MonetaryGift + Godmother.MonetaryGift;
        }
    }
}
