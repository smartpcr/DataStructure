using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructure.BinaryTrees
{
	public class Traversal
	{
		/// <summary>
		/// uses stack, no recursive calls, node has parent pointer
		/// time complexity = O(n)
		/// space complexity = O(h)
		/// </summary>
		/// <param name="tree"></param>
		/// <returns></returns>
		public string InorderTraversal(BinaryTree<int> tree)
		{
			if (tree == null)
				throw new ArgumentException("tree is empty", nameof(tree));

			var sb = new StringBuilder();
			var stack = new Stack<BinaryTree<int>>();
			stack.Push(tree);
//			BinaryTree<int> nodeWhoseLeftChildVisited = null;
//			BinaryTree<int> nodeWhoseRightChildVisited = null;
			BinaryTree<int> prevNodeVisited = null;
			BinaryTree<int> prevParentVisited = null;
			while (stack.Count>0)
			{
				var current = stack.Pop();
				if (current!=prevNodeVisited)
				{
					while (current.Left != null && current.Left!=prevNodeVisited && 
						current.Left!=prevParentVisited)
					{
						stack.Push(current);
						current = current.Left;
					}
				}
				Assert.IsNotNull(current);
				WriteNode(sb, current);
				prevNodeVisited = current;
				if (current.Parent!=null)
				{
					if (current == current.Parent.Right)
					{
						var prevRightChild = current;
						while (prevRightChild.Parent!=null && prevRightChild==prevRightChild.Parent.Right)
						{
							prevRightChild = prevRightChild.Parent;
							prevParentVisited = prevRightChild;
						}
						
					}
				}
				
				if (current.Right != null)
				{
					stack.Push(current.Right);
				}
			}

			return sb.ToString();
		}

		/// <summary>
		/// do not use stack or recursive call, the node have parent pointer
		/// time complexity = O(n)
		/// space complexity = O(1)
		/// </summary>
		/// <param name="tree"></param>
		/// <returns></returns>
		public string InorderTraversal2(BinaryTree<int> tree)
		{
			BinaryTree<int> prev = null;
			StringBuilder sb = new StringBuilder();
			BinaryTree<int> current = tree;
			while (current!=null)
			{
				BinaryTree<int> next = null;
				if (current.Parent == prev)
				{
					// we came down to curr from prev 
					if (current.Left != null)
					{
						next = current.Left;
					}
					else
					{
						WriteNode(sb, current);
						next = current.Right ?? current.Parent;
					}
				}
				else if (current.Left == prev)
				{
					// we came up to curr from its left child 
					WriteNode(sb, current);
					next = current.Right ?? current.Parent;
				}
				else
				{
					// done with both children, so move up
					next = current.Parent;
				}

				prev = current;
				current = next;
			}
			return sb.ToString();
		}

		private static void WriteNode(StringBuilder sb, BinaryTree<int> current)
		{
			if (sb.Length > 0)
				sb.Append(",");
			sb.Append(current.Value);
		}
	}
}
