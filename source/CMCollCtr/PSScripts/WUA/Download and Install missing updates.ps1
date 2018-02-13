write-progress -Activity "Updating" -Status "Checking available updates" 
# Opt-in to MU            
#$UpdateSvc = New-Object -ComObject Microsoft.Update.ServiceManager            
#$UpdateSvc.AddService2("7971f918-a847-4430-9279-4a52d1efe18d",7,"")              
#$UpdateSvc.QueryServiceRegistration("7971f918-a847-4430-9279-4a52d1efe18d")  | Out-Null                 
#$UpdateSvc.Services | ? Name -eq "Microsoft Update" | Out-Null           
            
# Scan for missing updates            
$Session = New-Object -ComObject Microsoft.Update.Session            
$Searcher = $Session.CreateUpdateSearcher()            
$Criteria = "AutoSelectOnWebSites=1 and IsInstalled=0 and DeploymentAction='Installation' or IsPresent=1 and DeploymentAction='Uninstallation' or IsInstalled=1 and DeploymentAction='Installation' and RebootRequired=1 or IsInstalled=0 and DeploymentAction='Uninstallation' and RebootRequired=1"            
$SearchResult = $Searcher.Search($Criteria)            
            
# Display missing updates            
$SearchResult.Updates | ft Title,AutoSelectOnWebSites 


# Prepare to download            
$updatesToDownload = New-Object -ComObject Microsoft.Update.UpdateColl            
$updatesToDownload.clear()            
$downloader = $Session.CreateUpdateDownloader()            
$updatesToInstall = New-Object -ComObject Microsoft.Update.UpdateColl            
$updatesToInstall.clear()            

write-progress -Activity "Updating" -Status "Download and install $($SearchResult.Updates.Count) updates"  

# Select items to be downloaded and installed            
$SearchResult.Updates | % {$updatesToDownload.Add($_)}  

# Download            
$downloader.Updates = $updatesToDownload            
$downresults = $downloader.Download()            
            
# Install            
$updatesToDownload | ? { -not($_.isInstalled) -and $_.isDownloaded} | % {$updatesToInstall.Add($_)}            
$installer = $Session.CreateUpdateInstaller()            
$installer.Updates = $updatesToInstall            
$installationResult = $installer.Install()            
            
# Show the result            
$installationResult   