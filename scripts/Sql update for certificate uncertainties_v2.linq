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

SELECT @SOURCE_BLOCK      = '<div class="certificate-clearfix certificate-body-output" data-ng-show="page.nonCalibrationReasonId === null"><div class="certificate-left certificate-body-output-label">Test Apparatus:</div><div class="certificate-left"><span data-ng-repeat="equipment in page.testEquipment"><strong>{{equipment.testApparatus.description}}                                                                                                <span data-ng-if="equipment.testApparatus.serialNumber"> S/N:{{equipment.testApparatus.serialNumber}}</span></strong><span data-ng-show="$last===false">, </span></span></div></div><div class="certificate-clearfix certificate-body-output" data-ng-show="page.nonCalibrationReasonId === null && page.measurementTolerance"><div class="certificate-left certificate-body-output-label">Tolerance: </div><div class="certificate-left"><strong>{{page.measurementTolerance}}</strong></div></div>';
SELECT @DESTINATION_BLOCK = '<div class="certificate-clearfix certificate-body-output" data-ng-show="page.nonCalibrationReasonId === null"><div class="certificate-left certificate-body-output-label">Test Apparatus:</div><div class="certificate-left"><span data-ng-repeat="equipment in page.testEquipment"><strong>{{equipment.testApparatus.description}}                                                                                                <span data-ng-if="equipment.testApparatus.serialNumber"> S/N:{{equipment.testApparatus.serialNumber}}</span></strong><span data-ng-show="$last===false">, </span></span></div></div><div class="certificate-clearfix certificate-body-output" ng-if="page.uncertainties.length > 0"><div class="certificate-left certificate-body-output-label">Uncertainty:</div><div class="certificate-left"><span data-ng-repeat="uncertainty in page.uncertainties"><strong>{{uncertainty}}</strong><br data-ng-show="$last===false" /></span></div></div><div class="certificate-clearfix certificate-body-output" data-ng-show="page.nonCalibrationReasonId === null && page.measurementTolerance"><div class="certificate-left certificate-body-output-label">Tolerance: </div><div class="certificate-left"><strong>{{page.measurementTolerance}}</strong></div></div><p data-ng-if="page.useUncertainties">(The tolerance stated above excludes the Uncertainty of Measurement)</p>';

SELECT @TEMPLATECOUNT = COUNT(0) 
FROM [dbo].[CertificateTemplates]
WHERE InnerTemplate LIKE '%' + @DESTINATION_BLOCK + '%';

IF @templateCount = 0
BEGIN
	print 'Add the Uncertainty descriptions inbetween the Test Apapratus and Tolerance labels';
	UPDATE [dbo].[CertificateTemplates]
	SET InnerTemplate =  REPLACE(InnerTemplate, @SOURCE_BLOCK, @DESTINATION_BLOCK);
END


SELECT @SOURCE_BLOCK      = '<td>{{getFormattedNumber(page.calibration,point.displayPointValue)}}</td>';
SELECT @DESTINATION_BLOCK = '<td>{{getFormattedNumber(page.calibration,point.displayPointValue)}} <span ng-if="page.useUncertainties && !point.uncertainty">*</span></td>';

SELECT @TEMPLATECOUNT = COUNT(0) 
FROM [dbo].[CertificateTemplates]
WHERE InnerTemplate LIKE '%' + @DESTINATION_BLOCK + '%';

IF @templateCount = 0
BEGIN
	print 'Add the Asterix to the point display value';
	UPDATE [dbo].[CertificateTemplates]
	SET InnerTemplate =  REPLACE(InnerTemplate, @SOURCE_BLOCK, @DESTINATION_BLOCK);
END

SELECT @SOURCE_BLOCK      = '<div class="certificate-body-content certificate-body-content-border-bottom" data-ng-if="page.nonCalibrationReasonId === null"><p>Connection method: {{page.connectionMethod}}</p></div>';
SELECT @DESTINATION_BLOCK = '<div class="certificate-body-content certificate-body-content-border-bottom" data-ng-if="page.nonCalibrationReasonId === null"><p>Connection method: {{page.connectionMethod}}</p></div><div class="certificate-body-content" data-ng-if="page.useUncertainties && page.pointsWithoutUncertainty"><p> * Calibration Point(s) are not covered by our Accredited Scope</p></div>';

SELECT @TEMPLATECOUNT = COUNT(0) 
FROM [dbo].[CertificateTemplates]
WHERE InnerTemplate LIKE '%' + @DESTINATION_BLOCK + '%';

IF @templateCount = 0
BEGIN
	print 'Add the Asterix to the point display value';
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
