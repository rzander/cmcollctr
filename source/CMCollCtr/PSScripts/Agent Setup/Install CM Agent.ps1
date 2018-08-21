$CMMP='MP.contoso.com'

$CMSiteCode='SR1'

$ErrorActionPreference = "SilentlyContinue" 

try 
{ 
#Get ccm cache path for later cleanup... 
    try 
    { 
        $ccmcache = ([wmi]"ROOT\ccm\SoftMgmtAgent:CacheConfig.ConfigKey='Cache'").Location 
    } catch {} 

#download ccmsetup.exe from MP 
    $webclient = New-Object System.Net.WebClient 
    $url = "http://$($CMMP)/CCM_Client/ccmsetup.exe" 
    $file = "c:\windows\temp\ccmsetup.exe" 
    $webclient.DownloadFile($url,$file) 

#stop the old sms agent service 
    stop-service 'ccmexec' -ErrorAction SilentlyContinue 

#Cleanup cache 
    if($ccmcache -ne $null) 
    { 
        try 
        { 
        dir $ccmcache '*' -directory | % { [io.directory]::delete($_.fullname, $true)  } -ErrorAction SilentlyContinue 
        } catch {} 
    } 

#Cleanup Execution History 
    Remove-Item -Path 'HKLM:\SOFTWARE\Wow6432Node\Microsoft\SMS\Mobile Client\*' -Recurse -ErrorAction SilentlyContinue 
	Remove-Item -Path 'HKLM:\SOFTWARE\Microsoft\SMS\Mobile Client\*' -Recurse -ErrorAction SilentlyContinue 

#kill existing instances of ccmsetup.exe 
    $ccm = (Get-Process 'ccmsetup' -ErrorAction SilentlyContinue) 
    if($ccm -ne $null) 
    { 
            $ccm.kill(); 
    } 

#run ccmsetup
    $proc = Start-Process -FilePath 'c:\windows\temp\ccmsetup.exe' -PassThru -ArgumentList "/mp:$($CMMP) /source:http://$($CMMP)/CCM_Client CCMHTTPPORT=80 RESETKEYINFORMATION=TRUE SMSSITECODE=$($CMSiteCode) SMSSLP=$($CMMP) FSP=$($CMMP)"
    Sleep(5)
	"ccmsetup started..." 
} 

catch 
{ 
        "an Error occured..." 
        $error[0] 
} 