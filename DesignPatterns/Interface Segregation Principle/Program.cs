namespace Interface_Segregation_Principle
{
    public class Document
    {

    }
    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }
    public class MultiFunctionPrinter : IMachine
    {

        public void Print(Document d)
        {
            
        }

        public void Scan(Document d)
        {
            
        }
        public void Fax(Document d)
        {

        }
    }
    public class OldFashionedPrinter : IMachine
    {
        public void Print(Document d)
        {

        }

        public void Scan(Document d)
        {
            
        }
        public void Fax(Document d)
        {
            throw new NotImplementedException();
        }

    }
    public interface IPrinter
    {
        void Print(Document d);
    }
    public interface IScanner
    {
        void Scan(Document d);
    }
    public class Photocopier : IPrinter, IScanner
    {
        public void Print (Document d)
        {
            throw new NotImplementedException();
        }
        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }
    }
    public interface IMultiFunctionDevice : IScanner, IPrinter
    {

    }
    public struct MultiFunctionMachine : IMultiFunctionDevice
    {
        // compose this out of several modules
        private IPrinter printer;
        private IScanner scanner;

        public MultiFunctionMachine(IPrinter printer, IScanner scanner)
        {
            if (printer == null)
            {
                throw new ArgumentNullException(paramName: nameof(printer));
            }
            if (scanner == null)
            {
                throw new ArgumentNullException(paramName: nameof(scanner));
            }
            this.printer = printer;
            this.scanner = scanner;
        }

        public void Print(Document d)
        {
            printer.Print(d);
        }

        public void Scan(Document d)
        {
            scanner.Scan(d);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}