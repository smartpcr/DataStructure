using System;
using DataStructure.BinaryTrees;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
	[TestClass]
	public class TraversalTest
	{
		[TestMethod]
		public void TestInorderTraversal()
		{
			const string expectedOrder = "28,271,0,6,561,17,3,314,2,401,641,1,257,6,271,28";
            var root = CreateBinaryTree();
			string inorderSeq = new Traversal().InorderTraversal(root);
			Assert.AreEqual(expectedOrder, inorderSeq);

			string inorderSeq2 = new Traversal().InorderTraversal2(root);
			Assert.AreEqual(expectedOrder, inorderSeq2);
		}

		private BinaryTree<int> CreateBinaryTree()
		{
			return new BinaryTree<int>(314,
				new BinaryTree<int>(
					6, 
					new BinaryTree<int>(
						271, 28, 0), 
					new BinaryTree<int>(
						561,
						null,
						new BinaryTree<int>(
							3,
							new BinaryTree<int>(17), 
							null))),
				new BinaryTree<int>(
					6, 
					new BinaryTree<int>(
						2, 
						null, 
						new BinaryTree<int>(
							1,
							new BinaryTree<int>(
								401,
								null,
								new BinaryTree<int>(641)), 
							new BinaryTree<int>(257))), 
					new BinaryTree<int>(
						271, 
						null, 
						new BinaryTree<int>(28))));
		}

		
	}
}
