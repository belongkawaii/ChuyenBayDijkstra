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
                                                                        ('Brazil', 'Brazil', 'BRA', -20, -90),
                                                                        ('Ho Chi Minh City', 'Vietnam', 'SGN', 6, 82),
                                                                        ('Tokyo', 'Japan', 'NRT', 35, 105),
                                                                        ('Moskva', 'Russia', 'MOS', 65, 50),
                                                                        ('New Delhi', 'India', 'NDI', 20, 45),
                                                                        ('Alaska', 'USA', 'ALA', 70, -165),
                                                                        ('London', 'United Kingdom', 'LHR', 60, -35),
                                                                        ('New York', 'USA', 'JFK', 40, -130),
                                                                        ('Nuuk', 'Green Land', 'NUU', 80, -70),
                                                                        ('Sydney', 'Australia', 'SYD', -40, 110);
GO

INSERT INTO Flight (source_city_id, dest_city_id, price, duration, airline) VALUES
-- Hà Nội
(1, 4, 150, 190, 'Vietnam Airlines'),
(1, 3, 450, 300, 'All Nippon Airways'),
(1, 2, 80, 120, 'VietJet Air'),
(1, 5, 120, 110, 'Emirates'),

-- TP.HCM
(2, 4, 120, 150, 'Singapore Airlines'),
(2, 5, 90, 100, 'Emirates'),
(2, 1, 75, 125, 'Vietnam Airlines'),

-- Tokyo
(3, 6, 450, 360, 'Air France'),
(3, 7, 430, 350, 'British Airways'),
(3, 8, 680, 720, 'United Airlines'),

-- Singapore
(4, 3, 250, 180, 'Japan Airlines'),
(4, 6, 520, 380, 'Air France'),
(4, 7, 500, 400, 'British Airways'),

-- New Delhi
(5, 3, 200, 160, 'Emirates'),
(5, 4, 180, 140, 'Singapore Airlines'),

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