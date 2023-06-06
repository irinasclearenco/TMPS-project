using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Models
{
    public interface ITour
    {
        TourA CreateHotel();
        TourB CreateTravel();
        int IPayment();
    }

    class PremiumTour : ITour
    {
        public TourA CreateHotel()
        {
            return new LuxaryHotel();
        }

        public TourB CreateTravel()
        {
            return new FirstClassTravel();
        }
        public int IPayment()
        {
   
            return 1500;
        }
    }

    class RegularTour : ITour
    {
        public TourA CreateHotel()
        {
            return new StandartHotel();
        }

        public TourB CreateTravel()
        {
            return new BusinessClassTravel();
        }

        public int IPayment()
        {
            return 800;
        }
    }

    class BudgetTour : ITour
    {
        public TourA CreateHotel()
        {
            return new BudgetHotel();
        }

        public TourB CreateTravel()
        {
            return new BudgetClassTravel();
        }
        public int IPayment()
        {
            return 400;

        }

    }

    public interface TourA
    {
        string UsefulFunctionA();
    }


    class LuxaryHotel : TourA
    {
        public string UsefulFunctionA()
        {
            return "\nDeoarece ati ales Premium tur, veti locui in cel mai bun hotel de 5 stele";
        }
    }

    class StandartHotel : TourA
    {
        public string UsefulFunctionA()
        {
            return "\nDeoarece ati ales Standart tur, veti locui in hotel standard de 4 stele";
        }
    }

    class BudgetHotel : TourA
    {
        public string UsefulFunctionA()
        {
            return "\nDeoarece ati ales Budget tur, veti locui in hotel simplu de 3 stele";
        }
    }

    public interface TourB
    {
        string UsefulFunctionB();
    }

    class FirstClassTravel : TourB
    {
        public string UsefulFunctionB()
        {
            return "Felicitari! Zborul dvs va fi de clasa intii!";

        }

    }

    class BusinessClassTravel : TourB
    {
        public string UsefulFunctionB()
        {
            return "Zborul dvs va fi de clasa business!";
        }

    }
    class BudgetClassTravel : TourB
    {
        public string UsefulFunctionB()
        {
            return "Zborul dvs va fi de clasa econom!";
        }

    }
}
