-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: art_space
-- ------------------------------------------------------
-- Server version	8.0.36

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
-- Table structure for table `art_form`
--

DROP TABLE IF EXISTS `art_form`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `art_form` (
  `id_art_form` int NOT NULL AUTO_INCREMENT,
  `name_a_f` varchar(50) NOT NULL,
  PRIMARY KEY (`id_art_form`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `art_form`
--

LOCK TABLES `art_form` WRITE;
/*!40000 ALTER TABLE `art_form` DISABLE KEYS */;
INSERT INTO `art_form` VALUES (1,'Графика'),(2,'Живопись'),(3,'Скульптура');
/*!40000 ALTER TABLE `art_form` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `authors`
--

DROP TABLE IF EXISTS `authors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `authors` (
  `id_author` int NOT NULL AUTO_INCREMENT,
  `surname_author` varchar(50) NOT NULL,
  `name_author` varchar(50) NOT NULL,
  `date_birth` date NOT NULL,
  `date_death` date DEFAULT NULL,
  PRIMARY KEY (`id_author`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `authors`
--

LOCK TABLES `authors` WRITE;
/*!40000 ALTER TABLE `authors` DISABLE KEYS */;
INSERT INTO `authors` VALUES (1,'Боттичелли','Сандро','1445-03-01','1510-05-17'),(2,'да Винчи','Леонардо ','1452-04-15','1519-05-02'),(3,'Буонарроти','Микеланджело','1475-03-06','1564-02-18'),(4,'Санти','Рафаэль','1483-04-06','1520-04-06'),(5,'ван Гог','Винсент ','1853-03-30','1890-07-29'),(6,'Шишкин','Иван ','1832-01-25','1898-03-20'),(7,'Савицкий','Константин','1844-06-06','1905-02-13'),(8,'Пикассо','Пабло','1881-10-25','1973-04-08');
/*!40000 ALTER TABLE `authors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `epoch`
--

DROP TABLE IF EXISTS `epoch`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `epoch` (
  `id_era` int NOT NULL AUTO_INCREMENT,
  `name_era` varchar(50) NOT NULL,
  PRIMARY KEY (`id_era`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `epoch`
--

LOCK TABLES `epoch` WRITE;
/*!40000 ALTER TABLE `epoch` DISABLE KEYS */;
INSERT INTO `epoch` VALUES (1,'Первобытная культура'),(2,'Античность'),(3,'Средние века'),(4,'Возрождение'),(5,'Барокко'),(6,'Классицизм'),(7,'Просвещение'),(8,'Сентиментализм'),(9,'Романтизм'),(10,'Реализм'),(11,'Модернизм'),(12,'Постмодернизм');
/*!40000 ALTER TABLE `epoch` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `evaluation`
--

DROP TABLE IF EXISTS `evaluation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `evaluation` (
  `id_exhibit` int NOT NULL,
  `id_user` int NOT NULL,
  `score` int NOT NULL,
  PRIMARY KEY (`id_exhibit`,`id_user`),
  KEY `fk_ev_u` (`id_user`),
  CONSTRAINT `fk_ev_e` FOREIGN KEY (`id_exhibit`) REFERENCES `exhibits` (`id_exhibit`),
  CONSTRAINT `fk_ev_u` FOREIGN KEY (`id_user`) REFERENCES `users` (`id_user`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `evaluation`
--

LOCK TABLES `evaluation` WRITE;
/*!40000 ALTER TABLE `evaluation` DISABLE KEYS */;
INSERT INTO `evaluation` VALUES (1,2,5),(1,4,4),(2,5,4),(3,6,5),(4,7,5),(5,8,4),(6,9,3),(7,10,5),(11,2,5),(11,4,5),(11,5,5),(11,8,5);
/*!40000 ALTER TABLE `evaluation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `exhibits`
--

DROP TABLE IF EXISTS `exhibits`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `exhibits` (
  `id_exhibit` int NOT NULL AUTO_INCREMENT,
  `name_exhibit` varchar(100) NOT NULL,
  `description_exhibit` text NOT NULL,
  `year_creation` int NOT NULL,
  `country_creation` varchar(50) NOT NULL,
  `id_era` int NOT NULL,
  `id_art_form` int NOT NULL,
  `id_genre` int NOT NULL,
  `id_storage_location` int NOT NULL,
  `number_views` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_exhibit`),
  KEY `fk_e_af` (`id_art_form`),
  KEY `fk_e_e` (`id_era`),
  KEY `fk_e_g` (`id_genre`),
  KEY `fk_e_sl` (`id_storage_location`),
  CONSTRAINT `fk_e_af` FOREIGN KEY (`id_art_form`) REFERENCES `art_form` (`id_art_form`),
  CONSTRAINT `fk_e_e` FOREIGN KEY (`id_era`) REFERENCES `epoch` (`id_era`),
  CONSTRAINT `fk_e_g` FOREIGN KEY (`id_genre`) REFERENCES `genres` (`id_genre`),
  CONSTRAINT `fk_e_sl` FOREIGN KEY (`id_storage_location`) REFERENCES `storage_locations` (`id_storage_location`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `exhibits`
--

LOCK TABLES `exhibits` WRITE;
/*!40000 ALTER TABLE `exhibits` DISABLE KEYS */;
INSERT INTO `exhibits` VALUES (1,'Рождение Венеры','Биограф Джорджо Вазари в своих «Жизнеописаниях» (1550) упоминает, что «Рождение Венеры» и «Весна» хранились на Вилле Кастелло, принадлежащей Козимо I Медичи. Большинство историков считают, что картины были созданы для Лоренцо ди Пьерфранческо Медичи, владельца виллы в 1486 году и двоюродного брата Лоренцо Великолепного. Инвентарные записи подтверждают, что Лоренцо владел «Весной», но прямых доказательств, что он заказал «Рождение Венеры», нет.\nСчитается, что моделью для Венеры была Симонетта Веспуччи. Есть версия, что Боттичелли написал «Рождение Венеры» не для Медичи, а для другого знатного современника.\nБоттичелли вряд ли был знатоком древних текстов, однако мог быть знаком с интеллектуалами Флоренции через своего соседа Джорджо Антонио Веспуччи. Возможно, он был знаком с поэтом Анжело Полициано, описывавшим рождение Венеры, или философом Марсилио Фичино, который в своей доктрине уделял внимание Небесной Венере, символизировавшей гуманизм, милосердие и любовь.',1486,'Италия',4,2,6,1,8),(2,'Воскресший Христос','Нет сведений',1490,'Италия',4,2,10,2,12),(3,'Мона Лиза','На картине прямоугольного формата изображена женщина в тёмной одежде, обернувшаяся вполоборота. Она сидит в кресле, сложив руки вместе, оперев одну руку на его подлокотник, а другую положив сверху, повернувшись в кресле почти лицом к зрителю. Разделённые пробором, гладко и плоско лежащие волосы, видные сквозь накинутую на них прозрачную вуаль (по некоторым предположениям — атрибут вдовства), падают на плечи двумя негустыми, слегка волнистыми прядями. Зелёное платье в тонких сборках, с жёлтыми рукавами в складках, вырезано на белой невысокой груди. Голова слегка повёрнута.',1503,'Италия',4,2,9,3,12),(4,'Тайная вечеря','Леонардо да Винчи, следуя давней традиции изображения «Тайной вечери Христа с учениками», изобразил момент, когда, согласно повествованию всех четырёх синоптических Евангелий, Иисус в «пасхальной горнице» в Иерусалиме, «возлёг с двенадцатью учениками» (по восточному обычаю иудеи не сидели, а «возлежали» вокруг центрального стола) и произнёс: «Истинно говорю вам, что один из вас предаст Меня»). Леонардо да Винчи в духе гуманистического мировоззрения и эстетики эпохи итальянского Возрождения попытался изобразительными средствами разрешить сложнейшую психологическую задачу: показать реакцию каждого из апостолов на пророческие слова Христа. При этом он исходил из различных характеров психотипов, так, как он их себе представлял в соответствии с евангельским повествованием и научными знаниями того времени.',1495,'Италия',4,2,10,4,3),(5,'Битва кентавров','Микеланджело создал барельеф \"Битва кентавров\" из куска каррарского мрамора, пожертвованного Лоренцо Великолепным для школы в садах Сан-Марко. На рельефе изображена ожесточённая батальная сцена с множеством молодых воинов. Одной из центральных фигур является юноша с камнем в руке, пытающийся его бросить. За его спиной находится бородатый воин, также с камнем в руке. Сцена настолько ожесточённая, что живые не замечают ни раненых, ни мертвых. Внизу рельефа изображена фигура убитого кентавра, которого топчут, и ещё один кентавр, пытающийся продолжить борьбу. В углу слева изображён умирающий юноша, получивший ранение головы. Этот рельеф стал свидетельством горячего и тревожного сознания семнадцатилетнего Микеланджело, который сумел передать ожесточённость и ужасные стороны войны.',1492,'Италия',4,3,6,5,5),(6,'Распятие','Распятого Христа художник изобразил обнаженным, так как перед казнью воины поделили его одежду, о чем упоминается в Евангелии от Иоанна (Ин. 19:23, 24).\r На табличке над Христом написаны слова: Иисус Назорей, Царь Иудейский (Ин. 19:19).\r По мнению же Эрика Шильяно, у Иисуса «мягкие, сглаженные линии, готическая симметрия, деликатная красота и наивные пропорции не имеют ничего общего с мощными (…) фигурами даже его ранних работ из камня».\r',1492,'Италия',4,3,10,6,3),(7,'Страшный суд','В \"Страшном суде\" Микеланджело композиция разделена на три части: верхнюю (люнеты с летящими ангелами), центральную (Христос и Дева Мария между блаженными) и нижнюю (конец времен). Количество персонажей превышает четыреста, высота фигур варьируется от 250 см до 155 см.\nВ люнетах изображены группы ангелов без крыльев, несущие символы Страстей Христовых. Они представлены в сложных ракурсах на фоне ультрамаринового неба и выделяются среди всех фигур фрески. В напряженных выражениях лиц ангелов предвосхищается мрачное видение конца времен.\nЦентр всей композиции - фигура Христа-Судии с Девой Марией в окружении проповедников, пророков, патриархов, сивилл, героев Ветхого Завета, мучеников и святых. Микеланджело частично следует традиционной иконографии, но изображает Христа без алой мантии и безбородым, что вызвало критику.\nНиз фрески разделен на пять частей: в центре ангелы с трубами и книгами возвещают Страшный суд; слева внизу представлено воскрешение мертвых, вверху - вознесение праведников; справа вверху - захват грешников дьяволами, внизу - ад.',1541,'Италия',4,2,10,7,6),(8,'Дама с единорогом','Композиция портрета, судя по всему, создана под влиянием «Моны Лизы», написанной Леонардо да Винчи в 1505—1506. В частности, речь идет об обрамляющих фигуру колоннах лоджии (в современном виде в «Моне Лизе» эти детали обрезаны), а также о позитуре модели.\nВ руках дама держит небольшого единорога — символ целомудрия: согласно средневековым легендам, приручить это мифическое существо могла только девственница.\nДве главные черты этого портрета — «грациозное изящество, которому трудно противостоять, и загадочный характер этой таинственной дамы, которая всё так же продолжает избегать опознания».',1506,'Италия',4,2,9,8,2),(9,'Автопортрет','«Автопортрет» — картина известного художника эпохи Возрождения Рафаэля. Хранится в галерее Уффици.\nНедавние исследования полотна обнаружили рисунок внизу, который подтверждает, что это действительно подлинный автопортрет, написанный около 1506 года. «Автопортрет» находился в коллекции кардинала Леопольда Медичи, с 1682 года — в собрании галереи Уффици.\nАвтопортрет, похожий на этот, но развернутый зеркально, изображен на фреске Рафаэля «Афинская школа» в одном из парадных залов Ватиканского дворца — станце делла Сеньятура — как образ древнегреческого художника Апеллеса.',1506,'Италия',4,2,9,1,5),(10,'Цветущие ветки миндаля','31 января 1890 года Тео ван Гог написал Винсенту о рождении сына, которого назвали Винсент Виллем в честь дяди. Винсент ван Гог сразу же принялся за работу над картиной, которую намеревался подарить своему младшему брату. По замыслу Винсента полотно должно было висеть над постелью супругов и символизировать начало новой жизни. Этим обоснован выбор сюжета полотна — ветки миндаля начинают цвести очень рано и являются предвестниками весны.',1890,'Франция',11,2,7,9,6),(11,'Череп с горящей сигаретой','Жанр картины, написанной в период, когда Ван Гог испытывал проблемы со здоровьем, можно определить, как ванитас или Memento mori. На её создание могли повлиять работы нидерландского художника XVII века Геркулеса Сегерса или бельгийца Фелисьена Ропса, современника Ван Гога. Самого Ван Гога зачастую считали критиком курения, хотя он оставался страстным курильщиком вплоть до своей смерти в 1890 году.',1886,'Нидерланды',11,2,7,9,15);
/*!40000 ALTER TABLE `exhibits` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `exhibits_authors`
--

DROP TABLE IF EXISTS `exhibits_authors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `exhibits_authors` (
  `id_exhibit` int NOT NULL,
  `id_author` int NOT NULL,
  PRIMARY KEY (`id_exhibit`,`id_author`),
  KEY `fk_ea_a` (`id_author`),
  CONSTRAINT `fk_ea_a` FOREIGN KEY (`id_author`) REFERENCES `authors` (`id_author`),
  CONSTRAINT `fk_ea_e` FOREIGN KEY (`id_exhibit`) REFERENCES `exhibits` (`id_exhibit`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `exhibits_authors`
--

LOCK TABLES `exhibits_authors` WRITE;
/*!40000 ALTER TABLE `exhibits_authors` DISABLE KEYS */;
INSERT INTO `exhibits_authors` VALUES (1,1),(2,1),(3,2),(4,2),(5,3),(6,3),(7,3),(8,4),(9,4),(10,5),(11,5);
/*!40000 ALTER TABLE `exhibits_authors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `exhibits_technique`
--

DROP TABLE IF EXISTS `exhibits_technique`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `exhibits_technique` (
  `id_exhibit` int NOT NULL,
  `id_e_t` int NOT NULL,
  PRIMARY KEY (`id_exhibit`,`id_e_t`),
  KEY `fk_et_t` (`id_e_t`),
  CONSTRAINT `fk_et_e` FOREIGN KEY (`id_exhibit`) REFERENCES `exhibits` (`id_exhibit`),
  CONSTRAINT `fk_et_t` FOREIGN KEY (`id_e_t`) REFERENCES `technique_of_execution` (`id_e_t`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `exhibits_technique`
--

LOCK TABLES `exhibits_technique` WRITE;
/*!40000 ALTER TABLE `exhibits_technique` DISABLE KEYS */;
INSERT INTO `exhibits_technique` VALUES (3,1),(8,1),(9,1),(3,2),(8,2),(9,2),(10,2),(11,2),(5,3),(6,3),(1,4),(2,4),(4,5),(7,5),(1,6),(2,6),(10,6),(11,6);
/*!40000 ALTER TABLE `exhibits_technique` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `favorite_exhibits`
--

DROP TABLE IF EXISTS `favorite_exhibits`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `favorite_exhibits` (
  `id_exhibit` int NOT NULL,
  `id_user` int NOT NULL,
  `date_addition` date NOT NULL,
  PRIMARY KEY (`id_exhibit`,`id_user`),
  KEY `fk_fe_u` (`id_user`),
  CONSTRAINT `fk_fe_e` FOREIGN KEY (`id_exhibit`) REFERENCES `exhibits` (`id_exhibit`),
  CONSTRAINT `fk_fe_u` FOREIGN KEY (`id_user`) REFERENCES `users` (`id_user`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `favorite_exhibits`
--

LOCK TABLES `favorite_exhibits` WRITE;
/*!40000 ALTER TABLE `favorite_exhibits` DISABLE KEYS */;
INSERT INTO `favorite_exhibits` VALUES (1,2,'2023-04-15'),(2,2,'2024-05-27'),(2,4,'2023-05-20'),(3,5,'2023-06-10'),(4,6,'2023-07-25'),(5,7,'2023-08-03'),(6,8,'2023-08-12'),(7,9,'2023-09-01'),(8,10,'2023-09-25');
/*!40000 ALTER TABLE `favorite_exhibits` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `genres`
--

DROP TABLE IF EXISTS `genres`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `genres` (
  `id_genre` int NOT NULL AUTO_INCREMENT,
  `name_genre` varchar(100) NOT NULL,
  PRIMARY KEY (`id_genre`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `genres`
--

LOCK TABLES `genres` WRITE;
/*!40000 ALTER TABLE `genres` DISABLE KEYS */;
INSERT INTO `genres` VALUES (1,'Анималистический жанр'),(2,'Батальный жанр'),(3,'Бытовой жанр'),(4,'Исторический жанр'),(5,'Марина'),(6,'Мифологический жанр'),(7,'Натюрморт'),(8,'Пейзаж'),(9,'Портрет'),(10,'Религиозная живопись');
/*!40000 ALTER TABLE `genres` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `images`
--

DROP TABLE IF EXISTS `images`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `images` (
  `id_image` int NOT NULL AUTO_INCREMENT,
  `id_exhibit` int NOT NULL,
  `image` text NOT NULL,
  PRIMARY KEY (`id_image`),
  KEY `fk_i_e` (`id_exhibit`),
  CONSTRAINT `fk_i_e` FOREIGN KEY (`id_exhibit`) REFERENCES `exhibits` (`id_exhibit`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `images`
--

LOCK TABLES `images` WRITE;
/*!40000 ALTER TABLE `images` DISABLE KEYS */;
INSERT INTO `images` VALUES (1,1,'Рождение_Венеры.jpg'),(2,1,'Рождение_Венеры2.jpg'),(3,2,'Воскресший Христос.jpg'),(4,3,'Мона Лиза.jpg'),(5,4,'Тайная вечеря.jpg'),(6,5,'Битва кентавров.jpg'),(7,6,'Распятие.jpg'),(8,7,'Страшный суд.jpg'),(9,7,'Страшный суд2.jpg'),(10,7,'Страшный суд3.jpg'),(11,7,'Страшный суд4.jpg'),(12,7,'Страшный суд5.jpg'),(13,8,'Дама с единорогом.jpg'),(14,9,'Автопортрет.jpg'),(15,10,'Цветущие ветки миндаля.jpg'),(16,11,'Череп с горящей сигаретой.jpg'),(17,5,'Битва кентавров1.jpg'),(18,5,'Битва кентавров2.jpg'),(19,5,'Битва кентавров3.jpg'),(20,5,'Битва кентавров4.jpg');
/*!40000 ALTER TABLE `images` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reviews`
--

DROP TABLE IF EXISTS `reviews`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reviews` (
  `id_review` int NOT NULL AUTO_INCREMENT,
  `id_exhibit` int NOT NULL,
  `id_user` int NOT NULL,
  `text_review` text NOT NULL,
  `date_review` date NOT NULL,
  `complaint` tinyint NOT NULL,
  PRIMARY KEY (`id_review`),
  KEY `fk_r_e` (`id_exhibit`),
  KEY `fk_r_u` (`id_user`),
  CONSTRAINT `fk_r_e` FOREIGN KEY (`id_exhibit`) REFERENCES `exhibits` (`id_exhibit`),
  CONSTRAINT `fk_r_u` FOREIGN KEY (`id_user`) REFERENCES `users` (`id_user`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reviews`
--

LOCK TABLES `reviews` WRITE;
/*!40000 ALTER TABLE `reviews` DISABLE KEYS */;
INSERT INTO `reviews` VALUES (1,1,2,'Очень красивая картина!','2023-04-20',1),(2,2,4,'Интересный сюжет, отличное исполнение.','2023-05-22',1),(3,3,5,'Великолепный портрет!','2023-06-12',0),(4,4,6,'Удивительное произведение искусства.','2023-07-30',0),(5,5,7,'Очень динамичное изображение.','2023-08-05',0),(6,6,8,'Впечатляющая картина.','2023-08-15',0),(7,7,9,'Глубокий смысл, потрясающие детали.','2023-09-05',0),(8,8,10,'Умиротворяющий образ.','2023-09-30',0),(9,1,4,'Не очень понравилась данная картина, если честно.','2023-10-01',0);
/*!40000 ALTER TABLE `reviews` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `storage_locations`
--

DROP TABLE IF EXISTS `storage_locations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `storage_locations` (
  `id_storage_location` int NOT NULL AUTO_INCREMENT,
  `name_s_l` varchar(50) NOT NULL,
  `city` varchar(100) NOT NULL,
  `country` varchar(50) NOT NULL,
  PRIMARY KEY (`id_storage_location`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `storage_locations`
--

LOCK TABLES `storage_locations` WRITE;
/*!40000 ALTER TABLE `storage_locations` DISABLE KEYS */;
INSERT INTO `storage_locations` VALUES (1,'Галерея Уффици','Флоренция','Италия'),(2,'Академия изящных искусств','Флоренция','Италия'),(3,'Лувр','Париж','Франция'),(4,'Монастырь Санта-Мария-делле-Грацие','Милан','Италия'),(5,'Музей Барджелло','Флоренция','Италия'),(6,'Церковь Санто-Спирито','Флоренция','Италия'),(7,'Сикстинская капелла','Ватикан','Италия'),(8,'Галерея Боргезе','Рим','Италия'),(9,'Музей ван Гога','Амстердам','Нидерланды');
/*!40000 ALTER TABLE `storage_locations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `technique_of_execution`
--

DROP TABLE IF EXISTS `technique_of_execution`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `technique_of_execution` (
  `id_e_t` int NOT NULL AUTO_INCREMENT,
  `name_e_t` varchar(50) NOT NULL,
  PRIMARY KEY (`id_e_t`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `technique_of_execution`
--

LOCK TABLES `technique_of_execution` WRITE;
/*!40000 ALTER TABLE `technique_of_execution` DISABLE KEYS */;
INSERT INTO `technique_of_execution` VALUES (1,'Дерево'),(2,'Масло'),(3,'Мрамор'),(4,'Темпера'),(5,'Фреска'),(6,'Холст');
/*!40000 ALTER TABLE `technique_of_execution` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id_user` int NOT NULL AUTO_INCREMENT,
  `surname_user` varchar(50) NOT NULL,
  `name_user` varchar(50) NOT NULL,
  `login` varchar(30) NOT NULL,
  `password_user` varchar(30) NOT NULL,
  `name_role` varchar(50) NOT NULL,
  PRIMARY KEY (`id_user`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Шаронова','Клара','klara.aronova@outlook.com','447af1f3a','Администратор'),(2,'Подкользина','София','sofiya18@mail.ru','6be8f2f1f','Пользователь'),(3,'Набалкин','Семен','semen27@hotmail.com','a0c8738f5','Администратор'),(4,'Чупов','Михаил','mihail1975@yandex.ru','42442ad36','Пользователь'),(5,'Головаха','Мила','mila1969@outlook.com','5dc39ea07','Пользователь'),(6,'Абоимова','Тамара','tamara1976@gmail.com','d344d06ad','Пользователь'),(7,'Неелов','Николай','nikolay06011990@hotmail.com','6087cc026','Пользователь'),(8,'Якушева','Ирина','irina.yakusheva@mail.ru','0507465a6','Пользователь'),(9,'Килин','Максим','maksim69@rambler.ru','ef4a624ef','Пользователь'),(10,'Груздев','Афанасий','afanasiy.gruzdev@mail.ru','b22cb8b7b','Пользователь');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-11-23 16:13:21
