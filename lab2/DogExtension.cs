using System;
using static System.Console;
namespace lab2
{
    static class DogExtension
    {
        public static void GiveCookie(this Dog dog)
        {
            WriteLine("Dog ate cookie you gave and now it is happy!");
        }
    }
}