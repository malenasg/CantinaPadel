-- MySQL dump 10.13  Distrib 8.0.45, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: cantina_padel
-- ------------------------------------------------------
-- Server version	8.0.45

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `caja`
--

DROP TABLE IF EXISTS `caja`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `caja` (
  `id_caja` int NOT NULL AUTO_INCREMENT,
  `fecha_apertura` datetime NOT NULL,
  `fecha_cierre` datetime DEFAULT NULL,
  `monto_inicial` decimal(10,2) NOT NULL,
  `monto_final` decimal(10,2) DEFAULT NULL,
  `turno` enum('Mañana','Tarde/Noche') DEFAULT NULL,
  `id_usuario_apertura` int NOT NULL,
  `id_usuario_cierre` int DEFAULT NULL,
  PRIMARY KEY (`id_caja`),
  KEY `id_usuario_apertura` (`id_usuario_apertura`),
  KEY `id_usuario_cierre` (`id_usuario_cierre`),
  CONSTRAINT `caja_ibfk_1` FOREIGN KEY (`id_usuario_apertura`) REFERENCES `usuario` (`id_usuario`),
  CONSTRAINT `caja_ibfk_2` FOREIGN KEY (`id_usuario_cierre`) REFERENCES `usuario` (`id_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `caja`
--

LOCK TABLES `caja` WRITE;
/*!40000 ALTER TABLE `caja` DISABLE KEYS */;
/*!40000 ALTER TABLE `caja` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cancha`
--

DROP TABLE IF EXISTS `cancha`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cancha` (
  `id_cancha` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `estado` enum('Activa','Inactiva') DEFAULT 'Activa',
  PRIMARY KEY (`id_cancha`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cancha`
--

LOCK TABLES `cancha` WRITE;
/*!40000 ALTER TABLE `cancha` DISABLE KEYS */;
INSERT INTO `cancha` VALUES (1,'Sur','Activa'),(2,'Norte','Activa'),(3,'Cancha \"Verde\"','Inactiva');
/*!40000 ALTER TABLE `cancha` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categoria`
--

DROP TABLE IF EXISTS `categoria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categoria` (
  `id_categoria` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `activo` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`id_categoria`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categoria`
--

LOCK TABLES `categoria` WRITE;
/*!40000 ALTER TABLE `categoria` DISABLE KEYS */;
INSERT INTO `categoria` VALUES (1,'Bebidas',1),(2,'Bebidas',1),(3,'Comida',1);
/*!40000 ALTER TABLE `categoria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cliente`
--

DROP TABLE IF EXISTS `cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cliente` (
  `id_cliente` int NOT NULL AUTO_INCREMENT,
  `id_persona` int NOT NULL,
  `activo` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`id_cliente`),
  UNIQUE KEY `id_persona` (`id_persona`),
  UNIQUE KEY `id_persona_2` (`id_persona`),
  CONSTRAINT `cliente_ibfk_1` FOREIGN KEY (`id_persona`) REFERENCES `persona` (`id_persona`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente`
--

LOCK TABLES `cliente` WRITE;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` VALUES (1,1,1),(2,4,1),(3,5,0),(4,6,1);
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `compra`
--

DROP TABLE IF EXISTS `compra`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `compra` (
  `id_compra` int NOT NULL AUTO_INCREMENT,
  `fecha` datetime NOT NULL,
  `total` decimal(10,2) NOT NULL,
  `estado` enum('ACTIVA','ANULADA') DEFAULT 'ACTIVA',
  `id_proveedor` int NOT NULL,
  PRIMARY KEY (`id_compra`),
  KEY `id_proveedor` (`id_proveedor`),
  CONSTRAINT `compra_ibfk_1` FOREIGN KEY (`id_proveedor`) REFERENCES `proveedor` (`id_proveedor`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `compra`
--

LOCK TABLES `compra` WRITE;
/*!40000 ALTER TABLE `compra` DISABLE KEYS */;
/*!40000 ALTER TABLE `compra` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cuenta_corriente`
--

DROP TABLE IF EXISTS `cuenta_corriente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cuenta_corriente` (
  `id_cuenta` int NOT NULL AUTO_INCREMENT,
  `id_cliente` int NOT NULL,
  PRIMARY KEY (`id_cuenta`),
  UNIQUE KEY `id_cliente` (`id_cliente`),
  CONSTRAINT `cuenta_corriente_ibfk_1` FOREIGN KEY (`id_cliente`) REFERENCES `cliente` (`id_cliente`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cuenta_corriente`
--

LOCK TABLES `cuenta_corriente` WRITE;
/*!40000 ALTER TABLE `cuenta_corriente` DISABLE KEYS */;
/*!40000 ALTER TABLE `cuenta_corriente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detalle_compra`
--

DROP TABLE IF EXISTS `detalle_compra`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `detalle_compra` (
  `id_detalle_compra` int NOT NULL AUTO_INCREMENT,
  `id_compra` int NOT NULL,
  `id_producto` int NOT NULL,
  `cantidad` int NOT NULL,
  `precio_unitario` decimal(10,2) NOT NULL,
  `subtotal` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id_detalle_compra`),
  KEY `id_compra` (`id_compra`),
  KEY `id_producto` (`id_producto`),
  CONSTRAINT `detalle_compra_ibfk_1` FOREIGN KEY (`id_compra`) REFERENCES `compra` (`id_compra`),
  CONSTRAINT `detalle_compra_ibfk_2` FOREIGN KEY (`id_producto`) REFERENCES `producto` (`id_producto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalle_compra`
--

LOCK TABLES `detalle_compra` WRITE;
/*!40000 ALTER TABLE `detalle_compra` DISABLE KEYS */;
/*!40000 ALTER TABLE `detalle_compra` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detalle_deuda`
--

DROP TABLE IF EXISTS `detalle_deuda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `detalle_deuda` (
  `id_detalle_deuda` int NOT NULL AUTO_INCREMENT,
  `id_cuenta` int NOT NULL,
  `id_producto` int DEFAULT NULL,
  `id_reserva` int DEFAULT NULL,
  `descripcion` varchar(200) DEFAULT NULL,
  `cantidad` int DEFAULT NULL,
  `precio_original` decimal(10,2) DEFAULT NULL,
  `precio_actual` decimal(10,2) DEFAULT NULL,
  `precio_anclado` tinyint(1) DEFAULT '0',
  `saldo_pendiente` decimal(10,2) NOT NULL,
  `estado` enum('Pendiente','Parcial','Pagada') DEFAULT 'Pendiente',
  PRIMARY KEY (`id_detalle_deuda`),
  KEY `id_cuenta` (`id_cuenta`),
  KEY `id_producto` (`id_producto`),
  KEY `id_reserva` (`id_reserva`),
  CONSTRAINT `detalle_deuda_ibfk_1` FOREIGN KEY (`id_cuenta`) REFERENCES `cuenta_corriente` (`id_cuenta`),
  CONSTRAINT `detalle_deuda_ibfk_2` FOREIGN KEY (`id_producto`) REFERENCES `producto` (`id_producto`),
  CONSTRAINT `detalle_deuda_ibfk_3` FOREIGN KEY (`id_reserva`) REFERENCES `reserva` (`id_reserva`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalle_deuda`
--

LOCK TABLES `detalle_deuda` WRITE;
/*!40000 ALTER TABLE `detalle_deuda` DISABLE KEYS */;
/*!40000 ALTER TABLE `detalle_deuda` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detalle_venta`
--

DROP TABLE IF EXISTS `detalle_venta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `detalle_venta` (
  `id_detalle_venta` int NOT NULL AUTO_INCREMENT,
  `id_venta` int NOT NULL,
  `id_producto` int NOT NULL,
  `cantidad` int NOT NULL,
  `precio_unitario` decimal(10,2) NOT NULL,
  `subtotal` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id_detalle_venta`),
  KEY `id_venta` (`id_venta`),
  KEY `id_producto` (`id_producto`),
  CONSTRAINT `detalle_venta_ibfk_1` FOREIGN KEY (`id_venta`) REFERENCES `venta` (`id_venta`),
  CONSTRAINT `detalle_venta_ibfk_2` FOREIGN KEY (`id_producto`) REFERENCES `producto` (`id_producto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalle_venta`
--

LOCK TABLES `detalle_venta` WRITE;
/*!40000 ALTER TABLE `detalle_venta` DISABLE KEYS */;
/*!40000 ALTER TABLE `detalle_venta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `empleado`
--

DROP TABLE IF EXISTS `empleado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `empleado` (
  `id_empleado` int NOT NULL AUTO_INCREMENT,
  `id_persona` int NOT NULL,
  `fecha_ingreso` date DEFAULT NULL,
  `activo` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`id_empleado`),
  UNIQUE KEY `id_persona` (`id_persona`),
  UNIQUE KEY `id_persona_2` (`id_persona`),
  CONSTRAINT `empleado_ibfk_1` FOREIGN KEY (`id_persona`) REFERENCES `persona` (`id_persona`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empleado`
--

LOCK TABLES `empleado` WRITE;
/*!40000 ALTER TABLE `empleado` DISABLE KEYS */;
INSERT INTO `empleado` VALUES (1,1,'2026-01-12',1),(2,3,'2020-06-12',0),(3,5,'2020-06-12',0);
/*!40000 ALTER TABLE `empleado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `historial_precio`
--

DROP TABLE IF EXISTS `historial_precio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `historial_precio` (
  `id_historial` int NOT NULL AUTO_INCREMENT,
  `id_producto` int NOT NULL,
  `precio_anterior` decimal(10,2) DEFAULT NULL,
  `precio_nuevo` decimal(10,2) DEFAULT NULL,
  `fecha` datetime NOT NULL,
  PRIMARY KEY (`id_historial`),
  KEY `id_producto` (`id_producto`),
  CONSTRAINT `historial_precio_ibfk_1` FOREIGN KEY (`id_producto`) REFERENCES `producto` (`id_producto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `historial_precio`
--

LOCK TABLES `historial_precio` WRITE;
/*!40000 ALTER TABLE `historial_precio` DISABLE KEYS */;
/*!40000 ALTER TABLE `historial_precio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `horario`
--

DROP TABLE IF EXISTS `horario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `horario` (
  `id_horario` int NOT NULL AUTO_INCREMENT,
  `hora_inicio` time NOT NULL,
  `hora_fin` time NOT NULL,
  PRIMARY KEY (`id_horario`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `horario`
--

LOCK TABLES `horario` WRITE;
/*!40000 ALTER TABLE `horario` DISABLE KEYS */;
INSERT INTO `horario` VALUES (3,'18:00:00','19:00:00'),(4,'18:00:00','19:30:00'),(5,'11:00:41','12:00:41'),(7,'11:00:49','12:30:49');
/*!40000 ALTER TABLE `horario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `marca`
--

DROP TABLE IF EXISTS `marca`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `marca` (
  `id_marca` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `activo` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`id_marca`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `marca`
--

LOCK TABLES `marca` WRITE;
/*!40000 ALTER TABLE `marca` DISABLE KEYS */;
INSERT INTO `marca` VALUES (1,'CocaCola',1),(2,'Lay\'s',1);
/*!40000 ALTER TABLE `marca` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pago_cuenta_corriente`
--

DROP TABLE IF EXISTS `pago_cuenta_corriente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pago_cuenta_corriente` (
  `id_pago` int NOT NULL AUTO_INCREMENT,
  `id_detalle_deuda` int NOT NULL,
  `fecha` datetime NOT NULL,
  `monto_pagado` decimal(10,2) NOT NULL,
  `id_caja` int NOT NULL,
  `id_usuario` int NOT NULL,
  `medio_pago` enum('Pendiente','\nParcial','\nPagada') DEFAULT NULL,
  PRIMARY KEY (`id_pago`),
  KEY `id_detalle_deuda` (`id_detalle_deuda`),
  KEY `pago_cuenta_corriente_ibfk_2_idx` (`id_caja`),
  KEY `pago_cuenta_corriente_ibfk_3_idx` (`id_usuario`),
  CONSTRAINT `pago_cuenta_corriente_ibfk_1` FOREIGN KEY (`id_detalle_deuda`) REFERENCES `detalle_deuda` (`id_detalle_deuda`),
  CONSTRAINT `pago_cuenta_corriente_ibfk_2` FOREIGN KEY (`id_caja`) REFERENCES `caja` (`id_caja`),
  CONSTRAINT `pago_cuenta_corriente_ibfk_3` FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pago_cuenta_corriente`
--

LOCK TABLES `pago_cuenta_corriente` WRITE;
/*!40000 ALTER TABLE `pago_cuenta_corriente` DISABLE KEYS */;
/*!40000 ALTER TABLE `pago_cuenta_corriente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `persona`
--

DROP TABLE IF EXISTS `persona`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `persona` (
  `id_persona` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `apellido` varchar(100) DEFAULT NULL,
  `telefono` varchar(50) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `direccion` varchar(200) DEFAULT NULL,
  `activo` tinyint(1) DEFAULT '1',
  `cuit` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id_persona`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `persona`
--

LOCK TABLES `persona` WRITE;
/*!40000 ALTER TABLE `persona` DISABLE KEYS */;
INSERT INTO `persona` VALUES (1,'Malena','Gonzalez','3644459033','malenasg1147@gmail.com','Checoslovaquia 1334',1,'27445683561'),(2,'Diego','Ramirez','3644789546','distribuidoradiego@info.com.ar','Ruta 12',0,'30987458361'),(3,'Raul','Perez','3644789541','perezraula@gmail.com','San Martin 478',0,'77777777777'),(4,'Nicolas','Gonzalez','3624587964','nicogonzz@gmail.com','Rivadavia 47',0,'87489479648'),(5,'Ramiro','Lopez','3644478512','loppramiro@gmail.com','San Martin 112',0,NULL),(6,'Nicolas','Gonzalez','3624587964','nicogonzz@gmail.com','Rivadavia 47',0,'7886587453');
/*!40000 ALTER TABLE `persona` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `producto`
--

DROP TABLE IF EXISTS `producto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `producto` (
  `id_producto` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(150) NOT NULL,
  `descripcion` varchar(200) DEFAULT NULL,
  `stock` int DEFAULT '0',
  `stock_minimo` int DEFAULT '0',
  `precio_compra` decimal(10,2) DEFAULT '0.00',
  `precio_venta` decimal(10,2) NOT NULL,
  `codigo` varchar(256) DEFAULT NULL,
  `id_categoria` int DEFAULT NULL,
  `id_marca` int DEFAULT NULL,
  `id_proveedor` int DEFAULT NULL,
  `activo` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`id_producto`),
  KEY `id_categoria` (`id_categoria`),
  KEY `id_marca` (`id_marca`),
  KEY `producto_ibfk_3_idx` (`id_proveedor`),
  CONSTRAINT `producto_ibfk_1` FOREIGN KEY (`id_categoria`) REFERENCES `categoria` (`id_categoria`),
  CONSTRAINT `producto_ibfk_2` FOREIGN KEY (`id_marca`) REFERENCES `marca` (`id_marca`),
  CONSTRAINT `producto_ibfk_3` FOREIGN KEY (`id_proveedor`) REFERENCES `proveedor` (`id_proveedor`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producto`
--

LOCK TABLES `producto` WRITE;
/*!40000 ALTER TABLE `producto` DISABLE KEYS */;
INSERT INTO `producto` VALUES (2,'Papas fritas',NULL,150,30,900.00,1400.00,'8463464463',3,2,NULL,1);
/*!40000 ALTER TABLE `producto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `proveedor`
--

DROP TABLE IF EXISTS `proveedor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `proveedor` (
  `id_proveedor` int NOT NULL AUTO_INCREMENT,
  `id_persona` int NOT NULL,
  `activo` tinyint(1) DEFAULT '1',
  `razon_social` varchar(150) DEFAULT NULL,
  `condicion_fiscal` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_proveedor`),
  UNIQUE KEY `id_persona` (`id_persona`),
  UNIQUE KEY `id_persona_2` (`id_persona`),
  CONSTRAINT `proveedor_ibfk_1` FOREIGN KEY (`id_persona`) REFERENCES `persona` (`id_persona`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proveedor`
--

LOCK TABLES `proveedor` WRITE;
/*!40000 ALTER TABLE `proveedor` DISABLE KEYS */;
INSERT INTO `proveedor` VALUES (1,2,0,'Distribuidora Diego','Monotributo'),(2,4,0,NULL,NULL),(3,6,0,NULL,NULL);
/*!40000 ALTER TABLE `proveedor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reserva`
--

DROP TABLE IF EXISTS `reserva`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reserva` (
  `id_reserva` int NOT NULL AUTO_INCREMENT,
  `id_cliente` int NOT NULL,
  `id_cancha` int NOT NULL,
  `id_horario` int NOT NULL,
  `fecha` date NOT NULL,
  `precio` decimal(10,2) DEFAULT NULL,
  `estado` enum('Reservada','Cancelada','Finalizada') DEFAULT 'Reservada',
  `tipo_reserva` enum('Diaria','Fija') DEFAULT NULL,
  PRIMARY KEY (`id_reserva`),
  UNIQUE KEY `uk_reserva_cancha_fecha_horario` (`id_cancha`,`fecha`,`id_horario`),
  KEY `id_cliente` (`id_cliente`),
  KEY `id_horario` (`id_horario`),
  CONSTRAINT `reserva_ibfk_1` FOREIGN KEY (`id_cliente`) REFERENCES `cliente` (`id_cliente`),
  CONSTRAINT `reserva_ibfk_2` FOREIGN KEY (`id_cancha`) REFERENCES `cancha` (`id_cancha`),
  CONSTRAINT `reserva_ibfk_3` FOREIGN KEY (`id_horario`) REFERENCES `horario` (`id_horario`)
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reserva`
--

LOCK TABLES `reserva` WRITE;
/*!40000 ALTER TABLE `reserva` DISABLE KEYS */;
INSERT INTO `reserva` VALUES (1,1,2,4,'2026-09-09',10000.00,'Reservada','Fija'),(2,1,2,4,'2026-09-16',10000.00,'Reservada','Fija'),(3,1,2,4,'2026-09-23',10000.00,'Reservada','Fija'),(4,1,2,4,'2026-09-30',10000.00,'Reservada','Fija'),(5,1,2,4,'2026-10-07',10000.00,'Reservada','Fija'),(6,1,2,4,'2026-10-14',10000.00,'Reservada','Fija'),(7,1,2,4,'2026-10-21',10000.00,'Reservada','Fija'),(8,1,2,4,'2026-10-28',10000.00,'Reservada','Fija'),(9,1,2,4,'2026-11-04',10000.00,'Reservada','Fija'),(10,1,2,4,'2026-11-11',10000.00,'Reservada','Fija'),(11,1,2,4,'2026-11-18',10000.00,'Reservada','Fija'),(12,1,2,4,'2026-11-25',10000.00,'Reservada','Fija'),(13,1,2,4,'2026-12-02',10000.00,'Reservada','Fija'),(14,1,2,4,'2026-12-09',10000.00,'Reservada','Fija'),(15,1,2,4,'2026-12-16',10000.00,'Reservada','Fija'),(16,1,2,4,'2026-12-23',10000.00,'Reservada','Fija'),(17,1,2,4,'2026-12-30',10000.00,'Reservada','Fija'),(18,1,2,4,'2027-01-06',10000.00,'Reservada','Fija'),(19,1,2,4,'2027-01-13',10000.00,'Reservada','Fija'),(20,1,2,4,'2027-01-20',10000.00,'Reservada','Fija'),(21,1,2,4,'2027-01-27',10000.00,'Reservada','Fija'),(22,1,2,4,'2027-02-03',10000.00,'Reservada','Fija'),(23,1,2,4,'2027-02-10',10000.00,'Reservada','Fija'),(24,1,2,4,'2027-02-17',10000.00,'Reservada','Fija'),(25,1,2,4,'2027-02-24',10000.00,'Reservada','Fija'),(26,1,2,4,'2027-03-03',10000.00,'Reservada','Fija'),(27,1,2,4,'2027-03-10',10000.00,'Reservada','Fija'),(28,1,2,4,'2027-03-17',10000.00,'Reservada','Fija'),(29,1,2,4,'2027-03-24',10000.00,'Reservada','Fija'),(30,1,2,4,'2027-03-31',10000.00,'Reservada','Fija'),(31,1,2,4,'2027-04-07',10000.00,'Reservada','Fija'),(32,1,2,4,'2027-04-14',10000.00,'Reservada','Fija'),(33,1,2,4,'2027-04-21',10000.00,'Reservada','Fija'),(34,1,2,4,'2027-04-28',10000.00,'Reservada','Fija'),(35,1,2,4,'2027-05-05',10000.00,'Reservada','Fija'),(36,1,2,4,'2027-05-12',10000.00,'Reservada','Fija'),(37,1,2,4,'2027-05-19',10000.00,'Reservada','Fija'),(38,1,2,4,'2027-05-26',10000.00,'Reservada','Fija'),(39,1,2,4,'2027-06-02',10000.00,'Reservada','Fija'),(40,1,2,4,'2027-06-09',10000.00,'Reservada','Fija'),(41,1,2,4,'2027-06-16',10000.00,'Reservada','Fija'),(42,1,2,4,'2027-06-23',10000.00,'Reservada','Fija'),(43,1,2,4,'2027-06-30',10000.00,'Reservada','Fija'),(44,1,2,4,'2027-07-07',10000.00,'Reservada','Fija'),(45,1,2,4,'2027-07-14',10000.00,'Reservada','Fija'),(46,1,2,4,'2027-07-21',10000.00,'Reservada','Fija'),(47,1,2,4,'2027-07-28',10000.00,'Reservada','Fija'),(48,1,2,4,'2027-08-04',10000.00,'Reservada','Fija'),(49,1,2,4,'2027-08-11',10000.00,'Reservada','Fija'),(50,1,2,4,'2027-08-18',10000.00,'Reservada','Fija');
/*!40000 ALTER TABLE `reserva` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `retiro_caja`
--

DROP TABLE IF EXISTS `retiro_caja`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `retiro_caja` (
  `id_retiro` int NOT NULL AUTO_INCREMENT,
  `id_caja` int NOT NULL,
  `id_usuario` int NOT NULL,
  `fecha` datetime NOT NULL,
  `monto` decimal(10,2) NOT NULL,
  `motivo` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id_retiro`),
  KEY `id_caja` (`id_caja`),
  KEY `id_usuario` (`id_usuario`),
  CONSTRAINT `retiro_caja_ibfk_1` FOREIGN KEY (`id_caja`) REFERENCES `caja` (`id_caja`),
  CONSTRAINT `retiro_caja_ibfk_2` FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `retiro_caja`
--

LOCK TABLES `retiro_caja` WRITE;
/*!40000 ALTER TABLE `retiro_caja` DISABLE KEYS */;
/*!40000 ALTER TABLE `retiro_caja` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `id_usuario` int NOT NULL AUTO_INCREMENT,
  `id_persona` int NOT NULL,
  `rol` enum('Administrador','Cajero') NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `activo` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`id_usuario`),
  UNIQUE KEY `username` (`username`),
  KEY `id_persona` (`id_persona`),
  CONSTRAINT `usuario_ibfk_1` FOREIGN KEY (`id_persona`) REFERENCES `empleado` (`id_persona`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `venta`
--

DROP TABLE IF EXISTS `venta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `venta` (
  `id_venta` int NOT NULL AUTO_INCREMENT,
  `fecha` datetime NOT NULL,
  `tipo_venta` enum('Cantina','Padel') DEFAULT NULL,
  `medio_pago` enum('Efectivo','Tarjeta','Transferencia') DEFAULT NULL,
  `tipo_comprobante` enum('Sin comprobante','Factura A','Factura B','Factura C') DEFAULT NULL,
  `tipo_salida` enum('NINGUNA','TICKET','EMAIL') DEFAULT NULL,
  `total` decimal(10,2) NOT NULL,
  `estado` enum('Pagada','\nFiada','\nAnulada') DEFAULT NULL,
  `id_cliente` int DEFAULT NULL,
  `id_caja` int NOT NULL,
  `id_reserva` int DEFAULT NULL,
  `id_usuario` int DEFAULT NULL,
  PRIMARY KEY (`id_venta`),
  KEY `id_cliente` (`id_cliente`),
  KEY `id_caja` (`id_caja`),
  KEY `id_reserva` (`id_reserva`),
  KEY `venta_ibfk_4_idx` (`id_usuario`),
  CONSTRAINT `venta_ibfk_1` FOREIGN KEY (`id_cliente`) REFERENCES `cliente` (`id_cliente`),
  CONSTRAINT `venta_ibfk_2` FOREIGN KEY (`id_caja`) REFERENCES `caja` (`id_caja`),
  CONSTRAINT `venta_ibfk_3` FOREIGN KEY (`id_reserva`) REFERENCES `reserva` (`id_reserva`),
  CONSTRAINT `venta_ibfk_4` FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `venta`
--

LOCK TABLES `venta` WRITE;
/*!40000 ALTER TABLE `venta` DISABLE KEYS */;
/*!40000 ALTER TABLE `venta` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-09-08 11:15:20
