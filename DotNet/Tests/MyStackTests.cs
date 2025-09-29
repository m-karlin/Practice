using App.Structures;

namespace App.Tests;

public class MyStackTests
{
    [Fact]
    public void Push_AddsItemToStack()
    {
        var stack = new MyStack(4);
        
        stack.Push(1);
        
        Assert.False(stack.IsEmpty());
        Assert.Equal(1, stack.Count);
    }
    
    [Fact]
    public void Pop_ReturnsLastPushedItem()
    {
        var stack = new MyStack(4);
        stack.Push(1);
        stack.Push(2);
        
        var result = stack.Pop();
        
        Assert.Equal(2, result);
        Assert.Equal(1, stack.Count);
    }
    
    [Fact]
    public void Pop_ThrowsException_WhenStackIsEmpty()
    {
        var stack = new MyStack(4);
        
        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }
    
    [Fact]
    public void Peek_ReturnsTopItem_WithoutRemovingIt()
    {
        var stack = new MyStack(4);
        stack.Push(1);
        stack.Push(2);
        
        var result = stack.Peek();
        
        Assert.Equal(2, result);
        Assert.Equal(2, stack.Count); // Count should remain the same
    }
    
    [Fact]
    public void Peek_ThrowsException_WhenStackIsEmpty()
    {
        var stack = new MyStack(4);
        
        Assert.Throws<InvalidOperationException>(() => stack.Peek());
    }
    
    [Fact]
    public void IsEmpty_ReturnsTrue_WhenStackIsEmpty()
    {
        var stack = new MyStack(4);
        
        Assert.True(stack.IsEmpty());
    }
    
    [Fact]
    public void IsEmpty_ReturnsFalse_WhenStackHasItems()
    {
        var stack = new MyStack(4);
        stack.Push(1);
        
        Assert.False(stack.IsEmpty());
    }
    
    [Fact]
    public void Count_ReturnsCorrectNumberOfItems()
    {
        var stack = new MyStack(4);
        
        Assert.Equal(0, stack.Count);
        
        stack.Push(1);
        Assert.Equal(1, stack.Count);
        
        stack.Push(2);
        Assert.Equal(2, stack.Count);
        
        stack.Pop();
        Assert.Equal(1, stack.Count);
        
        stack.Pop();
        Assert.Equal(0, stack.Count);
    }
    
    [Fact]
    public void Push_ResizesArray_WhenCapacityIsExceeded()
    {
        var stack = new MyStack(2); // Initial capacity of 2
        stack.Push(1);
        stack.Push(2);
        
        stack.Push(3); // This should trigger a resize
        
        Assert.Equal(3, stack.Count);
        Assert.Equal(3, stack.Pop());
    }
}