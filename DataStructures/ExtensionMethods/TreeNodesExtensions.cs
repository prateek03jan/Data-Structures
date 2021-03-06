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
		
		/**********************************************************
		Algo - 
			Step 1 : If node is not present, return 0
			Step 2 : Calculate the height recursively of the right tree
			Step 3 : Calculate the height recursively of the left tree
			Step 4 : Check for the greater height and return greater height + 1
			
			+1 is added to add the root node height
		**********************************************************/
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
		
		
		/**********************************************************
		Algo -
			1. If both tree nodes are null, return true!
			2. If both are not null and root nodes are equal root nodes
			are equal, then call the same method to calculate the tree height
			recursively for the left nodes and right nodes
		**********************************************************/
		public static bool IsSameTree(TreeNode p, TreeNode q)
		{
			if (p == null && q == null) return true;
			if (p != null && q != null && p.Data == q.Data)
			{
				return (IsSameTree(p.Left, q.Left) && IsSameTree(p.Right, q.Right));
			}
			return false;
		}
		
		public List<int> GetTopView(Node root)
		{
			Dictionary<int, List<int>> keyValuePairs = new Dictionary<int, List<int>>();
			int hDis = 0;
			TraverseVertically(keyValuePairs, hDis, node);
			List<int> answer = new List<int>();
			foreach(var item in keyValuePairs.OrderBy(key => key.Key))
			{
				answer.Add(item.Value[0]);
			}
			return answer;
		}
		
		public static List<List<int>> VerticalOrderTraversal(TreeNode node)
		{
			Dictionary<int, List<int>> keyValuePairs = new Dictionary<int, List<int>>();
			int hDis = 0;
			TraverseVertically(keyValuePairs, hDis, node);
			List<List<int>> answer = new List<List<int>>();
			foreach(var item in keyValuePairs.OrderBy(key => key.Key))
			{
				answer.Add(new List<int>(item.Value));
			}
			return answer;
		}
		
		private static void TraverseVertically(Dictionary<int, List<int>> kvp, int hDis, TreeNode node)
		{
			if(node == null) return;
			if(!kvp.ContainsKey(hDis)) kvp.Add(hDis, new List<int>());
			kvp[hDis].Add(node.Data);
			TraverseVertically(kvp, hDis - 1, node.Left);
			TraverseVertically(kvp, hDis + 1, node.Right);
		}

		public bool IsValidBST(TreeNode root)
		{
			if(root == null) return true;
			if(root.Left != null && root.Left.Data >= root.val) return false;
			if(root.right != null && root.Right.Data <= root.val) return false;
			if(!IsValidBST(root.Left) || !IsValidBST(root.Right)) return false;

			return true;
		}
		
		public static bool IsTreeSymmetric(this TreeNode node)
		{
			return IsSubTreeSymmetric(node.Left, node.Right);
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
