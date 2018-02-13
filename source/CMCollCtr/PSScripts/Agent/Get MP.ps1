$site = ([wmiclass]"ROOT\ccm:SMS_Client").GetAssignedSite().sSiteCode;
"MP:" + ([wmi]"ROOT\ccm:SMS_Authority.Name='SMS:$($site)'").CurrentManagementPoint