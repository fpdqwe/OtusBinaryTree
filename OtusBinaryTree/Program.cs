namespace OtusBinaryTree
{
	internal class Program
	{
		private static Tree _tree;
		static void Main(string[] args)
		{
			int mode = 0;
			while (true)
			{
				if (mode == 0)
				{
					_tree = new Tree();
					_tree.InputTree();
					_tree.Inorder(_tree.Root);
					_tree.SearchNode();
				}
				if (mode == 1)
				{
					_tree.SearchNode();
				}
				if (mode == -1) break;
				mode = InputMenuMode();
			}
		}

		private static int InputMenuMode()
		{
			Console.WriteLine("0 - Перезапуск программы. 1 - Поиск зарплаты");
			var reply = Console.ReadLine();
			if (reply == "1") return 1;
			else if (reply == "0") return 0;
			else return -1;
		}
	}
}
