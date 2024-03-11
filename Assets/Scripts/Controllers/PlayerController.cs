using UnityEngine;
using GameProject.Models; // Import the namespace where Player class is defined
using GameProject.Services; // Import the namespace where Player class is defined;
using UnityEngine.Networking;
using Assets.Scripts.BackEnd.Shared;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    public string backendURL = "http://192.168.50.197/api/player";
    
    // Adjust this value to control the update frequency (in seconds)

    void Update()
    {
        // Example: Get player's position and send it to the backend
        float x = transform.position.x;
        float y = transform.position.y;
        SendData(x, y);
    }

    void SendData(float x, float y)
    {
        PlayerData data = new PlayerData { X = x, Y = y };
        string json = JsonUtility.ToJson(data);
        StartCoroutine(PostData(json));
    }

    IEnumerator PostData(string json)
    {
        using (UnityWebRequest request = UnityWebRequest.Post(backendURL, json, "application/json"))
        {
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Failed to send data: " + request.error);
            }
            else
            {
                Debug.Log("Data sent successfully!");
            }
        }
    }

    IEnumerator GetData()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(backendURL))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Failed to get data: " + request.error);
            }
            else
            {
                string json = request.downloadHandler.text;
                PlayerData data = JsonUtility.FromJson<PlayerData>(json);
                Debug.Log("Received data: X = " + data.X + ", Y = " + data.Y);
            }
        }
    }
}

