using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Models;

namespace DataStructures.ExtensionMethods
{
	public static class TreeNodesExtensions
	{
		public static int GetHeightOfTree(this TreeNode node)
		{
			if (node == null) return 0;
			else
			{
				int lHeight = GetHeightOfTree(node.Left);
				int rHeight = GetHeightOfTree(node.Right);
				return lHeight > rHeight ? lHeight + 1 : rHeight + 1;
			}
		}

		public static List<int> TraverseTreeLevelOrderSameLine(this TreeNode node)
		{
			if (node == null) return default(List<int>);
			else
			{
				List<int> items = new List<int>();
				Queue<TreeNode> vs = new Queue<TreeNode>();
				vs.Enqueue(node);

				while (vs.Count > 0)
				{
					var val = vs.Peek();
					vs.Dequeue();
					items.Add(val.Data);

					if (node.Left != null) vs.Enqueue(node.Left);
					if (node.Right != null) vs.Enqueue(node.Right);
				}

				return items;
			}
		}

		public static List<List<int>> TraverseTreeLevelOrderNewLine(this TreeNode node)
		{
			if (node == null) return default(List<List<int>>);

			List<List<int>> items = new List<List<int>>();
			Queue<TreeNode> vs = new Queue<TreeNode>();

			vs.Enqueue(node);
			vs.Enqueue(null);
			List<int> sameLevelElement = new List<int>();
			while (vs.Count > 0)
			{
				var val = vs.Peek();
				vs.Dequeue();

				if (val == null)
				{
					items.Add(sameLevelElement);
					sameLevelElement = new List<int>();
					if (vs.Count > 0) vs.Enqueue(null);
				}
				else
				{
					sameLevelElement.Add(val.Data);
					if (node.Left != null) vs.Enqueue(val.Left);
					if (node.Right != null) vs.Enqueue(val.Right);
				}
			}

			return items;
		}

		//public static IList<IList<int>> ZigZagLevelOrderNewLine(this TreeNode node)
		//{
		//	if (node == null) return default(IList<IList<int>>);

		//	List<List<int>> items = new List<List<int>>();
		//	Queue<TreeNode> vs = new Queue<TreeNode>();
		//	int counter = 0;

		//	vs.Enqueue(node);
		//	vs.Enqueue(null);

		//	List<int> sameLevelElement = new List<int>();
		//	while (vs.Count > 0)
		//	{
		//		var val = vs.Peek();
		//		vs.Dequeue();

		//		if (val == null)
		//		{
		//			items.Add(sameLevelElement);
		//			sameLevelElement = new List<int>();
		//			vs.Enqueue(null);
		//		}
		//		else
		//		{
		//			sameLevelElement.Add(val.Data);
		//			if (counter % 2 != 0)
		//			{
		//				if (node.Left != null) vs.Enqueue(node.Left);
		//				if (node.Right != null) vs.Enqueue(node.Right);
		//			}
		//			else if (counter == 1 || counter % 2 == 0)
		//			{
		//				if (node.Right != null) vs.Enqueue(node.Right);
		//				if (node.Left != null) vs.Enqueue(node.Left);
		//			}
		//		}
		//		counter++;
		//	}
		//	return (IList<IList<int>>)items;
		//}

		public static bool IsTreeSymmetric(this TreeNode node)
		{
			return IsSubTreeSymmetric(node.Left, node.Right);
		}

		public static bool IsSameTree(TreeNode p, TreeNode q)
		{
			if (p == null && q == null) return true;
			if (p != null && q != null && p.Data == q.Data)
			{
				return (IsSameTree(p.Left, q.Left) && IsSameTree(p.Right, q.Right));
			}
			return false;
		}

		private static bool IsSubTreeSymmetric(TreeNode node1, TreeNode node2)
		{
			if (node1 == null && node2 == null)
				return true;

			if (node1 != null && node2 != null
				&& node1.Data == node2.Data)
				return (IsSubTreeSymmetric(node1.Left, node2.Right)
						&& IsSubTreeSymmetric(node1.Right, node2.Left));

			return false;
		}
	}
}
