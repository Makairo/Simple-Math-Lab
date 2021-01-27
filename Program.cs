using System;

namespace LAB_3D____Math_App
{
    class Program
    {
        static string userInput()
        {
            try
            {
                string userIn = "";
                userIn = Console.ReadLine();
                return userIn;
            }
            catch(FormatException ex)
            {
                Console.WriteLine($"Input was not valid: {ex.Message}. Please try again.");
                return userInput();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Something went wrong, please try again. Message: {ex.Message}.");
                return userInput();
            }
        }
        static Tuple<int, int> getOperands()
        {
            try
            {
                Console.WriteLine("Enter first operand: ");
                int x = checked(Int32.Parse(userInput()));
                Console.WriteLine("Enter second operand: ");
                int y = checked(Int32.Parse(userInput()));
                return Tuple.Create(x, y);
            }
            catch (System.OverflowException ex)
            {
                Console.WriteLine($"Error! {ex.Message}. Please try again.");
                return getOperands();
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error! {ex.Message}. Please try again.");
                return getOperands();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! {ex.Message}. Please try again.");
                return getOperands();
            }
        }
        static int doAddition(Tuple<int, int> operand)
        {
            try
            {

                return checked(operand.Item1 + operand.Item2);
            }
            catch (System.OverflowException ex)
            {
                Console.WriteLine($"Error! {ex.Message}. Please try again.");
                return doAddition(getOperands());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! {ex.Message}. Please try again.");
                return doAddition(getOperands());
            }
        }
        static int doSubtraction(Tuple<int, int> operand)
        {
            try
            {

                return checked(operand.Item1 - operand.Item2);
            }
            catch (System.OverflowException ex)
            {
                Console.WriteLine($"Error! {ex.Message}. Please try again.");
                return doSubtraction(getOperands());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! {ex.Message}. Please try again.");
                return doSubtraction(getOperands());
            }
        }
        static int doMultiplication(Tuple<int, int> operand)
        {
            try
            {

                return checked(operand.Item1 * operand.Item2);
            }
            catch (System.OverflowException ex)
            {
                Console.WriteLine($"Error! {ex.Message}. Please try again.");
                return doMultiplication(getOperands());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! {ex.Message}. Please try again.");
                return doMultiplication(getOperands());
            }
        }
        static int doDivision(Tuple<int, int> operand)
        {
            try
            {
                return checked(operand.Item1 / operand.Item2);
            }
            catch (System.OverflowException ex)
            {
                Console.WriteLine($"Error! {ex.Message}. Please try again.");
                return doDivision(getOperands());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! {ex.Message}. Please try again.");
                return doDivision(getOperands());
            }
        }
        static int doRemainder(Tuple<int, int> operand)
        {
            try
            {
                return checked(operand.Item1 % operand.Item2);
            }
            catch (System.OverflowException ex)
            {
                Console.WriteLine($"Error! {ex.Message}. Please try again.");
                return doRemainder(getOperands());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! {ex.Message}. Please try again.");
                return doRemainder(getOperands());
            }
        }
        static Tuple<int,int> checkForZero(Tuple<int, int> operand)
        {
            try
            {
                // Grabs second value, checks for divide by zero.
                int y = operand.Item2;
                while (y == 0)
                {
                    Console.WriteLine("Cannot divide by zero. Input new value for second operand: ");
                    y = checked(int.Parse(Console.ReadLine()));
                }
                //Will repeat as long as y == 0, then reassigns the tuple to the ajusted value.
                return Tuple.Create(operand.Item1, y);
            }
            catch(OverflowException ex)
            {
                Console.WriteLine($"Error! {ex.Message}. Please try again.");
                return checkForZero(operand);
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error! {ex.Message}. Please try again.");
                return checkForZero(operand);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! {ex.Message}. Please try again.");
                return checkForZero(operand);
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine($"Welcome to Andrew's Calculator!");
                bool endApp = false;
                Tuple<int, int> inputs = Tuple.Create(0, 0);
                
                do
                {
                    Console.WriteLine($"Please specify what kind of operation you'd like to perform: \n(+ , - , * , /) Enter any other value to exit.");
                    switch (userInput())
                    {
                        case "+":
                            Console.WriteLine($"Selected addition!");
                            inputs = getOperands();
                            Console.WriteLine($"Result: {doAddition(inputs)}.");
                            continue;
                        case "-":
                            Console.WriteLine($"Selected subtraction!");
                            inputs = getOperands();
                            Console.WriteLine($"Result: {doSubtraction(inputs)}.");
                            continue;
                        case "*":
                            Console.WriteLine($"Selected multiplication!");
                            inputs = getOperands();
                            Console.WriteLine($"Result: {doMultiplication(inputs)}.");
                            continue;
                        case "/":
                            Console.WriteLine($"Selected division!");
                            inputs = checkForZero(getOperands());
                            Console.WriteLine($"Result: {doDivision(inputs)} remainder {doRemainder(inputs)}.");
                            continue;
                        default:
                            endApp = true;
                            break;

                    }
                } while (endApp == false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! {ex.Message}. Please try again.");
            }
            finally
            {
                Console.WriteLine("Thanks for stopping by!");
            }
        }
    }
}