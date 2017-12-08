@echo off

rem
rem 3秒後にNode.jsのファイルをPowershellで実行する
rem

timeout 1

start "app" "%SystemRoot%\system32\WindowsPowerShell\v1.0\powershell.exe" "node EmpLocationCleanBatch.js"

exit