using System;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Print Pattern");
            int n = 9;  
            PrintPattern(n);//calling the recursive function to execute
            Console.WriteLine();

            Console.WriteLine("Print Series");
            int n2 = 7;
            PrintSeries(n2);           //calling the printseries function/method
            Console.WriteLine();

            Console.WriteLine("USF TIME - not case sensitive");
            string s = "09:15:35PM";
            string t = UsfTime(s);          //calling the USFTime(string s) function to return output
            Console.WriteLine(t);
            Console.WriteLine();

            Console.WriteLine("USF Numbers");
            int n3 = 115;//total integers
            int k =8;//numbers per line
            UsfNumbers(n3, k);
            Console.WriteLine();

            Console.WriteLine("Palindromes");
            string[] words = new string[] { "abcd","dcba","lls","s","sssll"};
            //the first method uses a reverse method to find out the palindrome
            PalindromePairs(words);
            Console.WriteLine();
            //the second method uses the basic reading an array of alphabets that make a word forward and reverse check logic to find out a palindrome
            Console.WriteLine("Palindromes2");
            PalindromePairs2(words);
            Console.WriteLine();

            Console.WriteLine("Stones");
            int n4 = 10;
            Stones(n4);
            Console.WriteLine();


        }//end of Main method

        /**LOGIC: for each line subtract x from n to get the numbers in decrements (where x increases by 1 to decrement the 
           * output value by 1)  - the loop runs n times to print n numbers in a line
           * to shift the output to next line use the writeline function
           * then decremement n by 1 (n--) and if n hasn't reached 0 yet, loop will run again (in the recursive function) with
           * decremented value of n ***/

        private static void PrintPattern(int n)
        {
            try
            {
                //corner case for negative numbers 
                if (n <=0)
                {
                    Exception ex = new Exception("Enter a positive integer number greater than 0 for question 1 please");
                    throw ex;
                };//end of corner case IF condition 
                /*if condition to ensure recursion breaks - n should be a positive integer always
                 * runs n times printing n lines by calling recursive function */
                if (n > 0)
                {
                    /*for loop to print numbers in one single line 
                     *the numbers being printed within a line decrement */
                    for (int x = 0; x < n; x++)
                    {   
                        Console.Write(n - x);
                    }
                    //to go to a new line before the next time recursive function is called
                    Console.WriteLine();
                    //decrementing n so that the next time n-1 numbers are printed within a line
                    n--;
                    if (n != 0)//only call recursive function when n>0 - this will also help in displaying error only when n=0 in the start not when it reaches n after the loop
                    {
                        PrintPattern(n);
                    }
                };//end of if condition
            }
            //this will catch any possible exception including decimals as input/alphabets
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exception Occured while computing printPattern");
            }
        }//end of PrintPattern method


        /**LOGIC::::: start of with sum=0 and addon=1
          * we already have a value of n2
          * add  addon value to sum and then output to console
          * increment the addon to increase the number adding by 1 for the next time the while loop runs
          * decrement the value of n2 (depicts the remaining number of times the loop has to run)**/

        private static void PrintSeries(int n2)
        {
            try
            {
                if (n2 <=0 )//handling the corner cases in case a negative number is entered by the user
                {
                        Exception ex = new Exception("Enter a positive integer number greater than 0 for question 1 please");
                        throw ex;
                }
                int sum = 0;    //initializing variable to contain sum to print
                int addon = 1;     //initializing variable to handle the addition
                while (n2 > 0)  //handles the loop and the corner case in case of entering a negative number it doesnt run
                {
                    sum += addon;   //add the addon to sum
                    Console.Write(sum + "    ");    //print it with space
                    addon++;    //increment the addon by 1 so that next time incremented number is added
                    n2--;   //decrement the remaining rounds of series by 1
                };//end of while 
                Console.WriteLine();
            }
            //this will catch exceptions like decimals /alphabets as inputs
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exception Occured while computing PrintSeries");
            }
        }//end of PrintSeries method

        /***:::LOGIC: convert the time to seconds
  * then start of with finding F (since its the smallest element in usftime) by dividing all the seconds by 45 and getting the remainder
  * the remainder is F
  * to get U and S, divide the seconds by 45 first and truncate (to avoid roundoff) and then by 60 - but get the remainder value of the division by 60
  * the remainder value becomes MINutes or S (its like converting seconds to minutes first and then hours - and in the conversion from minutes to hours
  * the remainder minutes are the minutes on time
  * the division of seconds by (45*60) gives us U like (60*60) division gives us hours*****/

        public static string UsfTime(string s)
        {
            try
            {
                //handling corner case of a. improper format with missing numbers/AM/PM b.hours>12 c.minutes>59 d.seconds>59
                if (s.Length != 10 || Convert.ToInt32(s.Substring(0,2))>12 || Convert.ToInt32(s.Substring(3, 2)) > 59||Convert.ToInt32(s.Substring(6, 2)) > 59)
                {
                    Exception ex = new Exception("Enter the time in proper format hh:mm:sstt");
                    throw ex;
                }

                else
                {
                    //parse the string input of time to convert it to 24hr format
                    TimeSpan input_24hr = DateTime.Parse(s).TimeOfDay;
                    //convert the 24hr input to seconds so we can go from smaller to bigger and leave the remainders as seconds, then minutes
                    double input_seconds = input_24hr.TotalSeconds;
                    //mode to get remainder - 1.converts f to s and the remainder becomes remaining f
                    int usf_f = Convert.ToInt32(input_seconds % 45);
                    //converts f to s and then s to u, takes the remainder on the second conversion this remainder is s (like mins)
                    //truncates to handle automatic round off cases
                    int usf_s = Convert.ToInt32(Math.Truncate(input_seconds / 45) % 60);
                    //converts  f to u by first dividing by 45 and then 60 - we've already account for the remainder by the this division above
                    //so this division gives us u (like hrs)
                    int usf_u = Convert.ToInt32(input_seconds / (45 * 60));
                    string output_time = Convert.ToString(usf_u) + ":" + Convert.ToString(usf_s) + ":" + Convert.ToString(usf_f);

                    return output_time;
                }//end of else of the corner case handling - normal run
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exception Occured while computing UsfTime");
                //since it needs to have a return line
                return null;
            }

        }//end of UsfTime method


        /**:::LOGIC *initialize a by 1 and run a while loop it till n3(total numbers to print-keeps a check on total numbers being printed
              *  run a for loop till k(number of numbers in a line) -keeps a check on numbers in a line
              *  if a hasnt completed n3 prints yet, stay in the loop else break and go to while -which will stop in case of last number scenario
              *  for each value of a - see if it exactly divides by 3,5,7 sequencly and print U,S,F respectively and then end with a space
              *  if it doesnt divide exactly by any of the three, print it as such and then add space */

        public static void UsfNumbers(int n3, int k)
        {
            try
            {
                //handling the corner case of total number of integers to display less than 1 OR total lines to display it in is less than 1
                if (n3 <= 0 || k <= 0)
                {
                    Exception ex = new Exception("Please enter total number of integers greater than 0 and lines to display in greater than 0 ");
                    throw ex;
                }
                //handling the corner case of number of integers being less than number of lines to display in
                if (n3 < k)
                {
                    Exception ex = new Exception("Please enter total number of integers greater than numbers per line to display in ");
                    throw ex;
                }
                else
                {
                    //initializing the variable to go up till n3
                    int a = 1;
                    //while loop 
                    while (a <= n3)
                    {
                        for (int i = 0; i < k; i++)
                        {
                            /*handling the corner case where : numbers remaining (n3) are less than numbers per line(k)
                             *compare a (variable for counting total numbers) with n3(total numbers) if a (after completing its
                             * last cycle and increment and completing n3 number prints) has now reached n3+1 break from the loop
                             */
                            if (a == n3 + 1)
                            {
                                a++;
                                break;
                            }
                            /*each if here adds the letter after checking the condition - using multiple ifs and finally 
                             an else to account for all the 3,5,7 multiples in correct order*/
                            if (a % 3 == 0 )
                                Console.Write("U");
                            if (a % 5 == 0 )
                                Console.Write("S");
                            if (a % 7 == 0)
                                Console.Write("F");
                            if (a % 3 == 0 || a % 5 == 0 || a % 7 == 0)
                                Console.Write(" ");
                            else
                                Console.Write(a + " ");
                            a++;
                        }//end of for loop
                        Console.WriteLine(" ");
                    }//end of while
                }//end of else after the corner cases check
            }//end of try
            //to handle cases like entering a double/decimal in input or any other exception  
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exception occured while computing UsfNumbers()");
            }
        }//end of UsfNumbers method


        /***LOGIC: run a loop to go till the end of the array/list of words
           * lock the first word with counter1 and start a for loop to go through the rest of the words using counter2
           * for each word locked in counter1 position, and the running counter2 words, join the word in counter1 position with counter2 position
           * check the length of this combo word and accordingly (subtract 1 for odd length combo words) split it into two halves
           * fix the first half and reverse the second half
           * now if the first half and the reversed second half are the same its a palindrome****/

        public static void PalindromePairs(string[] words)
        {
            try
            {
                //handling case of empty/ just 1 word array
                if (words.Length < 2)
                {
                    Exception ex = new Exception("Enter an array of more than 1 word to search for palindromes");
                    throw ex;
                }
                int l = 0;//initializing a variable to store length of the complete palindrome word
                int counter1 = 0; //initializing counter1 to lock the first word
                string arr1;//initializing string to store first half of probable palindrome
                char[] arr2;//initialize character array to store second half of probable palindrome and reverse it

                while (counter1 < words.Length  )//so it runs for each word in list and locks it and then searches the rest of the list for combinations to find palindromes
                {
                    for (int counter2 = 0; counter2 < words.Length; counter2++) //initializing for loop to run each of the possible second word against the first locked word to check for palindromes
                    {
                        //to ensure same indice words are not compared with themselves and no empty words are compared to other words
                        if (counter1 != counter2 && words[counter1].Length!=0 && words[counter2].Length!=0)    
                        {
                            string combo_word = words[counter1] + words[counter2];

                            if (combo_word.Length % 2 == 0)//if the joint probable palidrome is even
                            {
                                l = combo_word.Length; //to cater for even palindromes
                                arr1 = combo_word.Substring(0, l / 2);//to get first half of the combined 2 word string
                                arr2 = combo_word.Substring(l / 2).ToCharArray();//to get second half of the combined 2 word string
                            }
                            else
                            {
                                l = combo_word.Length + 1;// to cater for odd palindromes 
                                arr1 = combo_word.Substring(0, l / 2);//to get first half of the combined 2 word string
                                arr2 = combo_word.Substring((l / 2) - 1).ToCharArray();//to get second half of the combined 2 word string
                            }
                            Array.Reverse(arr2);    // to reverse the second half of our combo word
                            /*we use new string(arr2) for the arr2 chararray to 
                             *convert it into a string and disengage it from
                             *the pointer chararray to ensure correct comparison
                             *between arr1 and arr2 variables */
                            //if the first half and reversed second half are same its a palindrom and we update the list 
                            
                            if (String.Equals(arr1, new String(arr2)))
                            {
                                Console.Write("[" + counter1 + "," + counter2 + "] ");
                            }//end of if to display the palindromes
                        }//end of if condition that ensures same indice words are not compared with themselves
                    }//end of for loop running the second combination word against the locked word
                    counter1++;
                }
                Console.WriteLine();
            }//end of Palidrome try
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exception occured while computing PalindromePairs()");
            }
        }//end of Palidrome Pairs


        /**** LOGIC::: it runs for each word in list (length helps figure out the  total count of words provided)
         * it locks the first word and then searches the rest of the list for combinations to find palindromes
         *combining the locked counter1 word and counter2 position word make a combo word
         * the third for loop runs for half the length of the probable palindrome
         * matching the first alphabet with the last, second with second last and so on for the combo word
         * if at any moment the alphabet doesnt match, it breaks from the loop and goes on to searching the next word on counter2 against the locked counter1
         * if the above doesnt happen and counter3 reaches maximum its a palindrome*/

        public static void PalindromePairs2(string[] words)
        {
            try
            {
                //handling case of empty/ just 1 word array
                if (words.Length < 2)
                {
                    Exception ex = new Exception("Enter an array of more than 1 word to search for palindromes");
                    throw ex;
                }
                int counter1 = 0; //initializing counter1 to lock the first word
                int l = 0;//initializing l to get length of the probable palindrome


                while (counter1 < words.Length)       
                {
                    for (int counter2 = 0; counter2 < words.Length; counter2++) //initializing for loop to run each of the possible second word against the first locked word to check for palindromes
                    {
                        //to ensure same indice words are not compared with themselves and no empty words are compared to other words
                        if (counter1 != counter2 && words[counter1].Length != 0 && words[counter2].Length != 0)
                        {
                            //concatenate both the words to see the probable palindrome
                            string combo_word = words[counter1] + words[counter2];
                            l = combo_word.Length;
                            /*check first alphabet with last, 2nd with 2ndlast and so on
                             * to confirm existance of a palindrome... if all matches, its a palindrome*/
                            for (int counter3 = 0; counter3 <= (l/2); counter3++)
                            {
                                // if the first alphabet and last alphabet is same, continue comparison for the rest alphabets
                                if (combo_word[counter3] == combo_word[l -counter3-1]) 
                                {
                                    /*if the counter is at its max, it means it ran fine
                                     * through the whole word and found 
                                     * a palindrome, so output the index of those two words*/
                                    if (counter3 == (l / 2))
                                    {
                                        Console.Write( "[" + Convert.ToString(counter1) + "," + Convert.ToString(counter2) + "] ");
                                    }
                                    
                                }
                                else
                                {
                                    /*if its corresponding alphabet in reverse order doesnt match, 
                                     * its not a palindrom and so break the loop and
                                     * move on to pair the next word with the initial locked word(counter1)*/
                                    break;
                                };
                            }
                        }//end of if condition that ensures same indice words are not compared with themselves
                    }//end of for loop running the second combination word against the locked word
                    counter1++;
                }//end of the while(counter1) that locks the first word
                Console.WriteLine();
            }//end of Palidrome try
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exception occured while computing PalindromePairs2()");
            }
        }//end of Palidrome Pairs


        /*LOGIC:::: since player1 can never win with 4 stones on his turn (or a multiple of four)
 * it is required that he leaves 4 stones (or a multiple of 4) for the player2's turn
 * so in the first turn, in order to win, he will have to pick up stone that leave stones
 * in multiples of 4 for the player 2 (basically pick stones in remainder of 4)
 * and after that always pick stome to sum it to 4 (p2 stones+p1 stones)==4*/

        public static void Stones(int n4)
        {
            try
            {
                string moves="";
                //handling the corner case of less than 4 stones - in that case the player 1 will always win
                if (n4 < 4)
                {
                    Exception ex = new Exception("You need more than 3 stones to play the game");
                    throw ex;
                }
                if (n4 % 4 == 0 && n4>3)
                {
                    Console.WriteLine("False. Can not win this game");
                }
                else
                {   
                    /*remaining stones after division by 4 (to leave stones in multiple of 4 for player2) 
                    should be pick in first turn by player1 to win*/
                    int first_move = n4 % 4;

                    //total set of moves assuming you play cleverly to win - always in multiples of 4
                    int total_set_of_moves = n4 / 4;
                    //write the first move to console
                    moves += "[" + first_move ;

                    //to print any one set of moves to win the game, 
                    for (int x = 0; x < total_set_of_moves; x++)
                    {
                        Random r = new Random();
                        int p2move = r.Next(1, 3 + 1);
                        //always even out p2's move with a number that sums up p2 + p1 move = 4
                        int p1move = 4 - p2move;
                        moves += "," + p2move + "," + p1move;
                    }
                    moves += "]";
                    Console.WriteLine(moves);
                }//end of else condition 
            }//end of Stones try
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exception occured while computing Stones()");
            }
        }//end of Stones




    }//end of Class
}//end of Namespace
 