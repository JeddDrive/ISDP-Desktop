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
add column madeFirstLogin tinyint NOT NULL Default 0; 

-- alter user_permission table - so that all default users of the system have READUSER access
-- the admin user (number 1) already has this but the others do not
INSERT INTO `user_permission` (`employeeID`, `permissionID`) VALUES
(2, 'READUSER'),
(1000, 'READUSER'),
(1001, 'READUSER'),
(1002, 'READUSER'),
(1003, 'READUSER'),
(1004, 'READUSER'),
(1005, 'READUSER'),
(1006, 'READUSER'),
(1007, 'READUSER'),
(1008, 'READUSER'),
(1009, 'READUSER'),
(1010, 'READUSER'),
(1012, 'READUSER'),
(1013, 'READUSER'),
(1014, 'READUSER');

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
        VALUES(new.txnID, new.txnType, new.status, new.createdDate, new.SiteIDTo, new.deliveryID, new.notes);
	
	-- else if - the new status doesn't equal the old status and 
	-- if the new status is NOT complete or delivered
	-- inserting the siteIDFrom (starting site) then
    ELSEIF OLD.status <> new.status and (new.status <> "Complete" or new.status <> "Delivered") THEN
        INSERT INTO txnaudit(txnID, txnType, status, txnDate, SiteID, deliveryID, notes)
        VALUES(new.txnID, new.txnType, new.status, new.createdDate, new.SiteIDFrom, new.deliveryID, new.notes);
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
VALUES(new.txnID, new.txnType, new.status, new.createdDate, new.SiteIDFrom, new.deliveryID, new.notes);
	
END$$

DELIMITER ;