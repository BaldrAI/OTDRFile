using System.Collections;
using BaldrAI.OpenOTDR.OTDRFile.Implementation;

namespace BaldrAI.OpenOTDR.OTDRFile.Internal;

public class LandmarkList(List<LandmarkData> data, LandmarkConfig? config = null) : IList<Landmark>
{
    public List<LandmarkData> Data = data;
    private LandmarkConfig Config = config ?? new LandmarkConfig();

    public IEnumerator<Landmark> GetEnumerator()
    {
        foreach (var landmarkData in Data) yield return new Landmark(landmarkData, Config);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(Landmark item)
    {
        if (ushort.MaxValue < Data.Count + 1)
            throw new ArgumentOutOfRangeException(nameof(item));
        Data.Add(item.Data);
    }

    public void Clear()
    {
        Data.Clear();
    }

    public bool Contains(Landmark item)
    {
        return Data.Contains(item.Data);
    }

    public void CopyTo(Landmark[] array, int arrayIndex)
    {
        for (var i = 0; i < Data.Count; i++) array[arrayIndex + i] = new Landmark(Data[i]);
    }

    public bool Remove(Landmark item)
    {
        return Data.Remove(item.Data);
    }

    public int Count => Data.Count;

    public bool IsReadOnly => false;

    public int IndexOf(Landmark item)
    {
        return Data.IndexOf(item.Data);
    }

    public void Insert(int index, Landmark item)
    {
        Data.Insert(index, item.Data);
    }

    public void RemoveAt(int index)
    {
        Data.RemoveAt(index);
    }

    public Landmark this[int index]
    {
        get => new(Data[index], Config);
        set => Data[index] = value.Data;
    }
}