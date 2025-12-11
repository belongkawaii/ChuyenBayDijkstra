
//using Flight_Dijkstra.DatabaseScript;
//using System.Collections.Generic;
//using System.Linq;
//namespace Flight_Dijkstra
//{
//    public class Graph
//    {
//        public List<City> Cities = new List<City>();
//        public List<List<Flight>> Adj = new List<List<Flight>>();
//        private List<Flight> _allFlights = new List<Flight>();

//        public void LoadFromDatabase()
//        {
//            FlightDijkstraDataContext db = new FlightDijkstraDataContext();

//            // Load city
//            Cities = db.Cities.Select(dbCity => new City
//            {
//                Id = dbCity.city_id,                // Map city_id (DB) -> Id (Class)
//                Name = dbCity.name,
//                Country = dbCity.country,
//                AirportCode = dbCity.airport_code,
                
//                Latitude = (float)dbCity.latitude,
//                Longitude = (float)dbCity.longitude
//            }).OrderBy(c => c.Id).ToList();

//            // 2. LOAD FLIGHT (Lấy toàn bộ chuyến bay ra trước)
//            var dbFlights = db.Flights.Select(dbFlight => new Flight
//            {
//                Id = dbFlight.flight_id,
//                SourceCityId = dbFlight.source_city_id, // Map source_city_id -> SourceCityId
//                DestCityId = dbFlight.dest_city_id,
//                Price = (float)dbFlight.price,
//                Duration = (int)dbFlight.duration,
//                Airline = dbFlight.airline
//            }).ToList();

//            // 3. BUILD ADJACENCY LIST (Danh sách kề)
//            BuildAdjacencyList();
//        }

//        public void BuildAdjacencyList()
//        {
//            // Reset lại danh sách kề
//            Adj = new List<List<Flight>>();

//            if (Cities.Count == 0) return;

//            // Tạo các List rỗng cho từng thành phố
//            // (Dựa vào Max Id để đảm bảo index không bị lỗi)
//            int maxId = Cities.Max(c => c.Id);
//            for (int i = 0; i <= maxId; i++)
//            {
//                Adj.Add(new List<Flight>());
//            }

//            // Đổ dữ liệu từ _allFlights vào đúng "ngăn" của thành phố nguồn
//            foreach (var flight in _allFlights)
//            {
//                if (flight.SourceCityId < Adj.Count)
//                {
//                    Adj[flight.SourceCityId].Add(flight);
//                }
//            }
//        }

//        public void AddCity(City city)
//        {
//            Cities.Add(city);
//            // Mở rộng Adj nếu cần
//            while (Adj.Count <= city.Id)
//            {
//                Adj.Add(new List<Flight>());
//            }
//        }

//        public void AddFlight(Flight flight)
//        {
//            if (flight.SourceCityId < Adj.Count)
//            {
//                Adj[flight.SourceCityId].Add(flight);
//            }
//        }
//    }

//}
