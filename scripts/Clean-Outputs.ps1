Get-ChildItem ..\src -include bin,obj -Recurse | foreach ($_) {
  Write-Host "DELETING:" $_.fullname
  Remove-Item $_.fullname -Force -Recurse
}
Read-Host -Prompt "Press Enter to exit"