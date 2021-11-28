using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_15
{
    /*
     * Разработать интерфейс ISeries генерации ряда чисел. Интерфейс содержит следующие элементы: 
     * 
     *      метод void setStart(int x) - устанавливает начальное значение 
     *      метод int getNext() - возвращает следующее число ряда 
     *      метод void reset() - выполняет сброс к начальному значению 
     * 
     * Разработать классы ArithProgression и GeomProgression, которые реализуют интерфейс ISeries. 
     * В классах реализовать методы интерфейса в соответствии с логикой арифметической и геометрической прогрессии соответственно.
     */
    class Program
    {
        static void Main(string[] args)
        {
            ArithProgression arithProgression1 = new ArithProgression(2);

            arithProgression1.setStart(10);
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine("Следующий элемент последовательности: {0}", arithProgression1.getNext());
            }
            Console.WriteLine("Индекс последнего значения: {0}", arithProgression1.IndexProgress);

            arithProgression1.reset();

            Console.WriteLine();
            GeomProgression geomProgression = new GeomProgression(2);
            geomProgression.setStart(5);
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine("Следующий элемент последовательности: {0}", geomProgression.getNext());
            }
            Console.WriteLine("Индекс последнего значения: {0}", geomProgression.IndexProgress);


            Console.ReadKey();
        }
    }
    interface ISeries
    {
        void setStart(int x);
        int getNext();
        void reset();
    }

    public class ArithProgression : ISeries
    {
        int indexProgress;
        int StartElement { set; get; }
        int elemProgress;
        readonly int stepProgr;
        public ArithProgression() { }
        public ArithProgression(int stepProgr)
        {
            this.stepProgr = stepProgr;
            StartElement = 0;
            elemProgress = 0;
        }
        public int IndexProgress
        {
            get
            {
                return indexProgress;
            }
            set
            {
                if (value >= 0)
                {
                    indexProgress = value;
                }
            }
        }
        public int getNext()
        {
            IndexProgress++;
            elemProgress = StartElement + IndexProgress * stepProgr;
            return elemProgress;
        }

        public void reset()
        {
            elemProgress = 0;
            IndexProgress = 0;
            Console.WriteLine("Проведен сброс до начального значения прогрессии: {0}", StartElement);
        }

        public void setStart(int x)
        {
            StartElement = x;
            IndexProgress = 0;
            Console.WriteLine("В арифметическую последовательность установлено начальное значение {0}", x);
        }
    }

    public class GeomProgression : ISeries
    {
        int indexProgress;
        int StartElement { set; get; }
        int elemProgress;
        readonly int stepProgr;
        public GeomProgression() { }
        public GeomProgression(int stepProgr)
        {
            this.stepProgr = stepProgr;
            StartElement = 0;
            elemProgress = 0;
        }
        public int IndexProgress
        {
            get
            {
                return indexProgress;
            }
            set
            {
                if (value >= 0)
                {
                    indexProgress = value;
                }
            }
        }
        public int getNext()
        {
            IndexProgress++;
            elemProgress = ((elemProgress == 0) ? StartElement : elemProgress) * stepProgr;
            //elemProgress = Convert.ToInt32(StartElement * Math.Pow(Convert.ToDouble(stepProgr), Convert.ToDouble(IndexProgress)));
            return elemProgress;
        }

        public void reset()
        {
            elemProgress = 0;
            IndexProgress = 0;
            Console.WriteLine("Проведен сброс до начального значения прогрессии: {0}", StartElement);
        }

        public void setStart(int x)
        {
            StartElement = x;
            IndexProgress = 0;
            Console.WriteLine("В геометрическую последовательность установлено начальное значение {0}", x);
        }
    }
}
