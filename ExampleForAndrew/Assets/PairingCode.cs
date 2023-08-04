using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VELConnect;
using TMPro;
public class PairingCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<TMP_Text>().text = "Pairing Code:"+  VELConnectManager.PairingCode;
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
