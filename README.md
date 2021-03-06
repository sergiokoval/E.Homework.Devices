# Device Telemetry Dashboard

__AppVeyor build status:__ [![AppVeyor](https://ci.appveyor.com/api/projects/status/github/sergiokoval/E.Homework.Devices?branch=master&svg=true)](https://ci.appveyor.com/project/sergiokoval/e-homework-devices)

__Project build and Continuous Integration  link:__  https://ci.appveyor.com/project/sergiokoval/e-homework-devices

__Project type:__ ASP.NET Web/Windows Console Application

__Programming Languages used:__ Javascript/C#

__Platform:__ .net

__Used IDE:__ Visual Studio 2017

Telemetry dashboard provides basic infrastructure to simulate and gather statistics for connected devices.
The data access layer has been omitted in order to make application easy to run.
Currently the data being persisted in memory on web server. 
Sure there is a lot of things to improve but for demo purposes the logic has been simplified. As well as project structre, e.g.
javascript code kept in the same file with html.

System provides basic Live Telemetry Statistic data presentation for monitoring and measurements view done by connected devices.


![ScreenShot](https://github.com/sergiokoval/E.Homework.Devices/raw/master/UI_Screenshot.png)
![ScreenShot](https://github.com/sergiokoval/E.Homework.Devices/raw/master/TelemetryDetailView.png)

Application is composed of two main modules:

 * Console application to simulate connected devices.
 * Web server in messaging hub role and host for user interface to view device live telemetry summary/statistics
 
 The project can be run directly from visual studio following the next steps:
  * make sure the Console application app.config contains correct Web server URL:
    ![ScreenShot](https://github.com/sergiokoval/E.Homework.Devices/raw/master/ConsoleAppConfig.PNG)
    
  * Setup Multiple Project Run Options in order shown below:
   ![ScreenShot](https://github.com/sergiokoval/E.Homework.Devices/raw/master/ProjectStartupOptionsVS.png)
   
  * Make sure that Start Page is set to __TelemetryDashboard.html__ inside E.Homework.Devices.Web project
	![ScreenShot](https://github.com/sergiokoval/E.Homework.Devices/raw/master/StartPage.png)
   
   * Or run projects in next order:
    1. WebServer, and open __TelemetryDashboard.html__ page, e.g. http://localhost:36210/TelemetryDashboard.html
    2. Console Application
    
In terms of technology the point to highlight is that SignalR 2 (https://www.asp.net/signalr)  is being used as communication framework for device message exchange.
    
    
    
 

