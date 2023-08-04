using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using VelNet;
using VELConnect;
public class NetworkPlayer : NetworkSerializedObjectStream
{
	public string _object_url = "";
	public string object_url {
		get {
			return _object_url;
		}
		set {
			_object_url = value;
			StartCoroutine(downloadData());
		}
	}

	IEnumerator downloadData()
	{
		if(object_url == "")
		{
			Debug.Log("object_url is empty");
			//maybe delete or something
		}
		Debug.Log("download avatar");
		yield return null;
	}
	protected override void ReceiveState(BinaryReader binaryReader)
	{
		string target_object_url = binaryReader.ReadString();
		if (target_object_url != object_url)
		{
			Debug.Log("here");
			object_url = target_object_url;
		}

	}

	protected override void SendState(BinaryWriter binaryWriter)
	{
		binaryWriter.Write(object_url);
	}



	// Start is called before the first frame update
	void Start()
    {
		if (IsMine)
		{
			VELConnectManager.AddDeviceDataListener("avatar_url", this, (val) =>
			{

				if (val == null)
				{
					Debug.Log("is null");
				}
				else
				{
					object_url = val;
					Debug.Log(val);
				}

			}, true);
		}
    }

    // Update is called once per frame
    void Update()
    {
		if (IsMine)
		{
			//modify the state

		}
		else
		{
			//force the object to achieve the state
		}
        
    }
}
