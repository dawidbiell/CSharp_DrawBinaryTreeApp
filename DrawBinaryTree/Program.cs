
using BinaryTreeLib;


Graph binaryTree = new Graph();
int levels;
do
{

    Console.WriteLine("\nSet number of levels of the tree:");
    bool isNumber = Int32.TryParse(Console.ReadLine(), out levels);
    if (!isNumber)
    {
        Console.WriteLine("You did not set a number!");
        goto Reapet;
    }

    binaryTree.CreateTree(2);
    

Reapet:
    Console.WriteLine("Do you want to repeat?[y/n]");
} while (Console.ReadLine().Length>0) ;

