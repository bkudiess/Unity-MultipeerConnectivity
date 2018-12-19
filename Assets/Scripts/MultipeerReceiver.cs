using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityMultipeerConnectivity;

public class MultipeerReceiver : MonoBehaviour
{
    public Text text;
    void Start()
    {
        UnityMCSessionNativeInterface.GetMcSessionNativeInterface()
            .DataReceivedAsObservable()
            .Subscribe(Received)
            .AddTo(this);
    }

    void Received(byte[] bytes)
    {
        string dataReceived = System.Text.Encoding.UTF8.GetString(bytes);
        string[] tokens = dataReceived.Split(',');
        text.text += "\n"+ "Received " + tokens[1] + " from " + tokens[0];
    }

}
