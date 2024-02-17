CREATE TABLE communication
(outTelNo char(10), callDate varchar(20), startTime TIME, endTime TIME)
INSERT INTO communication VALUES 
('0928', '2023-11-01', '13:00:05', '13:31:34'),
('0920', '2023-11-04', '15:00:33', '15:54:55'),
('0928', '2023-12-01', '05:08:02', '05:53:03'),
('0971', '2023-12-11', '02:11:28', '02:13:35'),
('0938', '2023-12-29', '06:41:22', '06:48:29'),
('0923', '2023-01-06', '13:18:42', '13:51:23'),
('0921', '2023-01-14', '12:18:28', '12:28:30'),
('0928', '2023-01-29', '07:46:21', '07:48:25'),
('0925', '2023-02-16', '11:13:43', '11:54:23'),
('0921', '2023-02-24', '10:10:20', '10:20:00'),
('0978', '2023-02-09', '01:03:24', '01:45:25'),
('0935', '2023-03-08', '03:08:02', '03:51:03'),
('0933', '2023-03-17', '02:19:28', '02:38:35'),
('0938', '2023-03-24', '09:44:22', '09:48:29')

CREATE TABLE users
(telNo char(10), contractID char(20), contractStartDate char(30), cutBillDate char(8))
INSERT INTO users VALUES
('0930', 'A', '2023-11-01', '05'),
('0933', 'B', '2022-08-16', '20')

CREATE TABLE contracts
(contractID char(20), contractName varchar(50), TelcomRates REAL, freeCallSec int)
INSERT INTO contracts VALUES
('A', 'allYouCanEat', 0.1, 600),
('B', 'normal', 0.3, 60)

CREATE TABLE totalUsers
(customerID INT PRIMARY KEY, telNo char(10), customerName varchar(50), contractID char(20), contractStartDate char(30), cutBillDate char(8))
INSERT INTO totalUsers (customerID, telNo, customerName, contractID, contractStartDate, cutBillDate) VALUES
(1, '0930', '王小明', 'A', '2023-11-05', '5號'),
(2, '0933', '周原淳', 'B', '2022-08-20', '20號'),
(3, '0928', '謝欣裕', 'B', '2021-11-30', '30號'),
(4, '0921', '林韻如', 'B', '2021-06-15', '15號'),
(5, '0978', '高雅琪', 'A', '2023-01-25', '25號')
SELECT * FROM totalUsers

CREATE TABLE Users_Info
(myName char(50), myID char(20), myBirth char(20), myAddress char(100), myTel char(10), myJob char(20))
INSERT INTO Users_Info VALUES
('王小明', '123456789', '2001-08-03', 'Taipei', '0930', 'Student'),
('周原淳', '987654321', '2005-01-25', 'Tainan', '0933', 'Teacher')