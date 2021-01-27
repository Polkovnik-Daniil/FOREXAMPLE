using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    public interface IOperation<T>
    {
        public void ADD(T val);
        public T DEL();
        public void SHW();
        public int SST();
    }
    public class CollectionTypes<T>: IComparable<T>, IEnumerable<T>, IOperation<T>
    {
        public static Stack<T> stack = new Stack<T>();

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        int IComparable<T>.CompareTo(T other)
        {
            throw new NotImplementedException();
        }

        public void ADD(T val)
        {
            try
            {
                stack.Push(val);
                Console.WriteLine("Value: " + val);
                return;
            }
            catch
            {
                Console.WriteLine("Error add");
                return;
            }
        }

        public T DEL()
        {
            object obj;
            try
            {
                obj = stack.Pop();
                Console.WriteLine("Value was fetched\n");
            }
            catch
            {
                Console.WriteLine("Value wasnt fetched\n");
                obj = null;
            }
            return (T)obj;
        }

        public void SHW()
        {
            try
            {
                int size_stack = SST();
                string[] array_stack = new string[size_stack];
                object obj;
                int i;
                for (i = size_stack - 1; i > -1; i--)
                {
                    try
                    {
                        obj = stack.Pop();
                        Console.WriteLine("value array: " + (string)obj);
                        array_stack[i] = (string)obj;
                        Console.WriteLine("value array: " + array_stack[i]);
                    }
                    catch
                    {
                        Console.WriteLine("Error Show stack(Error Pop)");
                        return;
                    }
                    finally
                    {
                        Console.WriteLine("was");
                    }
                }
                for (i = 0; i < size_stack; i++)
                {
                    object str = (string)array_stack[i];
                    stack.Push((T)str);
                    //ADD((T)str);
                }
            }
            catch 
            {
                Console.WriteLine("Fail");
            }
            return;
        }
        public int SST()
        {
            return stack.Count;
        }

    }

    class Generalizedlimitation<T> where T : UserType
    {
        public T x;
        public T y;
        public T GetX
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public T GetY
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public void show()
        {
            Console.WriteLine("Result: " + x + ", " + y);
        }
    }

    class UserType
    {
        struct struc 
        {
            string str;
            int val;
            public struc(string str, int val)
            {
                this.str = str;
                this.val = val;
            }
            public void DisplayInfo()
            {
                Console.WriteLine($"string: {str}  integer: {val}");
            }
        }
        enum en
        {
            VAL_1,
            VAL_2
        };
        public void Shw(int val_1_st,string val_2_st)
        {
            struc stu = new struc(val_2_st, val_1_st);
            stu.DisplayInfo();
        }
        public string gX { get; set; }
        public string gY { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!\n");
            //int i = 0;
            //CollectionTypes<string> st = new CollectionTypes<string>();
            //while (i < 4)
            //{
            //    Console.Write("Enter value: ");
            //    string str = Console.ReadLine();
            //    st.ADD(str);
            //    i++;
            //}
            //int size_stack_1 = st.SST();
            //st.DEL();
            //int size_stack_2 = st.SST();
            //if (size_stack_1 == size_stack_2)
            //{
            //    Console.WriteLine("Fetch error");
            //}
            //st.SHW();

            UserType us = new UserType();
            UserType us1 = new UserType();

            Console.Write("Enter first value(to class Generalizedlimitation): ");
            string str_ = Console.ReadLine();
            us.gX = str_;
            Console.Write("Enter second value(to class Generalizedlimitation): ");
            str_ = Console.ReadLine();
            us1.gY = str_;

            Generalizedlimitation<UserType> genlim = new Generalizedlimitation<UserType>()
            {
                GetX = us,
                GetY = us1
            };
            genlim.show();

            Console.Write("\nEnter value to struct(integer): ");
            int val = int.Parse(Console.ReadLine());
            Console.Write("\nEnter value to struct(string): ");
            string val_string = Console.ReadLine();
            us.Shw(val, val_string);
            
            Console.Write("\nEnter value to write to file: ");
            string wr_string = Console.ReadLine();
            Write(wr_string);
            Read();
            
            Console.WriteLine("\n");
        }
        public static void Write(string str)
        {
            string writePath = @"C:\Users\Пользователь\source\repos\ConsoleApp1\ConsoleApp1\TextFile1.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(str);
                }

                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(str);
                    sw.Write(str);
                }
                Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static async System.Threading.Tasks.Task Read()
        {
            string path = @"C:\Users\Пользователь\source\repos\ConsoleApp1\ConsoleApp1\TextFile1.txt";
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            // асинхронное чтение
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}