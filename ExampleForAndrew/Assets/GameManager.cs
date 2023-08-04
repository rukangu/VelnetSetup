using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VelNet;
public class GameManager : MonoBehaviour
{
    public NetworkPlayer playerPrefab;
    private NetworkPlayer myPlayer;
    // Start is called before the first frame update
    void Start()
    {
        VelNetManager.OnLoggedIn += () =>
        {

            VelNetManager.JoinRoom("default");

        };

        VelNetManager.OnJoinedRoom += (room)=>{
            //we can instantiate objects now
            myPlayer = VelNetManager.NetworkInstantiate(playerPrefab.name).GetComponent<NetworkPlayer>();
		};
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
            foreach(NetworkObject no in FindObjectsOfType<NetworkObject>())
			{
                no.TakeOwnership();
			}
		}
    }
}
