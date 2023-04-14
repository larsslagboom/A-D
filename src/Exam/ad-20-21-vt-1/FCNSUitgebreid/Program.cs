using System;

namespace AD
{
    class Program
    {
        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //
        // In de opgave staat dat hier de method
        //    FirstChildNextSibling<int> CreateFirstChildNextSibling_Practicum()
        // gemaakt moet worden.C:\Users\lars\Google Drive\Windesheim\jaar 3\A&D\CODE\ad (1)\src\Exam\ad-20-21-vt-1\FCNSUitgebreid\Program.cs
        // Dit is een foutje. Implementeer in plaats daarvan de method
        //    IFirstChildNextSibling<int> CreateFirstChildNextSibling_Practicum()
        // in FCNSUitgebreidBuilder.cs
        // 
        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        static void Main(string[] args)
        {
            // Part a
            IFirstChildNextSibling<int> tree = DSBuilder.CreateFirstChildNextSibling_Practicum();

            // Part b
            // -- your test code --

            // Part c
            // -- your test code --
            for (int i = 2; i < 9; i++)
            {
                Console.Write($"Parent of {i}: ");
                if(tree.FindParent(i).GetData().Equals(default))
                {
                    Console.Write("null");
                }
                else
                {
                    Console.Write(tree.FindParent(i).GetData().ToString());
                }
                Console.WriteLine();
            }
        }
    }
}