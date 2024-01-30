-- Jeddore_ISDP_DB_Script - January 2024
-- The purpose of this script is to update the default base DB as needed or for ease of work.
-- version 1.0
-- January 10, 2024
-- Nicholas Jeddore

use bullseyedb2024;

-- drop any table(s) and trigger(s) here at the start of script
drop table if exists passwordsalt;
drop trigger if exists afterTxnUpdate;
drop trigger if exists afterTxnInsert;

-- creating a table for storing password salts for each employee
CREATE TABLE `passwordsalt` (
  `employeeID` int NOT NULL PRIMARY KEY,
  `passwordSalt` varchar(64) NOT NULL,
  FOREIGN KEY(`employeeID`) REFERENCES employee(`employeeID`)
);

-- need to insert a record into this table for each employee in the initial DB
INSERT INTO `passwordsalt` (`employeeID`, `passwordSalt`) VALUES
(1, '9l2akfab5j8hv3m7o7svazhd6kq0alby'),
(2, 'y6usx3h104e9bn4qolqzva6scfp65yxq'),
(1000, 'shh67lragl9n37kvxswjhuv9p4rz5j94'),
(1001, 'r32662dvupf3tdfzj8oxmff6pb5nbz7e'),
(1002, 'ky1m9t25taibjibpmvkiv4l90u9jwvnj'),
(1003, 'x8h1u4kk0y7zlpsvlss8hz6ic3c5w0gb'),
(1004, '9ok0c8uooqri3z02i2mxxykzm454fhjm'),
(1005, 'sffxyivncup4n4gfpj71e3pgcrpwj0ur'),
(1006, 'akfow73fx8qe9sqxb60lku871o4qidbo'),
(1007, '3q89kd9l61wfw3ctqro0cmy8gnst8ao5'),
(1008, 'k017nra7206q3001fmvd893qv5q2ce0r'),
(1009, 'uhntlxfhly0o8us3479wck97sj6nxiii'),
(1010, 'fkxzkd44nst938qytcnshpxa6krdg3y0'),
(1012, 'dwbi6rtqq9p6uvvipwtv5qd6rucoc4ab'),
(1013, 'br114qsdyt4fzwj2lby4zw36ypuap6g4'),
(1014, 'f3xonswow2r580hgfv30gz698pelrn8j');

-- need to modify the password column of the employee table 
-- to hold a hashed string that is 64 chars long
alter table employee
modify column Password varchar(64);

-- also need to update the employee table with their hashed/encrypted passwords (SHA256)
update `employee`
set Password = '527a85f332c92053d32e497113c9b145aa29aaa426141766a375e40f97d0071b'
where employeeID = 1;

update `employee`
set Password = '3933537e5729e243d375a870617da44a210e654a949915999d5ca474863665c9'
where employeeID = 2;

update `employee`
set Password = '2e2fdbe5ac28dbee96a202a1671844e78574274ac393982a20aa5f4849e6f9d8'
where employeeID = 1000;

update `employee`
set Password = '58eae166c860a46963ce7a928e12f049b55d60825815e228b022be40575ae9cb'
where employeeID = 1001;

update `employee`
set Password = '3f7ad054644005887b5b0486e4d2b1235bb2669aa97867fec2ebdb0283774efb'
where employeeID = 1002;

update `employee`
set Password = 'be6f8104c1e453aa50cca6ec2ef983ebf54437733f844638678c1f5177d21083'
where employeeID = 1003;

update `employee`
set Password = '1a96992d1fb12c7bf74febb76ebbb37f1c1a73b600a3ed9f934a75f5943f91d8'
where employeeID = 1004;

update `employee`
set Password = '59198d2799668662c8211b238b982315b9750b9cb0ae6ebaffe24c48dc85e81c'
where employeeID = 1005;

update `employee`
set Password = '3721df502cd69e50edfef071929430c6a0a511851d09b4572b092d845439067b'
where employeeID = 1006;

update `employee`
set Password = 'b6b99fd88830015de1432ea790d5370b76cf5aeab1f5c8b982f334cfc713131d'
where employeeID = 1007;

