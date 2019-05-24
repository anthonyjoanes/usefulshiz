<Query Kind="SQL">
  <Connection>
    <ID>812fc83d-7638-4493-a4ce-5b037c7b8290</ID>
    <Persist>true</Persist>
    <Server>tcp:devtestidentitysql.database.windows.net,1433</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>nuuk@devtestidentitysql</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAc8q1p3LC/UmEd/FLWt9CvgAAAAACAAAAAAADZgAAwAAAABAAAADi6mr098Vf7DiNs83Il9CqAAAAAASAAACgAAAAEAAAAEDYhMUrL0ce1ENNutEI7R0gAAAA4P3y0CufA6p5hkbZ3zhfQIBRCP9Y0yrYuqUl5rSfIYIUAAAAdu/9Gx3Q6+6kdZzsTZBf4j9vlSo=</Password>
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
VALUES ('http://localhost:8383/index.html', @ECATID)

SELECT * FROM [dbo].[ClientRedirectUris] WHERE Id = @@IDENTITY;

	--ROLLBACK TRAN