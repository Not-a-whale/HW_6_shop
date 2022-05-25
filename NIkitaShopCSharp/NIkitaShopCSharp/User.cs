using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIkitaShopCSharp
{
    class User
    {
        private double _money;
        private string[] _products = new string[50];

        public User(double money, string[] products)
        {
            this._money = money;
            this._products = products;
        }

        public double Purchase(double amount)
        {
            this._money -= amount;
            return this._money >= 0 ? this._money : 0;
        }
        public void AddToCart(string name)
        {
            for(int i = 0; i < _products.Length; i++)
            {
                if(_products[i] == null || _products[i] == "")
                {
                    _products[i] = name;
                    break;
                }
            }
        }

        public bool RemoveFromTheCart(string name)
        {
            for(int i = 0; i < this._products.Length; i++)
            {
                if(_products[i] == name)
                {
                    _products[i] = "";
                    return true;
                }
            }
            return false;
        }
        public double GetMoney()
        {
            return this._money;
        }

        public string[] GetCart()
        {
            return this._products;
        }
    }
}
