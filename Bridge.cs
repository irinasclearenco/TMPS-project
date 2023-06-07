using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Models
{
    //bridge implementer
    public interface IAccount
    {
        
        IAccount CreateAccount();
        double CreateDiscount();


    }

    //concrete implementation

    public class DiscountAccount : IAccount
    {
        public double discount = 0.25;
        
        public IAccount CreateAccount()
        {
            Console.WriteLine("Inregistrare cu succes!\n");
            return new DiscountAccount();
        }
        public double CreateDiscount()
        {
            Console.WriteLine("Calculam reducerea\n\nFelicitari, aveti reducere pentru primul tur - 25%!");
            return discount;
        }

      
    }

  
    public class RegularAccount : IAccount
    {
        public double discount = 0.1;
        public IAccount CreateAccount()
        {
            Console.WriteLine("Inregistrare cu succes!");
            return new RegularAccount();
        }
        public double CreateDiscount()
        {
            Console.WriteLine("Calculam reducerea\n\nFelicitari, aveti reducere pentru primul tur - 10%!");
            return discount;
        }

    }

    public abstract class Person
    {
        protected IAccount account;
        public Person(IAccount account)
        {
            this.account = account;
        }
        public abstract IAccount CreateAccount();
    }

    //first abstraction (refined)
    public class NaturalPerson : Person
    {
        
        public NaturalPerson(IAccount account) : base(account)
        {
            Console.WriteLine("\nPrelucram datele");
        }
        public override IAccount CreateAccount()
        {
            
            return account;
        }
        
    }

    //second abstraction
    public class LegalPerson : Person
    {
        public LegalPerson(IAccount account) : base(account)
        {
            Console.WriteLine("\nPrelucram datele");
        }
        public override IAccount CreateAccount()
        {
            return account;
        }
    }

}