update `employee`
set Password = '7fb32419a52500593cddd2a60df7b4efa084118c6f681ab7eb0450584c2607b4'
where employeeID = 1008;

update `employee`
set Password = '75e617a7c81b01c9d1f00e4daa1142278a0a4ad0f517a6dabe771152bca19536'
where employeeID = 1009;

update `employee`
set Password = '271e4698a88368773fbb5154ed0202a2f4448754312ccd98164f1dd82cb03aa3'
where employeeID = 1010;

update `employee`
set Password = '784c443d9a52d9d673c44f2061e2fc3348903bcfdecd5dbeb6313d1b5b23ff0b'
where employeeID = 1012;

update `employee`
set Password = 'f4eb2a1acad30b95d58426e961cb0f95c8deec546f5bb0c0bad3bbefdfb09f1b'
where employeeID = 1013;

update `employee`
set Password = '4aea5d7f00ada32db2c3ac7415fff5415ff4ebb52fd0b841ab72892aef48346c'
where employeeID = 1014;

-- alter employee table - adding the loginAttempts column
-- default starting number for login attempts is 3
-- using tinyint since this should only ever be a very small int
alter table `employee`
add column loginAttempts tinyint NOT NULL Default 3;

-- alter employee table again - adding the madeFirstLogin column
-- to track if each employee made their first login yet or not, and
-- prompting them to changing the default password if not
-- using tinyint here too
alter table `employee`
add column madeFirstLogin tinyint(1) NOT NULL Default 0; 

-- alter user_permission table - adding the hasPermission column
-- to track if each employee has permission for that respective permission
-- using tinyint here too
alter table `user_permission`
add column hasPermission tinyint(1) NOT NULL Default 0;

-- alter item table - adding the Image file location
-- to track the file location for an item's image
alter table `item`
add column imageFileLocation varchar(200) DEFAULT NULL;

-- alter user_permission table - so that all default users of the system have READUSER access
-- the admin user (number 1) already has this but the others do not
-- also are giving EDITITEM access to the warehouse manager, cpatstone
INSERT INTO `user_permission` (`employeeID`, `permissionID`,  `hasPermission`) VALUES
(2, 'READUSER', 1),
(1000, 'READUSER', 1),
(1001, 'READUSER', 1),
(1002, 'READUSER', 1),
(1003, 'READUSER', 1),
(1004, 'READUSER', 1),
(1005, 'READUSER', 1),
(1006, 'READUSER', 1),
(1007, 'READUSER', 1),
(1008, 'READUSER', 1),
(1009, 'READUSER', 1),
(1010, 'READUSER', 1),
(1012, 'READUSER', 1),
(1013, 'READUSER', 1),
(1014, 'READUSER', 1),
(1003, 'EDITITEM', 1);

-- for all records currently in the user_permission table, set hasPermission to 1
-- since all admin records in this table right now are all permissions that the admin user should have
update user_permission
set hasPermission = 1
where hasPermission = 0;

