$username = (get-wmiobject -query "SELECT Username FROM Win32_ComputerSystem" -namespace "root\cimv2").Username;$user = New-Object System.Security.Principal.NTAccount($username.split('\')[0],$username.split('\')[1]);$sid= $user.Translate([System.Security.Principal.SecurityIdentifier]); $cmsid=$sid.value.replace('-','_');
$a=([wmi]"root\ccm\Policy\$($cmsid)\ActualConfig:CCM_Scheduler_ScheduledMessage.ScheduledMessageID='{00000000-0000-0000-0000-000000000026}'");$a.Triggers=@('SimpleInterval;Minutes=1;MaxRandomDelayMinutes=0');$a.Put() | out-null;"Policy requested for: " + $sid.value