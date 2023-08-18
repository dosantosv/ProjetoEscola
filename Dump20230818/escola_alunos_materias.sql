-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: escola
-- ------------------------------------------------------
-- Server version	5.5.5-10.4.28-MariaDB

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
-- Table structure for table `alunos_materias`
--

DROP TABLE IF EXISTS `alunos_materias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `alunos_materias` (
  `materia` varchar(20) DEFAULT NULL,
  `N1` decimal(4,2) DEFAULT NULL,
  `N2` decimal(4,2) DEFAULT NULL,
  `N3` decimal(4,2) DEFAULT NULL,
  `N4` decimal(4,2) DEFAULT NULL,
  `media` decimal(4,2) DEFAULT NULL,
  `ra_aluno` int(11) DEFAULT NULL,
  `status` varchar(50) DEFAULT NULL,
  KEY `ra_aluno` (`ra_aluno`),
  KEY `materia` (`materia`),
  CONSTRAINT `alunos_materias_ibfk_1` FOREIGN KEY (`ra_aluno`) REFERENCES `alunos` (`ra`),
  CONSTRAINT `alunos_materias_ibfk_2` FOREIGN KEY (`materia`) REFERENCES `materias` (`materia`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alunos_materias`
--

LOCK TABLES `alunos_materias` WRITE;
/*!40000 ALTER TABLE `alunos_materias` DISABLE KEYS */;
INSERT INTO `alunos_materias` VALUES ('Filosofia',10.00,10.00,10.00,10.00,10.00,17,'Aprovado'),('Artes',1.00,1.00,1.00,1.00,1.00,16,'Reprovado'),('Artes',10.00,10.00,10.00,10.00,10.00,18,'Aprovado');
/*!40000 ALTER TABLE `alunos_materias` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-08-18 10:29:03
