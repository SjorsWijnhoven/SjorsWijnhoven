using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TelloSharp;

public class Tello
{
    private int vsPort = 11111;
    private bool streaming = false;
    public enum FlipDirection
    {
        Forward,
        Back,
        Left,
        Right
    }
    private UdpClient client = new UdpClient();
    private UdpClient videoServer = new UdpClient();
    public bool isFlying = false;
    public int defTimeout = 5000;
    public bool printResults = true;
    private string SendToDrone(string message, bool printresults)
    {
        client.Send(Encoding.UTF8.GetBytes(message));
        IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 8889);

        //TRY/CATCH BLOCK ADDED BY ME: DELETE IF CAUSING PROBLEMS
        //(terrible solution, does seem to work most of the time... Fix works well enough for now)
        //START
        byte[] receivedResults = [];
        try {
            /*byte[]*/ receivedResults = client.Receive(ref remoteEndPoint);
        } catch (System.Net.Sockets.SocketException e) {
            Connect();
        }
        //END

        string data = Encoding.UTF8.GetString(receivedResults);
        if (printResults && printresults) { Console.WriteLine(data); }
        return data;
    }
    private string STDGR(string message)
    {
        client.Send(Encoding.UTF8.GetBytes(message));
        IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 8889);
        byte[] receivedResults = client.Receive(ref remoteEndPoint);
        string data = Encoding.UTF8.GetString(receivedResults);
        return data;
    }
    public string SendCommand(string message, bool printResults)
    {
        return SendToDrone(message, printResults);
    }
    public string Connect()
    {
        client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, defTimeout);
        client.Connect("192.168.10.1", 8889);
        return SendToDrone("command", false);
    }
    public void End()
    {
        client.Close();
        videoServer.Close();
        streaming = false;
        isFlying = false;
    }
    public string Takeoff()
    {
        if (isFlying) return "Already Flying";
        isFlying = true;
        return SendToDrone("takeoff", true);
    }
    public string Land()
    {
        if (!isFlying) return "Already Landed";
        isFlying = false;
        return SendToDrone("land", false);
    }
    public void Emergency()
    {
        SendToDrone("emergency", false);
    }
    public string Up(int distance)
    {
        return SendToDrone("up " + distance.ToString(), true);
    }
    public string Down(int distance)
    {
        return SendToDrone("down " + distance.ToString(), true);
    }
    public string Left(int distance)
    {
        return SendToDrone("left " + distance.ToString(), true);
    }
    public string Right(int distance)
    {
        return SendToDrone("right " + distance.ToString(), true);
    }
    public string Forward(int distance)
    {
        return SendToDrone("forward " + distance.ToString(), true);
    }
    public string Back(int distance)
    {
        return SendToDrone("back " + distance.ToString(), true);
    }
    public string Clockwise(int degrees)
    {
        return SendToDrone("cw " + degrees.ToString(), true);
    }
    public string CounterClockwise(int degrees)
    {
        return SendToDrone("ccw " + degrees.ToString(), true);
    }
    public string Flip(FlipDirection direction)
    {
        string flipDir = "";
        if (direction == FlipDirection.Forward)
        {
            flipDir = "f";
        }
        else if (direction == FlipDirection.Back)
        {
            flipDir = "b";
        }
        else if (direction == FlipDirection.Left)
        {
            flipDir = "l";
        }
        else if (direction == FlipDirection.Right)
        {
            flipDir = "r";
        }
        else
        {
            flipDir = "f";
        }
        return SendToDrone("flip " + flipDir, true);
    }
    /// <summary>
    /// | x is -500 to 500 |
    /// y is -500 to 500 |
    /// z is -500 to 500 |
    /// speed is 10 to 100 |
    /// </summary>
    public string Go(int x, int y, int z, int speed)
    {
        x = Math.Clamp(x, -500, 500);
        y = Math.Clamp(y, -500, 500);
        z = Math.Clamp(z, -500, 500);
        speed = Math.Clamp(speed, 10, 100);
        return SendToDrone("go " + x.ToString() + " " + y.ToString() + " " + z.ToString() + " " + speed.ToString(), true);
    }
    public string Stop()
    {
        return SendToDrone("stop", true);
    }

    /// <summary>
    /// | x1 is -500 to 500 |
    /// y1 is -500 to 500 |
    /// z1 is -500 to 500 |
    /// x2 is -500 to 500 |
    /// y2 is -500 to 500 |
    /// z2 is -500 to 500 |
    /// speed is 10 to 100 |
    /// </summary>
    public string Curve(int x1, int y1, int z1, int x2, int y2, int z2, int speed)
    {
        x1 = Math.Clamp(x1, -500, 500);
        y1 = Math.Clamp(y1, -500, 500);
        z1 = Math.Clamp(z1, -500, 500);
        x2 = Math.Clamp(x2, -500, 500);
        y2 = Math.Clamp(y2, -500, 500);
        z2 = Math.Clamp(z2, -500, 500);
        speed = Math.Clamp(speed, 10, 60);
        return SendToDrone("curve " + x1.ToString() + " " + y1.ToString() + " " + z1.ToString() + " " + x2.ToString() + " " + y2.ToString() + " " + z2.ToString() + " " + speed.ToString(), true);
    }
    public string SetSpeed(int speed)
    {
        return SendToDrone("speed " + speed.ToString(), true);
    }

    /// <summary>
    /// | leftright is -100 to 100 |
    /// forawrdback is -100 to 100 |
    /// updown is -100 to 100 |
    /// yaw is -100 to 100 |
    /// </summary>
    public void SendRcControl(int leftright, int forwardback, int updown, int yaw)
    {
        int a = Math.Clamp(leftright, -100, 100);
        int b = Math.Clamp(forwardback, -100, 100);
        int c = Math.Clamp(updown, -100, 100);
        int d = Math.Clamp(yaw, -100, 100);
        byte[] message = Encoding.UTF8.GetBytes("rc " + a.ToString() + " " + b.ToString() + " " + c.ToString() + " " + d.ToString());
        client.Send(message);
    }
    public int GetSpeed()
    {
        string response = STDGR("speed?");
        return Int32.Parse(response);
    }
    public int GetBattery()
    {
        string response = STDGR("battery?");
        return Int32.Parse(response);
    }
    public string GetTime()
    {
        return STDGR("time?");
    }
    public string GetWifi()
    {
        return STDGR("wifi?");
    }
    public string GetSDK()
    {
        return STDGR("sdk?");
    }
    public string GetSerialNumber()
    {
        return STDGR("sn?");
    }
    /// <summary>
    /// | x1 is -500 to 500 |
    /// y1 is -500 to 500 |
    /// z1 is -500 to 500 |
    /// x2 is -500 to 500 |
    /// y2 is -500 to 500 |
    /// z2 is -500 to 500 |
    /// speed is 10 to 100 |
    /// missionPadId is 1 - 8 |
    /// </summary>
    public string Curve(int x1, int y1, int z1, int x2, int y2, int z2, int speed, int missionPadId)
    {
        x1 = Math.Clamp(x1, -500, 500);
        y1 = Math.Clamp(y1, -500, 500);
        z1 = Math.Clamp(z1, -500, 500);
        x2 = Math.Clamp(x2, -500, 500);
        y2 = Math.Clamp(y2, -500, 500);
        z2 = Math.Clamp(z2, -500, 500);
        speed = Math.Clamp(speed, 10, 60);
        return SendToDrone("curve " + x1.ToString() + " " + y1.ToString() + " " + z1.ToString() + " " + x2.ToString() + " " + y2.ToString() + " " + z2.ToString() + " " + speed.ToString() + " " + missionPadId.ToString(), true);
    }

    /// <summary>
    /// | x is -500 to 500 |
    /// y is -500 to 500 |
    /// z is -500 to 500 |
    /// speed is 10 to 100 |
    /// missionPadId is 1 - 8 |
    /// </summary>
    public string Go(int x, int y, int z, int speed, int missionPadId)
    {
        x = Math.Clamp(x, -500, 500);
        y = Math.Clamp(y, -500, 500);
        z = Math.Clamp(z, -500, 500);
        speed = Math.Clamp(speed, 10, 100);
        return SendToDrone("go " + x.ToString() + " " + y.ToString() + " " + z.ToString() + " " + speed.ToString() + " " + missionPadId.ToString(), true);
    }

    /// <summary>
    /// | x is -500 to 500 |
    /// y is -500 to 500 |
    /// z is -500 to 500 |
    /// speed is 10 to 100 |
    /// yaw is rotation degrees |
    /// missionPadId is 1 - 8 |
    /// </summary>
    public string Jump(int x, int y, int z, int speed, int yaw, int missionPadId1, int missionPadId2)
    {
        x = Math.Clamp(x, -500, 500);
        y = Math.Clamp(y, -500, 500);
        z = Math.Clamp(z, -500, 500);
        speed = Math.Clamp(speed, 10, 100);
        missionPadId1 = Math.Clamp(missionPadId1, 1, 8);
        missionPadId2 = Math.Clamp(missionPadId2, 1, 8);
        return SendToDrone("jump " + " " + x.ToString() + " " + y.ToString() + " " + z.ToString() + " " + speed.ToString() + " " + yaw.ToString() + " " + missionPadId1.ToString() + " " + missionPadId2.ToString(), true);
    }
    public string StreamOn()
    {
        videoServer = new UdpClient(vsPort);
        streaming = true;
        return SendToDrone("streamon", true);
    }
    public string StreamOff()
    {
        streaming = false;
        videoServer.Close();
        return SendToDrone("streamoff", true);
    }
    public byte[] GetVideoImage()
    {
        if (!streaming) return null;
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse("0.0.0.0"), vsPort);
        return videoServer.Receive(ref ep);
    }

    public Tello() { }

}
