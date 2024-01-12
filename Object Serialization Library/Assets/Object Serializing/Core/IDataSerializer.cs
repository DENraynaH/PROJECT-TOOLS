using System.Collections;
using System.Collections.Generic;

public interface IDataSerializer
{
    public bool SaveFile(object state);
    public bool LoadFile<T>(out T loadedState);
}

