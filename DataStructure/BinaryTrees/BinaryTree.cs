namespace DataStructure.BinaryTrees
{
	public class BinaryTree<T> 
	{
		public T Value { get; set; }

		public BinaryTree<T> Parent { get; set; }

		public BinaryTree<T> Left { get; set; }

		public BinaryTree<T> Right { get; set; }

		public BinaryTree(T value)
		{
			this.Value = value;
		}

		public BinaryTree(T value, T leftValue, T rightValue)
			: this(value)
		{
			if (leftValue != null)
			{
				this.Left=new BinaryTree<T>(leftValue);
				this.Left.Parent = this;
			}
			if (rightValue != null)
			{
				this.Right=new BinaryTree<T>(rightValue);
				this.Right.Parent = this;
			}
		}

		public BinaryTree(T value, BinaryTree<T> left, BinaryTree<T> right)
			: this(value)
		{
			this.Left = left;
			if (this.Left != null)
			{
				this.Left.Parent = this;
			}
			this.Right = right;
			if (this.Right != null)
			{
				this.Right.Parent = this;
			}
		}

		public override string ToString()
		{
			return this.Value.ToString();
		}
	}
}
