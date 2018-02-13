#$devices contains all selected devices
$CollectionName = 'TEST'

import-module ($Env:SMS_ADMIN_UI_PATH.Substring(0,$Env:SMS_ADMIN_UI_PATH.Length-5) + '\ConfigurationManager.psd1')
$provider = Get-PSDrive -PSProvider CMSite -ErrorAction Stop
cd "$($provider.SiteCode[0]):\"

#Get-Command -module ConfigurationManager 

foreach($Device in $devices)
{
	#get Device from CM12
	$Resource = Get-CMDevice -Name $Device

	if($Device -ne $null)
	{
	  Add-CMDeviceCollectionDirectMembershipRule -CollectionName $CollectionName -Resource $Resource
	}
}


