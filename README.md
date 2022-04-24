# SimpleLog4.NET - Log All The Things

[![Nuget](https://img.shields.io/nuget/v/SimpleLog4.NET)](https://www.nuget.org/packages/SimpleLog4.NET)

```cs 
using SimpleLog4.NET;
```

Create a new `Log` with `LogLevel.Error`
``` cs
Log Log = new(@"C:\loglevelError.txt");
```

Create a new `Log` with `LogLevel.Error` that also logs to `Console`
``` cs
Log Log = new(@"C:\loglevelError.txt", true);
```

Create a new `Log` with `LogLevel.Information`
``` cs
Log Log = new(@"C:\test.txt", logLevel: LogLevel.Information);
```

Create a new `Log` and change the `DateFormat`
``` cs
Log Log  = new(@"C:\test.txt", dateFormat: "MM/dd/yyyy HH:mm:ss:fff");
```

Create a new `Log` using a `Logger`
``` cs
Logger logger = new(@"C:\test.txt");
Log Log = new(logger);
```


# Write to the Log

```cs
Log.Info("Info");
Log.Warning("Warning");
Log.Error("Message", ex);
Log.Trace(ex);
```

# Examples

Creating multiple loggers and logging a ridiculous amount of messages is Simple

![Example](https://i.imgur.com/ywVvBbB.png)

#### Example output
```
[04/24/22 23:48:11:446][Info] Loading Settings
[04/24/22 23:48:11:491][Info] Timer WatchDog Started Successfully..
[04/24/22 23:48:11:612][Info] Loaded Exchange Informaiton from File
[04/24/22 23:48:11:616][Info] Initialized Commands
[04/24/22 23:48:11:617][Info] Loaded Deleted Order List..
[04/24/22 23:48:11:630][Info] Loaded Stored Orders from File
[04/24/22 23:48:11:844][Info] Selected Mode: Spot
[04/24/22 23:48:13:387][Info] Updated Exchange Information..
[04/24/22 23:48:14:511][Info] BTNET Started Successfully
```

#### Example Exception

```
[04/19/22 19:40:31:272] BTNET Failed to Start, [Error] Exception:  | Exception: Could not find file 'C:\BNET\notes.txt'.| Trace:    at System.IO.__Error.WinIOError(Int32 errorCode, String maybeFullPath)
   at System.IO.FileStream.Init(String path, FileMode mode, FileAccess access, Int32 rights, Boolean useRights, FileShare share, Int32 bufferSize, FileOptions options, SECURITY_ATTRIBUTES secAttrs, String msgPath, Boolean bFromProxy, Boolean useLongPath, Boolean checkHost)
   at System.IO.FileStream..ctor(String path, FileMode mode, FileAccess access, FileShare share, Int32 bufferSize, FileOptions options, String msgPath, Boolean bFromProxy, Boolean useLongPath, Boolean checkHost)
   at System.IO.StreamReader..ctor(String path, Encoding encoding, Boolean detectEncodingFromByteOrderMarks, Int32 bufferSize, Boolean checkHost)
   at System.IO.File.InternalReadAllText(String path, Encoding encoding, Boolean checkHost)
   at BTNET.VM.ViewModels.NotepadViewModel.LoadNotes() in C:\BinanceTrader.NET\VM\ViewModels\NotepadViewModel.cs:line 45
   at BTNET.BVVM.MainContext..ctor() in C:\BinanceTrader.NET\BVVM\MainContext.cs:line 119| Inner: 
```