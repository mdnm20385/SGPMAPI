using System.IO.Ports;

namespace SGPMAPI
{
    public class Smscomms
    {
        private SerialPort _smsPort;
        private Thread _readThread;
        public static bool Continue;
        public static bool ContSms;
        private bool _wait;
        public delegate void SendingEventHandler(bool done);
        public event SendingEventHandler Sending = null!;
        public delegate void DataReceivedEventHandler(string? message);
        public event DataReceivedEventHandler DataReceived = null!;
        bool _isOpen=false;
        public Smscomms(ref string commport)
        {
            _smsPort = new SerialPort();
            _smsPort.PortName = commport;
            _smsPort.BaudRate = 9600;
            _smsPort.Parity = Parity.None;
            _smsPort.DataBits = 8;
            _smsPort.StopBits = StopBits.One;
            _smsPort.Handshake = Handshake.RequestToSend;
            _smsPort.DtrEnable = true;
            _smsPort.RtsEnable = true;
            _smsPort.NewLine = Environment.NewLine;
            _readThread = new Thread(ReadPortz);
        }
        
        private void ReadPortz()
        {
            string? serialIn = null;
            byte[] rxBuffer = new byte[_smsPort.ReadBufferSize + 1];
            while (_smsPort.IsOpen)
            {
                if ((_smsPort.BytesToRead != 0) & _smsPort.IsOpen)
                {
                    while (_smsPort.BytesToRead != 0)
                    {
                        _smsPort.Read(rxBuffer, 0, _smsPort.ReadBufferSize);
                        serialIn =
                            serialIn + System.Text.Encoding.ASCII.GetString(
                            rxBuffer);
                        if (serialIn.Contains(">"))
                        {
                            ContSms = true;
                        }
                        if (serialIn.Contains("+CMGS:"))
                        {
                            Continue = true;
                            if (Sending != null)
                                Sending(true);
                            _wait = false;
                            serialIn = string.Empty;
                            rxBuffer = new byte[_smsPort.ReadBufferSize + 1];
                        }
                    }
                    if (DataReceived != null)
                        DataReceived(serialIn);
                    serialIn = string.Empty;
                    rxBuffer = new byte[_smsPort.ReadBufferSize + 1];
                }
            }
        }

        public bool SendSms(string cellNumber, string smsMessage)
        {
            string myMessage;
            if (smsMessage.Length <= 160)
            {
                myMessage = smsMessage;
            }
            else
            {
                myMessage = smsMessage.Substring(0, 160);
            }
            if (_isOpen)
            {
                _smsPort.WriteLine("AT+CMGS=" + cellNumber + "r");
                ContSms = false;
                _smsPort.WriteLine(
                    myMessage + Environment.NewLine + (char)(26));
                Continue = false;
                Sending(false);
            }
            return false;
        }

        public void Open()
        {
            if (_isOpen == false)
            {
                _smsPort.Open();
                _readThread.Start();
            }
        }

        public void Close()
        {
            if (_isOpen)
            {
                _smsPort.Close();
            }
        }
    }
}
