
using ChuyenBayDijkstra.DatabaseScript;
using System.Collections.Generic;
using System.Linq;
namespace Flight_Dijkstra

{
    public class Graph
    {
        public List<City> Cities = new List<City>();
        public List<List<Flight>> Adj = new List<List<Flight>>();
        private List<Flight> _allFlights = new List<Flight>();

        public void LoadFromDatabase()
        {
            FlightDijkstraDataContext db = new FlightDijkstraDataContext();

            // Load city
            Cities = db.Cities.Select(dbCity => new City
            {
                city_id = dbCity.city_id,                // Map city_id (DB) -> Id (Class)
                name = dbCity.name,
                country = dbCity.country,
                airport_code = dbCity.airport_code,

                latitude = (float)dbCity.latitude,
                longitude = (float)dbCity.longitude
            }).OrderBy(c => c.city_id).ToList();

            // 2. LOAD FLIGHT (Lấy toàn bộ chuyến bay ra trước)
            var dbFlights = db.Flights.Select(dbFlight => new Flight
            {
                flight_id = dbFlight.flight_id,
                source_city_id = dbFlight.source_city_id, // Map source_city_id -> SourceCityId
                dest_city_id = dbFlight.dest_city_id,
                price = (float)dbFlight.price,
                duration = (int)dbFlight.duration,
                airline = dbFlight.airline
            }).ToList();

            // 3. BUILD ADJACENCY LIST (Danh sách kề)
            BuildAdjacencyList();
        }

        public void BuildAdjacencyList()
        {
            // Reset lại danh sách kề
            Adj = new List<List<Flight>>();

            if (Cities.Count == 0) return;

            // Tạo các List rỗng cho từng thành phố
            // (Dựa vào Max Id để đảm bảo index không bị lỗi)
            int maxId = Cities.Max(c => c.city_id);
            for (int i = 0; i <= maxId; i++)
            {
                Adj.Add(new List<Flight>());
            }

            // Đổ dữ liệu từ _allFlights vào đúng "ngăn" của thành phố nguồn
            foreach (var flight in _allFlights)
            {
                if (flight.source_city_id < Adj.Count)
                {
                    Adj[flight.source_city_id].Add(flight);
                }
            }
        }

        public void AddCity(City city)
        {
            Cities.Add(city);
            // Mở rộng Adj nếu cần
            while (Adj.Count <= city.city_id)
            {
                Adj.Add(new List<Flight>());
            }
        }

        public void AddFlight(Flight flight)
        {
            if (flight.source_city_id < Adj.Count)
            {
                Adj[flight.source_city_id].Add(flight);
            }
        }
    }
}
