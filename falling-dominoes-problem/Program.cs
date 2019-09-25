using System;
using System.Collections.Generic;
using System.Linq;

namespace falling_dominoes_problem
{
    class Program
    {

        /*
         * Given a string with the initial condition of dominoes, where:

            . represents that the domino is standing still
            L represents that the domino is falling to the left side
            R represents that the domino is falling to the right side

            Figure out the final position of the dominoes. If there are dominoes that get pushed on both ends, the force cancels out and that domino remains upright.

            Example:
            Input:  ..R...L..R.
            Output: ..RR.LL..RR
            Here is your starting point:

            class Solution(object):
              def pushDominoes(self, dominoes):
                # Fill this in.

            print Solution().pushDominoes('..R...L..R.')
            # ..RR.LL..RR
         *
         */


        static void Main(string[] args)
        {
            Console.Write("Enter input: ");

            string input = Console.ReadLine(); 

            Console.Write("Output: " );
            RunSimulation(input);
        }

        //this method should be named push Dominoes I guess. 
        private static void RunSimulation(string input)
        {

            int numberOfdominoes = input.Length;

            //easier to work with during loop.
            List<char> inputAsList = input.ToList();

            //Buffer the front and end with place holder X. Should first dominoe fall left or last dominoe fall right
            inputAsList.Insert(0, 'X');
            inputAsList.Add('X');

            List<char> tempHolding = new List<char>();

            //outer loop (front -> end) 
            for(int counter = 1; counter <=  numberOfdominoes ; counter++)
            {
                //Loop each dominoe. 
                //pass in the current dominoe and the dominoe to the Left and Right of the current.
                //If current dominoe is the first or the last - then use X for place holder as the end and remove X at end of processing. 


                tempHolding.AddRange(performCheck(

                inputAsList[counter - 1].ToString(),
                inputAsList[counter].ToString(),
                inputAsList[counter + 1].ToString()).ToList()

                            );


                //Store current state of dominoes 
                inputAsList[counter - 1] = tempHolding[0];
                inputAsList[counter] = tempHolding[1];
                inputAsList[counter + 1] = tempHolding[2];

                

                tempHolding.Clear();

                ////inner loop (end -> front)
                //for(int y = numberOfdominoes; y != 0; y --)
                //{

                //}
            }

            //Should any place holder X's exist in the list then need to remove.
            if (inputAsList.Any(q => q == 'X'))
            {
                inputAsList.RemoveAll(EqualsX);
                //for (int counter2 = 0; counter2 == inputAsList.Count; counter2++)
                //{
                //    if (inputAsList[counter2] == 'X')
                //    {
                //        //Remove the X placeholder
                //        //inputAsArray.CopyTo(input)
                //    }

                //}
            }


            inputAsList.ForEach(q => Console.Write( q.ToString() ) );

        }

        /// <summary>
        ///     Check contains logic only to made adjustments to the x2 parameter. 
        //      We need x1 and x3 ( the dominoes on the left and right to help determine what needs to happen to x2 ( i.e. current dominoe )
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="x3"></param>
        /// <returns></returns>

        private static string performCheck(string x1, string x2, string x3) {

            string result = "";

            if(( x1 == "X" || x1 == "."  || x1 == "R" || x1 == "L") 
                && x2 == "." 
                && ( x3 == "." || x3 == "X" || x3 == "L" || x3 == "R") )
            {
                //no change
                result = x1 + x2 + x3;
            }

            else if(x2 == "L" &&  ( x3 == "." || x3 == "R" ) )
            {
                //dominoe falls to the left
                result = "L" + "L" + x3;
            }

            else if(x2 == "R" && x3 == ".")
            {
                //dominoe falls to the right
                result = x1 + "R" + "R";
            }

            else if(x1 == "R" && x2 == "L")
            {
                //Momentum canceled. Force canceled. dominoes stay upright.
                result = "." + "." + x3;
            }

            else if(x2 == "R" && x3 == "L")
            {
                //Momentum canceld. Force Cancled. dominoes stay upright.
                result = x1 + "." + ".";
            }

            else
            {
                //State in which the dominoes current are needs to be maitined for this 'frame in time'.
                result = x1 + x2 + x3;
            }




            return result;
        }


        private static bool EqualsX(char c)
        {
            return c == 'X';
        }
    }
}
