"""
PiFunctions.py

Contains the actions that will control the Raspberry Pi.
"""

import RPi.GPIO as GPIO

def init():
    GPIO.setmode(GPIO.BCM)

def pinMode(pinNumber,mode):
    """
    Changes whether a pin is treated as input or output.
    
    @param pinNumber - number of the pin to initialize
    @param mode - input mode or output mode
    """
    if mode == 'i':
        chanMode = GPIO.IN
    else:
        chanMode = GPIO.OUT
    GPIO.setup(pinNumber,chanMode)
    
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
    return GPIO.input(pinNumber)

def finish():
    """
    Resets the board for the next connection
    """
    GPIO.cleanup()
