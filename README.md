# Device Telemetry Dashboard

Travis:   [![Travis](https://travis-ci.org/aspnet/SignalR.svg?branch=dev)](https://travis-ci.org/aspnet/SignalR)

Telemetry dashboard provides basic infrastructure to simulate and gather statistics for connected devices.

It can be split into two main parts:

 - Console application to simulate connected device
 - Web server that acts like messaging hub and host for user interface to view device telemetry summary/statistics
 
 The project can be run directly from visual studio following next steps:
  - make sure the Console application app.config contains correct Web server URL:
    [screenshotgoeshere]
    
  - Setup Multiple Project Run Options in order shown below:
   [screenshot goes here]
   
   - Or run projectes in next order:
    -- WebServer
    -- Console Application
 
 ![ScreenShot](https://github.com/sergiokoval/E.Homework.Devices/raw/master/UI_Screenshot.png)
