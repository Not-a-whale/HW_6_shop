using System;

namespace NIkitaShopCSharp
{
    class Program
    {
        private static Product[] _products;
        private static User _user;
        
        static void Main(string[] args)
        {
            _products = GetWares();
            createUser();
            
        }

        static void createUser()
        {
            double money;
            string[] products = new string[10];

            Console.WriteLine("Hi, this is our awesome toy shop. \n Please insert some money: ");
            string tempAmountOfMoneyStr = Console.ReadLine();
            if (Double.TryParse(tempAmountOfMoneyStr, out money))
            {
                Console.WriteLine($"You have {money}$ now");
                _user = new User(money, products);
                ShowTheCart();
            }
            else
            {
                Console.WriteLine("You've made a mistake, please try again");
                createUser();
            }

        }

        static void Buy()
        {
            Console.WriteLine("Please tell us the Name of what you want to buy!");
            string nameOfTheProduct = Console.ReadLine();
            Product currentProduct = Array.Find(_products, elem => elem.PrintName() == nameOfTheProduct);
            if (currentProduct != null && !currentProduct.isAvaliable() && !currentProduct.isBooked())
            {

                // Remove money from the wallet
                if(_user.Purchase(currentProduct.GetPrice()) > 0)
                {
                    // Remove an item from the wares permanently, if there are any
                    currentProduct.RemoveAnItem();
                    Console.WriteLine($"Thank you for your purchase! You've got {_user.GetMoney()}$ left");
                    ShowTheCart();
                } else
                {
                    Console.WriteLine("You currently don't have any money. Please do something else");
                    GetAnActionFromUser();
                }
            } else
            {
                // Show an error if there aren't any goods on the market
                Console.WriteLine("I am sorry, we are out of our wares!");
                Console.WriteLine("Please do something else");
                GetAnActionFromUser();
            }
        }

        static void Book()
        {
            Console.WriteLine("Please tell us, what would you like to book.");
            string name = Console.ReadLine();
            Product currentProduct = Array.Find(_products, elem => elem.PrintName() == name);
            if (currentProduct != null && !currentProduct.isAvaliable() && !currentProduct.isBooked())
            {
                // Add an item to the card 
                _user.AddToCart(name);
                Array.Find(_products, product => product.PrintName() == name).BookAnItem();

                if (_user.GetCart().Length > 0)
                {
                    Console.WriteLine("These are all your current wares");
                    foreach(string item in _user.GetCart())
                    {
                        if(item != "")
                        {
                            Console.WriteLine(item);
                        }
                    }
                    Console.WriteLine("\n");
                    ShowTheCart();
                    Console.WriteLine("\n");
                    GetAnActionFromUser();
                }
            } else
            {
                Console.WriteLine("You've inputed the name of an non-existing item, please try again");
                ShowTheCart();
            }
        }

        static void Unbook()
        {
            Console.WriteLine("Please tell us, what would you like to book.");
            string name = Console.ReadLine();
            // Add item back to the wares
            Array.Find(_products, item => item.PrintName() == name).UnbookAnItem();
            // Remove an item from the person's cart
            bool doesItemExistInTheCart = _user.RemoveFromTheCart(name);
            if (!doesItemExistInTheCart) 
            {
                Console.WriteLine("You've made a mistake, please try again");
                Unbook();
            }
            Console.WriteLine("We are sorry you did not want it");
            ShowTheCart();
        }

        static void ShowTheCart()
        {
            Console.WriteLine("Now look at our beautiful wares");
            foreach(Product product in _products)
            {
                if(!product.isAvaliable() && !product.isBooked())
                {
                    Console.WriteLine($"We have a {product.PrintName()} in the amount of {product.PrintAmount()}");
                }
            }
            Console.WriteLine("\nWhat would you like to do now?");
            GetAnActionFromUser();
        }

        static void GetAnActionFromUser()
        {
            int choice;
            Console.WriteLine("1 - Buy something;");
            Console.WriteLine("2 - Book something;");
            Console.WriteLine("3 - Rescind booking of something;");
            Console.WriteLine("4 - See the cart;");
            Console.WriteLine("5 - Exit");
            choice = Convert.ToInt32(Console.ReadLine());

            switch(choice)
            {
                case 1:
                    Buy();
                    break;
                case 2:
                    Book();
                    break;
                case 3:
                    Unbook();
                    break;
                case 4:
                    ShowTheCart();
                    break;
                case 5:
                    return;
            }
        }

        static Product[] GetWares()
        {
            Product[] products = new Product[10];

            for(int i = 0; i < 10; i++)
            {
                switch (i) 
                {
                    case 0:
                        products[i] = new Product("sock bunny", 1, 50, false);
                        break;
                    case 1:
                        products[i] = new Product("fake muppet", 2, 70, false);
                        break;
                    case 2:
                        products[i] = new Product("plastic sonic blaster", 1, 79, false);
                        break;
                    case 3:
                        products[i] = new Product("purrple cat", 1, 33, false);
                        break;
                    case 4:
                        products[i] = new Product("\"White\" Bear", 1, 63, false);
                        break;
                    case 5:
                        products[i] = new Product("Monster truck", 1, 120, false);
                        break;
                    case 6:
                        products[i] = new Product("Fake syringe water fountain", 1, 20, false);
                        break;
                    case 7:
                        products[i] = new Product("Book of names", 1, 74, false);
                        break;
                    case 8:
                        products[i] = new Product("Animals playing Mozart, the book", 1, 178, false);
                        break;
                    case 9:
                        products[i] = new Product("The illustrated history of embroidery", 4, 44, false);
                        break;
                } 
            }
            return products;
        }
    }
}
