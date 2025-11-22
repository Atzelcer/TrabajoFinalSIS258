
CREATE DATABASE IF NOT EXISTS bd_demandas
CHARACTER SET utf8mb4
COLLATE utf8mb4_unicode_ci;


USE bd_demandas;


DROP TABLE IF EXISTS pronosticos;


CREATE TABLE pronosticos (
    id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
    fecha VARCHAR(10) NOT NULL COMMENT 'Formato DD-MM-YY',
    cantidad_estimada INT NOT NULL,
    created_at TIMESTAMP NULL DEFAULT NULL,
    updated_at TIMESTAMP NULL DEFAULT NULL,
    PRIMARY KEY (id),
    INDEX idx_fecha (fecha)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;


INSERT INTO pronosticos (fecha, cantidad_estimada, created_at, updated_at) VALUES
('01-06-25', 150, NOW(), NOW()),
('02-06-25', 145, NOW(), NOW()),
('03-06-25', 165, NOW(), NOW()),
('04-06-25', 170, NOW(), NOW()),
('05-06-25', 180, NOW(), NOW()),
('06-06-25', 130, NOW(), NOW()),
('07-06-25', 160, NOW(), NOW()),
('08-06-25', 190, NOW(), NOW()),
('09-06-25', 200, NOW(), NOW());


SELECT * FROM pronosticos;


SELECT 
    COUNT(*) as total_registros,
    AVG(cantidad_estimada) as promedio_demanda,
    MIN(cantidad_estimada) as demanda_minima,
    MAX(cantidad_estimada) as demanda_maxima
FROM pronosticos;
