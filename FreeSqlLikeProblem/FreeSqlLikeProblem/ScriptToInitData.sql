CREATE TABLE IF NOT EXISTS `tuser`  (
  `Id` int(11) NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Password` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci;

replace into tuser(`Id`, `Name`, `Password`) values(1, '姓名1', 'mima1');
replace into tuser(`Id`, `Name`, `Password`) values(2, '姓名2', 'mima2');
replace into tuser(`Id`, `Name`, `Password`) values(3, '姓名3', 'mima3');