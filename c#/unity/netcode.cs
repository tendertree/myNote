public struct NetString:INetworkSerializable, System.IEquatable<NetString>{
    public string st;
    public voied NetworkSerialize<T>(BufferSerializer<T> serializer) where : T:IReaderWriter{
        if(serializer.IsReader){
            var reader=serializer.GetFastBufferReader();
            reader.ReadValueSafe(out st);
            }else{
            var writer=serializer.GetFastBufferWriter();
            writer.WriteValueSafe(st);
            }
        }
    publict bool Equals(NetString other){
        if(String.Equals(other.st,st,StringComparision.CurrentCultureIgnoreCase)) return true;
        retrun false;
        }


	//Connection
using System;
using Unity.Entities;
using Unity.NetCode;

[UnityEngine.Scripting.Preserve]
public class GameBootstrap : ClientServerBootstrap
{
    public override bool Initialize(string defaultWorldName)
    {
        AutoConnectPort = 7979; // Enabled auto connect
        return base.Initialize(defaultWorldName); // Use the regular bootstrap
    }
}

