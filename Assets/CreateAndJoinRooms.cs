using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    
    public void CreateRoom() {
        PhotonNetwork.CreateRoom("ASD");
    }

    public void JoinRoom() {
        PhotonNetwork.JoinRoom("ASD");
    }


    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("SampleScene");
    }
    // Update is called once per frame
    void OnTEST() {
        CreateRoom();
        Debug.Log("CREAR");
    }

    void OnTEST2() {
        JoinRoom();
        Debug.Log("UNIRSE");
    }
}
