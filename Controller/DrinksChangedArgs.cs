using Model;
using System;
namespace Controller
{
    public class DrinksChangedArgs : EventArgs
    {

        public Drink Drink;

        public DrinksChangedArgs(Drink drink)
        {
            Drink = drink;
        }


    }
}

