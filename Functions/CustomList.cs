using System;
using System.Reflection;

namespace Functions
{
    public class CustomList<T>
    {
        private Element<T> FirstElement;
        public int Length = 0;

        /// <summary>
        /// Creates new list with first element value
        /// </summary>
        /// <param name="value"></param>
        public CustomList(T value)
        {
            Element<T> e = new Element<T>(value);
            Length = 1;
            FirstElement = e;
        }

        /// <summary>
        /// Creates new list from array of values
        /// </summary>
        /// <param name="values"></param>
        public CustomList(T[] values)
        {
            FirstElement = null;
            Length = 0;
            this.Add(values);
        }

        /// <summary>
        /// Creates new empty list
        /// </summary>
        public CustomList()
        {
            FirstElement = null;
            Length = 0;
        }

        /// <summary>
        /// Returns value of element at given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T At(int index)
        {
            if (index > Length - 1) return default(T);
            Element<T> e = FirstElement;
            for (int i = 0; i < Length; i++)
            {
                if (i == index) return e.Value;
                e = e.NextElement;
            }
            //shuldnt return here
            return e.Value;
        }

        /// <summary>
        /// Adds new element at the end of the list
        /// </summary>
        /// <param name="value"></param>
        public bool Add(T value)
        {
            if(Length == 0)
            {
                FirstElement = new Element<T>(value);
                Length = 1;
                return true;
            }

            Element<T> e = FirstElement;
            for (int i = 0; i < Length-1; i++)
                e = e.NextElement;
            Element<T> newE = new Element<T>(value);
            e.NextElement = newE;
            Length++;
            return true;
        }

        /// <summary>
        /// Adds new element at index, if list is shorter than index returns false
        /// </summary>
        /// <param name="value"></param>
        /// <param name="index"></param>
        public bool Add(T value, int index)
        {
            if (index == 0 && Length == 0) return this.Add(value);

            Element<T> e = FirstElement;
            Element<T> newE = new Element<T>(value);
            if (index == 0)
            {
                newE.NextElement = FirstElement;
                FirstElement = newE;
                Length++;
                return true;
            }
            if (index > Length || index < 0) return false;
            for (int i = 1; i < index; i++)
                e = e.NextElement;
            newE.NextElement = e.NextElement;
            e.NextElement = newE;
            Length++;
            return true;
                
        }

        /// <summary>
        /// Adds array of elements at the end of list
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public bool Add(T[] values)
        {
            if (Length == 0)
            {
                Element<T> e = new Element<T>(values[0]);
                FirstElement = e;
                Element<T> preE = FirstElement;
                for (int i = 1; i < values.Length; i++)
                {
                    e = new Element<T>(values[i]);
                    preE.NextElement = e;
                    preE = e;
                }
                Length = values.Length;
                return true;
            }

            Element<T> prevE = this.LastElement();
            for (int i = 0; i < values.Length; i++)
            {
                Element<T> e = new Element<T>(values[i]);
                prevE.NextElement = e;
                prevE = e;
            }
            this.UpdateLength();
            //Console.WriteLine(this.LastElement().Value);
            return true;
        }

        /// <summary>
        /// Adds array of elements at index
        /// </summary>
        /// <param name="values"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool Add(T[] values, int index)
        {
            if (Length == 0 && index == 0) return this.Add(values);

            Element<T> e;
            if (index == 0)
            {
                Element<T> first = new Element<T>(values[0]);
                Element<T> prevE = first;
                for (int i = 1; i < values.Length; i++)
                {
                    e = new Element<T>(values[i]);
                    prevE.NextElement = e;
                    prevE = e;
                }
                prevE.NextElement = FirstElement;
                FirstElement = first;
                UpdateLength();
                return true;
            }

            if (index > Length || index < 0) return false;

            e = FirstElement;
            for (int i = 1; i < index; i++)
                e = e.NextElement;
            Element<T> nextElement = e.NextElement;
            Console.WriteLine(nextElement.Value);
            for (int i = 0; i < values.Length; i++)
            {
                Element<T> element = new Element<T>(values[i]);
                e.NextElement = element;
                e = element;
            }
            e.NextElement = nextElement;
            Console.WriteLine(e.NextElement.Value);
            this.UpdateLength();
            return true;
        }

