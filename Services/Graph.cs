using ChuyenBayDijkstra.DatabaseScript;
using System.Collections.Generic;
using System.Linq;

namespace ChuyenBayDijkstra.Services
{
    public class Graph
    {
        public List<City> Cities { get; set; } = new List<City>();
        public List<Flight> AllFlights { get; set; } = new List<Flight>();
        public List<List<Flight>> Adj { get; set; } = new List<List<Flight>>();

        public Graph()
        {
            LoadFromDatabase(GetCities());
        }

        public List<City> GetCities()
        {
            return Cities;
        }

        public void LoadFromDatabase(List<City> cities)
        {
            FlightDijkstraDataContext db = new FlightDijkstraDataContext();
            cities = db.Cities.Select(c => new City
            {
                city_id = c.city_id,
                name = c.name,
                country = c.country,
                airport_code = c.airport_code,
                latitude = (float)(c.latitude ?? 0),
                longitude = (float)(c.longitude ?? 0)
            }).OrderBy(c => c.city_id).ToList();

            // Load flights
            AllFlights = db.Flights.Select(f => new Flight
            {
                flight_id = f.flight_id,
                source_city_id = f.source_city_id,
                dest_city_id = f.dest_city_id,
                price = f.price == null ? 0f : (float)f.price,
                duration = f.duration ?? 0,
                airline = f.airline
            }).ToList();

            // Build adjacency list
            BuildAdjacencyList();
        }

        public void BuildAdjacencyList()
        {
            Adj = new List<List<Flight>>();

            if (Cities.Count == 0) return;

            int maxId = Cities.Max(c => c.city_id);

            for (int i = 0; i <= maxId; i++)
                Adj.Add(new List<Flight>());

            foreach (var f in AllFlights)
            {
                if (f.source_city_id < Adj.Count)
                    Adj[f.source_city_id].Add(f);
            }
        }

        public void AddCity(City city)
        {
            Cities.Add(city);

            while (Adj.Count <= city.city_id)
                Adj.Add(new List<Flight>());
        }

        public void AddFlight(Flight flight)
        {
            AllFlights.Add(flight);

            if (flight.source_city_id < Adj.Count)
                Adj[flight.source_city_id].Add(flight);
        }
    }
}
