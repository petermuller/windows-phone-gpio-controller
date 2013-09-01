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
    if mode == 'i':
        global c
        c = connection
        GPIO.setup(pinNumber,GPIO.IN)
        #TODO: Real-time update of digital input values
        GPIO.add_event_detect(pinNumber, GPIO.BOTH, callback=readIn)
    else:
        GPIO.setup(pinNumber,GPIO.OUT)
        GPIO.remove_event_detect(pinNumber)
    
def setOut(pinNumber,state):
    """
    Sets the output state of the specified pin.
    
    @param pinNumber - number of the pin to set
    @param state - low (0V) or high (~3.3V)
    """
    if state == 'h':
        volt = True #high
    else:
        volt = False #low
    GPIO.output(pinNumber,volt)
    
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
