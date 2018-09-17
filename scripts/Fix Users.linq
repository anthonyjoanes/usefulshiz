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
//	var newRole = new OrganizationRoleUsers
//	{
//		UserId = 56,
//		RoleId = 22
//	};
//		
//	OrganizationRoleUsers.InsertOnSubmit(newRole);
	//SubmitChanges();
	
//	OrganizationRoleUsers.Where(oru => oru.UserId == 56).Dump();
//	
//	var newUserApproval = new UserApprovals()
//	{
//		ActivityTypeId = 1,
//		OrganizationRoleUserId = 26,
//		IsSelfSignatory = true,
//		IsPeerApprover = false,
//		IsCertificateApprover = false
//	};
//	
//	UserApprovals.InsertOnSubmit(newUserApproval);
//	
//	
	UserApprovals.Dump();
}

void CreateOrganizationRoleUser(int userId)
{
	
}

// Define other methods and classes here
