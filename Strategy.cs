using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Models;

namespace AbstractFactory.Models
{
    public abstract class PersonalData
    {
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string PassportId { get; set; }
        public string QualityTour { get; set; }
        public string Destination { get; set; }
        public DateTime Date { get; set; }
        public string Pay { get; set; }

        public PersonalData(string clientName, string clientSurname, string passportId, string qualitytour, string destination, DateTime date, string pay)
        {
            ClientName = clientName;
            ClientSurname = clientSurname;
            PassportId = passportId;
            QualityTour = qualitytour;
            Destination = destination;
            Date = date;
            Pay = pay;

        }

    }
    public interface IPaymentStrategy
    {
        void Payment();
    }

   
    public class CashPayment : IPaymentStrategy
    {
        public void Payment()
        {
            Console.WriteLine("Pentru plata cash va invitam la biroul de pe bd. Moscova 17");
        }
    }

    public class CardPayment : PersonalData, IPaymentStrategy
    {
        public CardPayment (string clientName, string clientSurname, string passportId, string qualitytour, string destination, DateTime date, string pay) : base(clientName, clientSurname,passportId, qualitytour,destination, date,  pay)
        {
            Console.Write("\nNume:" + this.ClientName + "\nPrenume: "
                       + this.ClientSurname +
                       "\nID pasaport: " +
                       this.PassportId +
                       "\nTur:" + this.QualityTour+ "\nTara:" + 
                       this.Destination + "\nData: "+ 
                       this.Date + "\nPlata: "+ this.Pay + " card\n");

        }
        public void Payment()
        {
            Console.Write("\nIntroduceti nr. cardului: ");
            string card=Console.ReadLine();
            System.Threading.Thread.Sleep(1000);
            Console.Write("Clientul cu nr. cardului {0} este gasit\n",card);

        }
    }

    public class EWalletPayment : PersonalData,IPaymentStrategy
    {
        public EWalletPayment(string clientName, string clientSurname, string passportId, string qualitytour, string destination, DateTime date, string pay) : base(clientName, clientSurname, passportId, qualitytour, destination, date, pay)
        {
            Console.Write("\nNume:" + this.ClientName + "\nPrenume: "
                       + this.ClientSurname +
                       "\nID pasaport: " +
                       this.PassportId +
                       "\nTur:" + this.QualityTour + "\nTara:" +
                       this.Destination + "\nData: " +
                       this.Date + "\nPlata: " + this.Pay + " e-Wallet\n");

        }
        public void Payment()
        {
            Console.Write("\nIntroduceti numarul e-Wallet: ");
            string card = Console.ReadLine();
            System.Threading.Thread.Sleep(1000);
            Console.Write("Clientul cu nr e-Wallet {0} este gasit\n", card);

        }
    }

    public class PaymentContext
    {
        private IPaymentStrategy paymentStrategy;

        public void SetPaymentStrategy(IPaymentStrategy strategy)
        {
            this.paymentStrategy = strategy;
        }
        public void payment()
        {
            paymentStrategy.Payment();
        }
    }
}
