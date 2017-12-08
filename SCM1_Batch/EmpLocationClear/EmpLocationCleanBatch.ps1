$param = @{
   EmpNo='DailyClearBatch'
}
$json = $param | ConvertTo-Json
$response = Invoke-RestMethod 'http://scm1api.azurewebsites.net/api/emplocation/ClearEmpLocationInfo' -Method Delete -Body $json -ContentType 'application/json'