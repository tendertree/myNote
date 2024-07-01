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
