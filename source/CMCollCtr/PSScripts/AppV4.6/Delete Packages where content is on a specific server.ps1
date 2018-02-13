$Server = '%CHRM%';
(get-wmiobject -query "SELECT * FROM Package WHERE SftPath like '$($Server)' AND InUse = 'FALSE' " -namespace "root\Microsoft\appvirt\client") | % { start-process -wait sftmime.exe -argumentlist "delete package:$([char]34)$($_.Name)$([char]34) /global"; $_.Name }	
