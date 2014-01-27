windows-phone-gpio-controller
=============================

This is a Windows Phone app to control the Raspberry Pi GPIO.

Requirements
------------
**Phone Application**

* Windows Phone 8+

**Raspberry Pi Server**

* Download from https://github.com/petermuller/pi-phone-server
* Python 2.7.x
* Raspberry Pi GPIO v0.5.3a+

How to Use
----------
**Phone Application**

1. Enter the IP or URL of the Raspberry Pi you want to connect to
2. Enter the Port Number of the PiServer (by default, it is 9001)
3. Hit the Connect button
4. Use the buttons and sliders on the app to adjust the input and output options for the Pi
5. Enjoy!

**Raspberry Pi Server**

1. Copy the Python files (.py) to your Raspberry Pi
2. Ensure your Raspberry Pi distribution is up to date (# yum/apt-get upgrade)
3. As root, run the command "python PiServer.py"
4. Use the phone application to interact with your Pi!

To-do List
----------
**Definite**

1. Finish cleaning up the app
2. Add more error handling
3. Port to Android

**Potential**

1. Bluetooth in additon to TCP/IP
2. Graphs to show input activity over time
3. Port to IOS