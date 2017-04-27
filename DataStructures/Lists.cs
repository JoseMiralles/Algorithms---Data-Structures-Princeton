using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class Lists
    {
        /// <summary>
        /// This list is defined in page 68 of the book.
        /// </summary>
        public class SingleLinkList
        {
            public class SingleLinkItemPointer
            {
                public int item { get; set; }
                public SingleLinkItemPointer next { get; set; }
                /// <summary>
                /// This is a simple list item that points to the next item.
                /// </summary>
                public SingleLinkItemPointer(int item, SingleLinkItemPointer nextItem)
                {
                    this.item = item;
                    this.next = nextItem;
                }
            }

            /// <summary>
            /// Searches for the pointer containing the given item in the given list recursevely.
            /// </summary>
            /// <param name="pointer"></param>
            /// <param name="item"></param>
            /// <returns></returns>
            public SingleLinkItemPointer SearchList(SingleLinkItemPointer pointer, int item)
            {
                //End of the list, the item is not in it, return null.
                if (pointer == null) return null;
                //Item found, return it's pointer.
                if (pointer.item == item) return pointer;
                //Recall this same function passing in the next item in the list linked by the given pointer.
                else return (SearchList (pointer.next, item));
            }


            public void InsertItem(SingleLinkItemPointer pointer, int item)
            {
                SingleLinkItemPointer p; //Temporary pointer.
                //p = new SingleLinkItemPointer();
            }
        }


    }
}
