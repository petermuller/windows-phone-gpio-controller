"""
PiServer.py

Listens for communications and feeds read data back to the program.
"""

import socket
import sys
from PiFunctions import *

def main():
    #Initialize the server
    try:
        s = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
        s.setsockopt(socket.SOL_SOCKET,socket.SO_REUSEADDR,1)
        s.bind(('',9001)) #Tuple argument (HOST,PORT)
        s.listen(1) #limit number of concurrent connections to 1
    except socket.error,msg:
        print "Error: " + str(msg[0]) + ": " +msg[1]
        print "Please restart the server."
        print "Exiting"
        #sys.exit()

    try:
        while True: #trying to get signal from client
            connection, address = s.accept()
            connection.send("Success")
            init() #turn on the Pi GPIO
            while True: #once connected
                try:
                    data = connection.recv(10) #TODO Determine space needed
                    parseInput(data,connection)
                    if not data:
                        break
                except socket.error: #on phone disconnect
                    finish()
            connection.close()
    except KeyboardInterrupt:
        finish()
        s.close()
        sys.exit()
            

def parseInput(data,connection):
    """
    Processes the data so that operations can be done on the Raspberry Pi.

    @param data - the data to interpret into a command
    @param connection - socket to send and receive data
    @pre - All data is formatted into 3 sections, separated by commas.
    """
    args = data.strip().split(',')
    print args
    if args[0] == "set": #set input or output
        pinMode(int(args[1]),args[2],connection)
    elif args[0] == "volt": #set voltage on output pins
        setOut(int(args[1]),args[2])
    
    else:
        pass
    

if __name__ == "__main__":
    main()
