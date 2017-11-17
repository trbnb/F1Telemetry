using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdpTestApp
{
    public static class Constants
    {
        public static readonly IDictionary<int, string> TRACK_IDS = new Dictionary<int, string>()
        {
            { 0, "Melbourne" },
            { 1, "Sepang" },
            { 2, "Shanghai" },
            { 3, "Sakhir" },
            { 4, "Barcelona" },
            { 5, "Monaco" },
            { 6, "Montreal" },
            { 7, "Silverstone" },
            { 8, "Hockenheim" },
            { 9, "Hungaroring" },
            { 10, "Spa" },
            { 11, "Monza" },
            { 12, "Singapore" },
            { 13, "Suzuka" },
            { 14, "Abu Dhabi" },
            { 15, "Austin" },
            { 16, "Interlagos" },
            { 17, "Spielberg" },
            { 18, "Sochi" },
            { 19, "Mexico" },
            { 20, "Baku" },
            { 21, "Sakhir Short" },
            { 22, "Silverstone Short" },
            { 23, "Austin Short" },
            { 24, "Suzuka Short" }
        };

        public static readonly IDictionary<int, string> TEAM_IDS = new Dictionary<int, string>()
        {
            { 0, "Red Bull" },
            { 1, "Ferrari" },
            { 2, "McLaren" },
            { 3, "Renault" },
            { 4, "Mercedes" },
            { 5, "Sauber" },
            { 6, "Force India" },
            { 7, "Williams" },
            { 8, "Toro Rosso" },
            { 11, "Haas" },
        };

        public static readonly IDictionary<int, string> DRIVER_IDS = new Dictionary<int, string>()
        {
            { 9, "Lewis Hamilton" },
            { 15, "Valtteri Bottas" },
            { 16, "Daniel Ricciardo" },
            { 22, "Max Verstappen" },
            { 0, "Sebastian Vettel" },
            { 6, "Kimi Räikkönen" },
            { 5, "Sergio Perez" },
            { 33, "Esteban Ocon" },
            { 3, "Felipe Massa" },
            { 35, "Lance Stroll" },
            { 2, "Fernando Alonso" },
            { 34, "Stoffel Vandoorne" },
            { 23, "Carlos Sainz Jr." },
            { 1, "Daniil Kvyat" },
            { 7, "Romain Grosjean" },
            { 14, "Kevin Magnussen" },
            { 10, "Nico Hulkenberg" },
            { 20, "Jolyon Palmer" },
            { 18, "Marcus Ericsson" },
            { 31, "Pascal Wehrlein" }
        };
        
        public static readonly IDictionary<int, string> CLASSIC_TEAM_IDS = new Dictionary<int, string>()
        {
            { 0, "Williams 1992" },
            { 1, "McLaren 1988" },
            { 2, "McLaren 2008" },
            { 3, "Ferrari 2004" },
            { 4, "Ferrari 1995" },
            { 5, "Ferrari 2007" },
            { 6, "McLaren 1998" },
            { 7, "Williams 1996" },
            { 8, "Renault 2006" },
            { 10, "Ferrari 2002" },
            { 11, "Red Bull 2010" },
            { 12, "McLaren 1991" },
        };

        public static readonly IDictionary<int, string> CLASSIC_DRIVER_IDS = new Dictionary<int, string>()
        {
            { 23, "Arron Barnes" },
            { 1, "Martin Giles" },
            { 16, "Alex Murray" },
            { 68, "Lucas Roth" },
            { 2, "Igor Correia" },
            { 3, "Sophie Levasseur" },
            { 24, "Jonas Schiffer" },
            { 4, "Alain Forest" },
            { 20, "Jay Letourneau" },
            { 6, "Esto Saari" },
            { 9, "Yasar Atiyeh" },
            { 18, "Callisto Calabresi" },
            { 22, "Naota Izum" },
            { 10, "Howard Clarke" },
            { 8, "Lars Kaufmann" },
            { 14, "Marie Laursen" },
            { 31, "Flavio Nieves" },
            { 7, "Peter Belousov" },
            { 0, "Klimek Michalski" },
            { 5, "Santiago Moreno" },
            { 15, "Benjamin Coppens" },
            { 32, "Noah Visser" },
            { 33, "Gert Waldmuller" },
            { 34, "Julian Quesada" }
        };
    }
}
