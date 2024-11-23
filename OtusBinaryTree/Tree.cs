namespace OtusBinaryTree
{
	internal class Tree
	{
		public TreeNode Root { get; set; }
		public void SearchNode()
		{
			Console.WriteLine("Введите размер заработной платы искомого сотрудника");
			var salary = IntegerInput();
			var node = Find(salary, Root);
			if (node != null) Console.WriteLine(node.Value.Name);
			else Console.WriteLine("Сотрудник с такой заработной платой не найден");
		}
		public TreeNode InputTree()
		{
			while (true)
			{
				var employee = new Employee();
				string reply;
				Console.WriteLine("Введите имя, затем зарплату сотрудника");

				reply = Console.ReadLine();
				if (reply == string.Empty) { break; }
				else { employee.Name = reply; }

				employee.Salary = IntegerInput();
				AddNode(new TreeNode() { Value = employee }, Root);
			}
			return Root;
		}
		public void AddNode(TreeNode nodeToAdd, TreeNode rootNode = null)
		{
			if (Root == null) { Root = nodeToAdd; return; }

			if (nodeToAdd.Value.Salary < rootNode.Value.Salary)
			{
				if (rootNode.Left != null)
				{
					AddNode(nodeToAdd, rootNode.Left);
				}
				else
				{
					rootNode.Left = nodeToAdd;
				}
			}
			else
			{
				if (rootNode.Right != null)
				{
					AddNode(nodeToAdd, rootNode.Right);
				}
				else
				{
					rootNode.Right = nodeToAdd;
				}
			}
		}
		public void Inorder(TreeNode node)
		{
			if(node != null)
			{
				Inorder(node.Left);
				Console.WriteLine($"{node.Value.Name} - {node.Value.Salary}");
				Inorder(node.Right);
			}
		}
		public TreeNode Find(int salary, TreeNode node)
		{
			if (salary < node.Value.Salary)
			{
				if (node.Left != null)
				{
					return Find(salary, node.Left);
				}

				return null;
			}
			if (salary > node.Value.Salary)
			{
				if (node.Right != null)
				{
					return Find(salary, node.Right);
				}

				return null;
			}

			return node;
		}
		private int IntegerInput()
		{
			int result;
			while (true)
			{
				var input = Console.ReadLine();
				if (!int.TryParse(input, out result))
				{
					Console.WriteLine("Невозможно перевести ввод в int, введите число заново");
					continue;
				}
				else break;
			}
			return result;
		}
	}
}
