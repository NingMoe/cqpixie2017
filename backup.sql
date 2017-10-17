-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: cqpixie
-- ------------------------------------------------------
-- Server version	5.7.17-log

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
-- Current Database: `cqpixie`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `cqpixie` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `cqpixie`;

--
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `category` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `categoryname` varchar(100) NOT NULL,
  `description` longtext,
  `editor` varchar(50) DEFAULT NULL,
  `editdate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` VALUES (11,'低帮系列安全防护鞋','低帮','admin','2017-06-11 23:25:04'),(12,'高腰系列安全防护鞋','高腰','admin','2017-06-11 23:25:22'),(13,'长筒系列安全防护鞋','长筒','admin','2017-06-11 23:25:40');
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `page`
--

DROP TABLE IF EXISTS `page`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `page` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(100) DEFAULT NULL,
  `content` longtext,
  `editor` varchar(50) DEFAULT NULL,
  `editdate` datetime DEFAULT NULL,
  `imgurl` longtext,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `page`
--

LOCK TABLES `page` WRITE;
/*!40000 ALTER TABLE `page` DISABLE KEYS */;
INSERT INTO `page` VALUES (3,'title1','<p><a href=\"http://www.baidu.com\">水电费水电费是发生的</a></p>\n','admin','2017-06-14 23:58:04','/Uploads/2017614235725.jpg'),(4,'title3','<p>fsfsfsfsfsdfsfsd</p>\n','admin','2017-06-14 23:59:03','/Uploads/2017614235859.jpg'),(5,'title2','<p><strong><em>sdfsfsdfsdf</em></strong></p>\n','admin','2017-06-14 23:58:25',''),(6,'title4','<p>contentdddddddddddddddd</p>\n','admin','2017-06-17 11:56:18','/Uploads/2017617115612.jpg'),(7,'title5','<p>contentsdfsfsdfsdfeeeeeeee</p>\n','admin','2017-06-17 11:55:55','/Uploads/2017617115550.PNG'),(8,'联系我们','<p>二位二位</p>\n','admin','2017-06-19 21:33:59',''),(10,'人才招聘','<p>TTTTT</p>\n','admin','2017-06-19 21:33:38',''),(12,'企业介绍','<p>&nbsp; &nbsp; 这是企业介绍</p>\n\n<p>&nbsp; &nbsp; 这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊这是一个好企业啊</p>\n\n<p><img alt=\"\" src=\"/Uploads/2017619214655.jpg\" style=\"height:72px; width:200px\" /></p>\n','admin','2017-06-19 21:47:56','/Uploads/2017619214655.jpg'),(13,'设备展示','<p>啥地方顺丰速递</p>\n','admin','2017-06-19 21:32:23','');
/*!40000 ALTER TABLE `page` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `post`
--

DROP TABLE IF EXISTS `post`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `post` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(100) DEFAULT NULL,
  `content` longtext,
  `editor` varchar(50) DEFAULT NULL,
  `editdate` datetime DEFAULT NULL,
  `imgurl` longtext,
  `categoryid` int(11) NOT NULL,
  `tags` longtext,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `post`
--

LOCK TABLES `post` WRITE;
/*!40000 ALTER TABLE `post` DISABLE KEYS */;
INSERT INTO `post` VALUES (3,'P001','<p><strong>产品描述：</strong></p>\n\n<p>也是说了的开发</p>\n\n<p>也是说了的开发</p>\n\n<p>也是说了的开发</p>\n\n<p>也是说了的开发</p>\n\n<p>也是333说了的开发</p>\n\n<p>也是说了的开发</p>\n\n<p>也是说了的开发</p>\n\n<p>也是说了的开发</p>\n\n<p>也是说了的开发</p>\n\n<p>也是333说了的开发</p>\n\n<p>也是说了的开发</p>\n\n<p>也是说了的开发</p>\n\n<p>也是说了的开发</p>\n\n<p>也是说了的开发</p>\n','admin','2017-06-19 11:40:40','/Uploads/2017617113543.png',11,'电绝缘,耐油'),(4,'P002','<p><s>XXXXXXXXXXXXXXX</s></p>\n\n<p><strong><em>F<a href=\"http://WWW.BAIDU.COM\">SDDFS</a>D</em></strong></p>\n','admin','2017-06-22 10:20:18','https://ss1.bdstatic.com/70cFuXSh_Q1YnxGkpoWK1HF6hhy/it/u=267153297,1157686928&fm=117&gp=0.jpg',13,'保护足趾,防静电,耐油,防寒,导电'),(5,'P003','<p><strong>SDFSDFSDFSDFSDFSDFSDFSDFSSSS</strong></p>\n','admin','2017-06-20 11:32:48','/Uploads/2017614213828.jpg',12,'保护足趾,防静电,电绝缘,耐油,耐酸碱,防寒,耐高温,导电'),(6,'P004','<p>SDFSDFSSDF</p>\n','admin','2017-06-19 15:36:24','/Uploads/2017619153614.png',12,'电绝缘,耐油'),(7,'P005','<p>SDFSDFSSDF</p>\n','admin','2017-06-19 15:36:35','/Uploads/2017619153614.png',12,'电绝缘,耐油'),(8,'P006','<p>SDFSDFSSDF</p>\n','admin','2017-06-19 15:36:40','/Uploads/2017619153614.png',12,'电绝缘,耐油'),(9,'P007','<p>SDFSDFSSDF</p>\n','admin','2017-06-19 15:36:45','/Uploads/2017619153614.png',12,'电绝缘,耐油'),(10,'P008','<p>SDFSDFSSDF</p>\n','admin','2017-06-19 15:36:50','/Uploads/2017619153614.png',12,'电绝缘,耐油'),(11,'P009','<p>SDFSDFSSDF</p>\n','admin','2017-06-19 15:36:54','/Uploads/2017619153614.png',12,'电绝缘,耐油'),(12,'P0010','<p>SDFSDFSSDF</p>\n','admin','2017-06-19 15:36:59','/Uploads/2017619153614.png',12,'电绝缘,耐油'),(13,'P0011','<p>SDFSDFSSDF</p>\n','admin','2017-06-19 15:37:04','/Uploads/2017619153614.png',12,'电绝缘,耐油'),(14,'P0012','<p>SDFSDFSSDF</p>\n','admin','2017-06-19 15:37:08','/Uploads/2017619153614.png',12,'电绝缘,耐油'),(15,'P0013','<p>SDFSDFSSDF</p>\n','admin','2017-06-19 15:37:12','/Uploads/2017619153614.png',12,'电绝缘,耐油'),(16,'P0014','<p>SDFSDFSSDF</p>\n','admin','2017-06-20 11:30:24','/Uploads/2017619153614.png',12,'保护足趾,防刺穿,防静电,电绝缘,耐油,耐酸碱,防寒,耐高温,导电'),(17,'P0015','<p>SDFSDFSSDF</p>\n','admin','2017-06-22 10:23:04','/Uploads/2017619153614.png',12,'防刺穿,耐油,耐高温'),(18,'P0016','<p>SDFSDFSSDF</p>\n','admin','2017-06-19 15:37:25','/Uploads/2017619153614.png',12,'电绝缘,耐油');
/*!40000 ALTER TABLE `post` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `password` varchar(100) DEFAULT NULL,
  `editor` varchar(50) DEFAULT NULL,
  `editdate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (2,'ycm','ycm119','admin','2017-06-27 21:26:57'),(3,'admin','admin123','admin','2017-06-28 00:05:55'),(5,'test','test123','admin','2017-06-28 02:02:08');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-06-28  2:07:37
