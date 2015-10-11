using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructure.BinaryTrees
{
	public class BinaryTreeBuilder
	{
		public static BinaryTree<char> BuildTree(string inOrderSeq, string preOrderSeq)
		{
			Assert.IsFalse(string.IsNullOrEmpty(inOrderSeq));
			Assert.IsFalse(string.IsNullOrEmpty(preOrderSeq));
			Assert.IsTrue(inOrderSeq.Length>0);
			Assert.IsTrue(preOrderSeq.Length > 0);
			BinaryTree<char> root = new BinaryTree<char>(preOrderSeq[0]);
			string nextLeftInOrderSeq, nextRightInOrderSeq;
			string nextLeftPreOrderSeq, nextRightPreOrderSeq;
			SplitInOrderSequence(inOrderSeq, preOrderSeq[0], out nextLeftInOrderSeq, out nextRightInOrderSeq);
			SplitPreOrderSequence(preOrderSeq, nextLeftInOrderSeq, nextRightInOrderSeq, out nextLeftPreOrderSeq, out nextRightPreOrderSeq);
			if (nextLeftInOrderSeq.Length > 0)
			{
				root.Left = BuildTree(nextLeftInOrderSeq, nextLeftPreOrderSeq);
			}
			if (nextRightInOrderSeq.Length > 0)
			{
				root.Right = BuildTree(nextRightInOrderSeq, nextRightPreOrderSeq);
			}
			return root;

		}

		private static void SplitInOrderSequence(string inOrderSeq, char prev,
			out string leftInOrderSeq, out string rightInOrderSeq)
		{
			List<char> left = new List<char>();
			List<char> right = new List<char>();
			bool addToLeft = true;
			foreach (var t in inOrderSeq)
			{
				if (t == prev)
				{
					addToLeft = false;
					continue;
				}
				if (addToLeft)
					left.Add(t);
				else
					right.Add(t);
			}
			leftInOrderSeq=new string(left.ToArray());
			rightInOrderSeq=new string(right.ToArray());
		}

		private static void SplitPreOrderSequence(string preOrderSeq, 
			string leftInOrderSeq, string rightInOrderSeq,
			out string leftPreOrderSeq, out string rightPreOrderSeq)
		{
			List<char> left = new List<char>();
			List<char> right = new List<char>();
			foreach (var c in preOrderSeq)
			{
				if(leftInOrderSeq.Contains(c))
					left.Add(c);
				if(rightInOrderSeq.Contains(c))
					right.Add(c);
			}
			leftPreOrderSeq = new string(left.ToArray());
			rightPreOrderSeq = new string(right.ToArray());
		}
		//
		//		private static string GetChildInOrderSeq(string inOrderSeq, char prev, char curr, out bool isOnLeftSide)
		//		{
		//			List<char> left=new List<char>();
		//			List<char> right = new List<char>();
		//			bool addToLeft = true;
		//			foreach (var t in inOrderSeq)
		//			{
		//				if (t == prev)
		//				{
		//					addToLeft = false;
		//					continue;
		//				}
		//				if (addToLeft)
		//					left.Add(t);
		//				else
		//					right.Add(t);
		//			}
		//			isOnLeftSide = left.Any(c => c.Equals(curr));
		//			return isOnLeftSide ? new string(left.ToArray()) : new string(right.ToArray());
		//		}
	}
}
