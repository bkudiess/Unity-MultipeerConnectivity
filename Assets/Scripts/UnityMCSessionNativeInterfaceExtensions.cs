using System;
using System.Text;
using UniRx;

namespace UnityMultipeerConnectivity
{
    public static class UnityMCSessionNativeInterfaceExtensions
    {

        public static void SendToAllPeers(this UnityMCSessionNativeInterface mcSessionNativeInterface, string data)
        {
            mcSessionNativeInterface.SendToAllPeers(Encoding.ASCII.GetBytes(data));
        }

        public static IObservable<byte[]> DataReceivedAsObservable(this UnityMCSessionNativeInterface mcSessionNativeInterface)
        {
            return Observable.FromEvent<byte[]>(
                h => mcSessionNativeInterface.DataReceivedEvent += h,
                h => mcSessionNativeInterface.DataReceivedEvent -= h
                );
        }

        public static IObservable<Tuple<UnityMCPeerID, UnityMCSessionState>> StateChangedAsObservable(
            this UnityMCSessionNativeInterface mcSessionNativeInterface)
        {
            return Observable.FromEvent<Action<UnityMCPeerID, UnityMCSessionState>, Tuple<UnityMCPeerID, UnityMCSessionState>>(
                h => (peerID, state) => h(Tuple.Create(peerID, state)),
                h => mcSessionNativeInterface.StateChangedEvent += h,
                h => mcSessionNativeInterface.StateChangedEvent -= h
            );
        }
    }
}
