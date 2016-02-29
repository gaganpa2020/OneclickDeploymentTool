using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SerialPortExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int baud = 9600;
            SerialPort currentPort;
            string newport = "COM6";

            DeployBuild deployBuild = new DeployBuild();

            while (true)
            {
                int intReturnASCII = 0;
                string[] ports = SerialPort.GetPortNames();
                currentPort = new SerialPort(newport, baud);
                currentPort.Open();
                Thread.Sleep(1000);
                int count = currentPort.BytesToRead;
                string returnMessage = "";
                while (count > 0)
                {
                    intReturnASCII = currentPort.ReadByte();
                    returnMessage = returnMessage + Convert.ToChar(intReturnASCII);
                    count--;
                }

                currentPort.Close();

                //Console.Write(returnMessage);

                if (returnMessage.Trim().ToString().Contains("deploy"))
                {
                    deployBuild.Deploy();
                    Thread.Sleep(20000);
                }
            }
        }
    }
}
