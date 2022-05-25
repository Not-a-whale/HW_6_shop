using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIkitaShopCSharp
{
    class Product
    {
        private string _name;
        private int _amount;
        private double _price;
        private bool _isBooked;
        private bool _isRemoved;

        public Product(string _name, int _amount = 1, double _price = 100, bool _isBooked = false)
        {
            this._name = _name;
            this._amount = _amount;
            this._price = _price;
            this._isBooked = _isBooked;
            this._isRemoved = false;
        }

        public string PrintName()
        {
            return this._name;
        }

        public int PrintAmount()
        {
            return this._amount;
        }

        public void RemoveAnItem()
        {
            if(_amount == 1)
            {
                this._isRemoved = true;
            } else
            {
                this._amount -= 1;
            }
        }

        public void BookAnItem()
        {
            if (_amount == 1)
            {
                this._isBooked = true;
            }
            else
            {
                this._amount -= 1;
            }
        }

        public void UnbookAnItem()
        {
            if(_amount == 1 && _isBooked == true)
            {
                this._isBooked = false;
            } else
            {
                this._amount += 1;
            }
        }

        public double GetPrice()
        {
            return this._price;
        }

        public bool isAvaliable()
        {
            return this._isRemoved;
        }

        public bool isBooked()
        {
            return this._isBooked;
        }
    }
}
