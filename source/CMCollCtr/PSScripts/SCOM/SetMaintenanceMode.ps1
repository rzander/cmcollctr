#Note: This script will not work if integrated (Kerberos) authentication is used. You have to specify a Username\password in Collection Commander to allow double hop authentication.

$SCOMServer = (Get-ChildItem 'HKLM:\software\Microsoft\Microsoft Operations Manager\3.0\Agent Management Groups\*\0' -Recurse)[0].getvalue('NetworkName')
$Reason = 'PlannedOperatingSystemReconfiguration'
$Comment = 'Applying software update.'
[int]$Minutes = 45
$TargetHost = [System.Net.Dns]::GetHostByName(($env:computerName)).HostName

invoke-command -computername $SCOMServer -ArgumentList $TargetHost, $Reason, $Comment, $Minutes -ScriptBlock {
Param ($scomHost, $scomReason, $scomComment, [int]$scomMinutes)
Import-Module OperationsManager
$Instance = Get-SCOMClassInstance -Name $scomHost
$Time = ((Get-Date).AddMinutes($scomMinutes))
Start-SCOMMaintenanceMode -Instance $Instance -EndTime $Time -Comment $scomComment -Reason $scomReason
}
"SCOM Maintenance mode activated..."