using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public delegate void PriceChanged(decimal OldPrice, decimal NewPrice);

    public class Product
    {
        private decimal _price;

        public event PriceChanged PriceChanged;

        public decimal price
        {
            get => _price;
            set { 
               if (value != _price)
                {
                    var oldPrice = _price;
                    _price = value;
                    PriceChanged?.Invoke(oldPrice, _price);
                }
            }
        }
        


    }
}
