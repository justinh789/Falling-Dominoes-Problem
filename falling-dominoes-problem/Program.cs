using System;

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

            Console.WriteLine("Output: " + RunSimulation(input));
        }

        //this method should be named push Dominoes I guess. 
        private static string RunSimulation(string input)
        {

            int numberOfdominoes = input.Length;

            //easier to work with during loop.
            char[] inputAsArray = input.ToCharArray();

            string tempHolding;

            //outer loop (front -> end) 
            for(int x = 0; x != ( numberOfdominoes - 1 ) ; x ++)
            {
                //Loop each dominoe. 
                //pass in the current dominoe and the dominoe to the Left and Right of the current.
                tempHolding = performCheck( inputAsArray[x - 1].ToString(), 
                                            inputAsArray[x].ToString(), 
                                            inputAsArray[x + 1].ToString());



                inputAsArray[x - 1] = tempHolding[x - 1];
                inputAsArray[x] = tempHolding[x];
                inputAsArray[x + 1] = tempHolding[x + 1];


                tempHolding = "";



                ////inner loop (end -> front)
                //for(int y = numberOfdominoes; y != 0; y --)
                //{

                //}
                    


            }

            return inputAsArray.ToString();

        }

        private static string performCheck(string x1, string x2, string x3) {

            string result = "";

            if(x2 == "." && x1 == "." && x3 == ".")
            {
                //no change
                result = x1 + x2 + x3;
            }

            if(x2 == "L" && x3 == ".")
            {
                //dominoe falls to the left
                result = "L" + "L" + x3;
            }

            if(x2 == "R" && x3 == ".")
            {
                //dominoe falls to the right
                result = x1 + "R" + "R";
            }

            if(x1 == "R" && x2 == "L")
            {
                //Momentum canceled. Force canceled. dominoes stay upright.
                result = "." + "." + x3;
            }

            if(x2 == "R" && x3 == "L")
            {
                //Momentum canceld. Force Cancled. dominoes stay upright.
                result = x1 + "." + ".";
            }


            return result;
        }
    }
}
