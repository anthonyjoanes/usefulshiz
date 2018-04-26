<Query Kind="SQL">
  <Connection>
    <ID>812fc83d-7638-4493-a4ce-5b037c7b8290</ID>
    <Persist>true</Persist>
    <Server>tcp:devtestidentitysql.database.windows.net,1433</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>nuuk@devtestidentitysql</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAA7hweDBJuV0ChIhyqdZCM/gAAAAACAAAAAAADZgAAwAAAABAAAACpElSN49dN2As60HinJ2xMAAAAAASAAACgAAAAEAAAAF25GfkBDP2RJMOD1tF4ieAgAAAA33wbMU6bZYL/Rt2tSA2g4RRcFxAK53jxLD3f+dRWYrUUAAAA2OFrD3V0f/sT/j5kDPjA1ziwLUg=</Password>
    <DbVersion>Azure</DbVersion>
    <Database>eosidentity</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

DECLARE
@ECATID INT;

USE eosidentity;

	--BEGIN TRAN

SELECT @ECATID = [Id] FROM [dbo].[Clients] where ClientId = 'ECAT'

INSERT INTO [dbo].[ClientRedirectUris] (Uri, Client_Id)
VALUES ('http://127.0.0.1:8383/index.html', @ECATID)

SELECT * FROM [dbo].[ClientRedirectUris] WHERE Id = @@IDENTITY;

	--ROLLBACK TRAN
