(get-wmiobject -namespace "root\ccm\scheduler" -class  CCM_Scheduler_History) | % { $_.delete() }