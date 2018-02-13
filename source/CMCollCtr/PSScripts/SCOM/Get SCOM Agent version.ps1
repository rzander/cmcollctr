$File = (Get-Item('HKLM:\SYSTEM\CurrentControlSet\Services\HealthService\')).GetValue('ImagePath').replace('"', '')
[System.Diagnostics.FileVersionInfo]::GetVersionInfo($File).FileVersion