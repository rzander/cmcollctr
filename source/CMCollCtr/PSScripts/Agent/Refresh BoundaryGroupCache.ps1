[wmi]'ROOT\ccm\LocationServices:BoundaryGroupCache=@' | remove-wmiobject
([wmiclass]'ROOT\ccm:SMS_Client').TriggerSchedule('{00000000-0000-0000-0000-000000000023}')