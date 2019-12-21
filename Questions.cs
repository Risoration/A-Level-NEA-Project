using System;
using System.Collections.Generic;
using System.Linq;

namespace NEA___Boolean_and_Binary_Algebra_Revision_Tool
{

    public class SubExpression
    {
        public string subexp; 
        public string oper;

        public SubExpression(string subexp, string oper)
        {
            this.subexp = subexp;
            this.oper = oper;
        }
    }

    public class Questions
    {
        protected string[] operands;
        protected string quesType;
        protected int quesDiff;
        protected char operand1;
        protected char operand2;
        protected char oprtr;

        public Questions(char operand1, char operand2, char oprtr)
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
            this.oprtr = oprtr;
        }

        protected virtual int Precedence(string element) //method to determine the precedence value of an operator, default method which will be inherited
        {
            return 0;
        }

        protected virtual bool isOperator(string element) //method to determine whether a specific element in a question is an operator, default method which will be inherited
        {
            return false;
        }

        protected string ConvertInfixToRPN(string infixQuestion, string[] operands) //method to convert the question that the user enters from infix to reverse polish notation (RPN)
        {
            //initialise variables to be used in the conversion
            List<string> RPNQuestionArray = new List<string>(); //the array of characters in RPN form
            var questionStack = new Stack<string>(); //stack to be used to temporarily store values during the conversion
            string RPNQuestion = string.Join(",", RPNQuestionArray); //string variable which will hold the question in RPN after the conversion is finished
            string[] tokens = infixQuestion.Split(' '); //string array which holds the indivdual elements of the infix question

            foreach (string element in tokens) //looks at every index of the array tokens, and temporarily assigns its value to the variable element, until it moves onto the next cycle
            {
                if (operands.Contains(element)) //if the element is an operand
                {
                    RPNQuestionArray.Add(element); //add it to the RPN question array
                }
                else if (element == "(") //if the element is an opening bracket
                {
                    questionStack.Push(element); //add it to the question stack
                }
                else if (element == ")") //if the element is a closing bracket 
                {
                    while (questionStack.Count != 0 && questionStack.Peek() != "(") //look through the question stack until an opening bracket is found
                    {
                        RPNQuestionArray.Add(questionStack.Pop()); //remove the opening bracket from the question stack once it is reached, and add it to the RPN question array
                    }
                    questionStack.Pop(); //remove the closing bracket from the question stack
                }
                else if (isOperator(element) == true) //if the element is an operator
                {
                    while (questionStack.Count != 0 && Precedence(questionStack.Peek()) >= Precedence(element)) //look through the question stack until an operator with smaller precedence than the one of the corrent element is found
                    {
                        RPNQuestionArray.Add(questionStack.Pop()); //remove each of the highest precedence operators from the list and add them to the RPN question array
                    }
                    questionStack.Push(element); //add the current element to the question stack
                }
            }

            while (questionStack.Count != 0) //if there are still elements left in the question stack
            {
                RPNQuestionArray.Add(questionStack.Pop()); //remove them from the question stack and add them to the RPN question array
            }
            return RPNQuestion;
        }

        //protected string ConvertRPNToInfix(string RPNQuestion)
        //{
        //    List<string> infixQuestionArray = new List<string>();
        //    var questionStack = new Stack<SubExpression>();
        //    string infixQuestion = string.Join(",", infixQuestionArray);
        //    string[] tokens = RPNQuestion.Split(' ');

        //    foreach(string element in tokens)
        //    {
        //        if (operands.Contains(element))
        //        {
        //            var rightOperand = questionStack.Pop();
        //            var leftOperand = questionStack.Pop();

        //            var newExpr = leftOperand.subexp + element + rightOperand.subexp;

        //            questionStack.Push(new SubExpression(newExpr, element));
        //        }
        //        else if()
        //    }

        //    return infixQuestion;
        //}

