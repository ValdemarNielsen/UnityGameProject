using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class UDPClient
{
    private UdpClient client;
    private IPEndPoint endPoint;

    // Host and port to connect to
    private string host;
    private int port;

    public UDPClient(string host, int port)
    {
        this.host = host;
        this.port = port;

        // Create UDP client
        client = new UdpClient();
        // Set the remote endpoint
        endPoint = new IPEndPoint(IPAddress.Parse(host), port);
    }

    public void SendPlayerInput(float horizontalInput, bool jumpInput, bool attackInput, bool interactInput)
    {
        // Convert input data to a string (you can customize this format based on your needs)
        string inputString = string.Format("Input|{0},{1},{2},{3}", horizontalInput, jumpInput ? 1 : 0, attackInput ? 1 : 0, interactInput ? 1 : 0);

        // Convert the message to bytes
        byte[] data = Encoding.UTF8.GetBytes(inputString);
        try
        {
            // Send the data
            client.Send(data, data.Length, endPoint);
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.LogError("Error sending data: " + e.Message);
        }
    }

    // Close the UDP client when necessary
    public void Close()
    {
        client.Close();
    }
}
