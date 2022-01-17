
using BinaryTreeLib;


BinaryTree binaryTree;
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

    binaryTree = new BinaryTree(levels);


Reapet:
    Console.WriteLine("Do you want to repeat?[y/n]");
} while (Console.ReadLine().Length>0) ;

