# SimpleLogger.NET

```cs 
using SimpleLogger;
```

Create a new Log with Log Level Error
``` cs
Log Log = new(@"C:\loglevelError.txt");
```

Create a new Log with Log Level Error that also logs to console
``` cs
Log Log = new(@"C:\loglevelError.txt", true);
```

Create a new Log with Log Level Information
``` cs
Log Log = new(@"C:\test.txt", logLevel: LogLevel.Information);
```

Create a new Log and change the Date Format
``` cs
Log Log  = new(@"C:\test.txt", dateFormat: "MM/dd/yyyy HH:mm:ss:fff");
```

Write to the Log
```cs
Log.Write("Message", LogLevel.Critical);
```

Example output
> [04/18/22 23:55:50:755] Message

