<Query Kind="Program">
  <Connection>
    <ID>52d61495-45ad-417f-91e4-c1afa6747da8</ID>
    <Persist>true</Persist>
    <Server>tcp:devcieosadvisorsql.database.windows.net,1433</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>nuuk@devcieosadvisorsql</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAbzAni3YEa0i9265e6dh4hgAAAAACAAAAAAADZgAAwAAAABAAAAC++/oWHCcLO5mfDcLGaq74AAAAAASAAACgAAAAEAAAAE9tNm2sb3q0ox05AzxLnwYgAAAAqjcMne9nNPpGZCzFe+iksFhTNa9706RwmdaWIq5nxqcUAAAAVwxvm++DJk19v/yLWEtH/4NMiqg=</Password>
    <DbVersion>Azure</DbVersion>
    <Database>eosadvisor</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

void Main()
{
	var eventId = 17;
	// PC Set to UTC-11
	// Event created, note it goes in current time
	Events
		.Where(e => e.Id == eventId)
		.Select(e => new 
		{
			Id = e.Id,
			StartDate = e.StartDate,
			Created = e.CreatedUtc,
			Modified = e.ModifiedUtc
		})
		.Dump();
	
	ActivityInstances
		.Where(ai => ai.ActivitiesEventId == eventId)
		.Dump();
		
	// In eCAT the Test Instance 
	// testPerformedUtc : "2018-05-16T14:34:53.000Z"
}

// Define other methods and classes here
