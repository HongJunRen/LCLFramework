@ECHO OFF

%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\msbuild "%~dp0\LCLFramework.sln" /v:minimal /maxcpucount /nodeReuse:false %*



pause
