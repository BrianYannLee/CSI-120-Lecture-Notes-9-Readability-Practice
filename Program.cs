//Programmer: Brian Lee          // STEP 1: LIST DOWN NAME, DATE AND TITLE
//Date: 05/24/2024

//Title: Readability Practice
using System.Runtime.InteropServices.Marshalling;
using System.Text.RegularExpressions;

namespace CSI_120_Lecture_Notes_9_Readability_Practice
{
    internal class Program
    {
        delegate void Menuaction();
        delegate double Operation(double a, double b);

        static void Main(string[] args)
        {
            Console.WriteLine("Brian Lee- 05/24/2024");         //STEP 2: PRINT INFO 
            Console.WriteLine("Lecture 9 Readability Practice");
            Console.WriteLine();

            try                 //STEP 3: PUT A TRY CATCH IN MAIN
            {
                int userMenuInput;
                const int firstMainMenuChoice = 1;
                const int lastMainMenuChoice = 5;
                do
                {
                    Menuaction[] MainMenu = {PrintNumber, PerformAlgebra, WorkwithName, Opperation};
                    Console.WriteLine("Select the Number of the Program to Execute:");
                    Console.WriteLine("1. Print Number");
                    Console.WriteLine("2. Perform Algebra");
                    Console.WriteLine("3. Work With Name");
                    Console.WriteLine("4. Opperation");
                    Console.WriteLine("5. End");
                    Console.WriteLine();

                    userMenuInput = userMenuInputCheck(firstMainMenuChoice, lastMainMenuChoice);
                    if(userMenuInput == 5)
                    {
                        break;
                    }
                    
                    MainMenu[userMenuInput - 1]();

                } while (userMenuInput != 5);

            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error has occred: {ex.Message}");
            }
        }//end of Main 

        //--------------------USER INPUT CHECKER--------------------//   //STEP 4: CREATE A USER INPUT CHECKER METHODS
        #region
        public static int userMenuInputCheck(int firstChoice, int lastChoice)  //Method to check user Input for Menu.
        {
            int userInput;
            while (!int.TryParse(Console.ReadLine(), out userInput) || userInput < firstChoice || userInput > lastChoice)
            {
                Console.WriteLine("Inalid Input. Try Again.");
            }
            return userInput;
        }//end of userIntInputCheck
        
        public static int userIntInputCheck()  //Method to check user Input for Int.
        {
            int userInput;
            while(!int.TryParse(Console.ReadLine(),out userInput ))
            {
                Console.WriteLine("Inalid Input. Try Again.");
            }
            return userInput;
        }//end of userIntInputCheck
        public static double userDoubleInputCheck()  //Method to check user Input for Int.
        {
            double userInput;
            while (!double.TryParse(Console.ReadLine(), out userInput))
            {
                Console.WriteLine("Inalid Input. Try Again.");
            }
            return userInput;
        }//end of userDoubleInputCheck
        #endregion

        //-------------------MAIN MENU SELECTION---------------------------//  //STEP 5: CREATE A MAIN MENU SELECTION
        #region

        public static void PrintNumber() //Print Number inbetween two user input.
        {
            Console.WriteLine("Print Number");
            Console.WriteLine("--------------");
            Console.WriteLine();
            int firstNum, lastNum;

            Console.WriteLine("Please Enter the First Number.");
            firstNum = userIntInputCheck();
            Console.WriteLine("Please Enter the Last Number.");
            lastNum = userIntInputCheck();

            if (firstNum < lastNum)
            {
                for (int i = firstNum; i < lastNum; i++)
                {
                    Console.Write($"{i}, ");
                }
                Console.WriteLine(lastNum);
            }
            else if(firstNum > lastNum)
            {
                for (int i = firstNum; i > lastNum; i--)
                {
                    Console.Write($"{i}, ");
                }
                Console.WriteLine(lastNum);
            }
            else
            {
                Console.WriteLine(lastNum);
            }
            Console.WriteLine();
        }//end of PrintNumber
        public static void PerformAlgebra()//Solve One of 3 Equation
        {
            Console.WriteLine("Perform Algebra");
            Console.WriteLine("--------------");
            Console.WriteLine();
            const int firstSubAlgebraMenuChoice = 1;
            const int lastSubAlgebraMenuChoice = 2;

            Menuaction[] SubAlgebraMenu = {Equation1, Equation2};
            Console.WriteLine("Select the Number of the Program to Execute:");
            Console.WriteLine("1. Solve 2 Linear Equation System of Equation");
            Console.WriteLine("2. Solve 1 Linear Equation System of Equation");

            int userSubMenuInput = userMenuInputCheck(firstSubAlgebraMenuChoice,lastSubAlgebraMenuChoice);
            SubAlgebraMenu[userSubMenuInput - 1]();

            Console.WriteLine();
        }//end of PerformAlgebra
        public static void WorkwithName()
        {
            Console.WriteLine("Work with Name");
            Console.WriteLine("--------------");
            Console.WriteLine();
            int numName;
            string userNameInput;

            Console.WriteLine("Enter the amount of names you want to enter.");
            numName = userIntInputCheck();
            string pattern = @"^[a-zA-Z]+$";

            string[] names = new string[numName];
            for (int i = 0; i < numName; i++)
            {
                Console.WriteLine($"Enter Name number {i+1}");
                while(!Regex.IsMatch(userNameInput = Console.ReadLine(), pattern))
                {
                    Console.WriteLine("Invalid Input. Try Again");
                }
            }
            Console.WriteLine();
            for (int i = 0; i < numName; i++)
            {
                Console.Write($"{names[i]}, ");
            }
            Console.WriteLine(names[numName]);
            Console.WriteLine();

        }//end of WorkwithName
        public static void Opperation()
        {
            Console.WriteLine("Opperation");
            Console.WriteLine("--------------");
            Console.WriteLine();
            double x, y,answer;

            Console.WriteLine("Please Enter the First Number.");
            x = userDoubleInputCheck();
            Console.WriteLine("Please Enter the Second Number.");
            y = userDoubleInputCheck();
            Console.WriteLine();

            Operation[] SubOperationMenu = { Add, Subtract, Multiply, Divide };
            Console.WriteLine("Do you want to");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subtract");
            Console.WriteLine("3. Multiply");
            Console.WriteLine("4. Divide");
            Console.WriteLine();
            const int firstSubOpperationMenuChoice = 1;
            const int lastSubOpperationMenuChoice = 2;

            int userSubMenuInput = userMenuInputCheck(firstSubOpperationMenuChoice, lastSubOpperationMenuChoice);
            answer = SubOperationMenu[userSubMenuInput - 1](x,y);
            Console.WriteLine($"The answer is {answer}");

            Console.WriteLine();
        }//end of Opperation
        #endregion

