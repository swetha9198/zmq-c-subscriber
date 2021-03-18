using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Runtime.Serialization.Json;
using NetMQ;
using NetMQ.Sockets;
using System.Threading;

namespace Subscriber
{    class Program
    {
        static void Main(string[] args)
        {
            var subSocket = new SubscriberSocket();            
            subSocket.Options.ReceiveHighWatermark = 1000;
            subSocket.Bind("tcp://localhost:5558");
            subSocket.Subscribe(""); //subscribing to all
            Console.WriteLine("Subscriber socket connecting...");
            while (true)
            {                
                string messageTopicReceived = subSocket.ReceiveFrameString();
                string header = subSocket.ReceiveFrameString();
                string messageReceived = subSocket.ReceiveFrameString();
                Console.WriteLine("***************************");
                Console.WriteLine(messageReceived);
                Console.WriteLine("***************************");
            }
        }
    }
}
