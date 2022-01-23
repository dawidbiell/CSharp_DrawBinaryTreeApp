
using BinaryTreeLib;


BinaryTree binaryTree;
int levels;
string figure;
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
    binaryTree.Draw();



Reapet:
    Console.WriteLine("Do you want to repeat?[Y-any char, N-Enter key]");
} while (Console.ReadLine().Length>0) ;

