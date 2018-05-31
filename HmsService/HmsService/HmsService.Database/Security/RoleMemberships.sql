EXECUTE sp_addrolemember @rolename = N'db_owner', @membername = N'devSkyplus';


GO
EXECUTE sp_addrolemember @rolename = N'db_owner', @membername = N'skyup';


GO
EXECUTE sp_addrolemember @rolename = N'db_accessadmin', @membername = N'skyup';


GO
EXECUTE sp_addrolemember @rolename = N'db_securityadmin', @membername = N'skyup';


GO
EXECUTE sp_addrolemember @rolename = N'db_ddladmin', @membername = N'skyup';


GO
EXECUTE sp_addrolemember @rolename = N'db_backupoperator', @membername = N'skyup';


GO
EXECUTE sp_addrolemember @rolename = N'db_datareader', @membername = N'skyup';


GO
EXECUTE sp_addrolemember @rolename = N'db_datawriter', @membername = N'skyup';

