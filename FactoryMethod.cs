using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Models
{
   

    abstract class Tour
    {

        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string PassportId { get; set; }



        public Tour(string clientName, string clientSurname, string passportId)
        {
            ClientName = clientName;
            ClientSurname = clientSurname;
            PassportId = passportId;

        }

        // фабричный метод
        abstract public CountryTour CreateCountryTour();
    }

    class TurkeyTour : Tour
    {
        public TurkeyTour(string clientName, string clientSurname, string clientAddress) : base(clientName, clientSurname, clientAddress)
        {
            Console.Write("\n" + this.ClientName + " "
                        + this.ClientSurname +
                        " cu ID pasaport " +
                        this.PassportId +
                        " a ales calatorie in Turcia!\n");
        
        }

        public override CountryTour CreateCountryTour()
        {
            return new TourInTurkey();
        }

    }

    class GreeceTour: Tour
    {
        public GreeceTour(string clientName, string clientSurname, string clientAddress) : base(clientName, clientSurname, clientAddress)
        {
            Console.Write("\n" + this.ClientName + " "
                        + this.ClientSurname +
                        " cu ID pasaport " +
                        this.PassportId +
                        " a ales calatorie in Grecia!\n");
           

        }

        public override CountryTour CreateCountryTour()
        {
            return new TourInTurkey();
        }
    }

    class EgyptTour : Tour
    {
        public EgyptTour(string clientName, string clientSurname, string clientAddress) : base(clientName, clientSurname, clientAddress)
        {
            Console.Write("\n"+this.ClientName + " "
                        + this.ClientSurname +
                        " cu ID pasaport " +
                        this.PassportId +
                        " a ales calatorie in Egipt!\n");
          

        }

        public override CountryTour CreateCountryTour()
        {
            return new TourInEgypt();
        }
    }

    abstract class CountryTour
    {
         abstract public void someInformation();
    }

    class TourInTurkey : CountryTour
    {
        public TourInTurkey()
        {
            Console.WriteLine("Turul in Turcia este inregistrat\n");
        }
        public override void someInformation()
        {
            Console.WriteLine("");
            Console.WriteLine("Informatie despre tur: \nTurcia nu este doar despre plaje excelente ale celor patru mari, ci si Istanbul magnific\ncu Moscheea Albastra si Palatul Topkapi, izvoare termale Yalova și \nPamukkale alb ca zapada, manastiri Cappadocia, schi si cumparaturi.");
            Console.WriteLine("\n\n");
        }

    }
    class TourInGreece : CountryTour
    {
        public TourInGreece()
        {
            Console.WriteLine("Turul in Grecia este inregistrat\n");
        }
        public override void someInformation()
        {
            Console.WriteLine("");
            Console.WriteLine("Informatie despre tur:\nGrecia este o tara in care antichitatile sunt la fiecare pas: Atena, Delphi, Teba si Meteora,\nmanastiri de stanca si sfantul Munte Athos. Exista, de asemenea, plaje grozave, mare limpede, insule pitoresti si hoteluri spa. ");
            Console.WriteLine("\n");
        }
    }
    class TourInEgypt : CountryTour
    {
        public TourInEgypt()
        {
            Console.WriteLine("Turul in Egipt este inregistrat\n");
        }
        public override void someInformation()
        {
            Console.WriteLine("");
            Console.WriteLine("Informatie despre tur: \nAvantajele Egiptului sunt cunoscute de toata lumea: o vacanta la plaja de calitate pe tot parcursul anului\nfara Marea Mediterana si Marea Rosie, diluata cu scufundari excelente,\nplus o „excursie” variata: piramidele, Sfinxul si Luxor.");
            Console.WriteLine("\n");
        }
    }
}

