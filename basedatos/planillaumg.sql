-- MariaDB dump 10.19  Distrib 10.4.32-MariaDB, for Win64 (AMD64)
--
-- Host: localhost    Database: planillaumg
-- ------------------------------------------------------
-- Server version	10.4.32-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `trabajadores`
--

DROP TABLE IF EXISTS `trabajadores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `trabajadores` (
  `id_trabajador` int(11) NOT NULL,
  `nombres` varchar(100) NOT NULL,
  `cargo` varchar(50) DEFAULT NULL,
  `sueldo` decimal(10,2) DEFAULT NULL,
  `igss` decimal(10,2) DEFAULT NULL,
  `bono` decimal(10,2) DEFAULT NULL,
  `otros` decimal(10,2) DEFAULT NULL,
  `liquido` decimal(10,2) DEFAULT NULL,
  `correo` varchar(150) NOT NULL DEFAULT '',
  `no_cuenta` varchar(50) NOT NULL DEFAULT '',
  PRIMARY KEY (`id_trabajador`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trabajadores`
--

LOCK TABLES `trabajadores` WRITE;
/*!40000 ALTER TABLE `trabajadores` DISABLE KEYS */;
INSERT INTO `trabajadores` VALUES (1,'floppa','Ceo',3000.00,144.90,250.00,0.00,3105.10,'',''),(10,'hecker','floppa',4000.00,193.20,250.00,0.00,4056.80,'',''),(12,'pumba','floppa',3000.00,144.90,250.00,0.00,3105.10,'',''),(20,'jjose','ceo',33232323.00,1605121.20,250.00,0.00,31627451.80,'chajoncito123@gmail.com','322323'),(30,'negro','Ceo',500000.00,24150.00,250.00,0.00,476100.00,'jtecum593@gmail.com','5550505050'),(111,'ebert muñoz','floppa',4500.00,217.35,250.00,0.00,4532.65,'',''),(112,'makumba','floppa',4500.00,217.35,250.00,0.00,4532.65,'',''),(1010,'hey','ceo',5000000.00,241500.00,250.00,0.00,4758750.00,'',''),(1111,'heisenflopp','floppa',10000.00,483.00,250.00,0.00,9767.00,'',''),(2020,'pumbober','ceo',60000.00,2898.00,250.00,0.00,57352.00,'jczc30jc@gmail.com','5050551'),(202020,'Henry Mejia','ceo',99999999.99,99999999.99,250.00,0.00,99999999.99,'cmejiahenry@gmail.com','666666666666666');
/*!40000 ALTER TABLE `trabajadores` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-05-23 11:07:07
