using System;
using System.Collections.Generic;

namespace epi
{
	public class BTNode
	{
		public int data;

		private BTNode _left;
		public BTNode left
		{
			get {
				return _left;
			}
			set {
				_left = value;
				if (_left != null)
					_left.parent = this;
			}
		}

		private BTNode _right;
		public BTNode right
		{
			get {
				return _right;
			}
			set {
				_right = value;
				if (_right != null)
					_right.parent = this;
			}
		}

		public BTNode parent;

		public BTNode(int data)
		{
			this.data = data;
			this.parent = null;
		}

		public override string ToString ()
		{
			string result = "";
			int height = GetHeight (this);
			Console.WriteLine ("height = " + height);
			BTNode dummy = new BTNode (-1);
			List<BTNode> curLevel = new List<BTNode>();
			curLevel.Add (this);
			for (int i = 0; i < height; ++i) {
				string indent = new string ('\t', (int)Math.Pow (2, height - i - 1));
				string sep = new string ('\t', (int)Math.Pow (2, height - i));
				result += indent;
				List<BTNode> nextLevel = new List<BTNode> ();
				foreach (BTNode n in curLevel) {
					if (n == dummy)
						result += sep;
					else
						result += n.data.ToString() + sep;
					nextLevel.Add (n.left ?? dummy);
					nextLevel.Add (n.right ?? dummy);
				}
				result += '\n';
				curLevel = nextLevel;
			}
			return result;
		}

		private int GetHeight(BTNode node)
		{
			if (node == null)
				return 0;
			int leftHeight = GetHeight (node.left);
			int rightHeight = GetHeight (node.right);
			return 1 + Math.Max (leftHeight, rightHeight);
		}

        public static BTNode CreateMinimalBST(int[] arr)
        {
            return CreateMinimalBST (arr, 0, arr.Length - 1);
        }

        public static BTNode CreateMinimalBST(int[] arr, int left, int right)
        {
            if (left > right)
                return null;
            int mid = left + (right - left) / 2;
            BTNode n = new BTNode (arr [mid]);
            n.left = CreateMinimalBST (arr, left, mid - 1);
            n.right = CreateMinimalBST (arr, mid + 1, right);
            return n;
        }
	}
}

