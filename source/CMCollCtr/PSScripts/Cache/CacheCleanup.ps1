#http://myitforum.com/myitforumwp/2014/09/23/removing-stale-cache-from-the-configmgr-client/
#(c) by 2014 Daniel Ratliff

$CacheElements =  get-wmiobject -query "SELECT * FROM CacheInfoEx" -namespace "ROOT\ccm\SoftMgmtAgent"
$ElementGroup = $CacheElements | Group-Object ContentID
[int]$Cleaned = 0;

#Cleanup CacheItems where ContentFolder does not exist
$CacheElements | where {!(Test-Path $_.Location)} | % { $_.Delete(); $Cleaned++ }
$CacheElements = get-wmiobject -query "SELECT * FROM CacheInfoEx" -namespace "ROOT\ccm\SoftMgmtAgent"

foreach ($ElementID in $ElementGroup) 
{
    if ($ElementID.Count -gt 1) 
    {
        #write-host “Found”$ElementID.Name”with”$ElementID.Count”versions. ” -ForegroundColor Yellow -NoNewline
        $max = ($ElementID.Group.ContentVer| Measure-Object -Maximum).Maximum
        #write-host “Max version is”$max -ForegroundColor Yellow

        $ElementsToRemove = $CacheElements | where {$_.contentid -eq $ElementID.Name -and $_.ContentVer-ne $Max}
        foreach ($Element in $ElementsToRemove) 
        {
            write-host “Deleting”$Element.ContentID”with version”$Element.ContentVersion -ForegroundColor Red

            Remove-Item $Element.Location -recurse
            $Element.Delete()
            #$Cache.DeleteCacheElement($Element.CacheElementId)
            $Cleaned++
        }
    } 
    elseif ($ElementID.Count -eq 1) 
    {
        #write-host “Found”$ElementID.Name”with”$ElementID.Count”version. ” -ForegroundColor Green
    }
}

#Cleanup Orphaned Folders in ccmcache
$UsedFolders = $CacheElements | % { Select-Object -inputobject $_.Location }
[string]$CCMCache = ([wmi]"ROOT\ccm\SoftMgmtAgent:CacheConfig.ConfigKey='Cache'").Location
if($CCMCache.EndsWith('ccmcache'))
{
    Get-ChildItem($CCMCache) |  ?{ $_.PSIsContainer } | WHERE { $UsedFolders -notcontains $_.FullName } | % { Remove-Item $_.FullName -recurse ; $Cleaned++ }
}

"Cleaned Items:" + $Cleaned