        //----------SUB MENU PERFORM ALGEBRA SELECTION -------------// //STEP 6: CREATE A SUB MENU SELECTION
        #region
        public static void Equation1()
        {
            int[] coefficient = new int[6] ;
            double detA, detB, detC;
            double x, y;
            string[] coefficientName = new string[] { "A1", "B1", "C1", "A2", "B2", "C2" };
            Console.WriteLine("Your Equation is in Ax + By = C");

            for (int i = 0; i < 6; i++) 
            {
                Console.WriteLine($"Please Enter the Value of {coefficientName[i]}");
                coefficient[i] = userIntInputCheck();
            }
            Console.WriteLine();

            detC = Determinant2x2(coefficient[0], coefficient[3], coefficient[1], coefficient[4]);
            detA = Determinant2x2(coefficient[2], coefficient[5], coefficient[1], coefficient[4]);
            detB = Determinant2x2(coefficient[0], coefficient[3], coefficient[2], coefficient[5]);

            x = detA / detC;
            y = detB / detC;

            Console.WriteLine($"The value of the equations are ({x}, {y})");

        }//end of Equation1
        public static void Equation2()
        {
            int[] coefficient = new int[3];
            double x1, y1,x2,y2, discriminant, ans1, ans2;
            string[] coefficientName = new string[] { "A", "B", "C" };
            Console.WriteLine("Your Equation is in Ax + By + C = 0");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Please Enter the Value of {coefficientName[i]}");
                coefficient[i] = userIntInputCheck();
            }
            Console.WriteLine();

            discriminant = DiscriminantCheck(coefficient[0], coefficient[1], coefficient[2]);

            if (discriminant < 0)
            {
                Console.WriteLine("There is no solution");
            }
            else if (discriminant == 0)
            {
                (ans1, ans2) = QuadradicCalculation(coefficient[0], coefficient[1], discriminant);
                (x1,y1) = QuadradicCheck1Sol(ans1, ans2, coefficient[0], coefficient[1], coefficient[2]);
                Console.WriteLine($"The solution for (x,y) is ({x1},{y1})") ;
            }
            else
            {
                (ans1, ans2) = QuadradicCalculation(coefficient[0], coefficient[1], discriminant);
                (x1, y1,x2,y2) = QuadradicCheck2Sol(ans1, ans2, coefficient[0], coefficient[1], coefficient[2]);
                Console.WriteLine($"The solution for (x,y) is ({x1},{y1}) and ({x2},{y2})");
            }
        }//end of Equation2
        #endregion

        //-------------MATH FORMULA CLASS----------------// // STEP 7: CREATE A FORMULA CLASS
        
            //BASIC OPPERATION
            #region
            public static double Add(double a, double b)
            {
                return a + b;
            }
            public static double Subtract(double a, double b)
            {
                return a - b;
            }
            public static double Multiply(double a, double b)
            {
                return a * b;
            }
            public static double Divide(double a, double b)
            {
                if(b == 0)
                {
                    throw new ArgumentException("Division by zero is not allowed.");
                }
                return a + b;
            }
            #endregion
            //DETERMINANT
            #region
            static double Determinant2x2(int a1, int a2, int b1, int b2)
            {
                double det = a1 * b2-a2 * b1;
                return det;
            }
            #endregion
            //QUADRATIC FORMULA
            #region
            static double DiscriminantCheck(int a, int b, int c)     //WHY NO PUBLIC HERE
            {
                double discriminant;

                discriminant = Math.Pow(b, 2) - 4 * a * c;
               
                return discriminant;
            }
            static (double, double) QuadradicCalculation(double a, double b, double discriminant)
            {
                double ans1, ans2;

                ans1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                ans2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                return (ans1, ans2);
            }
            static (double,double) QuadradicCheck1Sol(double ans1, double ans2, int a, int b, int c)
            {
                double ans3;

                ans3 = a * Math.Pow(ans1, 2) + b * ans1 + c;
                if (ans3 == 0)
                {
                    return (ans1, ans3);
                }
                else
                {
                    ans3 = a * Math.Pow(ans2, 2) + b * ans2 + c;
                    return (ans1, ans3);
                }
            }
            static (double, double,double, double) QuadradicCheck2Sol(double ans1, double ans2, int a, int b, int c) //IS THERE A WAY TO RETURN 2 OR 4 VALUES IN ONE METHOD
            {
                double ans3,ans4;

                ans3 = a * Math.Pow(ans1, 2) + b * ans1 + c;
                
                
                ans4 = a * Math.Pow(ans2, 2) + b * ans2 + c;
                return (ans1, ans3,ans2,ans4);
            }
        #endregion

    }//end of Program
}//end of Namespace
