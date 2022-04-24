### Version 1.0.6
- [x] Added the `LogLevel` to the output message, eg. `[Info]`

### Version 1.0.5
- [x] Add Destructor to Logger
- [x] Add Dispose to Logger
- [x] Add Reset to Logger (default state)
- [x] Disposing the Log will stop the current Logger.
- [x] Add IsTimerRunning to Logger

### Version 1.0.4
- [x] Get/Set LogLevel of the current Logger
- [x] Get/Set LogToConsole of the current Logger
- [x] Get/Set DateFormat of the current Logger
- [x] Add Destructor to Log that calls Dispose()

### Version 1.0.3
- [x] Users can now provide a Logger that was prepared earlier when creating a Log (optional)

### Version 1.0.2
- [x] Extended Log so you don't need to provide the log level every time
- [x] Default Logger is created automatically
