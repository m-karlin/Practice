namespace App.Problems;

public class SimpleHashMap
{
	private record Entry<T>(string Key, T Value);

	private class HashMap<T>
	{
		private const double LoadFactorThreshold = 0.75;
		private List<Entry<T>>[] _buckets;

		public int Count { get; private set; }
		public int Capacity => _buckets.Length;

		public HashMap(int capacity = 16)
		{
			_buckets = new List<Entry<T>>[capacity];
			for (var i = 0; i < capacity; i++)
			{
				_buckets[i] = [];
			}
		}

		public void Set(string key, T value)
		{
			if ((double)Count / _buckets.Length > LoadFactorThreshold)
			{
				Resize();
			}

			var index = GetHash(key);
			var bucket = _buckets[index];

			var existingIndex = bucket.FindIndex(x => x.Key == key);
			if (existingIndex >= 0)
			{
				bucket[existingIndex] = new Entry<T>(key, value);
			}
			else
			{
				bucket.Add(new Entry<T>(key, value));
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
			_buckets = new List<Entry<T>>[_buckets.Length * 2];

			for (var i = 0; i < _buckets.Length; i++)
			{
				_buckets[i] = [];
			}

			Count = 0;

			foreach (var bucket in oldBuckets)
			{
				foreach (var entry in bucket)
				{
					Set(entry.Key, entry.Value);
				}
			}
		}
	}

	public static void Run()
	{
		var hashMap = new HashMap<int>(2);
		hashMap.Set("key1", 5);
		hashMap.Set("key2", 10);
		hashMap.Set("key3", 15);

		// 4
		Console.WriteLine(hashMap.Capacity);
		// 3
		Console.WriteLine(hashMap.Count);

		hashMap.TryGetValue("key1", out var value1);
		// 5
		Console.WriteLine(value1);

		hashMap.TryGetValue("key2", out var value2);
		// 10
		Console.WriteLine(value2);

		// false
		Console.WriteLine(hashMap.TryGetValue("key4", out _));
	}
}