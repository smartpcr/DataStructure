using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructure.BinaryTrees;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
	[TestClass]
	public class ReconstructTreeTest
	{
		[TestMethod]
		public void CanReconstructTree()
		{
			const string inOrderSeq = "FBAEHCDIG";
			const string preOrderSeq = "HBFEACDGI";
			BinaryTree<char> tree = BinaryTreeBuilder.BuildTree(inOrderSeq, preOrderSeq);
			Assert.AreEqual('H', tree.Value);

			Assert.AreEqual('B', tree.Left.Value);
			Assert.AreEqual('F',tree.Left.Left.Value);
			Assert.AreEqual('E',tree.Left.Right.Value);
			Assert.AreEqual('A',tree.Left.Right.Left.Value);

			Assert.AreEqual(tree.Right.Value, 'C');
			Assert.AreEqual(tree.Right.Right.Value, 'D');
			Assert.AreEqual(tree.Right.Right.Right.Value, 'G');
			Assert.AreEqual(tree.Right.Right.Right.Left.Value, 'I');
		}

		private BinaryTree<char> CreateUniqueTree()
		{
			return new BinaryTree<char>(
				'H',
				new BinaryTree<char>(
					'B',
					new BinaryTree<char>('F'),
					new BinaryTree<char>(
						'E',
						new BinaryTree<char>('A'),
						null)),
				new BinaryTree<char>(
					'C',
					null,
					new BinaryTree<char>(
						'D',
						null,
						new BinaryTree<char>(
							'G',
							new BinaryTree<char>('I'),
							null))));
		}
	}
}
