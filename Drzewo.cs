using System;
using System.Collections.Generic;
using System.Text;

namespace Main
{
    class Drzewo
    {
        Element Pierwszy;

        public Drzewo()
        {
            Pierwszy = null;
        }

        public Drzewo(int value)
        {
            Pierwszy = new Element(value);
        }


        public bool Dodaj(int value)
        {
            Element newElement = new Element(value);
            Element current = Pierwszy, previous = null;

            while (current != null)
            {
                previous = current;
                if (value == current.Value)
                    return false;
                else if (value > current.Value)
                    current = current.Right;
                else
                    current = current.Left;
            }

            current = previous;
            if (value > current.Value)
                current.Right = newElement;
            else
                current.Left = newElement;
            return true;
        }

        public bool Wyszukaj(int value)
        {
            Element current = Pierwszy;

            while (current != null)
            {
                if (value == current.Value)
                    return true;
                else if (value > current.Value)
                    current = current.Right;
                else
                    current = current.Left;
            }

            return false;
        }
        
        public void Wyswietl()
        { 
            Wyswietl(Pierwszy.Left);
            Console.WriteLine(Pierwszy.Value);
            Wyswietl(Pierwszy.Right);
        }

        private bool Wyswietl(Element element)
        {
            if (element == null) return false;
            Wyswietl(element.Left);
            Console.WriteLine(element.Value);
            Wyswietl(element.Right);
            return true;
        }

        public bool Usun(int value)
        {
            Element element = Pierwszy;
            Element prev = null;
            while (element.Value != value)
            {
                prev = element;
                element = (value > element.Value) ? element.Right : element.Left;
                if (element == null) break;
            }
            if (element == null)
                return false;
            // przedluzanie poprzedniego linku
            if (element.Right == null || element.Left == null)
            {
                if(prev.Right == null) // prawy jest pusty, element jest w lewym
                {
                    if (element.Right == null) prev.Left = element.Left;
                    else prev.Left = element.Right;
                }
                else // lewy jest pusty, element jest w prawym
                {
                    if (element.Right == null) prev.Right = element.Left;
                    else prev.Right = element.Right;
                }
                return true;
            }

            //usuwanie przez scalanie
            Element ostatniPrawy = element.Left;
            while (ostatniPrawy.Right != null)
                ostatniPrawy = ostatniPrawy.Right;
            ostatniPrawy.Right = element.Right;

            if (prev.Right == element)
                prev.Right = element.Left;
            else
                prev.Left = element.Left;

            return true;
        }
    }

    class Element
    {
        public int Value;
        public Element Right, Left;

        public Element(int value)
        {
            Value = value;
            Right = null;
            Left = null;
        }
    }
}
