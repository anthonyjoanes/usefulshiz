<Query Kind="SQL">
  <Connection>
    <ID>812fc83d-7638-4493-a4ce-5b037c7b8290</ID>
    <Persist>true</Persist>
    <Server>tcp:devtestidentitysql.database.windows.net,1433</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>nuuk@devtestidentitysql</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAA7hweDBJuV0ChIhyqdZCM/gAAAAACAAAAAAADZgAAwAAAABAAAACpElSN49dN2As60HinJ2xMAAAAAASAAACgAAAAEAAAAF25GfkBDP2RJMOD1tF4ieAgAAAA33wbMU6bZYL/Rt2tSA2g4RRcFxAK53jxLD3f+dRWYrUUAAAA2OFrD3V0f/sT/j5kDPjA1ziwLUg=</Password>
    <DbVersion>Azure</DbVersion>
    <Database>master</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

USE Master
GO
EXEC sp_who2
GO

USE Master
GO
SELECT * 
FROM sys.dm_exec_requests
WHERE blocking_session_id <> 0;
GO

USE Master
GO
SELECT session_id, wait_duration_ms, wait_type, blocking_session_id 
FROM sys.dm_os_waiting_tasks 
WHERE blocking_session_id <> 0
GO

