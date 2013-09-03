"""
ServerInstance.py

A class to contain the actions that will control the Raspberry Pi.
"""

import RPi.GPIO as GPIO

class ServerInstance:
    """
    Main class to interact with the Raspberry Pi GPIO
    """
    
    #Structure of pins dictionary
    #
    #Each key is the board number of the pin (so it is unique per pin)
    #The corresponding values are tuples structured as (mode) for input pins or
    #(mode, PWM instance) for output pins
    pins = {}
    
    #Constants
    _FREQ = 100 #100Hz for PWM instances
    
    def __init__(self,connection):
        """
        @param connection - TCP connection to phone app
        """
        self.connection = connection
        GPIO.setmode(GPIO.BOARD)
        
    def pinMode(pinNumber,mode):
        """
        Changes whether a pin is treated as input or output.
        
        @param pinNumber - number of the pin to initialize
        @param mode - input mode or output mode
        """
        if mode == 'i':
            if pinNumber in pins:
                pins[pinNumber][1].stop()
            pins[pinNumber] = ("input")
            GPIO.setup(pinNumber,GPIO.IN)
            GPIO.add_event_detect(pinNumber, GPIO.BOTH, callback=readIn)
        else: # mode == 'o'
            if pinNumber in pins:
                #This only happens after pin set to output after being an input
                GPIO.remove_event_detect(pinNumber)
            GPIO.setup(pinNumber,GPIO.OUT)
            pins[pinNumber] = ("output",GPIO.PWM(pinNumber,_FREQ))
            pins[pinNumber][1].start(0)
    
    def setOut(pinNumber,percent):
        """
        Sets the output state of the specified pin.
        
        @param pinNumber - number of the pin to set
        @param percent - percent duty cycle to set average voltage
        """
        try:
            pins[pinNumber][1].ChangeDutyCycle(float(percent))
        except ValueError:
            #only happens when commands are flushed incorrectly
            pass
            
    def readIn(pinNumber):
        """
        Reads in the value from the specified pin
        
        @param pinNumber - pin to read input from
        """
        #connection is a global variable set in pinMode
        connection.send(str(GPIO.input(pinNumber)))
        
    def finish():
        """
        Resets the board for the next connection
        """
        GPIO.cleanup()