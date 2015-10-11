using System.Collections.Generic;
using System.Diagnostics;
using DataStructure.Heaps;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
	[TestClass]
	public class HeapTest
	{
		[TestMethod]
		public void BuildMinHeap()
		{
			List<int> items = new List<int>()
			{
				11,28,314,3,156,561,401,359,271
			};
			var minHeap = new MinHeap<int>(items);
			Assert.AreEqual(3, minHeap.GetTop());
			var itemRemoved = minHeap.ExtractDominating();
			Assert.AreEqual(3, itemRemoved);
			Assert.AreEqual(11, minHeap.GetTop());

			var maxHeap = new MaxHeap<int>(items);
			Assert.AreEqual(561, maxHeap.GetTop());
			itemRemoved = maxHeap.ExtractDominating();
			Assert.AreEqual(561, itemRemoved);
			Assert.AreEqual(401, maxHeap.GetTop());
		}

	}
}
