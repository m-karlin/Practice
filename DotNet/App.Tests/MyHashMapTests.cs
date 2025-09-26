using App.Structures;
using Xunit;

namespace App.Tests;

public class MyHashMapTests
{
    [Fact]
    public void Set_AddsNewItem_WhenKeyDoesNotExist()
    {
        // Arrange
        var hashMap = new MyHashMap<int>();
        
        // Act
        hashMap.Set("key1", 100);
        
        // Assert
        var result = hashMap.TryGetValue("key1", out var value);
        Assert.True(result);
        Assert.Equal(100, value);
        Assert.Equal(1, hashMap.Count);
    }
    
    [Fact]
    public void Set_UpdatesExistingItem_WhenKeyAlreadyExists()
    {
        // Arrange
        var hashMap = new MyHashMap<int>();
        hashMap.Set("key1", 100);
        
        // Act
        hashMap.Set("key1", 200); // Update existing key
        
        // Assert
        var result = hashMap.TryGetValue("key1", out var value);
        Assert.True(result);
        Assert.Equal(200, value);
        Assert.Equal(1, hashMap.Count); // Count should remain the same
    }
    
    [Fact]
    public void TryGetValue_ReturnsTrueAndValue_WhenKeyExists()
    {
        // Arrange
        var hashMap = new MyHashMap<string>();
        hashMap.Set("key1", "value1");
        
        // Act
        var result = hashMap.TryGetValue("key1", out var value);
        
        // Assert
        Assert.True(result);
        Assert.Equal("value1", value);
    }
    
    [Fact]
    public void TryGetValue_ReturnsFalse_WhenKeyDoesNotExist()
    {
        // Arrange
        var hashMap = new MyHashMap<int>();
        hashMap.Set("key1", 100);
        
        // Act
        var result = hashMap.TryGetValue("nonexistent", out var value);
        
        // Assert
        Assert.False(result);
        Assert.Equal(default(int), value);
    }
    
    [Fact]
    public void Count_ReturnsCorrectNumberOfItems()
    {
        // Arrange
        var hashMap = new MyHashMap<int>();
        
        // Act & Assert
        Assert.Equal(0, hashMap.Count);
        
        hashMap.Set("key1", 100);
        Assert.Equal(1, hashMap.Count);
        
        hashMap.Set("key2", 200);
        Assert.Equal(2, hashMap.Count);
        
        hashMap.Set("key1", 150); // Update existing key
        Assert.Equal(2, hashMap.Count); // Count should remain the same
        
        hashMap.Set("key3", 300);
        Assert.Equal(3, hashMap.Count);
    }
    
    [Fact]
    public void Capacity_ReturnsInitialCapacity_WhenNoResizeOccurred()
    {
        // Arrange
        var hashMap = new MyHashMap<int>(16);
        
        // Act & Assert
        Assert.Equal(16, hashMap.Capacity);
    }
    
    [Fact]
    public void Set_ResizesHashMap_WhenLoadFactorThresholdIsExceeded()
    {
        // Arrange
        var hashMap = new MyHashMap<int>(2); // Initial capacity of 2
        // With a load factor threshold of 0.75, resize should happen when we add the 2nd item
        // (2 items in 2 buckets = 1.0 load factor, which exceeds 0.75)
        
        // Act
        hashMap.Set("key1", 100);
        
        // Check capacity and count before adding the 2nd item
        Assert.Equal(2, hashMap.Capacity);
        Assert.Equal(1, hashMap.Count);
        
        hashMap.Set("key2", 200); // This should trigger a resize
        
        // Assert
        Assert.Equal(4, hashMap.Capacity); // Capacity should double
        Assert.Equal(2, hashMap.Count);
        
        // Verify all items are still accessible
        Assert.True(hashMap.TryGetValue("key1", out var value1));
        Assert.Equal(100, value1);
        
        Assert.True(hashMap.TryGetValue("key2", out var value2));
        Assert.Equal(200, value2);
    }
    
    [Fact]
    public void Set_DoesNotResize_WhenLoadFactorIsBelowThreshold()
    {
        var hashMap = new MyHashMap<int>(4);
        
        hashMap.Set("key1", 100);
        hashMap.Set("key2", 200);
        hashMap.Set("key3", 300);
        
        Assert.Equal(8, hashMap.Capacity);
        Assert.Equal(3, hashMap.Count);
        
        hashMap.Set("key4", 400);
        
        Assert.Equal(8, hashMap.Capacity);
        Assert.Equal(4, hashMap.Count);
        
        Assert.True(hashMap.TryGetValue("key1", out var value1));
        Assert.Equal(100, value1);
        
        Assert.True(hashMap.TryGetValue("key2", out var value2));
        Assert.Equal(200, value2);
        
        Assert.True(hashMap.TryGetValue("key3", out var value3));
        Assert.Equal(300, value3);
        
        Assert.True(hashMap.TryGetValue("key4", out var value4));
        Assert.Equal(400, value4);
    }
    
    [Fact]
    public void Set_AddsMultipleItems_Correctly()
    {
        var hashMap = new MyHashMap<int>();
        
        hashMap.Set("key1", 100);
        hashMap.Set("key2", 200);
        hashMap.Set("key3", 300);
        
        Assert.True(hashMap.TryGetValue("key1", out var value1));
        Assert.Equal(100, value1);
        
        Assert.True(hashMap.TryGetValue("key2", out var value2));
        Assert.Equal(200, value2);
        
        Assert.True(hashMap.TryGetValue("key3", out var value3));
        Assert.Equal(300, value3);
        
        Assert.Equal(3, hashMap.Count);
    }
    
    [Fact]
    public void Set_HandlesCollisions_Correctly()
    {
        var hashMap = new MyHashMap<int>(2);
        
        hashMap.Set("key1", 100);
        hashMap.Set("key2", 200);
        
        Assert.True(hashMap.TryGetValue("key1", out var value1));
        Assert.Equal(100, value1);
        
        Assert.True(hashMap.TryGetValue("key2", out var value2));
        Assert.Equal(200, value2);
        
        Assert.Equal(2, hashMap.Count);
    }
    
    [Fact]
    public void TryGetValue_ReturnsDefaultValue_WhenKeyDoesNotExist_GenericType()
    {
        var hashMap = new MyHashMap<string>();
        
        var result = hashMap.TryGetValue("nonexistent", out var value);
        
        Assert.False(result);
        Assert.Null(value);
    }
}