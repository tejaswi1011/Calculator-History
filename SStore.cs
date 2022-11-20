using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal sealed class SStore
    {
        private static int privatePageNum = 0;
        public static int page

        { 
            get

            {
                return privatePageNum;

            }

        }



        public static void set(int p)

        {

            privatePageNum = p;

        }
    }
}