-- now need to insert permissions in user_permission for users besides the admin
-- NOTE: don't need READUSER since it's already been done above
INSERT INTO `user_permission` (`employeeID`, `permissionID`,  `hasPermission`) VALUES
(2, 'ADDUSER', 0),
(2, 'EDITUSER', 0),
(2, 'DELETEUSER', 0),
(2, 'SETPERMISSION', 0),
(2, 'MOVEINVENTORY', 0),
(2, 'CREATESTOREORDER', 0),
(2, 'RECEIVESTOREORDER', 0),
(2, 'PREPARESTOREORDER', 0),
(2, 'FULFILSTOREORDER', 0),
(2, 'ADDITEMTOBACKORDER', 0),
(2, 'CREATEBACKORDER', 0),
(2, 'EDITSITE', 0),
(2, 'ADDSITE', 0),
(2, 'VIEWORDERS', 0),
(2, 'DELETELOCATION', 0),
(2, 'EDITINVENTORY', 0),
(2, 'EDITITEM', 0),
(2, 'DELIVERY', 0),
(2, 'ACCEPTSTOREORDER', 0),
(2, 'MODIFYRECORD', 0),
(2, 'CREATELOSS', 0),
(2, 'PROCESSRETURN', 0),
(2, 'ADDNEWPRODUCT', 0),
(2, 'EDITPRODUCT', 0),
(2, 'CREATESUPPLIERORDER', 0),
(2, 'CREATEREPORT', 0),
(1000, 'ADDUSER', 0),
(1000, 'EDITUSER', 0),
(1000, 'DELETEUSER', 0),
(1000, 'SETPERMISSION', 0),
(1000, 'MOVEINVENTORY', 0),
(1000, 'CREATESTOREORDER', 0),
(1000, 'RECEIVESTOREORDER', 0),
(1000, 'PREPARESTOREORDER', 0),
(1000, 'FULFILSTOREORDER', 0),
(1000, 'ADDITEMTOBACKORDER', 0),
(1000, 'CREATEBACKORDER', 0),
(1000, 'EDITSITE', 0),
(1000, 'ADDSITE', 0),
(1000, 'VIEWORDERS', 0),
(1000, 'DELETELOCATION', 0),
(1000, 'EDITINVENTORY', 0),
(1000, 'EDITITEM', 0),
(1000, 'DELIVERY', 0),
(1000, 'ACCEPTSTOREORDER', 0),
(1000, 'MODIFYRECORD', 0),
(1000, 'CREATELOSS', 0),
(1000, 'PROCESSRETURN', 0),
(1000, 'ADDNEWPRODUCT', 0),
(1000, 'EDITPRODUCT', 0),
(1000, 'CREATESUPPLIERORDER', 0),
(1000, 'CREATEREPORT', 0),
(1001, 'ADDUSER', 0),
(1001, 'EDITUSER', 0),
(1001, 'DELETEUSER', 0),
(1001, 'SETPERMISSION', 0),
(1001, 'MOVEINVENTORY', 0),
(1001, 'CREATESTOREORDER', 0),
(1001, 'RECEIVESTOREORDER', 0),
(1001, 'PREPARESTOREORDER', 0),
(1001, 'FULFILSTOREORDER', 0),
(1001, 'ADDITEMTOBACKORDER', 0),
(1001, 'CREATEBACKORDER', 0),
(1001, 'EDITSITE', 0),
(1001, 'ADDSITE', 0),
(1001, 'VIEWORDERS', 0),
(1001, 'DELETELOCATION', 0),
(1001, 'EDITINVENTORY', 0),
(1001, 'EDITITEM', 0),
(1001, 'DELIVERY', 0),
(1001, 'ACCEPTSTOREORDER', 0),
(1001, 'MODIFYRECORD', 0),
(1001, 'CREATELOSS', 0),
(1001, 'PROCESSRETURN', 0),
(1001, 'ADDNEWPRODUCT', 0),
(1001, 'EDITPRODUCT', 0),
(1001, 'CREATESUPPLIERORDER', 0),
(1001, 'CREATEREPORT', 0),
(1002, 'ADDUSER', 0),
(1002, 'EDITUSER', 0),
(1002, 'DELETEUSER', 0),
(1002, 'SETPERMISSION', 0),
(1002, 'MOVEINVENTORY', 0),
(1002, 'CREATESTOREORDER', 0),
(1002, 'RECEIVESTOREORDER', 0),
(1002, 'PREPARESTOREORDER', 0),
(1002, 'FULFILSTOREORDER', 0),
(1002, 'ADDITEMTOBACKORDER', 0),
(1002, 'CREATEBACKORDER', 0),
(1002, 'EDITSITE', 0),
(1002, 'ADDSITE', 0),
(1002, 'VIEWORDERS', 0),
(1002, 'DELETELOCATION', 0),
(1002, 'EDITINVENTORY', 0),
(1002, 'EDITITEM', 0),
(1002, 'DELIVERY', 0),
(1002, 'ACCEPTSTOREORDER', 0),
(1002, 'MODIFYRECORD', 0),
(1002, 'CREATELOSS', 0),
(1002, 'PROCESSRETURN', 0),
(1002, 'ADDNEWPRODUCT', 0),
(1002, 'EDITPRODUCT', 0),
(1002, 'CREATESUPPLIERORDER', 0),
(1002, 'CREATEREPORT', 0),
(1003, 'ADDUSER', 0),
(1003, 'EDITUSER', 0),
(1003, 'DELETEUSER', 0),
(1003, 'SETPERMISSION', 0),
(1003, 'MOVEINVENTORY', 0),
(1003, 'CREATESTOREORDER', 0),
(1003, 'RECEIVESTOREORDER', 0),
(1003, 'PREPARESTOREORDER', 0),
(1003, 'FULFILSTOREORDER', 0),
(1003, 'ADDITEMTOBACKORDER', 0),
(1003, 'CREATEBACKORDER', 0),
(1003, 'EDITSITE', 0),
(1003, 'ADDSITE', 0),
(1003, 'VIEWORDERS', 0),
(1003, 'DELETELOCATION', 0),
(1003, 'EDITINVENTORY', 0),
(1003, 'DELIVERY', 0),
(1003, 'ACCEPTSTOREORDER', 0),
(1003, 'MODIFYRECORD', 0),
(1003, 'CREATELOSS', 0),
(1003, 'PROCESSRETURN', 0),
(1003, 'ADDNEWPRODUCT', 0),
(1003, 'EDITPRODUCT', 0),
(1003, 'CREATESUPPLIERORDER', 0),
(1003, 'CREATEREPORT', 0),
(1004, 'ADDUSER', 0),
(1004, 'EDITUSER', 0),
(1004, 'DELETEUSER', 0),
(1004, 'SETPERMISSION', 0),
(1004, 'MOVEINVENTORY', 0),
(1004, 'CREATESTOREORDER', 0),
(1004, 'RECEIVESTOREORDER', 0),
(1004, 'PREPARESTOREORDER', 0),
(1004, 'FULFILSTOREORDER', 0),
(1004, 'ADDITEMTOBACKORDER', 0),
(1004, 'CREATEBACKORDER', 0),
(1004, 'EDITSITE', 0),
(1004, 'ADDSITE', 0),
(1004, 'VIEWORDERS', 0),
(1004, 'DELETELOCATION', 0),
(1004, 'EDITINVENTORY', 0),
(1004, 'EDITITEM', 0),
(1004, 'DELIVERY', 0),
(1004, 'ACCEPTSTOREORDER', 0),
(1004, 'MODIFYRECORD', 0),
(1004, 'CREATELOSS', 0),
(1004, 'PROCESSRETURN', 0),
(1004, 'ADDNEWPRODUCT', 0),
(1004, 'EDITPRODUCT', 0),
(1004, 'CREATESUPPLIERORDER', 0),
(1004, 'CREATEREPORT', 0),
(1005, 'ADDUSER', 0),
(1005, 'EDITUSER', 0),
(1005, 'DELETEUSER', 0),
(1005, 'SETPERMISSION', 0),
(1005, 'MOVEINVENTORY', 0),
(1005, 'CREATESTOREORDER', 0),
(1005, 'RECEIVESTOREORDER', 0),
(1005, 'PREPARESTOREORDER', 0),
(1005, 'FULFILSTOREORDER', 0),
(1005, 'ADDITEMTOBACKORDER', 0),
(1005, 'CREATEBACKORDER', 0),
(1005, 'EDITSITE', 0),
(1005, 'ADDSITE', 0),
(1005, 'VIEWORDERS', 0),
(1005, 'DELETELOCATION', 0),
(1005, 'EDITINVENTORY', 0),
(1005, 'EDITITEM', 0),
(1005, 'DELIVERY', 0),
(1005, 'ACCEPTSTOREORDER', 0),
(1005, 'MODIFYRECORD', 0),
(1005, 'CREATELOSS', 0),
(1005, 'PROCESSRETURN', 0),
(1005, 'ADDNEWPRODUCT', 0),
(1005, 'EDITPRODUCT', 0),
(1005, 'CREATESUPPLIERORDER', 0),
(1005, 'CREATEREPORT', 0),
(1006, 'ADDUSER', 0),
(1006, 'EDITUSER', 0),
(1006, 'DELETEUSER', 0),
(1006, 'SETPERMISSION', 0),
(1006, 'MOVEINVENTORY', 0),
(1006, 'CREATESTOREORDER', 0),
(1006, 'RECEIVESTOREORDER', 0),
(1006, 'PREPARESTOREORDER', 0),
(1006, 'FULFILSTOREORDER', 0),
(1006, 'ADDITEMTOBACKORDER', 0),
(1006, 'CREATEBACKORDER', 0),
(1006, 'EDITSITE', 0),
(1006, 'ADDSITE', 0),
(1006, 'VIEWORDERS', 0),
(1006, 'DELETELOCATION', 0),
(1006, 'EDITINVENTORY', 0),
(1006, 'EDITITEM', 0),
(1006, 'DELIVERY', 0),
(1006, 'ACCEPTSTOREORDER', 0),
(1006, 'MODIFYRECORD', 0),
(1006, 'CREATELOSS', 0),
(1006, 'PROCESSRETURN', 0),
(1006, 'ADDNEWPRODUCT', 0),
(1006, 'EDITPRODUCT', 0),
(1006, 'CREATESUPPLIERORDER', 0),
(1006, 'CREATEREPORT', 0),
(1007, 'ADDUSER', 0),
(1007, 'EDITUSER', 0),
(1007, 'DELETEUSER', 0),
(1007, 'SETPERMISSION', 0),
(1007, 'MOVEINVENTORY', 0),
(1007, 'CREATESTOREORDER', 0),
(1007, 'RECEIVESTOREORDER', 0),
(1007, 'PREPARESTOREORDER', 0),
(1007, 'FULFILSTOREORDER', 0),
(1007, 'ADDITEMTOBACKORDER', 0),
(1007, 'CREATEBACKORDER', 0),
(1007, 'EDITSITE', 0),
(1007, 'ADDSITE', 0),
(1007, 'VIEWORDERS', 0),
(1007, 'DELETELOCATION', 0),
(1007, 'EDITINVENTORY', 0),
(1007, 'EDITITEM', 0),
(1007, 'DELIVERY', 0),
(1007, 'ACCEPTSTOREORDER', 0),
(1007, 'MODIFYRECORD', 0),
(1007, 'CREATELOSS', 0),
(1007, 'PROCESSRETURN', 0),
(1007, 'ADDNEWPRODUCT', 0),
(1007, 'EDITPRODUCT', 0),
(1007, 'CREATESUPPLIERORDER', 0),
(1007, 'CREATEREPORT', 0),
(1008, 'ADDUSER', 0),
(1008, 'EDITUSER', 0),
(1008, 'DELETEUSER', 0),
(1008, 'SETPERMISSION', 0),
(1008, 'MOVEINVENTORY', 0),
(1008, 'CREATESTOREORDER', 0),
(1008, 'RECEIVESTOREORDER', 0),
(1008, 'PREPARESTOREORDER', 0),
(1008, 'FULFILSTOREORDER', 0),
(1008, 'ADDITEMTOBACKORDER', 0),
(1008, 'CREATEBACKORDER', 0),
(1008, 'EDITSITE', 0),
(1008, 'ADDSITE', 0),
(1008, 'VIEWORDERS', 0),
(1008, 'DELETELOCATION', 0),
(1008, 'EDITINVENTORY', 0),
(1008, 'EDITITEM', 0),
(1008, 'DELIVERY', 0),
(1008, 'ACCEPTSTOREORDER', 0),
(1008, 'MODIFYRECORD', 0),
(1008, 'CREATELOSS', 0),
(1008, 'PROCESSRETURN', 0),
(1008, 'ADDNEWPRODUCT', 0),
(1008, 'EDITPRODUCT', 0),
(1008, 'CREATESUPPLIERORDER', 0),
(1008, 'CREATEREPORT', 0),
(1009, 'ADDUSER', 0),
(1009, 'EDITUSER', 0),
(1009, 'DELETEUSER', 0),
(1009, 'SETPERMISSION', 0),
(1009, 'MOVEINVENTORY', 0),
(1009, 'CREATESTOREORDER', 0),
(1009, 'RECEIVESTOREORDER', 0),
(1009, 'PREPARESTOREORDER', 0),
(1009, 'FULFILSTOREORDER', 0),
(1009, 'ADDITEMTOBACKORDER', 0),
(1009, 'CREATEBACKORDER', 0),
(1009, 'EDITSITE', 0),
(1009, 'ADDSITE', 0),
(1009, 'VIEWORDERS', 0),
(1009, 'DELETELOCATION', 0),
(1009, 'EDITINVENTORY', 0),
(1009, 'EDITITEM', 0),
(1009, 'DELIVERY', 0),
(1009, 'ACCEPTSTOREORDER', 0),
(1009, 'MODIFYRECORD', 0),
(1009, 'CREATELOSS', 0),
(1009, 'PROCESSRETURN', 0),
(1009, 'ADDNEWPRODUCT', 0),
(1009, 'EDITPRODUCT', 0),
(1009, 'CREATESUPPLIERORDER', 0),
(1009, 'CREATEREPORT', 0),
(1010, 'ADDUSER', 0),
(1010, 'EDITUSER', 0),
(1010, 'DELETEUSER', 0),
(1010, 'SETPERMISSION', 0),
(1010, 'MOVEINVENTORY', 0),
(1010, 'CREATESTOREORDER', 0),
(1010, 'RECEIVESTOREORDER', 0),
(1010, 'PREPARESTOREORDER', 0),
(1010, 'FULFILSTOREORDER', 0),
(1010, 'ADDITEMTOBACKORDER', 0),
(1010, 'CREATEBACKORDER', 0),
(1010, 'EDITSITE', 0),
(1010, 'ADDSITE', 0),
(1010, 'VIEWORDERS', 0),
(1010, 'DELETELOCATION', 0),
(1010, 'EDITINVENTORY', 0),
(1010, 'EDITITEM', 0),
(1010, 'DELIVERY', 0),
(1010, 'ACCEPTSTOREORDER', 0),
(1010, 'MODIFYRECORD', 0),
(1010, 'CREATELOSS', 0),
(1010, 'PROCESSRETURN', 0),
(1010, 'ADDNEWPRODUCT', 0),
(1010, 'EDITPRODUCT', 0),
(1010, 'CREATESUPPLIERORDER', 0),
(1010, 'CREATEREPORT', 0),
(1012, 'ADDUSER', 0),
(1012, 'EDITUSER', 0),
(1012, 'DELETEUSER', 0),
(1012, 'SETPERMISSION', 0),
(1012, 'MOVEINVENTORY', 0),
(1012, 'CREATESTOREORDER', 0),
(1012, 'RECEIVESTOREORDER', 0),
(1012, 'PREPARESTOREORDER', 0),
(1012, 'FULFILSTOREORDER', 0),
(1012, 'ADDITEMTOBACKORDER', 0),
(1012, 'CREATEBACKORDER', 0),
(1012, 'EDITSITE', 0),
(1012, 'ADDSITE', 0),
(1012, 'VIEWORDERS', 0),
(1012, 'DELETELOCATION', 0),
(1012, 'EDITINVENTORY', 0),
(1012, 'EDITITEM', 0),
(1012, 'DELIVERY', 0),
(1012, 'ACCEPTSTOREORDER', 0),
(1012, 'MODIFYRECORD', 0),
(1012, 'CREATELOSS', 0),
(1012, 'PROCESSRETURN', 0),
(1012, 'ADDNEWPRODUCT', 0),
(1012, 'EDITPRODUCT', 0),
(1012, 'CREATESUPPLIERORDER', 0),
(1012, 'CREATEREPORT', 0),
(1013, 'ADDUSER', 0),
(1013, 'EDITUSER', 0),
(1013, 'DELETEUSER', 0),
(1013, 'SETPERMISSION', 0),
(1013, 'MOVEINVENTORY', 0),
(1013, 'CREATESTOREORDER', 0),
(1013, 'RECEIVESTOREORDER', 0),
(1013, 'PREPARESTOREORDER', 0),
(1013, 'FULFILSTOREORDER', 0),
(1013, 'ADDITEMTOBACKORDER', 0),
(1013, 'CREATEBACKORDER', 0),
(1013, 'EDITSITE', 0),
(1013, 'ADDSITE', 0),
(1013, 'VIEWORDERS', 0),
(1013, 'DELETELOCATION', 0),
(1013, 'EDITINVENTORY', 0),
(1013, 'EDITITEM', 0),
(1013, 'DELIVERY', 0),
(1013, 'ACCEPTSTOREORDER', 0),
(1013, 'MODIFYRECORD', 0),
(1013, 'CREATELOSS', 0),
(1013, 'PROCESSRETURN', 0),
(1013, 'ADDNEWPRODUCT', 0),
(1013, 'EDITPRODUCT', 0),
(1013, 'CREATESUPPLIERORDER', 0),
(1013, 'CREATEREPORT', 0),
(1014, 'ADDUSER', 0),
(1014, 'EDITUSER', 0),
(1014, 'DELETEUSER', 0),
(1014, 'SETPERMISSION', 0),
(1014, 'MOVEINVENTORY', 0),
(1014, 'CREATESTOREORDER', 0),
(1014, 'RECEIVESTOREORDER', 0),
(1014, 'PREPARESTOREORDER', 0),
(1014, 'FULFILSTOREORDER', 0),
(1014, 'ADDITEMTOBACKORDER', 0),
(1014, 'CREATEBACKORDER', 0),
(1014, 'EDITSITE', 0),
(1014, 'ADDSITE', 0),
(1014, 'VIEWORDERS', 0),
(1014, 'DELETELOCATION', 0),
(1014, 'EDITINVENTORY', 0),
(1014, 'EDITITEM', 0),
(1014, 'DELIVERY', 0),
(1014, 'ACCEPTSTOREORDER', 0),
(1014, 'MODIFYRECORD', 0),
(1014, 'CREATELOSS', 0),
(1014, 'PROCESSRETURN', 0),
(1014, 'ADDNEWPRODUCT', 0),
(1014, 'EDITPRODUCT', 0),
(1014, 'CREATESUPPLIERORDER', 0),
(1014, 'CREATEREPORT', 0);

