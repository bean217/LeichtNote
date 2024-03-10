namespace LeichtNote.Utils;

public class DictEntry<TKey,TVal>
{
    public TKey Key { get; set; }
    public TVal Value { get; set; }
    
    public DictEntry(TKey key, TVal value)
    {
        Key = key;
        Value = value;
    }
}