(get-wmiobject -query "SELECT * FROM CacheInfoEx" -namespace "ROOT\ccm\SoftMgmtAgent") | % { $s= $s + $_.ContentSize }; "content (MB):" + "{0:N0}" -f ( $s / 1024 ) 