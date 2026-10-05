using System.Runtime.CompilerServices;
using System.Text;

namespace Work3;

internal class Program
{
    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("1. БЛОК USING");
        using (SerialPortConnection port = new SerialPortConnection("COM1"))
        {
            port.SendData(new byte[] { 1, 2, 3 });
        }
        Console.WriteLine("Вийшли з using — порт уже закрито.");

        Console.WriteLine("\n2. ЯВНИЙ DISPOSE");
        SerialPortConnection explicitPort = new SerialPortConnection("COM2");
        explicitPort.SendData(new byte[] { 10, 20 });
        explicitPort.Dispose();
        Console.WriteLine("Повторний Dispose не повинен закривати порт вдруге:");
        explicitPort.Dispose();
        Console.WriteLine($"Стан: відкрито = {explicitPort.IsPortOpen}, звільнено = {explicitPort.IsDisposed}.");
        try
        {
            explicitPort.SendData(new byte[] { 99 });
        }
        catch (ObjectDisposedException)
        {
            Console.WriteLine("Передавання після Dispose відхилено.");
        }

        Console.WriteLine("\n3. БЕЗ DISPOSE — ФІНАЛІЗАТОР");
        CreateWithoutDispose();
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("Фіналізацію завершено.");
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void CreateWithoutDispose()
    {
        SerialPortConnection port = new SerialPortConnection("COM3");
        port.SendData(new byte[] { 255 });
        Console.WriteLine("Запускаємо GC.Collect().");
        // Об’єкт залишається живим до повідомлення, а потім метод повертається.
        GC.KeepAlive(port);
    }
}
