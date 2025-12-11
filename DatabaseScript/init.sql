CREATE DATABASE FlightDijkstra
GO

USE FlightDijkstra;
GO

CREATE TABLE City (
                      city_id INT IDENTITY(1, 1) PRIMARY KEY,
                      name VARCHAR(100) NOT NULL,
                      country VARCHAR(100),
                      airport_code CHAR(3) UNIQUE,
                      latitude DOUBLE PRECISION, -- vĩ độ
                      longitude DOUBLE PRECISION -- kinh độ
);
GO

CREATE TABLE Flight (
                        flight_id INT IDENTITY(1, 1) PRIMARY KEY,
                        source_city_id INT NOT NULL, -- Điểm nguồn
                        dest_city_id INT NOT NULL, -- Điểm đén
                        price DOUBLE PRECISION NOT NULL, 
                        duration INT, -- Thời gian
                        airline VARCHAR(100),

                        FOREIGN KEY (source_city_id) REFERENCES City(city_id),
                        FOREIGN KEY (dest_city_id) REFERENCES City(city_id)
);
GO

INSERT INTO City (name, country, airport_code, latitude, longitude) VALUES
                                                                        ('Hanoi', 'Vietnam', 'HAN', 21.0278, 105.8342),
                                                                        ('Ho Chi Minh City', 'Vietnam', 'SGN', 10.8231, 106.6297),
                                                                        ('Tokyo', 'Japan', 'NRT', 35.6895, 139.6917),
                                                                        ('Singapore', 'Singapore', 'SIN', 1.3521, 103.8198),
                                                                        ('Bangkok', 'Thailand', 'BKK', 13.7563, 100.5018),
                                                                        ('Paris', 'France', 'CDG', 48.8566, 2.3522),
                                                                        ('London', 'United Kingdom', 'LHR', 51.5074, -0.1278),
                                                                        ('New York', 'USA', 'JFK', 40.7128, -74.0060),
                                                                        ('Los Angeles', 'USA', 'LAX', 34.0522, -118.2437),
                                                                        ('Sydney', 'Australia', 'SYD', -33.8688, 151.2093);
GO

INSERT INTO Flight (source_city_id, dest_city_id, price, duration, airline) VALUES
-- Hà Nội
(1, 4, 150, 190, 'Vietnam Airlines'),
(1, 3, 450, 300, 'All Nippon Airways'),
(1, 2, 80, 120, 'VietJet Air'),
(1, 5, 120, 110, 'Thai Airways'),

-- TP.HCM
(2, 4, 120, 150, 'Singapore Airlines'),
(2, 5, 90, 100, 'Thai Airways'),
(2, 1, 75, 125, 'Vietnam Airlines'),

-- Singapore
(4, 3, 250, 180, 'Japan Airlines'),
(4, 6, 520, 380, 'Air France'),
(4, 7, 500, 400, 'British Airways'),

-- Tokyo
(3, 6, 450, 360, 'Air France'),
(3, 7, 430, 350, 'British Airways'),
(3, 8, 680, 720, 'United Airlines'),

-- Paris
(6, 7, 200, 70, 'British Airways'),
(6, 8, 350, 420, 'Air France'),
(6, 9, 500, 600, 'Delta'),

-- London
(7, 6, 180, 70, 'Air France'),
(7, 8, 330, 415, 'Delta'),
(7, 9, 470, 650, 'American Airlines'),

-- New York
(8, 9, 280, 320, 'United Airlines'),
(8, 10, 750, 900, 'Qantas'),

-- Los Angeles
(9, 10, 700, 840, 'Qantas');
GO