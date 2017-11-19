using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MyMsgType
{
    public static short Phone = 48;
}

public class PhoneMessage : MessageBase
{
    public string sound;
    public override void Deserialize(NetworkReader reader)
    {
        sound = reader.ReadString();
    }
}

public class Client : MonoBehaviour {

    NetworkClient myClient;

    [SerializeField]
    private string Ip;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void SetupClient()
    {
        myClient = new NetworkClient();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
        myClient.RegisterHandler(MyMsgType.Phone, OnPhone);
        myClient.Connect(Ip, 4444);
    }

    public void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("Connected to server");
    }

    public void OnPhone(NetworkMessage netMsg)
    {
        PhoneMessage msg = netMsg.ReadMessage<PhoneMessage>();

        Debug.Log(msg.sound);
        RoomManagerLocal.instance.Phone(msg.sound);
    }
    public void StartGame()
    {
        LoadingBar.instance.StartLoading("VR_room");
    }
}
