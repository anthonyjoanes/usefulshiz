<Query Kind="SQL">
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

DECLARE @SOURCE_BLOCK 	   VARCHAR(MAX);
DECLARE @DESTINATION_BLOCK VARCHAR(MAX);
DECLARE @TEMPLATECOUNT INT;

BEGIN TRY

BEGIN TRAN

SELECT @SOURCE_BLOCK      = '<td>{{getFormattedNumber(page.calibration,page.sensitivityPoints.sensitivityRising.displayPointValue)}}</td>';
SELECT @DESTINATION_BLOCK = '<td>{{getFormattedNumber(page.calibration,page.sensitivityPoints.sensitivityRising.displayPointValue)}}<span ng-if="page.useUncertainties && !page.sensitivityPoints.sensitivityRising.uncertainty">*</span></td>';

SELECT @TEMPLATECOUNT = COUNT(0) 
FROM [dbo].[CertificateTemplates]
WHERE InnerTemplate LIKE '%' + @DESTINATION_BLOCK + '%';

IF @templateCount = 0
	BEGIN
		print 'Add the Uncertainty asterix for the sensitivityRising point';
		UPDATE [dbo].[CertificateTemplates]
		SET InnerTemplate =  REPLACE(InnerTemplate, @SOURCE_BLOCK, @DESTINATION_BLOCK);
	END

SELECT @SOURCE_BLOCK      = '<td>{{getFormattedNumber(page.calibration,page.sensitivityPoints.sensitivityPoint.displayPointValue)}}</td>';
SELECT @DESTINATION_BLOCK = '<td>{{getFormattedNumber(page.calibration,page.sensitivityPoints.sensitivityPoint.displayPointValue)}}<span ng-if="page.useUncertainties && !page.sensitivityPoints.sensitivityPoint.uncertainty">*</span></td>';

SELECT @TEMPLATECOUNT = COUNT(0) 
FROM [dbo].[CertificateTemplates]
WHERE InnerTemplate LIKE '%' + @DESTINATION_BLOCK + '%';

IF @templateCount = 0
	BEGIN
		print 'Add the Uncertainty asterix for the sensitivityPoint point';
		UPDATE [dbo].[CertificateTemplates]
		SET InnerTemplate =  REPLACE(InnerTemplate, @SOURCE_BLOCK, @DESTINATION_BLOCK);
	END

SELECT @SOURCE_BLOCK      = '<td>{{getFormattedNumber(page.calibration,page.sensitivityPoints.sensitivityFalling.displayPointValue)}}</td>';
SELECT @DESTINATION_BLOCK = '<td>{{getFormattedNumber(page.calibration,page.sensitivityPoints.sensitivityFalling.displayPointValue)}}<span ng-if="page.useUncertainties && !page.sensitivityPoints.sensitivityFalling.uncertainty">*</span></td>';

SELECT @TEMPLATECOUNT = COUNT(0) 
FROM [dbo].[CertificateTemplates]
WHERE InnerTemplate LIKE '%' + @DESTINATION_BLOCK + '%';

IF @templateCount = 0
	BEGIN
		print 'Add the Uncertainty asterix for the sensitivityFalling point';
		UPDATE [dbo].[CertificateTemplates]
		SET InnerTemplate =  REPLACE(InnerTemplate, @SOURCE_BLOCK, @DESTINATION_BLOCK);
	END
	
	--COMMIT TRAN
	ROLLBACK TRANSACTION

END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION
	PRINT ERROR_MESSAGE()
END CATCH
