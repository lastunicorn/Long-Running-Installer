# Long Running Installer

## Description

This installer is simulating, as the name suggests, a long running installation experience by sleeping the specified amount of time.

## Parameters

`SECONDS` - Integer number that specifies how many seconds to delay the installation.

```
msiexec /i LongRunningInstaller.msi SECONDS=10
```

`TIME` - `TimeStamp` value that specifies how much time to delay the installation.

```
msiexec /i LongRunningInstaller.msi TIME=0.00:00:10
```

The time has the following format: `days.hours.minutes.seconds`

**Note**: If no time parameter (`SECONDS` or `TIME`) is specified, the default sleep value is 10 seconds.

## How to force stop

The sleep loop can be manually stopped by creating a file named "stop" (without extension) in the installation directory, next to the `ReadMe.txt` file.
The default installation directory is:

	- `C:\Program Files\Dust in the Wind\Long Running Installer`

## Donations

> If you like my work and want to support me, you can buy me a coffee:
>
> [![ko-fi](https://www.ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/Y8Y62EZ8H)

