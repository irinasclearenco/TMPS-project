using System;


namespace AbstractFactory.Models
{
    interface IPayment
    {
        double Payment(double payment, double discount);
    }
    public abstract class ValidatorBase
    {
        protected ValidatorBase successor;
        public void SetSuccessor(ValidatorBase successor)
        {
            this.successor = successor;
        }
        public abstract void ProcessRequest(Request request);
    }

    public class DateAvailableValidator : ValidatorBase
    {
        
        public override void ProcessRequest(Request request)
        {
           
           
            if (request.request == "data")
            {
                Console.WriteLine("Data libera pentru tur: {0}",
                     request.RandomDay());
            }
            else if (successor != null)
            {
                successor.ProcessRequest(request);
            }
        }
    }

    
    public class ApartmentAvailableValidator : ValidatorBase
    {
        public override void ProcessRequest(Request request)
        {
            if (request.request == "numarul")
            {
                Console.WriteLine(
                   "Camera in hotel este disponibila"
                   );
            }

            else if (request != null)
            {
                successor.ProcessRequest(request);
            }

        }
    }

    public class PaymentValidator : ValidatorBase,IPayment
    {
        public double Payment(double payment, double discount)
        {
           
            payment -= (payment *discount);
            Console.WriteLine("Plata pentru tur este de: "+payment+"$");
            return payment;

        }
        public override void ProcessRequest(Request request)
        {

            if (request.request == "plata")
            {
                Console.WriteLine(
                   "Suma de plata este calculata" 
                   ); ;
            }

        }
    }

    public class Request:DateAvailableValidator
    {

        private Random gen = new Random();
        public DateTime RandomDay()
        {
            DateTime start = new DateTime(2023, 1, 1,13,30,0);
            DateTime end = new DateTime(2027, 1, 1,1,1,1);
            int range = (end - start).Days;
            return start.AddDays(gen.Next(range));
        }
        public string request;
        public Request(string request)
        {
            this.request = request;
        }

        public string Purpose { get; set; } 
       
        
    }
    
}

