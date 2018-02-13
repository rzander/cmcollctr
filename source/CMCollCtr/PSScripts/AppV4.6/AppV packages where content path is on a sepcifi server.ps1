$Compliance = $false;
$Server = '%CHRM%';
(get-wmiobject -query "SELECT * FROM Package WHERE SftPath like '$($Server)'" -namespace "root\Microsoft\appvirt\client") | % { $Compliance = $true }
$Compliance