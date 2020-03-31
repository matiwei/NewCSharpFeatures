using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncStreams
{
    class AsyncStreamExample
    {
        StringBuilder text = new StringBuilder();

        public async Task Run()
        {
            await foreach (byte b in GenerateAsyncEnumerable(7, new CancellationToken()))
            {
                textAppend(b + " ======================================================================================== \n");
            }
            //to wait for tasks in GenerateAsyncEnumerable, which are intentionally not awaited.
            await Task.Delay(1000);
            Console.Write(text);
        }

        async IAsyncEnumerable<int> GenerateAsyncEnumerable(int length, [EnumeratorCancellation] CancellationToken token = default)
        {
            byte counter = 0;
            Random random = new Random();

            while (counter < length && !token.IsCancellationRequested)
            {
                textAppend(counter + " Generator:(1) \n");
                //DelayTask returns counter value, so ContinueWith() knows with what counter started it's 'parent' and wirites as 'PrevID:'
                await DelayTask(random.Next(700), counter)
                    .ContinueWith(x => Sleep(100, counter, " PrevID:" + x.Result + " ContinueWith(DelayTask)"));
                //look for logs like "7 PrevID:3 ContinueWith(DelayTask):(before)" and analyse source of difference between values 7 and 3
                textAppend(counter + " Generator:(2) \n");
                Sleep(100, counter, " Sleep");
                //yield return doesn't end function
                yield return counter;
                //Thread.Sleep(50);
                counter++;
            }
        }

        async Task<int> DelayTask(int delay, int id)
        {
            textAppend(id + " DelayTask:(before) \n");
            await Task.Delay(delay);
            textAppend(id + " DelayTask:(after) \n");
            return id;
        }

        int Sleep(int delay, int id, string message)
        {
            textAppend(id + message + ":(before) \n");
            Thread.Sleep(delay);
            textAppend(id + message + ":(after) \n");
            return id;
        }

        static String GetTabs(int count)
        {
            String a = "";
            for (int i = 0; i < count; i++)
            {
                a += "\t";
            }
            return a;
        }

        void textAppend(string message)
        {
            lock (text)
            {
                text.Append(System.DateTime.Now.TimeOfDay + GetTabs(Thread.CurrentThread.ManagedThreadId) + message);
            }
        }
    }
}
