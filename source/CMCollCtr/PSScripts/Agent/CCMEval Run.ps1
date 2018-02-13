 $cmpath = (Get-ItemProperty("HKLM:\SOFTWARE\Microsoft\SMS\Client\Configuration\Client Properties")).$("Local SMS Path")
 (start-process "$($cmpath)ccmeval.exe" -PassThru).Id
 sleep 15