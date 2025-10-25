# WriteAs.cs
Mobile-API for [write.as](https://play.google.com/store/apps/details?id=com.abunchtell.writeas) application that provides an anonymous way to share your writing on the web

## Example
```cs
using System;
using WriteAsApi;
using System.Threading.Tasks;

namespace Application
{
    internal class Program
    {
        static async Task Main()
        {
            var api = new WriteAs();
            string text = await api.publishText("Hello World!");
            Console.WriteLine(text);
        }
    }
}
```
