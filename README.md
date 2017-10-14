# Device Telemetry Dashboard

AppVeyor build status: [![AppVeyor](https://ci.appveyor.com/api/projects/status/github/sergiokoval/E.Homework.Devices?branch=master&svg=true)](https://ci.appveyor.com/project/sergiokoval/e-homework-devices)

Project build link - https://ci.appveyor.com/project/sergiokoval/e-homework-devices

Telemetry dashboard provides basic infrastructure to simulate and gather statistics for connected devices.
The data access layer has been omitted in order to make application easy to run.
Currently the data being persisted in memory on web server.

System provides basic telemetry statistic data presentation for monitoring and  measurements view done by connected devices.


![ScreenShot](https://github.com/sergiokoval/E.Homework.Devices/raw/master/UI_Screenshot.png)
![ScreenShot](https://github.com/sergiokoval/E.Homework.Devices/raw/master/TelemetryDetailView.png)

Application is composed of two main parts:

 * Console application to simulate connected devices.
 * Web server in messaging hub role and host for user interface to view device telemetry summary/statistics
 
 The project can be run directly from visual studio following next steps:
  * make sure the Console application app.config contains correct Web server URL:
    ![ScreenShot](https://github.com/sergiokoval/E.Homework.Devices/raw/master/ConsoleAppConfig.PNG)
    
  * Setup Multiple Project Run Options in order shown below:
   ![ScreenShot](https://github.com/sergiokoval/E.Homework.Devices/raw/master/ProjectStartupOptionsVS.png)
   
   * Or run projects in next order:
    * WebServer
    * Console Application
 

