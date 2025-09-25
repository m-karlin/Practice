using App.Structures;
using Xunit;

namespace App.Tests;

public class MyLRUCacheTests
{
    [Fact]
    public void Get_ReturnsValue_WhenKeyExists()
    {
        var cache = new MyLRUCache(2);
        cache.Put(1, 1);
        cache.Put(2, 2);
        
        var result = cache.Get(1);
        
        Assert.Equal(1, result);
    }
    
    [Fact]
    public void Get_ReturnsMinusOne_WhenKeyDoesNotExist()
    {
        var cache = new MyLRUCache(2);
        cache.Put(1, 1);
        cache.Put(2, 2);
        
        var result = cache.Get(3);
        
        Assert.Equal(-1, result);
    }
    
    [Fact]
    public void Put_AddsNewItem_WhenCacheHasCapacity()
    {
        var cache = new MyLRUCache(2);
        cache.Put(1, 1);
        
        cache.Put(2, 2);
        
        Assert.Equal(1, cache.Get(1));
        Assert.Equal(2, cache.Get(2));
    }
    
    [Fact]
    public void Put_UpdatesExistingItem_WhenKeyAlreadyExists()
    {
        var cache = new MyLRUCache(2);
        cache.Put(1, 1);
        cache.Put(2, 2);
        
        cache.Put(1, 10); 
        
        Assert.Equal(10, cache.Get(1));
        Assert.Equal(2, cache.Get(2));
    }
    
    [Fact]
    public void Put_RemovesLeastRecentlyUsedItem_WhenCacheIsFull()
    {
        var cache = new MyLRUCache(2);
        cache.Put(1, 1);
        cache.Put(2, 2);
        cache.Get(1); 
        
        cache.Put(3, 3); 
        
        Assert.Equal(1, cache.Get(1));
        Assert.Equal(-1, cache.Get(2)); 
        Assert.Equal(3, cache.Get(3));
    }
    
    [Fact]
    public void Put_RemovesLeastRecentlyUsedItem_WhenAddingNewItemsToFullCache()
    {
        var cache = new MyLRUCache(2);
        cache.Put(1, 1);
        cache.Put(2, 2);
        
        cache.Put(3, 3); 
        
        Assert.Equal(-1, cache.Get(1));
        Assert.Equal(2, cache.Get(2));
        Assert.Equal(3, cache.Get(3));
    }
    
    [Fact]
    public void Get_MovesItemToHead_MakingItMostRecentlyUsed()
    {
        var cache = new MyLRUCache(2);
        cache.Put(1, 1);
        cache.Put(2, 2);
        cache.Put(3, 3);
        
        cache.Get(2);
        cache.Put(4, 4);
        
        Assert.Equal(-1, cache.Get(3));
        Assert.Equal(2, cache.Get(2));
        Assert.Equal(4, cache.Get(4));
    }
    
    [Fact]
    public void Put_MovesExistingItemToHead_MakingItMostRecentlyUsed()
    {
        var cache = new MyLRUCache(2);
        cache.Put(1, 1);
        cache.Put(2, 2);
        
        cache.Put(1, 10);
        cache.Put(3, 3);
        
        Assert.Equal(10, cache.Get(1));
        Assert.Equal(-1, cache.Get(2));
        Assert.Equal(3, cache.Get(3));
    }
}