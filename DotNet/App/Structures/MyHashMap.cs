namespace App.Structures;

public record MyHashMapEntry<T>(string Key, T Value);

public class MyHashMap<T>
{
	private const double LoadFactorThreshold = 0.75;
	private List<MyHashMapEntry<T>>[] _buckets;

	public int Count { get; private set; }
	public int Capacity => _buckets.Length;

	public MyHashMap(int capacity = 16)
	{
		_buckets = new List<MyHashMapEntry<T>>[capacity];
		for (var i = 0; i < capacity; i++)
		{
			_buckets[i] = new List<MyHashMapEntry<T>>();
		}
	}

	public void Set(string key, T value)
	{
		var index = GetHash(key);
		var bucket = _buckets[index];

		var existingIndex = bucket.FindIndex(x => x.Key == key);
		if (existingIndex >= 0)
		{
			bucket[existingIndex] = new MyHashMapEntry<T>(key, value);
		}
		else
		{
			if ((double)(Count + 1) / Capacity >= LoadFactorThreshold)
			{
				Resize();
				index = GetHash(key);
				bucket = _buckets[index];
			}

			bucket.Add(new MyHashMapEntry<T>(key, value));
			Count++;
		}
	}

	public bool TryGetValue(string key, out T? value)
	{
		value = default;
		var index = GetHash(key);
		var entry = _buckets[index].Find(x => x.Key == key);

		if (entry == null) return false;

		value = entry.Value;
		return true;
	}

	private int GetHash(string key)
	{
		unchecked
		{
			var hash = key.Aggregate(17, (current, c) => current * 31 + c);
			return Math.Abs(hash % _buckets.Length);
		}
	}

	private void Resize()
	{
		var oldBuckets = _buckets;
		var newCapacity = _buckets.Length * 2;

		_buckets = new List<MyHashMapEntry<T>>[newCapacity];

		for (var i = 0; i < newCapacity; i++)
		{
			_buckets[i] = new List<MyHashMapEntry<T>>();
		}

		foreach (var bucket in oldBuckets)
		{
			foreach (var entry in bucket)
			{
				var newIndex = GetHash(entry.Key);
				_buckets[newIndex].Add(new MyHashMapEntry<T>(entry.Key, entry.Value));
			}
		}
	}
}