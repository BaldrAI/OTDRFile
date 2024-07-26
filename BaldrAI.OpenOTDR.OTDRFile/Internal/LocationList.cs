using System.Collections;
using BaldrAI.OpenOTDR.OTDRFile.Implementation;
using Location = BaldrAI.OpenOTDR.OTDRFile.Implementation.Location;

namespace BaldrAI.OpenOTDR.OTDRFile.Internal;

public class LocationList(List<LocationData> data, LocationConfig? config = null) : IList<Location>
{
    public List<LocationData> Data = data;
    private LocationConfig Config = config ?? new LocationConfig();

    public IEnumerator<Location> GetEnumerator()
    {
        foreach (var locationData in Data) yield return new Location(locationData, Config);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(Location item)
    {
        if (ushort.MaxValue < Data.Count + 1)
            throw new ArgumentOutOfRangeException(nameof(item));
        Data.Add(item.Data);
    }

    public void Clear()
    {
        Data.Clear();
    }

    public bool Contains(Location item)
    {
        return Data.Contains(item.Data);
    }

    public void CopyTo(Location[] array, int arrayIndex)
    {
        for (var i = 0; i < Data.Count; i++) array[arrayIndex + i] = new Location(Data[i]);
    }

    public bool Remove(Location item)
    {
        return Data.Remove(item.Data);
    }

    public int Count => Data.Count;

    public bool IsReadOnly => false;

    public int IndexOf(Location item)
    {
        return Data.IndexOf(item.Data);
    }

    public void Insert(int index, Location item)
    {
        Data.Insert(index, item.Data);
    }

    public void RemoveAt(int index)
    {
        Data.RemoveAt(index);
    }

    public Location this[int index]
    {
        get => new(Data[index], Config);
        set => Data[index] = value.Data;
    }
}