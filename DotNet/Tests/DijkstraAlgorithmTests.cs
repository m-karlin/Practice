using App.Algorithms;
using System.Collections.Generic;

namespace App.Tests;

public class DijkstraAlgorithmTests
{
    [Fact]
    public void Dijkstra_ReturnsCorrectDistances_ForSimpleGraph()
    {
        
        const int vertices = 5;
        var graph = new List<DijkstraAlgorithm.Edge>[vertices];
        for (var i = 0; i < vertices; i++)
        {
            graph[i] = new List<DijkstraAlgorithm.Edge>();
        }

        // Создаем граф:
        // 0 -> 1 (вес 4), 0 -> 2 (вес 1)
        graph[0].Add(new DijkstraAlgorithm.Edge(1, 4));
        graph[0].Add(new DijkstraAlgorithm.Edge(2, 1));
        
        // 1 -> 3 (вес 1)
        graph[1].Add(new DijkstraAlgorithm.Edge(3, 1));
        
        // 2 -> 1 (вес 2), 2 -> 3 (вес 5)
        graph[2].Add(new DijkstraAlgorithm.Edge(1, 2));
        graph[2].Add(new DijkstraAlgorithm.Edge(3, 5));
        
        // 3 -> 4 (вес 3)
        graph[3].Add(new DijkstraAlgorithm.Edge(4, 3));

        // Ожидаемые расстояния от вершины 0:
        // 0: 0, 1: 3, 2: 1, 3: 4, 4: 7
        var expected = new[] { 0, 3, 1, 4, 7 };

        
        var result = DijkstraAlgorithm.Dijkstra(graph, 0);

        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Dijkstra_ReturnsZeroDistance_ForStartVertex()
    {
        
        const int vertices = 3;
        var graph = new List<DijkstraAlgorithm.Edge>[vertices];
        for (var i = 0; i < vertices; i++)
        {
            graph[i] = new List<DijkstraAlgorithm.Edge>();
        }

        graph[0].Add(new DijkstraAlgorithm.Edge(1, 5));
        graph[1].Add(new DijkstraAlgorithm.Edge(2, 3));

        
        var result = DijkstraAlgorithm.Dijkstra(graph, 0);

        
        Assert.Equal(0, result[0]);
    }

    [Fact]
    public void Dijkstra_ReturnsMaxValue_ForUnreachableVertex()
    {
        
        const int vertices = 3;
        var graph = new List<DijkstraAlgorithm.Edge>[vertices];
        for (var i = 0; i < vertices; i++)
        {
            graph[i] = new List<DijkstraAlgorithm.Edge>();
        }

        // Вершина 0 соединена только с вершиной 1
        graph[0].Add(new DijkstraAlgorithm.Edge(1, 5));
        // Вершина 2 недостижима

        
        var result = DijkstraAlgorithm.Dijkstra(graph, 0);

        
        Assert.Equal(int.MaxValue, result[2]);
    }

    [Fact]
    public void Dijkstra_ReturnsCorrectDistances_ForLinearGraph()
    {
        
        const int vertices = 4;
        var graph = new List<DijkstraAlgorithm.Edge>[vertices];
        for (var i = 0; i < vertices; i++)
        {
            graph[i] = new List<DijkstraAlgorithm.Edge>();
        }

        // Создаем линейный граф: 0 -> 1 -> 2 -> 3
        graph[0].Add(new DijkstraAlgorithm.Edge(1, 2));
        graph[1].Add(new DijkstraAlgorithm.Edge(2, 3));
        graph[2].Add(new DijkstraAlgorithm.Edge(3, 1));

        // Ожидаемые расстояния от вершины 0:
        // 0: 0, 1: 2, 2: 5, 3: 6
        var expected = new[] { 0, 2, 5, 6 };

        
        var result = DijkstraAlgorithm.Dijkstra(graph, 0);

        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Dijkstra_ReturnsCorrectDistances_ForSingleNodeGraph()
    {
        
        const int vertices = 1;
        var graph = new List<DijkstraAlgorithm.Edge>[vertices];
        for (var i = 0; i < vertices; i++)
        {
            graph[i] = new List<DijkstraAlgorithm.Edge>();
        }

        // Ожидаемое расстояние от вершины 0:
        // 0: 0
        var expected = new[] { 0 };

        
        var result = DijkstraAlgorithm.Dijkstra(graph, 0);

        
        Assert.Equal(expected, result);
    }
}