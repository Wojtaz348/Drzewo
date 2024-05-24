using System;

public class Node
{
    public int Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node(int value)
    {
        Value = value;
    }
}

public class BinaryTree
{
    private Node root;

    public BinaryTree()
    {
        root = null;
    }

    public void Add(int value)
    {
        root = AddRecursive(root, value);
    }

    private Node AddRecursive(Node node, int value)
    {
        if (node == null)
        {
            return new Node(value);
        }

        if (value % 2 == 0 && node.Left == null) // Jeśli wartość jest parzysta i lewa gałąź jest pusta
        {
            node.Left = new Node(value);
        }
        else if (value % 2 != 0 && node.Right == null) // Jeśli wartość jest nieparzysta i prawa gałąź jest pusta
        {
            node.Right = new Node(value);
        }
        else
        {
            // Jeśli obie gałęzie są pełne, dodajemy nowy węzeł na głębszych poziomach
            if (value % 2 == 0)
            {
                node.Left = AddRecursive(node.Left, value);
            }
            else
            {
                node.Right = AddRecursive(node.Right, value);
            }
        }

        return node;
    }

    public bool Contains(int value)
    {
        return ContainsRecursive(root, value);
    }

    private bool ContainsRecursive(Node node, int value)
    {
        if (node == null)
        {
            return false;
        }

        if (node.Value == value)
        {
            return true;
        }

        if (value % 2 == 0)
        {
            return ContainsRecursive(node.Left, value);
        }
        else
        {
            return ContainsRecursive(node.Right, value);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var tree = new BinaryTree();

        
        tree.Add(2);
        tree.Add(3); 
        tree.Add(4); 

        
        Console.WriteLine(tree.Contains(4)); 
        Console.WriteLine(tree.Contains(6)); 
    }
}
