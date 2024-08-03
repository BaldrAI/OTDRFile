using System.Collections;
using BaldrAI.OpenOTDR.OTDRFile.Implementation;

namespace BaldrAI.OpenOTDR.OTDRFile.Internal;

public class KeyEventList(List<KeyEventData> data, OTDRFile parent) : IList<KeyEvent>
{
    public OTDRFile Parent = parent;
    public List<KeyEventData> Data = data;

    public IEnumerator<KeyEvent> GetEnumerator()
    {
        foreach (var keyeventData in Data) yield return new KeyEvent(keyeventData, Parent);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(KeyEvent item)
    {
        if (ushort.MaxValue < Data.Count + 1)
            throw new ArgumentOutOfRangeException(nameof(item));
        Data.Add(item.Data);
    }

    public void Clear()
    {
        Data.Clear();
    }

    public bool Contains(KeyEvent item)
    {
        return Data.Contains(item.Data);
    }

    public void CopyTo(KeyEvent[] array, int arrayIndex)
    {
        for (var i = 0; i < Data.Count; i++) array[arrayIndex + i] = new KeyEvent(Data[i], parent);
    }

    public bool Remove(KeyEvent item)
    {
        return Data.Remove(item.Data);
    }

    public int Count => Data.Count;

    public bool IsReadOnly => false;

    public int IndexOf(KeyEvent item)
    {
        return Data.IndexOf(item.Data);
    }

    public void Insert(int index, KeyEvent item)
    {
        Data.Insert(index, item.Data);
    }

    public void RemoveAt(int index)
    {
        Data.RemoveAt(index);
    }

    public KeyEvent this[int index]
    {
        get => new(Data[index], Parent);
        set => Data[index] = value.Data;
    }
}