using TravelAgency.Models;
using System.IO;
using System;
using AbstractFactory.Models;

namespace TravelAgency
{
    
    class Client
    {
        public double tourpayment;

        public void Main()
        {

           //FactoryMethod

            Console.WriteLine("");
            Console.Write("Buna ziua! Bine ati venit la agentia noastra de turism!\nPnetru a continua, introduceti urmatoarele date:\n\nNume: ");
            string clientName = (Console.ReadLine());
            Console.Write("Prenume: ");
            string clientSurname = (Console.ReadLine());
            Console.Write("ID Pasaport: ");
            string passportId = (Console.ReadLine());
            Console.WriteLine("");
            Console.Clear();
            Method();
            Console.Write("La moment, sunt disponibile tururi in: Turcia, Grecia, Egipt\nAlegeti tara dorita: ");
            string destination = (Console.ReadLine());
            CountryTour countryTour;
            switch (destination)
            {
                case "Turcia":
                    new TurkeyTour(clientName, clientSurname, passportId);
                    countryTour = new TourInTurkey();
                    countryTour.someInformation();
                    break;

                case "Grecia":
                    new GreeceTour(clientName, clientSurname, passportId);
                    countryTour = new TourInGreece();
                    countryTour.someInformation();
                    break;

                case "Egipt":
                    new EgyptTour(clientName, clientSurname, passportId);
                    countryTour = new TourInEgypt();
                    countryTour.someInformation();
                    break;

            }


            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("");
            
            //AbstractFactory
            Console.Write("Alegeti turul in dependenta de pret: Premium, Regular, Budget\n");
            string qualitytour = (Console.ReadLine());
            
            switch (qualitytour)
            {
                case "Premium": ClientMethod(new PremiumTour());
                    break;


                case "Regular":ClientMethod(new RegularTour());
                    break;

                case "Budget": ClientMethod(new BudgetTour());
                    break;

            }
            Console.WriteLine("");
            Console.ReadKey();
            Console.Clear();

            //ChainofResposibiblity
            System.Threading.Thread.Sleep(1500);
            ValidatorBase datevalidator = new DateAvailableValidator();
            ValidatorBase apartmentvalidator = new ApartmentAvailableValidator();
            ValidatorBase paymentvalidator = new PaymentValidator();
            datevalidator.SetSuccessor(apartmentvalidator);
            apartmentvalidator.SetSuccessor(paymentvalidator);
            Request p = new Request("data");
            datevalidator.ProcessRequest(p);
            p = new Request("numarul");
            datevalidator.ProcessRequest(p);
            p = new Request("plata");
            datevalidator.ProcessRequest(p);
            IPayment payment = new PaymentValidator();
            double pay =payment.Payment(tourpayment, dis);
            Console.WriteLine("\n");
            Console.ReadKey();
            Console.Clear();

            try
            {
               
                StreamWriter sw = new StreamWriter(@"C:\\database.txt", true);
                sw.WriteLine("" + Environment.NewLine);
                //Write a line of text
                sw.WriteLine("Nume: {0}"+Environment.NewLine+"Prenume: {1}" + Environment.NewLine+"Tur: {2} " + Environment.NewLine+"Tara: {3}" + Environment.NewLine + "Data turului: {4}" +Environment.NewLine+"Pretul:{5} ", clientName,clientSurname,qualitytour,destination,p.RandomDay(), pay+"$");
                sw.WriteLine(Environment.NewLine+"");
                //Write a second line of text
                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            //Strategy
            Console.WriteLine("");
            Console.WriteLine("Alegeti metoda de plata: Cash, E-wallet, Card");
            Console.Write("Metoda de plata: ");
            string paymentType = Console.ReadLine();
            PaymentContext ctx = new PaymentContext();
            if ("Cash".Equals(paymentType, StringComparison.InvariantCultureIgnoreCase))
            {
                ctx.SetPaymentStrategy(new CashPayment());
            }
            else if ("E-wallet".Equals(paymentType, StringComparison.InvariantCultureIgnoreCase))
            {
                ctx.SetPaymentStrategy(new EWalletPayment(clientName, clientSurname,passportId, qualitytour, destination, p.RandomDay(), pay + "$"));
            }

            else if ("Card".Equals(paymentType, StringComparison.InvariantCultureIgnoreCase))
            {
                ctx.SetPaymentStrategy(new CardPayment(clientName, clientSurname,passportId, qualitytour, destination, p.RandomDay(), pay + "$"));
            }

            ctx.payment();
            Console.WriteLine("");
            Console.ReadKey();
            Console.Clear();

            //Facade
            Order order = new Order();
            order.PlaceOrder();
            Console.WriteLine("");
            Console.Clear();

        }
        
        
        public double ClientMethod(ITour tour)
        {
            var appA = tour.CreateHotel();
            tourpayment = tour.IPayment();
            Console.WriteLine("\nSuma de plata: "+ tour.IPayment());
            var appB = tour.CreateTravel();
            Console.WriteLine(appA.UsefulFunctionA());
            Console.WriteLine(appB.UsefulFunctionB());
            return tourpayment;
        }
        public double dis;
        //Bridge
        public void Method()
        {
            Console.WriteLine("");
            Console.Write("Aveti un cod promotional pentru primul tur? (da/nu) ");
            string answer = Console.ReadLine();
            Console.Write("Sunteti persoana juridica sau fizica? (j/f) ");
            string b = Console.ReadLine();
            if (answer == "da" && b == "j")
            {
                Person person = new LegalPerson(new DiscountAccount());
                IAccount discount = person.CreateAccount();
                discount.CreateAccount();
                dis = discount.CreateDiscount();


            }
            else if (answer == "nu" && b == "j")
            {
                Person person = new LegalPerson(new RegularAccount());
                person.CreateAccount();
                Console.WriteLine("");

            }
            else if (answer == "da" && b == "f")
            {
                Person person = new NaturalPerson(new DiscountAccount());
                IAccount discount = person.CreateAccount();
                discount.CreateAccount();
                dis = discount.CreateDiscount();


            }
            else if (answer == "nu" && b == "f")
            {
                Person person = new NaturalPerson(new RegularAccount());
                person.CreateAccount();
                Console.WriteLine("");
            }
            Console.WriteLine("");
            Console.ReadKey();
            Console.Clear();
          
            
        }
    
    }
       
    class Program
    {
        static void Main()
        {
            
            new Client().Main();
         
            Console.WriteLine("Lista clientilor companiei: ");
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\database.txt");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)

                {
                    //write the line to console window
                    Console.WriteLine(line);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            Console.ReadKey();
        }
    }
}
