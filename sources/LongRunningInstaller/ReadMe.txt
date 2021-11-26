================================================================================
Long Running Installer
================================================================================

This file is installed by the "Long Running Installer".
This installer is simulating, as the name suggests, a long running installation
experience by sleeping the specified amount of time.


--------------------------------------------------------------------------------
Usage
--------------------------------------------------------------------------------

msiexec /i LongRunningInstaller.msi SECONDS=10
OR
msiexec /i LongRunningInstaller.msi TIME=0.00:00:10

Default value:
If no time parameter (SECONDS or TIME) is specified, the default sleep value is
10 seconds.


--------------------------------------------------------------------------------
How to force stop
--------------------------------------------------------------------------------
The sleep loop can be manually stopped by creating a file named "stop"
(without extension) in the installation directory, next to the ReadMe.txt file.
The default installation directory is:
	- C:\Program Files\Dust in the Wind\Long Running Installer