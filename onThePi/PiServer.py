"""
PiServer.py

Listens for communications and feeds read data back to the program.
"""

import socket
import sys

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
            while True: #once connected
                try:
                    data = connection.recv(10) #TODO Determine space needed
                    parseInput(data)
                    if not data:
                        break
                except socket.error:
                    pass
            connection.close()
        #s.close() #commented to listen for new connections after disconnect
    except KeyboardInterrupt:
        s.close()
        sys.exit()
            

def parseInput(data):
    """
    Processes the data so that operations can be done on the Raspberry Pi.

    @param data - the data to interpret into a command
    """
    #if data == string1: #Format for adding new commands
    print data.strip() #at least for now

if __name__ == "__main__":
    main()
