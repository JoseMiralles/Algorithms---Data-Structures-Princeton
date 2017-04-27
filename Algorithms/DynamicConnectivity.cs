using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// Starting from:
    /// https://www.youtube.com/watch?v=XxyG_aPHjvg&index=2&list=PLxc4gS-_A5VDXUIOPkJkwQKYiT2T1t0I8
    /// </summary>
    public static class DynamicConnectivity
    {
        /// <summary>
        /// these are the steps which the union find algorithms must take.
        /// </summary>
        public static int[,] commands = new int[,]
            { {4,3},{3,8},{6,5},{9,4},{2,1},{8,9},{5,0},{7,2},{6,1},{1,0},{6,7} };
        /// <summary>
        /// this is the length of the id array.
        /// </summary>
        public static int length = 10;

        /// <summary>
        /// Uses the given union find object to run the commands.
        /// </summary>
        /// <param name="algo"></param>
        /// <param name="commands"></param>
        public static void Run(IUnionFind algo, int[,] commands)
        {
            int x, y;
            for (int i = 0; i < commands.GetLength(0); i++)
            {
                x = commands[i, 0];
                y = commands[i, 1];
                if (algo.CheckIfConnected(x, y) == false)
                {
                    Console.WriteLine("CHECK:\t{0} and {1} are not connected.", x, y);
                    algo.CreateUnion(x, y);
                    Console.WriteLine("UNION:\t{0} and {1} where successfully connected.", x, y);
                }
                else Console.WriteLine("CHECK:\t{0} and {1} are already connected.", x, y);

            }
        }

        /// <summary>
        /// Simple interface to follow
        /// </summary>
        public interface IUnionFind
        {
            int[] id { get; set; }

            bool CheckIfConnected(int node1, int node2);
            void CreateUnion(int node1, int node2);
        }

        ///If the items have the same id, then they are connected.
        ///This runs at N^2, and so it's too inefficient
        public class QuickFindUF : IUnionFind
        {
            public int[] id { get; set; }

            public QuickFindUF(int length)
            {
                InitializeIdArray(length);
            }
            /// <summary>
            /// Assigns id = {0,1,2,3 ... n-1};
            /// Costs N array accesses.
            /// </summary>
            /// <param name="length"></param>
            private void InitializeIdArray(int length)
            {
                this.id = new int[length];
                for (int i = 0; i < length; i++)
                    id[i] = i;
            }

            /// <summary>
            /// Checks if the given nodes are connected. I.e.: same ids
            /// </summary>
            /// <returns>True if they are connected</returns>
            public virtual bool CheckIfConnected(int node1, int node2)
            {
                return (id[node1] == id[node2]);
            }
            
            ///This particular approach runs at N time.
            ///Which is too expensive and raises the total
            ///cost of accessing the array to N^2
            ///(Initialize runs at N time too).
            /// <summary>
            /// Creates an union between the two given nodes.
            /// </summary>
            public virtual void CreateUnion(int node1, int node2)
            {
                int node1ID = id[node1];
                int node2ID = id[node2];
                for (int i = 0; i < id.Length; i++)
                    ///If the id in the current position == the first id,
                    ///switch its value to the second id.
                    ///This would "merge" node1's group into node2's group.
                    if (id[i] == node1ID) id[i] = node2ID;
            }
        }

        //NOTE: this class extends the QuickFindUF class
        //NOTE: GetRoot runs at N time, wich can be slow if the tree has too many levels.
        ///https://www.youtube.com/watch?v=H0bkmI1Xsxg&list=PLxc4gS-_A5VDXUIOPkJkwQKYiT2T1t0I8&index=4
        ///The lowest item are "i" while the highest items or "roots" are id[id[id[...id[i]...]]]
        ///One encapsulation is added per level. Each node may have multiple childs.
        ///To create an union, we merge the root of node1 into the group of node2 by making the
        ///root of node1 a child of the root of node2.
        public class QuickUnionUF : QuickFindUF
        {
            public QuickUnionUF(int length):base(length)
            {
                
            }
            
            /// <summary>
            /// Gets the root node of the given node.
            /// </summary>
            /// <param name="i"></param>
            /// <returns></returns>
            protected virtual int GetRoot(int i)
            {
                ///Once i == id[i], we have reached the root.
                ///Rembember that roots are their  own parents.
                while (i != id[i])
                    i = id[i];
                return i;
            }

            /// <summary>
            /// Uses the get root method to see if they have the same root.
            /// </summary>
            /// <returns>true of they are connected</returns>
            public override bool CheckIfConnected(int node1, int node2)
            {
                return (GetRoot(node1) == GetRoot(node2));
            }

            /// <summary>
            /// Sets the root of node1 to the root of node2.
            /// </summary>
            public override void CreateUnion(int node1, int node2)
            {
                int node1Root = GetRoot(node1);
                int node2Root = GetRoot(node2);
                id[node1] = node2Root;
            }
        }

        ///To avoid adding to many levels to the trees, whe are going to weigh each tree
        ///so that we always merge the smaller one to the bigger one.
        ///This leads to a runtime of log(N) since thats the height of the 
        ///biggest tree possible.
        public class QuickUnionUFWeighted : QuickUnionUF
        {
            /// <summary>
            /// Stores the sizes of the trees.
            /// </summary>
            protected int[] size { get; set; }

            public QuickUnionUFWeighted(int lenght) : base(lenght)
            {
                ///The heigth of the tallest tree is proportional to the provided length.
                ///height = log(n) where n is the length of the id[] array.
                size = new int [ lenght ];
            }

            protected override int GetRoot(int i)
            {
                while (i != id[i])
                {
                    id[i] = id[id[i]]; //This assigns id[i] to the grandparent of i.
                    i = id[i];
                }
                return i;
            }

            public override void CreateUnion(int node1, int node2)
            {
                int root1 = GetRoot(node1);
                int root2 = GetRoot(node2);

                if (size[root1] < size[root2])
                {
                    id[root1] = root2;
                    size[root2] += size[root1];
                }
                else
                {
                    id[root2] = root1;
                    size[root1] += size[root2];
                }
            }
        }
    }
}
