using System.Collections;
using BaldrAI.OpenOTDR.OTDRFile.Implementation;

namespace BaldrAI.OpenOTDR.OTDRFile.Internal;

public class TraceList(List<TraceData> data, TraceConfig? config = null) : IList<Trace>
{
    public List<TraceData> Data = data;
    private TraceConfig Config = config ?? new TraceConfig();

    public IEnumerator<Trace> GetEnumerator()
    {
        foreach (var traceData in Data)
        {
            yield return new Trace(traceData, Config);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(Trace item)
    {
        if (ushort.MaxValue < Data.Count + 1)
            throw new ArgumentOutOfRangeException(nameof(item));
        Data.Add(item.Data);
    }

    public void Clear()
    {
        Data.Clear();
    }

    public bool Contains(Trace item)
    {
        return Data.Contains(item.Data);
    }

    public void CopyTo(Trace[] array, int arrayIndex)
    {
        for (var i = 0; i < Data.Count; i++)
        {
            array[arrayIndex + i] = new Trace(Data[i]);
        }
    }

    public bool Remove(Trace item)
    {
        return Data.Remove(item.Data);
    }

    public int Count => Data.Count;

    public bool IsReadOnly => false;

    public int IndexOf(Trace item)
    {
        return Data.IndexOf(item.Data);
    }

    public void Insert(int index, Trace item)
    {
        Data.Insert(index, item.Data);
    }

    public void RemoveAt(int index)
    {
        Data.RemoveAt(index);
    }

    public Trace this[int index]
    {
        get => new(Data[index], Config);
        set => Data[index] = value.Data;
    }
}