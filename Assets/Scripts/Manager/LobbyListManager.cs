using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class LobbyListManager : MonoBehaviour
{
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Transform contentParent; // Reference to the content folder transform
   
    void Start()
    {
      
    }

    public void CreateButton()
    {
        GameObject newButton = Instantiate(buttonPrefab, contentParent);

    }


}