-- Trigger #1 - for transaction audit activity
-- after UPDATEs on the txn table
DELIMITER $$

CREATE TRIGGER afterTxnUpdate
AFTER UPDATE
ON txn FOR EACH ROW
BEGIN

	-- if the new status doesn't equal the old status and 
	-- if the new status is either complete or delivered
	-- inserting the siteIDTo (destination site) then
    IF OLD.status <> new.status and (new.status = "Complete" or new.status = "Delivered") THEN
        INSERT INTO txnaudit(txnID, txnType, status, txnDate, SiteID, deliveryID, notes)
        VALUES(new.txnID, new.txnType, new.status, NOW(), new.SiteIDTo, new.deliveryID, new.notes);
	
	-- else if - the new status doesn't equal the old status and 
	-- if the new status is NOT complete or delivered
	-- inserting the siteIDFrom (starting site) then
    ELSEIF OLD.status <> new.status and (new.status <> "Complete" or new.status <> "Delivered") THEN
        INSERT INTO txnaudit(txnID, txnType, status, txnDate, SiteID, deliveryID, notes)
        VALUES(new.txnID, new.txnType, new.status, NOW(), new.SiteIDFrom, new.deliveryID, new.notes);
	END IF;
	
END$$

DELIMITER ;

-- Trigger #2 - for transaction audit activity
-- after INSERTs on the txn table
DELIMITER $$

CREATE TRIGGER afterTxnInsert
AFTER INSERT
ON txn FOR EACH ROW
BEGIN

-- insert into the txnaudit table
INSERT INTO txnaudit(txnID, txnType, status, txnDate, SiteID, deliveryID, notes)
VALUES(new.txnID, new.txnType, new.status, NOW(), new.SiteIDFrom, new.deliveryID, new.notes);
	
END$$

DELIMITER ;