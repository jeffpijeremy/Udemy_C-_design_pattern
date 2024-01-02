﻿namespace Asynchronous_Factory_Method
{
    public class Foo
    {
        public Foo() {
            
        }
        private async Task<Foo> InitAsync()
        {
            await Task.Delay(1000);
            return this;
        }
        public static Task<Foo> CreateAsync()
        {
            var result = new Foo();
            return result.InitAsync();
        }
    }
    internal class Program
    {
        static async void Main(string[] args)
        {
            //var foo = new Foo();
            //await foo.InitAsync();
            Foo x = await Foo.CreateAsync();
        }
    }
}