# Unity-MultipeerConnectivity

Using the MultipeerConnectivity framework to share data between nearby devices.
Works with iOS and tvOS.

## Usage

1. From Source
    - Clone or download and copy `Assets/UnityMultipeerConnectivity`, `Assets/UnitySwift` and `Assets/Plugin` directories to your own project.

## Example code

### Send Data

```MultipeerSender.cs
public class MultipeerSender : MonoBehaviour
{
    public void SendData(string data)
    {
        UnityMCSessionNativeInterface.GetMcSessionNativeInterface()
            .SendToAllPeers(SystemInfo.deviceName + "," + data);
    }
}
```

### Receive Data

```MultipeerReceiver.cs
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
```

### And more

See [Example Sene](https://github.com/bkudiess/Unity-MultipeerConnectivity/Assets/Scenes).

Based on [noir-neo/UnityARKitMultipeerConnectivity] (https://github.com/noir-neo/UnityARKitMultipeerConnectivity/).

## Requirements

- Unity 2018.3+
- iOS 12.0+
- Xcode 10.0+
