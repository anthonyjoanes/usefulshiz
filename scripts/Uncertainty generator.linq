<Query Kind="Program">
  <Connection>
    <ID>f910b3c4-0aed-478c-bd30-8e36fdeed4f8</ID>
    <Persist>true</Persist>
    <Server>tcp:devtesteosadvisorsql.database.windows.net,1433</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>nuuk</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAA7hweDBJuV0ChIhyqdZCM/gAAAAACAAAAAAADZgAAwAAAABAAAAA+AsUIcI0nTnADR0WHGydAAAAAAASAAACgAAAAEAAAAPkwoFjKamoSo9PtndXVByQgAAAA+R89PAGsSBLzEJLvuaKvcby2rGGHKEUXWNjjZPC7/yoUAAAARge21NVmnyfRK2gM+BMV9PbaM/0=</Password>
    <DbVersion>Azure</DbVersion>
    <Database>eosadvisor</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Extensions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.Services.Design.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Design.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.ApplicationServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ServiceModel.Activation.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.Services.Client.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Namespace>System.Web.Script.Serialization</Namespace>
</Query>

void Main()
{
	
	var randomNumber = new Random();
	var uncertainties = new List<Uncertainty>();
	
	for (int i = 0; i < 100; i++)
	{
		var uncertainty = new Uncertainty
		{
			id							   = Guid.NewGuid(),
			organizationId                 = "58",
			key                            = "UncertaintyBucket-1",
			name 						   = $"Uncertainty {i}",
			label 						   = $"Label to be displayed: {i}",
			workingRangeMinimum 		   = randomNumber.Next(0, 10).ToString(),
			workingRangeMaximum 		   = randomNumber.Next(10, 100).ToString(),
			ambientTemperatureRangeMinimum = randomNumber.Next(0, 10).ToString(),
			ambientTemperatureRangeMaximum = randomNumber.Next(1, 30).ToString(),
			ambientTemperatureType         = "C",
			measurementUnitId              = "1",
			measurementUncertainty         = "2.0",
 			connectionTypeIds 			   = GetConnectionIds(),
 			testApparatusIds  			   = GetTestApparatuses(),
 			procedureIds      			   = GetProcedures()
 		};
		
		uncertainties.Add(uncertainty);
	}

	var json = new JavaScriptSerializer().Serialize(uncertainties);
	
	json.Dump();
}

string[] GetConnectionIds() 
{
	var r = new System.Random();
	return Connections
		.Select(x => x.Id.ToString())
		.Skip(r.Next(1, 100))
		.Take(r.Next(1, 200))
		.ToArray();
}

string[] GetTestApparatuses()
{
	var r = new System.Random();
	return TestApparatus
		.Select(ta => ta.Id.ToString())
		.Skip(r.Next(1, 100))
		.Take(r.Next(1, 200))
		.ToArray();
}

string[] GetProcedures()
{
	var r = new System.Random();
	return Procedures
		.Select(p => p.Id.ToString())
		.Skip(r.Next(1, 100))
		.Take(r.Next(1, 200))
		.ToArray();
}

// Define other methods and classes here
class Uncertainty
{
	public Guid id { get;set; }
	public string organizationId {get;set;}
	public string key {get;set;}
	public bool stopUpdatePropagation {get;set;}
	public string syncItemType {get;set;}
	public string name { get;set; }
	public string label {get;set;}
	public string workingRangeMinimum { get;set; }
	public string workingRangeMaximum { get;set; }
	public string ambientTemperatureRangeMinimum { get;set; }
	public string ambientTemperatureRangeMaximum { get;set; }
	public string ambientTemperatureType {get;set;}
	public string measurementUnitId {get;set;}
	public string measurementUncertainty {get;set;}
	public string[] procedureIds { get;set; }
	public string[] connectionTypeIds { get;set; }
	public string[] testApparatusIds { get;set; }
}