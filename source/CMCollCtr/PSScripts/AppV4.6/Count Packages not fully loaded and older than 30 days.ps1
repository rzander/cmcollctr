$c = 0;
Get-WmiObject Application -Namespace root/microsoft/appvirt/client | Where-Object { $_.ConvertToDateTime($_.LastLaunchOnSystem) -le ((date) - (New-TimeSpan -Days 30))  } | % {
$p = ([wmi]"root\microsoft\appvirt\client:Package.PackageGUID='$($_.PackageGUID)'");
if($p.CachedPercentage -ne 100) {$c++; } };"Old and unused:" + $c