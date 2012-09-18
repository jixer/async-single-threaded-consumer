using System;
using System.Threading;

namespace Cjam.Threading.Consumer.Example
{
    class Program
    {
        static AsyncConsumer consumer;

        static void Main(string[] args)
        {
            using (consumer = new AsyncConsumer())
            {
                consumer.BeginInvoke(EchoFirstAndLast, "John", "Smith", EchoCallback, null);
                consumer.BeginInvoke(EchoFirstAndLast, "Kelly", "Smith", EchoCallback, null);
                consumer.BeginInvoke(EchoFirstAndLast, "Steve", "Smith", EchoCallback, null);
                consumer.BeginInvoke(EchoFirstAndLast, "Brooke", "Smith", EchoCallback, null);
                consumer.BeginInvoke(EchoFirstAndLast, "Chris", "Smith", EchoCallback, null);
                consumer.BeginInvoke(EchoFirst, "Chris", EchoCallback, null);
                consumer.BeginInvoke(EchoFirst, "Michelle", EchoCallback, null);
                consumer.BeginInvoke(EchoFirst, "Brent", EchoCallback, null);
                consumer.BeginInvoke(EchoFirst, "John", EchoCallback, null);
                consumer.BeginInvoke(EchoFirst, "Ashley", EchoCallback, null);
                consumer.BeginInvoke(EchoFirstMiddleAndLast, "Elli", 'J', "Smith", EchoCallback, null);
                consumer.BeginInvoke(EchoFirstMiddleAndLast, "Jennifer", 'S', "Smith", EchoCallback, null);
                consumer.BeginInvoke(EchoFirstMiddleAndLast, "Richard", 'L', "Smith", EchoCallback, null);
                consumer.BeginInvoke(EchoFirstMiddleAndLast, "Donald", 'C', "Smith", EchoCallback, null);
                consumer.BeginInvoke(EchoFirstMiddleAndLast, "Heidi", 'D', "Smith", EchoCallback, null);


                Console.WriteLine("5 actions queued...  Press <ENTER> to continue");
                Console.ReadLine();

                Console.WriteLine("\nExecuting long transaction");
                var asyncResult = consumer.BeginInvoke(() => { while (true) { }; return "Done"; }, null, null);
                Thread.Sleep(1000);
            }

            Console.WriteLine("Thread successfully aborted prematurely.");
            Console.WriteLine("Press <ENTER> to continue...");
            Console.ReadLine();

        }

        static string EchoFirstAndLast(string firstName, string lastName)
        {
            return string.Format("Hello {0} {1}'s World!!!", firstName, lastName);
        }

        static string EchoFirstMiddleAndLast(string firstName, char middleInitial, string lastName)
        {
            return string.Format("Hello {0} {1}. {2}'s World!!!", firstName, middleInitial, lastName);
        }

        static string EchoFirst(string firstName)
        {
            return string.Format("Hello {0}'s World!!!", firstName);
        }

        static void EchoCallback(IAsyncResult result)
        {
            string message = consumer.EndInvoke<string>(result);
            Console.WriteLine("Callback received: " + message);
        }
    }
}
