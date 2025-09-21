namespace App.Problems;

public class DijkstraAlgorithm
{
	// Класс для представления ребра графа
	private class Edge(int target, int weight)
	{
		public int Target { get; } = target;
		public int Weight { get; } = weight;
	}

	// Реализация алгоритма Дейкстры
	private static int[] Dijkstra(List<Edge>[] graph, int start)
	{
		var n = graph.Length;
		var distances = new int[n];
		var visited = new bool[n];

		// Инициализируем расстояния как максимальное значение
		for (var i = 0; i < n; i++)
		{
			distances[i] = int.MaxValue;
		}

		distances[start] = 0;

		// Обрабатываем все вершины
		for (var count = 0; count < n - 1; count++)
		{
			// Находим вершину с минимальным расстоянием среди непосещенных
			var minVertex = -1;
			var minDistance = int.MaxValue;

			for (var v = 0; v < n; v++)
			{
				if (visited[v] || distances[v] >= minDistance) continue;
				minDistance = distances[v];
				minVertex = v;
			}

			// Если не нашли подходящую вершину, выходим
			if (minVertex == -1)
				break;

			visited[minVertex] = true;

			// Обновляем расстояния до соседей
			foreach (var edge in graph[minVertex])
			{
				if (visited[edge.Target]) continue;
				var newDistance = distances[minVertex] + edge.Weight;
				if (newDistance < distances[edge.Target])
				{
					distances[edge.Target] = newDistance;
				}
			}
		}

		return distances;
	}

	public static void Run()
	{
		Console.WriteLine("Демонстрация алгоритма Дейкстры");
		Console.WriteLine("===============================\n");

		// Создаем граф (5 вершин)
		const int vertices = 5;
		var graph = new List<Edge>[vertices];
		for (var i = 0; i < vertices; i++)
		{
			graph[i] = [];
		}

		// Добавляем ребра
		// Вершина 0 -> 1 (вес 4), 0 -> 2 (вес 1)
		graph[0].Add(new Edge(1, 4));
		graph[0].Add(new Edge(2, 1));

		// Вершина 1 -> 3 (вес 1)
		graph[1].Add(new Edge(3, 1));

		// Вершина 2 -> 1 (вес 2), 2 -> 3 (вес 5)
		graph[2].Add(new Edge(1, 2));
		graph[2].Add(new Edge(3, 5));

		// Вершина 3 -> 4 (вес 3)
		graph[3].Add(new Edge(4, 3));

		// Вершина 4 -> нет исходящих ребер

		// Выводим информацию о графе
		Console.WriteLine("Структура графа:");
		for (var i = 0; i < vertices; i++)
		{
			Console.Write($"Вершина {i} -> ");
			foreach (var edge in graph[i])
			{
				Console.Write($"{edge.Target}(вес:{edge.Weight}) ");
			}

			Console.WriteLine();
		}

		Console.WriteLine("\nЗапускаем алгоритм Дейкстры из вершины 0:");

		// Запускаем алгоритм Дейкстры из вершины 0
		var distances = Dijkstra(graph, 0);

		// Выводим результаты
		Console.WriteLine("\nКратчайшие расстояния от вершины 0:");
		for (var i = 0; i < vertices; i++)
		{
			Console.WriteLine(distances[i] == int.MaxValue
				? $"До вершины {i}: недостижима"
				: $"До вершины {i}: {distances[i]}");
		}

		// Демонстрация пути
		Console.WriteLine("\nПример пути от 0 до 4:");
		Console.WriteLine("0 -> 2 -> 1 -> 3 -> 4");
		Console.WriteLine($"Общий вес: {distances[4]}");
	}
}