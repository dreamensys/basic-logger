# Basic Logger Sample

This logger implements several ways to write a log. (Console, File, Database)

## How to run to the application?
1. From the Client Console Application set the value of **DestinationType** over the App.config one of the following:
**Destinations**
  - CONSOLE: it will log a new message on WIndows terminal.
  - FILE: it will write over a file with a set path (App.config)
  - DATABASE: it will write over a table from a DataBase.
  
  **VERBOSITY LEVELS**
  - Message
  - Warning
  - Error
2. Run the Console Application and Enjoy.

## Technical Overview

- Strategy Pattern
- Abstract Factory Pattern
- Inversion of Control
- Singleton Pattern
- NUnit
- Dependency Injection(Unity)

## TODO
- Add a new functionality requesting a web service.
- Inject dependencies loaded from a Unity.conf.
- Pass destinationType from constructor.

## Author
Angel Soto
dreamensys@gmail.com

