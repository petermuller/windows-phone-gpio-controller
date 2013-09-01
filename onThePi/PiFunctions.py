"""
PiFunctions.py

Contains the actions that will control the Raspberry Pi.
"""

import RPi.GPIO as GPIO

def init():
    GPIO.setmode(GPIO.BOARD)

def pinMode(pinNumber,mode,connection):
    """
    Changes whether a pin is treated as input or output.
    
    @param pinNumber - number of the pin to initialize
    @param mode - input mode or output mode
    @param connection - socket to send and receive data
    """
    FREQ = 100 #100Hz
    if mode == 'i':
        global c
        c = connection
        GPIO.setup(pinNumber,GPIO.IN)
        GPIO.add_event_detect(pinNumber, GPIO.BOTH, callback=readIn)
    else:
        GPIO.setup(pinNumber,GPIO.OUT)
        p = GPIO.PWM(pinNumber,FREQ)
        p.start(0)
        GPIO.remove_event_detect(pinNumber)
    
def setOut(pinNumber,percent):
    """
    Sets the output state of the specified pin.
    
    @param pinNumber - number of the pin to set
    @param percent - percent duty cycle to set average voltage
    """
    FREQ = 100 #100Hz
    try:
        p = GPIO.PWM(pinNumber,FREQ)
        p.start(float(percent))
    except ValueError:
        pass
    
def readIn(pinNumber):
    """
    Reads in the value from the specified pin
    
    @param pinNumber - pin to read input from
    """
    #connection is a global variable set in pinMode
    c.send(str(GPIO.input(pinNumber)))

def finish():
    """
    Resets the board for the next connection
    """
    GPIO.cleanup()
