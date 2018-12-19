using UniRx;
using UnityEngine;
using UnityMultipeerConnectivity;

public class MultipeerSender : MonoBehaviour
{
    public void SendData(string data)
    {
        Debug.Log("Sent: " + data);
        UnityMCSessionNativeInterface.GetMcSessionNativeInterface()
            .SendToAllPeers(SystemInfo.deviceName + "," + data);
    }
}