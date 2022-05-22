namespace DataStructures.Models
{
	public class Node
	{
		public int Data { get; set; }
		public Node(int data = 0)
		{
			Data = data;
		}
	}

	public class LinkedNode : Node
	{
		public Node Next { get; set; }
		public LinkedNode(int data, Node next) : base(data)
		{
			Next = next;
		}
	}

	public class TreeNode : Node
	{
		public TreeNode Right { get; set; }
		public TreeNode Left { get; set; }
		public TreeNode(int data, TreeNode left, TreeNode right) : base(data)
		{
			Left = left;
			Right = right;
		}
	}
}
