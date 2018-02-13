$Reg = [WMIClass]"root\default:StdRegProv"
$newDCOMSDDL = "O:BAG:BAD:(A;;CCDCLCSWRP;;;SY)(A;;CCDCLCSWRP;;;BA)(A;;CCDCLCSWRP;;;IU)"
$DCOMbinarySD = $converter.SDDLToBinarySD($newDCOMSDDL)
$Reg.SetBinaryValue(2147483650,"SOFTWARE\Microsoft\Ole","DefaultLaunchPermission", $DCOMbinarySD.binarySD)

$newDCOMSDDL = "O:BAG:BAD:(A;;CCDCLC;;;WD)(A;;CCDCLC;;;LU)(A;;CCDCLC;;;S-1-5-32-562)(A;;CCDCLC;;;AN)"
$DCOMbinarySD = $converter.SDDLToBinarySD($newDCOMSDDL)
$Reg.SetBinaryValue(2147483650,"SOFTWARE\Microsoft\Ole","MachineAccessRestriction", $DCOMbinarySD.binarySD)

$newDCOMSDDL = "O:BAG:BAD:(A;;CCDCSW;;;WD)(A;;CCDCLCSWRP;;;BA)(A;;CCDCLCSWRP;;;LU)(A;;CCDCLCSWRP;;;S-1-5-32-562)"
$DCOMbinarySD = $converter.SDDLToBinarySD($newDCOMSDDL)
$Reg.SetBinaryValue(2147483650,"SOFTWARE\Microsoft\Ole","MachineLaunchRestriction", $DCOMbinarySD.binarySD)