namespace Fluent_Builder_Inheritance_with_Recursive_Generics
{
    internal class Program
    {
        public class Person
        {
            public string Name;
            public string Position;

            public class Builder : PersonJobBuilder<Builder>
            {

            }
            public static Builder New => new Builder();
            public override string ToString()
            {
                return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
            }
        }
        public abstract class PersonBuilder
        {
            protected Person person = new Person();

            public Person Build()
            {
                return person;
            }
        }
        // class Foo : Bar<Foo>
        // SELF 是一個自行定義的類別，其主要命地就是強調是此類別對於自身的延伸
        // 這樣做的主要目的是在實現方法鏈和流暢介面時，
        // 能夠連續呼叫相關的方法，
        // 而不必擔心類型不一致的問題。

        //where 子句用於泛型宣告中，提供額外的條件或約束，
        //以確保泛型類型滿足特定的條件。
        //where SELF : PersonInfoBuilder<SELF> 是一個 where 子句，
        //它確保泛型參數 SELF 是 PersonInfoBuilder<SELF> 或其衍生類別。
        public class PersonInfoBuilder<SELF> 
            : PersonBuilder
            where SELF : PersonInfoBuilder<SELF>
        {
            public SELF Called(string name)
            {
                person.Name = name;
                return (SELF)this;
            }
        }
        public class PersonJobBuilder<SELF> 
            : PersonInfoBuilder<PersonJobBuilder<SELF>>
            where SELF : PersonJobBuilder<SELF>
        {
            public SELF WorkASA(string position)
            {
                person.Position = position;
                return (SELF)this;
            }
        }
        static void Main(string[] args)
        {
            var me = Person.New
                .Called("dmitri")
                .WorkASA("quant")
                .Build();
            Console.WriteLine(me);

        }
    }
}