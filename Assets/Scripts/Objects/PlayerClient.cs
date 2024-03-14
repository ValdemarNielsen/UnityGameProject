using System.Net.Sockets;
using System.Text;
using System;
using Unity.Plastic.Newtonsoft.Json;


public class PlayerClient
    {
        public string Id { get; set; }
        public string Name { get; set; }
    [JsonIgnore] public TcpClient TcpClient { get; set; }

        public PlayerClient(string name, TcpClient tcpClient)
        {

            Id = Guid.NewGuid().ToString();
            Name = name;
            TcpClient = tcpClient;
        }

        public void SendMessage(string message)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(message);

            NetworkStream stream = TcpClient.GetStream();
        stream.Write(buffer, 0, buffer.Length);
        }

    public string SerializeToJson()
    {
        return JsonConvert.SerializeObject(this);
    }

}