        /// <summary>
        /// Removes element at index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool Remove(int index)
        {
            this.UpdateLength();

            if (index < 0 || index >= Length) return false;

            Element<T> e = FirstElement;
            for (int i = 1; i < index; i++)
                e = e.NextElement;

            e.NextElement = e.NextElement.NextElement;
            Length--;

            return true;
        }

        /// <summary>
        /// Removes all elements including start index and not including end index
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public bool Remove(int startIndex, int endIndex)
        {
            if (startIndex < 0 || startIndex >= Length || endIndex < startIndex || endIndex >= Length) return false;

            this.UpdateLength();

            Element<T> e = FirstElement;
            for (int i = 1; i < startIndex; i++)
                e = e.NextElement;

            Element<T> element = e;
            for (int i = 0; i < endIndex - startIndex; i++)
                e = e.NextElement;
            element.NextElement = e.NextElement;

            this.UpdateLength();

            return true;
        }

        /// <summary>
        /// Removes number of elements, including start index
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="numOfElements"></param>
        /// <returns></returns>
        public bool Remove_(int startIndex, int numOfElements)
        {
            return Remove(startIndex, startIndex+numOfElements);
        }

        /// <summary>
        /// Returns list as array of <typeparamref name="T"/>
        /// </summary>
        /// <returns></returns>
        public T[] ReturnAsArray()
        {
            T[] arr = new T[Length];
            Element<T> e = FirstElement;
            for (int i = 0; i < Length; i++)
            {
                arr[i] = e.Value;
                e = e.NextElement;
                if (e == null) break;
            }
            return arr;
        }

        /// <summary>
        /// Updates length of list
        /// </summary>
        /// <returns>Updated length of list</returns>
        public int UpdateLength()
        {
            Element<T> e = FirstElement;
            int len = 1;
            if (e == null) return 0;
            while (e.NextElement != null)
            {
                e = e.NextElement;
                len++;
            }
            Length = ++len;
            return len;
        }

        /// <summary>
        /// Returns last element of list
        /// </summary>
        /// <returns>(class) Element</returns>
        public Element<T> LastElement()
        {
            Element<T> e = FirstElement;
            for (int i = 0; i < Length - 1; i++)
                e = e.NextElement;
            return e;
        }

        /// <summary>
        /// Shows list in console
        /// </summary>
        public void ShowList()
        {
            this.UpdateLength();

            Element<T> e = FirstElement;
            for (int i=1; i<this.Length; i++)
            {
                string v = Convert.ToString(e.Value);
                Console.Write(v + " ");
                e = e.NextElement;
            }
            Console.WriteLine("");
        }
    }

    public class Element<T>
    {
        public T Value;
        public Element<T> NextElement;
        public Element<T> PrevElement;

        public bool IncludesPrevElement;

        /// <summary>
        /// Creates new element of given value
        /// </summary>
        /// <param name="value"></param>
        public Element(T value)
        {
            Value = value;
            NextElement = null;
            PrevElement = null;
            IncludesPrevElement = false;
        }

        /// <summary>
        /// Creates new element of given value and linked to next element
        /// </summary>
        /// <param name="value"></param>
        /// <param name="nextElement"></param>
        public Element(T value, Element<T> nextElement)
        {
            Value = value;
            NextElement = nextElement;
            PrevElement = null;
            IncludesPrevElement = true;
        }

        /// <summary>
        /// Creates new element of given value and linked to both next and previous element
        /// </summary>
        /// <param name="value"></param>
        /// <param name="nextElement"></param>
        /// <param name="prevElement"></param>
        public Element(T value, Element<T> nextElement, Element<T> prevElement)
        {
            Value = value;
            NextElement = nextElement;
            PrevElement = prevElement;
            IncludesPrevElement = true;
        }
    }
}