        public virtual string QuestionSolve(string RPNQuestion)
        {
            string programAnswer = "";
            return programAnswer;
        }

        public virtual void QuestionMark()
        {

        }
    }

    public class BinaryQuestions : Questions
    {
        public BinaryQuestions(char operand1, char operand2, char oprtr) : base(operand1, operand2, oprtr)
        {
        }

        public new int[] operands = { 0, 1 };


        protected override int Precedence(string element) //method to determine the precedence value of an operator
        {
            if (element == "*") // precedence of binary division and multiplication
                return 2;
            else if (element == "-" || element == "+") //binary subtraction, addition and boolean OR operators
                return 1;
            else
                return 0;
        }

        protected override bool isOperator(string element) //method to determine whether a specific element in a question is an operator
        {
            if (element == "+" || element == "-" || element == "*" || element == "/") //if any operator is detected
                return true;
            else
                return false;
        }

        public override string QuestionSolve(string RPNQuestion)
        {
            return base.QuestionSolve(RPNQuestion);
        }

    }

    public class BooleanQuestions : Questions
    {
        public BooleanQuestions(char operand1 , char operand2, char oprtr) : base(operand1, operand2, oprtr)
        {
        }

        public new char[] operands =  "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
         /// <summary>
         /// METHOD TO SIMPLIFY AN GIVEN BOOLEAN EXPRESSION
         /// </summary>
         /// <param name="infixQuestion"></param>
         /// <returns></returns>
        protected string SimplifyExpression(string[] infixQuestion)
        {
            List<string> SimpleExpressionList = new List<string>();
            string simpleExprInitial = string.Join(" ", SimpleExpressionList);
            for (int i = 0; i < infixQuestion.Length; i++)
            {
                switch (infixQuestion[i])
                {
                    default:
                        SimpleExpressionList.Add(infixQuestion[i]);
                        break;
                    case "!":
                        if (infixQuestion[i + 1] == "(") //example: !(A+B) = !A!+!B = !A.!B
                        {
                            while (i < infixQuestion.Length && infixQuestion[i] != ")")
                            {
                                SimpleExpressionList.Add(Invert(infixQuestion[i]));
                                i++;
                            }
                        }
                        else if (infixQuestion[i + 1] == "!" && infixQuestion[i + 2] == "(") //example: !!(A+B) = A+B
                        {
                            while (i < infixQuestion.Length && infixQuestion[i] != ")")
                            {
                                SimpleExpressionList.Add(infixQuestion[i]);
                            }
                        }   
                        else if (infixQuestion[i + 1] == "!") //example: !!X = X
                            SimpleExpressionList.Add(infixQuestion[i + 2]);
                        else
                            SimpleExpressionList.Add(Invert(infixQuestion[i])); //example: !X
                        break;
                    case ".":
                        if (infixQuestion[i - 1] == "0" || infixQuestion[i + 1] == "0") //example: X.0 = 0
                            SimpleExpressionList.Add("0");
                        else if (infixQuestion[i - 1] == "1") //example: X.1 = X
                            SimpleExpressionList.Add("1");
                        else if (infixQuestion[i + 1] == "1")
                            SimpleExpressionList.Add("1");
                        else if (infixQuestion[i - 1] == infixQuestion[i + 1]) //example: X.X = X
                            SimpleExpressionList.Add(infixQuestion[i - 1]);
                        else if (infixQuestion[i - 1] == infixQuestion[i + 2] && infixQuestion[i + 1] == "!" || infixQuestion[i + 1] == infixQuestion[i - 1] && infixQuestion[i - 2] == "!") //example X.!X = 0
                            SimpleExpressionList.Add("0");
                        else if (infixQuestion[i + 1] == "(") //example X.(Y.Z) = X.Y.Z
                        {
                            List<string> inBrackets = new List<string>();
                            while (i < infixQuestion.Length && infixQuestion[i] != ")")
                            {
                                inBrackets.Add(infixQuestion[i]);
                            }
                            AssociativeRule(infixQuestion[i], inBrackets);
                            SingleBracketDistributiveRule(infixQuestion[i - 1], infixQuestion[i], inBrackets);
                        }
                        break;

                    case "+":
                        if (infixQuestion[i - 1] == "0") //example: X+0 = X
                            SimpleExpressionList.Add(infixQuestion[i + 1]);
                        else if (infixQuestion[i + 1] == "0")
                            SimpleExpressionList.Add(infixQuestion[i - 1]);
                        else if (infixQuestion[i - 1] == "1" || infixQuestion[i + 1] == "1") //example: X+1 = 1
                            SimpleExpressionList.Add("1");
                        else if (infixQuestion[i - 1] == infixQuestion[i + 1]) //example: X+X = X
                            SimpleExpressionList.Add(infixQuestion[i + 1]);
                        else if (infixQuestion[i - 1] == infixQuestion[i + 2] && infixQuestion[i + 1] == "!" || infixQuestion[i + 1] == infixQuestion[i - 1] && infixQuestion[i - 2] == "!") //example: X+!X = 1
                            SimpleExpressionList.Add("1");
                        else if (infixQuestion[i + 1] == "(") //example X+(Y+Z) = X+Y+Z
                        {
                            List<string> inBrackets = new List<string>();
                            while (i < infixQuestion.Length && infixQuestion[i] != ")")
                            {
                                inBrackets.Add(infixQuestion[i]);
                            }
                        }
                        break;
                    case "(":
                        List<string> parentheses = new List<string>();
                        List<string> rightparentheses = new List<string>();
                        if (infixQuestion[i] != ")")
                        {
                            while (i < infixQuestion.Length && infixQuestion[i] != ")")
                            {
                                parentheses.Add(infixQuestion[i]);
                                i++;
                            }
                            
                            if (infixQuestion[i+1] == "." && infixQuestion[i+2] == "(" || infixQuestion[i+1] == "+" && infixQuestion[i+2] == "(")// checking if the associative/distributive rule can be used 
                            {
                                while (i < infixQuestion.Length && infixQuestion[i] != ")")
                                {
                                    rightparentheses.Add(infixQuestion[i]);
                                    i++;
                                }
                                if (parentheses == rightparentheses) //if two brackets are the same 
                                {
                                    SimpleExpressionList.Add(string.Join(",", parentheses.ToArray()));
                                }
                            }
                        }
                        else if (infixQuestion[i + 1] == ")")
                            continue;
                        break;
                }
            }
            return simpleExprInitial;
        }

        protected string AssociativeRule(string outsideOperator, List<string> expr) //method to perform the associative rule, given the operator outside the bracket, and the expression in the brackets
        {
            List<string> associatedArray = new List<string>();
            if (expr.Contains(outsideOperator)) //if the brackets contain the operator found on the outside, the brackets can be removed as they don't change the output
            {
                associatedArray = expr.Where(val => val != "(").ToList();
            }
            else
                associatedArray = expr;
            return string.Join(",", associatedArray);
        }


        protected string SingleBracketDistributiveRule(string element, string outsideOperator, List<string> expr) //used to check and deal with single bracket expressions where the distributive rule could be used
        {
            List<string> distributedArray = new List<string>();
            string expression = expr.ToString();
            int orOperatorIndex = expression.IndexOf('+');
            int andOperatorIndex = expression.IndexOf('.');
            int operatorIndex = Math.Min(orOperatorIndex, andOperatorIndex);
            if (expr[operatorIndex] == outsideOperator)
            {
                foreach (string token in expr)
                {
                    string expressionToAdd = element + outsideOperator + token;
                    distributedArray.Add(expressionToAdd);
                }
            }
            return string.Join(",", distributedArray);
        }
        protected string DoubleBracketDistributiveRule(List<string> expr1, string outsideOperator, List<string> expr2) //used to check and deal with double bracket expressions where the distrbutive rule could be used
        {
            List<string> distributedArray = new List<string>();
            string expression1 = expr1.ToString();
            string expression2 = expr2.ToString();
            int orOperatorIndex1 = expression1.IndexOf('+');
            int orOperatorIndex2 = expression2.IndexOf('+');
            int andOperatorIndex1 = expression1.IndexOf('.');
            int andOperatorIndex2 = expression2.IndexOf('.');
            int operatorIndex1 = Math.Min(orOperatorIndex1, andOperatorIndex1);
            int operatorIndex2 = Math.Min(orOperatorIndex2, andOperatorIndex2);

            if (expr1[operatorIndex1] == expr2[operatorIndex2])
            {
                string bracketsOperator = expr1[operatorIndex1];
                if (bracketsOperator != outsideOperator)
                {
                    for(int i = 0; i < expr1.Count; i++)
                    {
                        for (int j = 0; j < expr2.Count; j++)
                        {
                            if (isOperator(expr1[i]) == true)
                            {
                                continue;
                            }
                            else
                            {
                                string exprToAdd = expr1[i] + outsideOperator + expr2[j];
                                distributedArray.Add(exprToAdd);
                            }
                        }
                    }
                }
            }
            return string.Join(",", distributedArray);
        }

        protected string AbsorptionRule(string element, string outsideOperator, List<string> bracket) //used to check and deal with expressions where the absorption rule may be used
        {
            foreach (string token in bracket)
            {
                if (bracket.Contains(element) && outsideOperator != token) //if the bracket contains the element on the other side of the operator and the operator inside is different to the one outside
                {
                    return element; //the whole expression is equivalent to the element on the other side of the operator
                }
                else
                {
                    continue; //otherwise this rule can't be used
                }
            }
            return null;
        }

        protected string TryCommutativeSwap(string[] expr) //use of the commutative rule to attempt to use all the different combinations of order, once no more rules can be used to simplify in its current form
        {
            string[] swappedArray = new string[expr.Length];
            for (int i = 0; i < expr.Length; i++) //cycle through each element in the expression given
            {
                if (isOperator(expr[i]) == true) //if the current element is an operator, keep it in the same position
                {
                    swappedArray[i] = expr[i];
                }
                else //otherwise, send it to the other end of the expression
                    swappedArray[expr.Length - (i + 1)] = expr[i];
            }
            return string.Join(",", swappedArray);
        }
        //protected bool ParenthesesCheck(List<string> leftparentheses, List<string> rightparentheses, string[] operands, List<string> SimpleExpressionList)
        //{
        //    foreach(string element in leftparentheses)
        //    {

        //    }
        //    return true;
        //}

        /// <summary>
        /// METHOD TO DETERMINE THE PRECEDENCE VALUE OF A GIVEN BOOLEAN OPERATOR
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>

        protected override int Precedence(string element) //method to determine the precedence value of an operator
        {
            if (element == "!") //boolean inverter
                return 3;
            else if (element == ".") //boolean AND operator
                return 2;
            else if (element == "+") //boolean OR operator
                return 1;
            else
                return 0;
        }

        protected override bool isOperator(string element) //method to determine whether a specific element in a question is an operator
        {
            if (element == "." || element == "+") //if any operator is detected
                return true;
            else
                return false;
        }

        protected string Invert(string token)
        {
            if (token == "+")
                return ".";
            else if (token == ".")
                return "+";
            else if (token == "!")
                return "";
            else if (token == "(")
            {
                List<string> tokens = new List<string>();
                string leftExpr = "!(";
                string rightExpr = tokens.ToString() + " )";
                string expr = leftExpr + rightExpr;
                while (token != ")")
                {
                    tokens.Add(token);
                }
                return expr;
            }
            else
                return "!" + token;
        }
    }
}