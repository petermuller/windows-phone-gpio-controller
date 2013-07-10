using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace windows_phone_gpio_controller
{
    class Communicator
    {
        //Class variables
        Socket sock;
        String host;
        int port;

        //Stolen from Microsoft tutorial
        // Signaling object used to notify when an asynchronous operation is completed
        static ManualResetEvent _clientDone = new ManualResetEvent(false);
        // Define a timeout in milliseconds for each asynchronous call. If a response is not received within this
        // timeout period, the call is aborted.
        const int TIMEOUT_MILLISECONDS = 5000;
        // The maximum size of the data buffer to use with the asynchronous socket methods
        const int MAX_BUFFER_SIZE = 2048;

        //Constructor
        public Communicator(String host, int port)
        {
            this.sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            this.host = host;
            this.port = port;
        }

        

        public String sendCommand(String command)
        {
            //Completely ripped this off the MSDN tutorial.
            
            String response = "Network Timeout";
            if (sock != null)
            {
                SocketAsyncEventArgs socketEventArg = new SocketAsyncEventArgs();
                socketEventArg.RemoteEndPoint = new DnsEndPoint(host, port);
                socketEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(delegate(object s, SocketAsyncEventArgs e)
                {
                    response = e.SocketError.ToString();
                    // Unblock the UI thread
                    _clientDone.Set();
                });
                byte[] payload = Encoding.UTF8.GetBytes(command);
                socketEventArg.SetBuffer(payload, 0, payload.Length);
                _clientDone.Reset();
                sock.SendToAsync(socketEventArg);
                _clientDone.WaitOne(TIMEOUT_MILLISECONDS);
            }
            else
            {
                response = "Socket not initialized";
            }
            return response;
        }

    }
}
