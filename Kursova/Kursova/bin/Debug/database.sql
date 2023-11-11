-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 11, 2023 at 03:47 PM
-- Server version: 10.4.25-MariaDB
-- PHP Version: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `milk`
--

-- --------------------------------------------------------

--
-- Table structure for table `client`
--

CREATE TABLE `client` (
  `client_id` int(11) NOT NULL,
  `SURNAME` varchar(60) NOT NULL,
  `NAME` varchar(60) NOT NULL,
  `ADDRESS` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `client`
--

INSERT INTO `client` (`client_id`, `SURNAME`, `NAME`, `ADDRESS`) VALUES
(1, 'Volodymer', 'Komzol', 'Zakrevskogo');

-- --------------------------------------------------------

--
-- Table structure for table `commision`
--

CREATE TABLE `commision` (
  `COMMISION_ID` int(11) NOT NULL,
  `COMMISION_DATE` date NOT NULL,
  `SUPPLYER_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `product`
--

CREATE TABLE `product` (
  `PRODUCT_ID` int(11) NOT NULL,
  `PRODUCT_NAME` varchar(15) NOT NULL,
  `PRICE` float(10,0) NOT NULL,
  `coef_sell` int(100) NOT NULL,
  `coef_buy` int(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`PRODUCT_ID`, `PRODUCT_NAME`, `PRICE`, `coef_sell`, `coef_buy`) VALUES
(1, 'milk', 10, 36, 32),
(2, 'milkshake', 11, 39, 14),
(3, 'cheese', 7, 23, 54),
(4, 'yogurt', 9, 30, 30),
(5, 'cake', 17, 62, 32),
(6, 'cottage cheese', 8, 19, 14);

-- --------------------------------------------------------

--
-- Table structure for table `product_in_comission`
--

CREATE TABLE `product_in_comission` (
  `PRODUCT_ID` int(11) NOT NULL,
  `COMMISION_ID` int(11) NOT NULL,
  `NUMBER` int(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `product_in_storage`
--

CREATE TABLE `product_in_storage` (
  `PRODUCT_ID` int(11) NOT NULL,
  `STORAGE_ID` int(11) NOT NULL,
  `NUMBER` int(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `product_in_supplying`
--

CREATE TABLE `product_in_supplying` (
  `SUPPLY_ID` int(11) NOT NULL,
  `PRODUCT_ID` int(11) NOT NULL,
  `NUMBER` int(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `storage`
--

CREATE TABLE `storage` (
  `STORAGE_ID` int(11) NOT NULL,
  `STORAGE_NAME` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `supply`
--

CREATE TABLE `supply` (
  `SUPPLY_ID` int(11) NOT NULL,
  `SUPPLY_DATE` date NOT NULL,
  `SUPPLYER_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `supplyer`
--

CREATE TABLE `supplyer` (
  `SUPPLYER_ID` int(11) NOT NULL,
  `COMPANY_NAME` varchar(60) NOT NULL,
  `ADDRESS` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `client`
--
ALTER TABLE `client`
  ADD PRIMARY KEY (`client_id`);

--
-- Indexes for table `commision`
--
ALTER TABLE `commision`
  ADD PRIMARY KEY (`COMMISION_ID`),
  ADD KEY `SUPPLYER_ID` (`SUPPLYER_ID`);

--
-- Indexes for table `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`PRODUCT_ID`);

--
-- Indexes for table `product_in_comission`
--
ALTER TABLE `product_in_comission`
  ADD UNIQUE KEY `PRODUCT_ID` (`PRODUCT_ID`),
  ADD UNIQUE KEY `COMMISION_ID` (`COMMISION_ID`);

--
-- Indexes for table `product_in_storage`
--
ALTER TABLE `product_in_storage`
  ADD UNIQUE KEY `PRODUCT_ID` (`PRODUCT_ID`),
  ADD UNIQUE KEY `STORAGE_ID` (`STORAGE_ID`);

--
-- Indexes for table `product_in_supplying`
--
ALTER TABLE `product_in_supplying`
  ADD UNIQUE KEY `SUPPLY_ID` (`SUPPLY_ID`),
  ADD UNIQUE KEY `PRODUCT_ID` (`PRODUCT_ID`);

--
-- Indexes for table `storage`
--
ALTER TABLE `storage`
  ADD PRIMARY KEY (`STORAGE_ID`);

--
-- Indexes for table `supply`
--
ALTER TABLE `supply`
  ADD PRIMARY KEY (`SUPPLY_ID`),
  ADD UNIQUE KEY `SUPPLYER_ID` (`SUPPLYER_ID`);

--
-- Indexes for table `supplyer`
--
ALTER TABLE `supplyer`
  ADD PRIMARY KEY (`SUPPLYER_ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `client`
--
ALTER TABLE `client`
  MODIFY `client_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `commision`
--
ALTER TABLE `commision`
  MODIFY `COMMISION_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `storage`
--
ALTER TABLE `storage`
  MODIFY `STORAGE_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `supply`
--
ALTER TABLE `supply`
  MODIFY `SUPPLY_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `supplyer`
--
ALTER TABLE `supplyer`
  MODIFY `SUPPLYER_ID` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
