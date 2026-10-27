using System.Runtime.CompilerServices;
using System.Text;
namespace Lab3;

internal class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("1. Використання using");
        using (var port = new SerialPortConnection("COM1"))
        {
            port.SendData(new byte[] { 1, 2, 3 });
        }

        Console.WriteLine("\n2. Явний виклик Dispose");
        var secondPort = new SerialPortConnection("COM2");
        secondPort.SendData(new byte[] { 10, 20 });
        secondPort.Dispose();
        secondPort.Dispose(); // Повторний виклик нічого не змінює.

        Console.WriteLine("\n3. Без Dispose, прибирання через GC");
        CreateForgottenPort();
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("Фіналізацію завершено.");
    }

    // Окремий метод не залишає локального посилання в Main.
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void CreateForgottenPort()
    {
        var port = new SerialPortConnection("COM3");
        port.SendData(new byte[] { 100 });
    }
}
