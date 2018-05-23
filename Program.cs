using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitFlyerTest
{
    class Program
    {
        static void Main(string[] args)
        {

            int blocksize = 1000000; //total bytes of blocksize		
            double answer500000bytes = 13.4376;
            double answer1byte = 0.00002687520;// (13.4376 / 500000)
            int blocks = 1;
            double answer = 0;
            int[] trnsctn = { 57247, 98732, 134928, 77275, 29240, 15440, 70820, 139603, 63718, 143807, 190457, 40572 };
            int sum = 0;
            for (int i = 0; i < trnsctn.Length; i++)
            {
                sum += trnsctn[i];
                if (sum == blocksize) { answer += (answer500000bytes * 2); blocks += 1; sum = 0; }
                else if (sum == 500000) { answer += answer500000bytes ; blocks += 1; sum = 0; }
                else if (sum > blocksize) { i = i - 1; sum = sum - trnsctn[i]; answer += sum * answer1byte; blocks += 1; sum = 0; }
                else { }
            }
            Console.WriteLine("blocks: " + blocks + ", maximum Rewards:" + answer);
            Console.ReadLine();
        }
    }
}
