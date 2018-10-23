/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `books`
--

DROP TABLE IF EXISTS `books`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `books` (
  `bIndex` int(11) NOT NULL AUTO_INCREMENT,
  `bID` varchar(32) NOT NULL,
  `bPublisherID` varchar(32) NOT NULL DEFAULT '',
  `bType` varchar(32) NOT NULL DEFAULT '0',
  `bName` varchar(128) DEFAULT '',
  `bFormat` varchar(32) DEFAULT '',
  `bCost` double DEFAULT '0',
  `bRetail` double DEFAULT '0',
  `bWholesale` double DEFAULT '0',
  `bNotes` varchar(512) DEFAULT '',
  PRIMARY KEY (`bIndex`,`bID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `books`
--

LOCK TABLES `books` WRITE;
/*!40000 ALTER TABLE `books` DISABLE KEYS */;
INSERT INTO `books` VALUES (1,'aaa','P1','BT1','图书a','111*111',111.1,333.3,222.2,'afsfsd'),(3,'bbb','P1','BT1','图书b','111*111',111.1,333.3,222.2,'afsfsd');
/*!40000 ALTER TABLE `books` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `booktype`
--

DROP TABLE IF EXISTS `booktype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `booktype` (
  `btIndex` int(11) NOT NULL AUTO_INCREMENT,
  `btID` varchar(32) NOT NULL,
  `btName` varchar(128) DEFAULT '',
  `btNotes` varchar(512) DEFAULT '',
  PRIMARY KEY (`btIndex`,`btID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `booktype`
--

LOCK TABLES `booktype` WRITE;
/*!40000 ALTER TABLE `booktype` DISABLE KEYS */;
INSERT INTO `booktype` VALUES (1,'BT1','默认类型','默认类型无法删除'),(4,'BT2','教育类',''),(5,'BT3','科幻类','');
/*!40000 ALTER TABLE `booktype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `department`
--

DROP TABLE IF EXISTS `department`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `department` (
  `dIndex` int(11) NOT NULL AUTO_INCREMENT,
  `dID` varchar(32) NOT NULL,
  `dManagerID` varchar(32) NOT NULL,
  `dName` varchar(128) DEFAULT '',
  `dType` varchar(32) DEFAULT '',
  `dPhone` varchar(32) DEFAULT '',
  `dAddress` varchar(256) DEFAULT '',
  `dCost` double DEFAULT '0',
  `dNotes` varchar(512) DEFAULT '',
  PRIMARY KEY (`dIndex`,`dID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `department`
--

LOCK TABLES `department` WRITE;
/*!40000 ALTER TABLE `department` DISABLE KEYS */;
INSERT INTO `department` VALUES (1,'D1','W1','默认部门','BT1','12345678910','',0,'默认部门无法删除'),(9,'D2','W2','部门A','BT2','','',1000,''),(10,'D3','W3','部门B','BT3','','',1000,'');
/*!40000 ALTER TABLE `department` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `log1`
--

DROP TABLE IF EXISTS `log1`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `log1` (
  `lIndex` int(11) NOT NULL AUTO_INCREMENT,
  `log1` varchar(256) NOT NULL,
  `time1` datetime NOT NULL,
  PRIMARY KEY (`lIndex`)
) ENGINE=InnoDB AUTO_INCREMENT=1578 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `log1`
--

LOCK TABLES `log1` WRITE;
/*!40000 ALTER TABLE `log1` DISABLE KEYS */;
/*!40000 ALTER TABLE `log1` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `posttype`
--

DROP TABLE IF EXISTS `posttype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `posttype` (
  `ptIndex` int(11) NOT NULL AUTO_INCREMENT,
  `ptID` varchar(32) NOT NULL,
  `ptName` varchar(128) DEFAULT '',
  `ptNotes` varchar(512) DEFAULT '',
  PRIMARY KEY (`ptIndex`,`ptID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `posttype`
--

LOCK TABLES `posttype` WRITE;
/*!40000 ALTER TABLE `posttype` DISABLE KEYS */;
INSERT INTO `posttype` VALUES (1,'PT1','默认职务','默认职务无法删除'),(6,'PT2','总经理',''),(7,'PT3','经理','');
/*!40000 ALTER TABLE `posttype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `publisher`
--

DROP TABLE IF EXISTS `publisher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `publisher` (
  `pIndex` int(11) NOT NULL AUTO_INCREMENT,
  `pID` varchar(32) NOT NULL,
  `pName` varchar(128) DEFAULT '',
  `pPhone` varchar(32) DEFAULT '',
  `pAddress` varchar(256) DEFAULT '',
  `pNotes` varchar(512) DEFAULT '',
  PRIMARY KEY (`pIndex`,`pID`)
) ENGINE=InnoDB AUTO_INCREMENT=58 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `publisher`
--

LOCK TABLES `publisher` WRITE;
/*!40000 ALTER TABLE `publisher` DISABLE KEYS */;
INSERT INTO `publisher` VALUES (1,'P1','默认出版商','12345678910','','默认出版商无法删除'),(20,'P2','出版商1','','',''),(57,'P3','出版商2','','','');
/*!40000 ALTER TABLE `publisher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sale`
--

DROP TABLE IF EXISTS `sale`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sale` (
  `saIndex` int(11) NOT NULL AUTO_INCREMENT,
  `saBookID` varchar(32) NOT NULL,
  `saTime` datetime NOT NULL,
  `saNum` int(11) DEFAULT '0',
  `saWholesaleNum` int(11) DEFAULT '0',
  `saRetailNum` int(11) DEFAULT '0',
  `saDiscount` double DEFAULT '0',
  `saCost` double DEFAULT '0',
  `saCount` double DEFAULT '0',
  `saNotes` varchar(512) DEFAULT '',
  `saStorageID` varchar(32) DEFAULT '',
  PRIMARY KEY (`saIndex`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sale`
--

LOCK TABLES `sale` WRITE;
/*!40000 ALTER TABLE `sale` DISABLE KEYS */;
INSERT INTO `sale` VALUES (10,'aaa','2018-10-21 12:50:33',0,1,0,1,0,222.2,'','S1'),(12,'aaa','2018-10-21 17:43:42',1,0,0,1,111.1,0,'','S1'),(13,'aaa','2018-10-21 17:44:06',1,0,0,1,111.1,0,'','L1'),(14,'bbb','2018-10-21 17:44:11',0,1,0,1,111.1,222.2,'','S1');
/*!40000 ALTER TABLE `sale` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stock`
--

DROP TABLE IF EXISTS `stock`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `stock` (
  `stIndex` int(11) NOT NULL AUTO_INCREMENT,
  `stBookID` varchar(32) NOT NULL,
  `stStorageID` varchar(32) NOT NULL,
  `stStorageNum` int(11) DEFAULT '0',
  `stNotes` varchar(512) DEFAULT NULL,
  PRIMARY KEY (`stIndex`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stock`
--

LOCK TABLES `stock` WRITE;
/*!40000 ALTER TABLE `stock` DISABLE KEYS */;
INSERT INTO `stock` VALUES (3,'aaa','S1',111,''),(4,'aaa','L1',221,NULL);
/*!40000 ALTER TABLE `stock` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `storages`
--

DROP TABLE IF EXISTS `storages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `storages` (
  `sIndex` int(11) NOT NULL AUTO_INCREMENT,
  `sID` varchar(32) NOT NULL,
  `sManagerID` varchar(32) DEFAULT '',
  `sName` varchar(128) DEFAULT '',
  `sPhone` varchar(32) DEFAULT '',
  `sAddress` varchar(256) DEFAULT '',
  `sCost` double DEFAULT '0',
  `sNotes` varchar(512) DEFAULT '',
  PRIMARY KEY (`sIndex`,`sID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `storages`
--

LOCK TABLES `storages` WRITE;
/*!40000 ALTER TABLE `storages` DISABLE KEYS */;
INSERT INTO `storages` VALUES (0,'L1','W1','默认购书中心','12345678910','',0,'默认购书中心无法删除'),(1,'S1','W1','默认仓库','12345678910','',0,'默认仓库无法删除'),(3,'S2','W1','nnn','1111','',111.313,'sssss'),(5,'111','W1','仓库','32323','',0,''),(6,'222','W2','仓库','','',2222,'');
/*!40000 ALTER TABLE `storages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `uID` int(11) NOT NULL AUTO_INCREMENT,
  `uCode` varchar(32) NOT NULL,
  `uLimit` int(11) DEFAULT '2',
  `uPhone` varchar(32) DEFAULT '',
  `uAddress` varchar(256) DEFAULT '',
  PRIMARY KEY (`uID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'92DQRS3PH0KFFKWC',2046,'12345678910','sdfssfsfsd');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `workers`
--

DROP TABLE IF EXISTS `workers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `workers` (
  `wIndex` int(11) NOT NULL AUTO_INCREMENT,
  `wID` varchar(32) NOT NULL,
  `wDepartmentID` varchar(32) NOT NULL,
  `wPostType` varchar(32) NOT NULL,
  `wName` varchar(32) DEFAULT '',
  `wAge` int(11) DEFAULT '0',
  `wGender` varchar(32) DEFAULT '',
  `wPay` double DEFAULT '0',
  `wPhone` varchar(32) DEFAULT '',
  `wAddress` varchar(128) DEFAULT '',
  `wNotes` varchar(512) DEFAULT '',
  PRIMARY KEY (`wIndex`,`wID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `workers`
--

LOCK TABLES `workers` WRITE;
/*!40000 ALTER TABLE `workers` DISABLE KEYS */;
INSERT INTO `workers` VALUES (1,'W1','D1','PT1','默认员工',1,'男',1,'12345678910','','默认员工无法删除'),(2,'W2','D1','PT2','张三',35,'男',3500,'','',''),(7,'W3','D1','PT3','李四',30,'男',3000,'','','');
/*!40000 ALTER TABLE `workers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'book1'
--

--
-- Dumping routines for database 'book1'
--
/*!50003 DROP PROCEDURE IF EXISTS `DELETE_BOOK` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `DELETE_BOOK`( in inID VARCHAR(32) )
BEGIN

	IF EXISTS ( SELECT stBookID FROM stock WHERE stBookID=inID LIMIT 1 ) OR
     EXISTS ( SELECT saBookID FROM sale WHERE saBookID=inID LIMIT 1 ) THEN   
	SELECT "FAILED";
	ELSE
	DELETE FROM books WHERE bID=inID;
	SELECT "SUCCESS";
	END IF;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `DELETE_BOOKTYPE` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `DELETE_BOOKTYPE`( in inID VARCHAR(32) )
BEGIN

	IF inID='PT1' THEN
    SELECT "FAILED";
    ELSE
		IF EXISTS ( SELECT bType FROM books WHERE bType=inID LIMIT 1 ) OR 
        ( SELECT dType FROM department WHERE dType=inID LIMIT 1 ) THEN   
		SELECT "FAILED";
        ELSE
        DELETE FROM booktype WHERE btID=inID;
		SELECT "SUCCESS";
		END IF;
    END IF;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `DELETE_DEPARTMENT` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `DELETE_DEPARTMENT`( in inID VARCHAR(32) )
BEGIN

	IF inID='D1' THEN
    SELECT "FAILED";
    ELSE
		IF EXISTS ( SELECT wID FROM workers WHERE wDepartmentID=inID LIMIT 1 ) THEN   
		SELECT "FAILED";
        ELSE
        DELETE FROM department WHERE dID=inID;
		SELECT "SUCCESS";
		END IF;
    END IF;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `DELETE_POSTTYPE` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `DELETE_POSTTYPE`( in inID VARCHAR(32) )
BEGIN

	IF inID='PT1' THEN
    SELECT "FAILED";
    ELSE
		IF EXISTS ( SELECT wPostType FROM workers WHERE wPostType=inID LIMIT 1 ) THEN   
		SELECT "FAILED";
        ELSE
        DELETE FROM posttype WHERE ptID=inID;
		SELECT "SUCCESS";
		END IF;
    END IF;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `DELETE_PUBLISHER` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `DELETE_PUBLISHER`( in inID VARCHAR(32) )
BEGIN

	IF inID='P1' THEN
    SELECT "FAILED";
    ELSE
		IF EXISTS ( SELECT bPublisherID FROM books WHERE bPublisherID=inID LIMIT 1 ) THEN   
		SELECT "FAILED";
        ELSE
        DELETE FROM publisher WHERE pID=inID;
		SELECT "SUCCESS";
		END IF;
    END IF;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `DELETE_SALE` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `DELETE_SALE`( in inIndex INT(11) )
BEGIN

	DELETE FROM sale WHERE saIndex=inIndex;
	SELECT "SUCCESS";
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `DELETE_STOCK` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `DELETE_STOCK`( in inIndex INT(11) )
BEGIN

	DELETE FROM stock WHERE stIndex=inIndex;
	SELECT "SUCCESS";
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `DELETE_STORAGE` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `DELETE_STORAGE`( in inID VARCHAR(32) )
BEGIN

	IF inID='S1' OR inID='L1' THEN
    SELECT "FAILED";
    ELSE
		IF EXISTS ( SELECT stStorageID FROM stock WHERE stStorageID=inID LIMIT 1 ) THEN   
		SELECT "FAILED";
        ELSE
        DELETE FROM storages WHERE sID=inID;
		SELECT "SUCCESS";
		END IF;
    END IF;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `DELETE_WORKER` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `DELETE_WORKER`( in inID VARCHAR(32) )
BEGIN

	IF inID='W1' THEN
    SELECT "FAILED";
    ELSE
		IF EXISTS ( SELECT dID FROM department WHERE dManagerID=inID LIMIT 1 ) AND
        ( SELECT sID FROM storages WHERE sManagerID=inID LIMIT 1 ) THEN   
		SELECT "FAILED";
        ELSE
        DELETE FROM workers WHERE wID=inID;
		SELECT "SUCCESS";
		END IF;
    END IF;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `INSERT_BOOK` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `INSERT_BOOK`( in inID VARCHAR(32) , in inPublisherID VARCHAR(32) , in inType VARCHAR(32) , in inName VARCHAR(32) )
BEGIN

  	DECLARE bid1 VARCHAR(32);
  	DECLARE btid1 VARCHAR(32);
	DECLARE pid1 VARCHAR(32);

	SELECT bID INTO bid1 FROM books WHERE bID=inID;
	SELECT pID INTO pid1 FROM publisher WHERE pID=inPublisherID;
	SELECT btID INTO btid1 FROM booktype WHERE btID=inType;

    IF ( NOT ISNULL( bid1 ) OR ISNULL( pid1 ) OR ISNULL( btid1 ) ) THEN
		SELECT 'FAILED';
	ELSE
		INSERT INTO books( bID , bPublisherID , bType , bName ) VALUES ( inID , inPublisherID , inType , inName );
		SELECT * FROM books WHERE bID=inID;
	END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `INSERT_BOOKTYPE` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `INSERT_BOOKTYPE`( in inID VARCHAR(32) , in inName VARCHAR(128) )
BEGIN
	DECLARE btid1 VARCHAR(32);
	SELECT btID INTO btid1 FROM booktype WHERE btID=inID;
    
    IF NOT ( ISNULL( btid1 ) ) THEN
		SELECT 'FAILED';
	ELSE
		INSERT INTO booktype( btID , btName ) VALUES ( inID , inName );
		SELECT * FROM booktype WHERE btID=inID;
	END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `INSERT_DEPARTMENT` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `INSERT_DEPARTMENT`( in inID VARCHAR(32) , in inManagerID VARCHAR(32) , inType VARCHAR(32) , in inName VARCHAR(32) )
BEGIN

  	DECLARE wid1 VARCHAR(32);
	DECLARE did1 VARCHAR(32);
	DECLARE btid1 VARCHAR(32);
	DECLARE did2 VARCHAR(32);

	SELECT dID INTO did1 FROM department WHERE dID=inID;
	SELECT wID INTO wid1 FROM workers WHERE wID=inManagerID;
	SELECT btID INTO btid1 FROM bookType WHERE btID=inType;
	SELECT dID INTO did2 FROM department WHERE dType=inType;

    IF ( NOT ISNULL( did1 ) OR ISNULL( wid1 ) OR ISNULL( btid1 ) OR NOT ISNULL( did2 ) ) THEN
		SELECT 'FAILED';
	ELSE
		INSERT INTO department( dID , dManagerID , dType , dName ) VALUES ( inID , inManagerID , inType , inName );
		SELECT * FROM department WHERE dID=inID;
	END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `INSERT_LOG` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `INSERT_LOG`( in inLog VARCHAR(256) )
BEGIN
	INSERT INTO log1( log1 , time1 ) VALUES ( inLog , now() );
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `INSERT_POSTTYPE` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `INSERT_POSTTYPE`( in inID VARCHAR(32) , in inName VARCHAR(128) )
BEGIN
	DECLARE ptid1 VARCHAR(32);
	SELECT ptID INTO ptid1 FROM posttype WHERE ptID=inID;
    
    IF NOT ( ISNULL( ptid1 ) ) THEN
		SELECT 'FAILED';
	ELSE
		INSERT INTO posttype( ptID , ptName ) VALUES ( inID , inName );
		SELECT * FROM posttype WHERE ptID=inID;
	END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `INSERT_PUBLISHER` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `INSERT_PUBLISHER`( in inID VARCHAR(32) , in inName VARCHAR(128) )
BEGIN
	DECLARE pid1 VARCHAR(32);
	SELECT pID INTO pid1 FROM publisher WHERE pID=inID;
    
    IF NOT ( ISNULL( pid1 ) ) THEN
		SELECT 'FAILED';
	ELSE
		INSERT INTO publisher( pID , pName ) VALUES ( inID , inName );
		SELECT * FROM publisher WHERE pID=inID;
	END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `INSERT_SALE` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `INSERT_SALE`( in inBookID VARCHAR(32) ,
in inStorageID VARCHAR(32) , in inNum INT(11) , in inWholesaleNum INT(11) , in inRetailNum INT(11) , in inDiscount DOUBLE )
BEGIN

    DECLARE num1 VARCHAR(32);
    DECLARE retail1 VARCHAR(32);
    DECLARE wholesale1 VARCHAR(32);
    DECLARE cost1 VARCHAR(32);
    
    IF NOT EXISTS ( SELECT bID FROM books WHERE bID=inBookID ) OR
     NOT EXISTS ( SELECT stStorageNum FROM stock WHERE stBookID=inBookID AND stStorageID=inStorageID ) THEN
    SELECT "FAILED";
    ELSE
    
	SELECT stStorageNum INTO num1 FROM stock WHERE stBookID=inBookID AND stStorageID=inStorageID;
	SELECT bCost , bRetail , bWholesale INTO cost1 , retail1 , wholesale1 FROM books WHERE bID=inBookID;

		IF num1 >= inWholesaleNum + inRetailNum THEN
			UPDATE stock SET stStorageNum=stStorageNum-inWholesaleNum-inRetailNum
			WHERE stBookID=inBookID AND stStorageID=inStorageID;
            
		INSERT INTO sale( saBookID , saTime , saNum , saWholesaleNum , saRetailNum , saDiscount , saCost , saCount , saStorageID ) 
        VALUES ( inBookID , now() , inNum , inWholesaleNum , inRetailNum , inDiscount , inNum*cost1 , inDiscount*retail1*inRetailNum + inDiscount*wholesale1*inWholesaleNum , inStorageID );
		SELECT * FROM sale WHERE saIndex=LAST_INSERT_ID(); 
		ELSE
            SELECT "FAILED";
		END IF;
	END IF;
    
	
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `INSERT_STOCK` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `INSERT_STOCK`( in inBookID VARCHAR(32) ,
in inStorageID VARCHAR(32) , in inStorageNum INT(11) )
BEGIN
   
	IF NOT EXISTS ( SELECT bID FROM books WHERE bID=inBookID ) OR
     NOT EXISTS ( SELECT sID FROM storages WHERE sID=inStorageID ) THEN
    SELECT "FAILED";
	ELSE
		IF EXISTS ( SELECT inBookID FROM stock WHERE stBookID=inBookID AND stStorageID=inStorageID LIMIT 1 ) THEN
		UPDATE stock SET stStorageNum=stStorageNum+inStorageNum
		WHERE stBookID=inBookID AND stStorageID=inStorageID;
		ELSE
			INSERT INTO stock( stBookID , stStorageID , stStorageNum ) VALUES ( inBookID , inStorageID , inStorageNum );
		END IF;
		
		SELECT * FROM stock WHERE stBookID=inBookID AND stStorageID=inStorageID;
	END IF;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `INSERT_STORAGE` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `INSERT_STORAGE`( in inID VARCHAR(32) , in inManagerID VARCHAR(32) , in inName VARCHAR(128) )
BEGIN
	DECLARE sid1 VARCHAR(32);
	DECLARE wid1 VARCHAR(32);
	SELECT sID INTO sid1 FROM storages WHERE sID=inID;
	SELECT wID INTO wid1 FROM workers WHERE wID=inManagerID;

    IF  ( NOT ISNULL( sid1 ) ) OR ISNULL( wid1 ) THEN
		SELECT 'FAILED';
	ELSE
		INSERT INTO storages( sID , sManagerID , sName ) VALUES ( inID , inManagerID , inName );
		SELECT * FROM storages WHERE sID=inID;
	END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `INSERT_WORKER` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `INSERT_WORKER`( in inID VARCHAR(32) , in inDepartmentID VARCHAR(32) , in inPostType VARCHAR(32) , in inName VARCHAR(32) )
BEGIN

  	DECLARE wid1 VARCHAR(32);
	DECLARE did1 VARCHAR(32);
	DECLARE pt1 VARCHAR(32);

	SELECT dID INTO did1 FROM department WHERE dID=inDepartmentID;
	SELECT wID INTO wid1 FROM workers WHERE wID=inID;
	SELECT ptID INTO pt1 FROM posttype WHERE ptID=inPostType;

    IF ( ISNULL( did1 ) OR NOT ISNULL( wid1 ) OR ISNULL( pt1 ) ) THEN
		SELECT 'FAILED';
	ELSE
		INSERT INTO workers( wID , wDepartmentID , wPostType , wName ) VALUES ( inID , inDepartmentID , inPostType , inName );
		SELECT * FROM workers WHERE wID=inID;
	END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `REPORT_PROFIT` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `REPORT_PROFIT`( in inYear YEAR )
BEGIN

	DECLARE i INT(11) DEFAULT 1;
	DECLARE storageCost INT(11) DEFAULT 0;
	DECLARE departmentCost INT(11) DEFAULT 0;
	DECLARE workerPay INT(11) DEFAULT 0;
	DECLARE monthCost INT(11) DEFAULT 0;
	DECLARE monthProfit INT(11) DEFAULT 0;
	DECLARE monthIncome INT(11) DEFAULT 0;
    
	DECLARE yearCost INT(11) DEFAULT 0;
	DECLARE yearProfit INT(11) DEFAULT 0;
	DECLARE yearIncome INT(11) DEFAULT 0;

	SELECT SUM( sCost ) INTO storageCost FROM storages;    
 	SELECT SUM( dCost ) INTO departmentCost FROM department;    
 	SELECT SUM( wPay ) INTO workerPay FROM workers;    
    
#    SELECT storageCost,departmentCost,workerPay;

	WHILE i <= 12 DO
    SET monthCost = 0;
    SET monthIncome = 0;
    SELECT SUM( saCost ) , SUM( saCount ) INTO monthCost , monthIncome FROM sale WHERE saTime like CONCAT( inYear , '-' , i , '-%'); 
    IF ISNULL( monthCost ) THEN SET monthCost=0; END IF;
    IF ISNULL( monthIncome ) THEN SET monthIncome=0; END IF;
	SET monthProfit = monthIncome - monthCost - workerPay - departmentCost - storageCost;
    SELECT CONCAT( inYear , '-' , i ), storageCost , departmentCost , workerPay , monthCost , monthIncome , monthProfit;
    
    SET yearCost=yearCost+monthCost;
	SET yearProfit=yearProfit+monthProfit;
    SET yearIncome=yearIncome+monthIncome;
	
	SET i = i + 1;
	END WHILE;
    
	SELECT inYear , storageCost*12 , departmentCost*12 , workerPay*12 , yearCost , yearIncome , yearProfit;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `REPORT_SALE` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `REPORT_SALE`( in inYear YEAR , in inMonth int(11) )
BEGIN
SELECT CONCAT( '' , sale.saBookId , '(' , books.bName , ')' ) , SUM(sale.saNum) , SUM(sale.saWholesaleNum) , SUM(sale.saRetailNum) , SUM(sale.saCost) , SUM(sale.saCount), CONCAT( '' , sale.saStorageID , '(' , storages.sName , ')' ) 
FROM sale,books,storages WHERE sale.saTime like CONCAT( inYear , '-' , inMonth , '-%' ) AND sale.saBookId=books.bID AND sale.saStorageID=storages.sID GROUP BY sale.saBookID,sale.saStorageID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SELECT_USER` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SELECT_USER`( IN inCode VARCHAR(32) )
BEGIN

	DECLARE uid1 INT(11);
	SELECT uID INTO uid1 from users WHERE uCode=inCode;
    
	IF ( uid1 ) THEN   
		SELECT * FROM users WHERE uCode=inCode;
	ELSE  
		INSERT INTO users( uCode ) VALUES ( inCode );
		SELECT * FROM users WHERE uCode=inCode;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SELECT_USER_LIMIT` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SELECT_USER_LIMIT`( in inID INT(11) )
BEGIN
	DECLARE limit1 INT;
	SELECT uLimit INTO limit1 from users where uID=inID;
    
    IF limit1 THEN
		SELECT limit1;
	ELSE
		SELECT 0;
	END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `UPDATE_BOOK` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `UPDATE_BOOK`( in inID VARCHAR(32) , in inPublisherID VARCHAR(32) , 
in inType VARCHAR(32) , in inName VARCHAR(128) , in inFormat VARCHAR(32) , in inCost DOUBLE , in inRetail DOUBLE , in inWholesale DOUBLE , in inNotes VARCHAR(512) )
BEGIN

	IF NOT EXISTS ( SELECT pID from publisher where pID=inPublisherID LIMIT 1 ) OR
    NOT EXISTS ( SELECT btID from booktype where btID=inType LIMIT 1 ) THEN   
		SELECT "FAILED";
	ELSE 
        
	UPDATE books SET bPublisherID=inPublisherID , bType=inType, bName=inName , 
    bFormat=inFormat, bCost=inCost, bRetail=inRetail, bWholesale=inWholesale, bNotes=inNotes
	WHERE bID = inID;
    SELECT "SUCCESS";
    
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `UPDATE_BOOKTYPE` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `UPDATE_BOOKTYPE`( in inID VARCHAR(32) , in inName VARCHAR(128) , in inNotes VARCHAR(512) )
BEGIN
	UPDATE booktype SET btName=inName , btNotes=inNotes
	WHERE btID = inID;
    SELECT "SUCCESS";
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `UPDATE_DEPARTMENT` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `UPDATE_DEPARTMENT`( in inID VARCHAR(32) , in inManagerID VARCHAR(32) , 
in inType VARCHAR(32) , in inName VARCHAR(128) , in inPhone VARCHAR(32) , in inAddress VARCHAR(256) , in inCost DOUBLE , in inNotes VARCHAR(512) )
BEGIN

	IF NOT EXISTS ( SELECT wID FROM workers WHERE wID=inManagerID LIMIT 1 ) OR 
	NOT EXISTS ( SELECT dID FROM department WHERE dID=inID AND dType=inType LIMIT 1 ) THEN   
		SELECT "FAILED";
	ELSE 
        
	UPDATE department SET dManagerID=inManagerID , dName=inName , 
    dType=inType, dPhone=inPhone, dAddress=inAddress, dCost=inCost, dNotes=inNotes
	WHERE dID = inID;
    SELECT "SUCCESS";
    
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `UPDATE_POSTTYPE` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `UPDATE_POSTTYPE`( in inID VARCHAR(32) , in inName VARCHAR(128) , in inNotes VARCHAR(512) )
BEGIN
	UPDATE posttype SET ptName=inName , ptNotes=inNotes
	WHERE ptID = inID;
    SELECT "SUCCESS";
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `UPDATE_PUBLISHER` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `UPDATE_PUBLISHER`( in inID VARCHAR(32) , in inName VARCHAR(128) , in inPhone VARCHAR(32) , in inAddress VARCHAR(256) , in inNotes VARCHAR(512) )
BEGIN
	UPDATE publisher SET pName=inName , pPhone=inPhone , pAddress=inAddress, pNotes=inNotes
	WHERE pID = inID;
    SELECT "SUCCESS";
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `UPDATE_SALE` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `UPDATE_SALE`( in inIndex INT(11) , in inNotes VARCHAR(512) )
BEGIN
	UPDATE sale SET saNotes=inNotes
	WHERE saIndex=inIndex;
    SELECT "SUCCESS";
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `UPDATE_STOCK` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `UPDATE_STOCK`( in inIndex INT(11) , in inBookID VARCHAR(32) ,
in inStorageID VARCHAR(32) , in inStorageNum INT(11) , in inNotes VARCHAR(512) )
BEGIN
   
    UPDATE stock SET stStorageNum=inStorageNum,stBookID=inBookID,stStorageID=inStorageID, stNotes=inNotes
	WHERE stIndex=inIndex;
    SELECT "SUCCESS";

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `UPDATE_STORAGE` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `UPDATE_STORAGE`( in inID VARCHAR(32) , 
in inManagerID VARCHAR(32) , in inName VARCHAR(128) , in inPhone VARCHAR(32) , in inAddress VARCHAR(256) , in inCost DOUBLE , in inNotes VARCHAR(512) )
BEGIN
	IF NOT EXISTS ( SELECT wID from workers where wID=inManagerID LIMIT 1 ) THEN   
		SELECT "FAILED";
	ELSE 
		UPDATE storages SET sManagerID=inManagerID , sName=inName, sPhone=inPhone , sAddress=inAddress, sCost=inCost, sNotes=inNotes
		WHERE sID = inID;
		SELECT "SUCCESS";
    END IF;
    
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `UPDATE_WORKER` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `UPDATE_WORKER`( in inID VARCHAR(32) , in inDepartmentID VARCHAR(32) , in inPostType VARCHAR(32) , 
in inName VARCHAR(32) , in inAge INT(11) , in inGender VARCHAR(32) , in inPay DOUBLE , in inPhone VARCHAR(32) , in inAddress VARCHAR(256) , in inNotes VARCHAR(512) )
BEGIN

	IF NOT EXISTS ( SELECT dID from department where dID=inDepartmentID LIMIT 1 ) OR
    NOT EXISTS ( SELECT ptID from posttype where ptID=inPostType LIMIT 1 ) THEN   
		SELECT "FAILED";
	ELSE 
        
	UPDATE workers SET wDepartmentID=inDepartmentID , wPostType=inPostType, wName=inName , 
    wAge=inAge, wGender=inGender, wPay=inPay, wPhone=inPhone, wAddress=inAddress,wNotes=inNotes
	WHERE wID = inID;
    SELECT "SUCCESS";
    
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-10-23 11:32:49
