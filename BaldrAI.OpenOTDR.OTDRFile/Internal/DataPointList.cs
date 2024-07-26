using System.Collections;
using BaldrAI.OpenOTDR.OTDRFile.Implementation;

namespace BaldrAI.OpenOTDR.OTDRFile.Internal;

public class DataPointList(ref List<ushort> data, TraceConfig? config = null) : IList<double>
{
    public List<ushort> Data = data;
    private TraceConfig Config = config ?? new TraceConfig();

    public IEnumerator<double> GetEnumerator()
    {
        foreach (var dataPointData in Data) yield return dataPointData * Config.DecibelsSF;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(double item)
    {
        if (uint.MaxValue < Data.Count + 1)
            throw new ArgumentOutOfRangeException(nameof(item));
        Data.Add((ushort)(item / Config.DecibelsSF));
    }

    public void Clear()
    {
        Data.Clear();
    }

    public bool Contains(double item)
    {
        return Data.Contains((ushort)(item / Config.DecibelsSF));
    }

    public void CopyTo(double[] array, int arrayIndex)
    {
        for (var i = 0; i < Data.Count; i++) array[arrayIndex + i] = (ushort)(Data[i] / Config.DecibelsSF);
    }

    public bool Remove(double item)
    {
        return Data.Remove((ushort)(item / Config.DecibelsSF));
    }

    public int Count => Data.Count;

    public bool IsReadOnly => false;

    public int IndexOf(double item)
    {
        return Data.IndexOf((ushort)(item / Config.DecibelsSF));
    }

    public void Insert(int index, double item)
    {
        Data.Insert(index, (ushort)(item / Config.DecibelsSF));
    }

    public void RemoveAt(int index)
    {
        Data.RemoveAt(index);
    }

    public double this[int index]
    {
        get => (double)(Data[index] * Config.DecibelsSF);
        set => Data[index] = (ushort)(value / Config.DecibelsSF);
    }
}