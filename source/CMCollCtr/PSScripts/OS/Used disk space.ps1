$WMILogicalDiskC = [wmi]"root\cimv2:Win32_logicalDisk.DeviceID='C:'"
$LogicalDiskCFreeSpace = $WMILogicalDiskC.FreeSpace
$LogicalDiskCSize = $WMILogicalDiskC.Size
$LogicalDiskCUsedSpace = $LogicalDiskCSize - $LogicalDiskCFreeSpace
$LogicalDiskCUsedSpaceinGB =  $LogicalDiskCUsedSpace/1GB
Write-Output $($LogicalDiskCUsedSpaceinGB.ToString("N2")+"GB")