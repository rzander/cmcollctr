$cmpath = (Get-ItemProperty("HKLM:\SOFTWARE\Microsoft\SMS\Client\Configuration\Client Properties")).$("Local SMS Path")
(Get-Item "$($cmpath)CcmEvalReport.xml").LastWriteTime