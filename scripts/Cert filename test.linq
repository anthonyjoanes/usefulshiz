<Query Kind="Program">
  <Connection>
    <ID>f910b3c4-0aed-478c-bd30-8e36fdeed4f8</ID>
    <Persist>true</Persist>
    <Server>tcp:devtesteosadvisorsql.database.windows.net,1433</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>nuuk</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAA7hweDBJuV0ChIhyqdZCM/gAAAAACAAAAAAADZgAAwAAAABAAAACPA4JjI94SBSWlUENpL4tFAAAAAASAAACgAAAAEAAAAIBjIi2FpfAottBSE1S5nuUgAAAAou+3746JuWx0ZhBV2OGIpUwz7GwFrv5earWt7QQVBh4UAAAAdZj5qzeQ1U7PVpfZbPmproXKogw=</Password>
    <DbVersion>Azure</DbVersion>
    <Database>eosadvisor</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

void Main()
{
	//130-171002-145117.pdf
	CertificateDetails
		.Where(cd => cd.Filename == "130-171002-145117.pdf")
		.Take(1);
		
	var cert = CertificateDetails.Where(cd => cd.Id == 4672).FirstOrDefault();
	cert.Filename = "130-171002-145117.pdf";
	
	//SubmitChanges();
	cert.Dump();
	
}

// Define other methods and classes here
