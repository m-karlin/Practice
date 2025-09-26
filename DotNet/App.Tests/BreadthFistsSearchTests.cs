using App.Algorithms;

namespace App.Tests
{
    public class BreadthFistsSearchTests
    {
        [Fact]
        public void TryFindNode_ExistingNodeInTreeWithoutCycles_ReturnsTrueAndCorrectNode()
        {
            // Arrange
            var rootId = Guid.NewGuid();
            var node2Id = Guid.NewGuid();
            var node3Id = Guid.NewGuid();
            var node4Id = Guid.NewGuid();
            
            var root = new BreadthFistsSearch.Node<int>(rootId);
            var node2 = new BreadthFistsSearch.Node<int>(node2Id);
            var node3 = new BreadthFistsSearch.Node<int>(node3Id);
            var node4 = new BreadthFistsSearch.Node<int>(node4Id);

            root.AddChild(node2);
            node2.AddChild(node3);
            root.AddChild(node4);

            // Act
            var result = root.TryFindNode(node3Id, out var resultNode);

            // Assert
            Assert.True(result);
            Assert.NotNull(resultNode);
            Assert.Equal(node3Id, resultNode.Id);
        }

        [Fact]
        public void TryFindNode_NonExistingNodeInTreeWithoutCycles_ReturnsFalse()
        {
            // Arrange
            var rootId = Guid.NewGuid();
            var node2Id = Guid.NewGuid();
            var node3Id = Guid.NewGuid();
            var node4Id = Guid.NewGuid();
            
            var root = new BreadthFistsSearch.Node<int>(rootId);
            var node2 = new BreadthFistsSearch.Node<int>(node2Id);
            var node3 = new BreadthFistsSearch.Node<int>(node3Id);
            var node4 = new BreadthFistsSearch.Node<int>(node4Id);

            root.AddChild(node2);
            node2.AddChild(node3);
            root.AddChild(node4);

            // Act
            var result = root.TryFindNode(Guid.NewGuid(), out var resultNode);

            // Assert
            Assert.False(result);
            Assert.Null(resultNode);
        }

        [Fact]
        public void TryFindNode_RootNode_ReturnsTrueAndCorrectNode()
        {
            // Arrange
            var rootId = Guid.NewGuid();
            var node2Id = Guid.NewGuid();
            var node3Id = Guid.NewGuid();
            var node4Id = Guid.NewGuid();
            
            var root = new BreadthFistsSearch.Node<int>(rootId);
            var node2 = new BreadthFistsSearch.Node<int>(node2Id);
            var node3 = new BreadthFistsSearch.Node<int>(node3Id);
            var node4 = new BreadthFistsSearch.Node<int>(node4Id);

            root.AddChild(node2);
            node2.AddChild(node3);
            root.AddChild(node4);

            // Act
            var result = root.TryFindNode(rootId, out var resultNode);

            // Assert
            Assert.True(result);
            Assert.NotNull(resultNode);
            Assert.Equal(rootId, resultNode.Id);
        }

        [Fact]
        public void TryFindNode_ExistingNodeInTreeWithCycles_ReturnsTrueAndCorrectNode()
        {
            // Arrange
            var rootId = Guid.NewGuid();
            var node2Id = Guid.NewGuid();
            
            var root = new BreadthFistsSearch.Node<int>(rootId);
            var node2 = new BreadthFistsSearch.Node<int>(node2Id);

            root.AddChild(node2);
            // Cycle
            node2.AddChild(root);

            // Act
            var result = root.TryFindNode(node2Id, out var resultNode);

            // Assert
            Assert.True(result);
            Assert.NotNull(resultNode);
            Assert.Equal(node2Id, resultNode.Id);
        }

        [Fact]
        public void TryFindNode_NonExistingNodeInTreeWithCycles_ReturnsFalse()
        {
            // Arrange
            var rootId = Guid.NewGuid();
            var node2Id = Guid.NewGuid();
            
            var root = new BreadthFistsSearch.Node<int>(rootId);
            var node2 = new BreadthFistsSearch.Node<int>(node2Id);

            root.AddChild(node2);
            // Cycle
            node2.AddChild(root);

            // Act
            var result = root.TryFindNode(Guid.NewGuid(), out var resultNode);

            // Assert
            Assert.False(result);
            Assert.Null(resultNode);
        }

        [Fact]
        public void TryFindNode_InTreeWithOnlyRootNode_ReturnsTrueAndCorrectNode()
        {
            // Arrange
            var rootId = Guid.NewGuid();
            var root = new BreadthFistsSearch.Node<int>(rootId);

            // Act
            var result = root.TryFindNode(rootId, out var resultNode);

            // Assert
            Assert.True(result);
            Assert.NotNull(resultNode);
            Assert.Equal(rootId, resultNode.Id);
        }

        [Fact]
        public void TryFindNode_NonExistingNodeInTreeWithOnlyRootNode_ReturnsFalse()
        {
            // Arrange
            var rootId = Guid.NewGuid();
            var root = new BreadthFistsSearch.Node<int>(rootId);

            // Act
            var result = root.TryFindNode(Guid.NewGuid(), out var resultNode);

            // Assert
            Assert.False(result);
            Assert.Null(resultNode);
        }
    }
}