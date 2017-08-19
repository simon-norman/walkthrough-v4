﻿using System.Collections;
using UnityEngine;

    public class WalkthroughGameManager : Photon.MonoBehaviour
    {
        public string verNum = "0.1";
        public string roomName = "room01";
        public Transform spawnPoint;
        public GameObject playerPref;
        public bool isConnected = false;


        void Start()
        {
            Debug.Log("Start");
            PhotonNetwork.ConnectUsingSettings(verNum);
            Debug.Log("Starting Connection");
        }

        public void OnConnectedToMaster()
        {
            PhotonNetwork.JoinOrCreateRoom(roomName, null, null);
            Debug.Log("Starting Server!");
        }

        public void OnJoinedRoom()
        {
            isConnected = true;
            spawnPlayer();
        }

        public void spawnPlayer()
        {
            GameObject pl = PhotonNetwork.Instantiate(playerPref.name, spawnPoint.position, spawnPoint.rotation, 0) as GameObject;
            GameObject warehouse = PhotonNetwork.Instantiate("Warehouse", spawnPoint.position, spawnPoint.rotation, 0) as GameObject;
            pl.GetComponent<RigidbodyFPSController>().enabled = true;
            pl.GetComponent<RigidbodyFPSController>().fpsCam.SetActive(true);
    }
    }
