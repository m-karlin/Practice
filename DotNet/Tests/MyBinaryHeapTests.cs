using App.Structures;
using Xunit;

namespace App.Tests;

public class MyBinaryHeapTests
{
    [Fact]
    public void Push_AddsItemToMaxHeap()
    {
        var heap = new MyBinaryHeap(10);
        
        heap.Push(5);
        
        Assert.Equal(5, heap.Pop());
    }
    
    [Fact]
    public void Pop_ReturnsMaxItem_FromMaxHeap()
    {
        var heap = new MyBinaryHeap(10);
        heap.Push(1);
        heap.Push(4);
        heap.Push(5);
        heap.Push(1);
        heap.Push(3);
        
        var result = heap.Pop();
        
        Assert.Equal(5, result);
    }
    
    [Fact]
    public void Pop_ReturnsItemsInDescendingOrder_FromMaxHeap()
    {
        var heap = new MyBinaryHeap(10);
        heap.Push(1);
        heap.Push(4);
        heap.Push(5);
        heap.Push(1);
        heap.Push(3);
        
        Assert.Equal(5, heap.Pop());
        Assert.Equal(4, heap.Pop());
        Assert.Equal(3, heap.Pop());
        Assert.Equal(1, heap.Pop());
        Assert.Equal(1, heap.Pop());
    }
    
    [Fact]
    public void Pop_ThrowsException_WhenMaxHeapIsEmpty()
    {
        var heap = new MyBinaryHeap(10);
        
        Assert.Throws<InvalidOperationException>(() => heap.Pop());
    }
    
    [Fact]
    public void Push_ThrowsException_WhenMaxHeapIsFull()
    {
        var heap = new MyBinaryHeap(2);
        heap.Push(1);
        heap.Push(2);
        
        Assert.Throws<InvalidOperationException>(() => heap.Push(3));
    }
    
    [Fact]
    public void Push_AddsItemToMinHeap()
    {
        var heap = new MyBinaryHeap(10, false);
        
        heap.Push(5);
        
        Assert.Equal(5, heap.Pop());
    }
    
    [Fact]
    public void Pop_ReturnsMinItem_FromMinHeap()
    {
        var heap = new MyBinaryHeap(10, false);
        heap.Push(5);
        heap.Push(1);
        heap.Push(3);
        heap.Push(4);
        heap.Push(2);
        
        var result = heap.Pop();
        
        Assert.Equal(1, result);
    }
    
    [Fact]
    public void Pop_ReturnsItemsInAscendingOrder_FromMinHeap()
    {
        var heap = new MyBinaryHeap(10, false);
        heap.Push(5);
        heap.Push(1);
        heap.Push(3);
        heap.Push(4);
        heap.Push(2);
        
        Assert.Equal(1, heap.Pop());
        Assert.Equal(2, heap.Pop());
        Assert.Equal(3, heap.Pop());
        Assert.Equal(4, heap.Pop());
        Assert.Equal(5, heap.Pop());
    }
    
    [Fact]
    public void Pop_ThrowsException_WhenMinHeapIsEmpty()
    {
        var heap = new MyBinaryHeap(10, false);
        
        Assert.Throws<InvalidOperationException>(() => heap.Pop());
    }
    
    [Fact]
    public void Push_ThrowsException_WhenMinHeapIsFull()
    {
        var heap = new MyBinaryHeap(2, false);
        heap.Push(1);
        heap.Push(2);
        
        Assert.Throws<InvalidOperationException>(() => heap.Push(3));
    }
    
    [Fact]
    public void PushAndPop_WorkCorrectly_WithDuplicateValues()
    {
        var heap = new MyBinaryHeap(10);
        heap.Push(3);
        heap.Push(1);
        heap.Push(3);
        heap.Push(2);
        heap.Push(3);
        
        Assert.Equal(3, heap.Pop());
        Assert.Equal(3, heap.Pop());
        Assert.Equal(3, heap.Pop());
        Assert.Equal(2, heap.Pop());
        Assert.Equal(1, heap.Pop());
    }
    
    [Fact]
    public void PushAndPop_WorkCorrectly_WithNegativeValues()
    {
        var heap = new MyBinaryHeap(10);
        heap.Push(-1);
        heap.Push(-5);
        heap.Push(0);
        heap.Push(-3);
        heap.Push(2);
        
        Assert.Equal(2, heap.Pop());
        Assert.Equal(0, heap.Pop());
        Assert.Equal(-1, heap.Pop());
        Assert.Equal(-3, heap.Pop());
        Assert.Equal(-5, heap.Pop());
    }
    
    [Fact]
    public void PushAndPop_WorkCorrectly_WithZero()
    {
        var heap = new MyBinaryHeap(10);
        heap.Push(0);
        heap.Push(1);
        heap.Push(-1);
        
        Assert.Equal(1, heap.Pop());
        Assert.Equal(0, heap.Pop());
        Assert.Equal(-1, heap.Pop());
    }
}