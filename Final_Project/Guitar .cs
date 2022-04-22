using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    internal class Guitar 
    {
        private string _name;
        private string _num;
        private string _type;
        private string _amount;
        private string _price;
        private string _date;
        private string _accessories;
        public Guitar(string name,string num, string type, string amount,string price, string date, string accessories)
        {
            this._name = name;
            this._num = num;
            this._type = type;
            this._amount = amount;
            this._price = price;
            this._date = date;
            this._accessories = accessories;
        }

        public string getName() {
            return _name;
        }
        public string getNum() {
            return _num;
        }
        public string getType() {
            return _type;
        }
        public string getAmount() {
            return _amount;
        }
        public string getPrice() {
            return _price;
        }
        public string getDate() {
            return _date;
        }
        public string getAccessories() {
            return _accessories;
        }
    }
}
