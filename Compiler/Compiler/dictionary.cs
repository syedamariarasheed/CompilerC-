﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    class dictionary
    {
        public Dictionary<string, string> dictionary1;
        public dictionary()
        {
            dictionary1 = new Dictionary<string, string>();

            dictionary1.Add("+", "Addition");
            dictionary1.Add("-", "Subtraction");
            dictionary1.Add("*", "Multiplication");
            dictionary1.Add("/", "Division");
            dictionary1.Add("%", "Reminder");
            dictionary1.Add("--", "Decrement");
            dictionary1.Add("++", "Increment");
            //relational
            dictionary1.Add("==", "EqualTo");
            dictionary1.Add("!=", "Not equal to");
            dictionary1.Add("<", "Lessthan");
            dictionary1.Add(">", "Greaterthan");
            dictionary1.Add("<=", "Lessequal");
            dictionary1.Add(">=", "Greaterequal");
            //Logical
            dictionary1.Add("!", "NOT");
            dictionary1.Add("&&", "AND");
            dictionary1.Add("||", "OR");
            //Bitwise
            dictionary1.Add("^", "Bitwise XOR");
            dictionary1.Add("|", "Bitwise OR");
            dictionary1.Add("&", "Bitwise AND");
            dictionary1.Add("<<", "ShiftLeft");
            dictionary1.Add(">>", "ShiftRight");
            dictionary1.Add(">>>", "Shiftrightzero");
            dictionary1.Add("`", "complement");
            //Assignment Operator
            dictionary1.Add("=", "Equal");
            dictionary1.Add("+=", "Add AND");
            dictionary1.Add("-=", "Subtract AND");
            dictionary1.Add("*=", "Multiply AND");
            dictionary1.Add("%=", "Modulus AND");
            dictionary1.Add("<<=", "Left shift AND");
            dictionary1.Add(">>=", "Right shift AND");
            dictionary1.Add("&=", "Bitwise AND");
            dictionary1.Add("^=", "Bitwise exclusive OR");
            dictionary1.Add("|=", "Bitwise inclusive OR");
            dictionary1.Add("/=", "Divide AND");
            //dataType
            dictionary1.Add("int", "INT");
            dictionary1.Add("float", "FLOAT");
            dictionary1.Add("char", "CHAR");
            dictionary1.Add("boolean", "BOOLEAN");
            dictionary1.Add("long", "LONG");
            dictionary1.Add("short", "SHORT");
            dictionary1.Add("string", "STRING");
            dictionary1.Add("void", "this is ValueLess");
            dictionary1.Add("wchar_t", "this is Wide character");
            dictionary1.Add("double", "DOUBLE");
            dictionary1.Add("byte", "this is BYTE");
            dictionary1.Add("int16", "this is INTEGER16");
            dictionary1.Add("int32", "this is INTEGER32");
            dictionary1.Add("int64", "this is INTEGER64");
            //keyword
            dictionary1.Add("if", "if keyword");
            dictionary1.Add("else", "else keyword");
            dictionary1.Add("then", "then keyword");
            dictionary1.Add("for", "keyword");
            dictionary1.Add("while", "while keyword");
            dictionary1.Add("Foreach", "keyword");
            dictionary1.Add("do", "keyword");
            dictionary1.Add("break", "keyword");
            //brackets and symbols
            dictionary1.Add(";", "semi colon");
            dictionary1.Add(",", "comma");
            dictionary1.Add("(", "opening round bracket");
            dictionary1.Add(")", "closing round bracket");
            dictionary1.Add("{", "opening curly bracket");
            dictionary1.Add("}", "closing curly bracket");
        }
    }
}
