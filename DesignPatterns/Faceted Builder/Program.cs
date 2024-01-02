namespace Faceted_Builder
{
    public class Person
    {
        // address
        public string StreetAddress, Postcode, City;
        // employment
        public string CompanyName, Position;
        public int AnnualIncome;
        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome} ";
        }
    }
    public class PersonBuilder //facade
    {
        //reference!
        protected Person person = new Person();
        public PersonJobBuilder works => new PersonJobBuilder(person);
        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);

        //使用 operator 和 implicit 或 explicit 關鍵字，分別定義隱含或明確轉換。 您用來定義轉換的型別必須是來源型別或該轉換的目標型別。 您可以將兩個使用者定義型別之間的轉換定義為兩個型別其中之一。
        public static implicit operator Person(PersonBuilder pb)
        {
            return pb.person;
        }
    }
    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder (Person person)
        {
            this.person = person;
        }
        public PersonAddressBuilder At(string streetAddress)
        {
            person.StreetAddress = streetAddress;
            return this;
        }
        public PersonAddressBuilder WithPostcode(string postcode)
        {
            person.Postcode = postcode;
            return this;
        }
        public PersonAddressBuilder In(string city)
        {
            person.City = city;
            return this;
        }
    }
    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person)
        {
            this.person = person;
        }
        public PersonJobBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }
        public PersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }
        public PersonJobBuilder Earning(int amount)
        {
            person.AnnualIncome = amount;
            return this;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var pb = new PersonBuilder();
            Person person = pb
                .Lives
                    .At("TP").In("TW").WithPostcode("42044")
                .works
                    .At("Fabrikam")
                    .AsA("Engineer")
                    .Earning(123000);
            Console.WriteLine(person);
        }
    }
}