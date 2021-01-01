using System;
using System.Collections.Generic;
using System.Text;

namespace Dodatkowe_Zadanie
{
    class GenericMethods
    {

        public static IEnumerable<To> Map<From, To>
            (IEnumerable<From> toChange, Func<From, To> func)
        {
            if (func == null) throw new ArgumentNullException("func");

            List<To> keepChanges = new List<To>();
            foreach(From elem in toChange)
            {
                keepChanges.Add(func(elem));
            }
            return keepChanges;
        }

        public static bool All<checkType>
            (IEnumerable<checkType> ToCheck,Func<checkType, bool> func)
        {
            if (func == null) throw new ArgumentNullException("func");
            foreach(checkType elem in ToCheck)
            {
                if(!func(elem))
                {
                    return false;
                }
            }
            return true;
        }

        public static void ForEach<T>
            (IEnumerable<T> toAction,Action<T> action)
        {
            if (action == null) throw new ArgumentNullException("action");
            
            foreach(T elem in toAction)
            {
                action(elem);
            }
        }

    }
}
