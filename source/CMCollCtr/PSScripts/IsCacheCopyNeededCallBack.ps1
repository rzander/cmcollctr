if((Get-ItemProperty 'hklm:\Software\Microsoft\SMS\Mobile Client\Software Distribution\' 'IsCacheCopyNeededCallBack' -ea SilentlyContinue)) { $true } else { $false }

#Only fix if CAS.log indicates an Issue with 'IsCacheCopyNeededCallBack' key
#To Fix, run the following line
#Remove-ItemProperty 'hklm:\Software\Microsoft\SMS\Mobile Client\Software Distribution\' 'IsCacheCopyNeededCallBack' -ea SilentlyContinue