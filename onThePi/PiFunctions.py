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
        GPIO.setup(pinNumber,GPIO.IN)
        GPIO.add_event_detect(pinNumber, GPIO.BOTH, callback=readIn)
        global connection = connection
    else:
        GPIO.setup(pinNumber,GPIO.OUT)
    
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
    connection.send(GPIO.input(pinNumber))

def finish():
    """
    Resets the board for the next connection
    """
    GPIO.cleanup()
