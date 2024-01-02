﻿namespace Functional_Builder
{
    public class Person
    {
        public string Name, Position;
    }
    public abstract class FunctionalBuilder<TSubject,TSelf>
        where TSelf : FunctionalBuilder<TSubject, TSelf>
        where TSubject :new()
    {
        private readonly List<Func<Person, Person>> actions =
            new List<Func<Person, Person>>();
        public TSelf Do(Action<Person> action)
            => AddAction(action);
        public Person Build() => actions.Aggregate(new Person(), (p, f) => f(p));
        private TSelf AddAction(Action<Person> action)
        {
            actions.Add(p =>
            {
                action(p);
                return p;
            });
            return (TSelf)this;
        }
    }
    public sealed class PersonBuilder:
        FunctionalBuilder<Person, PersonBuilder>
    {
        public PersonBuilder Called(string name)
            => Do(p => p.Name =name);
    }
    //防止後續類別繼承此類別
    #region 封裝方式的寫法
    //public sealed class PersonBuilder
    //{
    //    private readonly List<Func<Person,Person>> actions = 
    //        new List<Func<Person,Person>>();
    //    public PersonBuilder Called (string name) 
    //        => Do(p=>p.Name = name);
    //    public PersonBuilder Do(Action<Person> action) 
    //        => AddAction(action);
    //    public Person Build() => actions.Aggregate(new Person(), (p, f) => f(p));
    //    private PersonBuilder AddAction(Action<Person> action)
    //    {
    //        actions.Add(p =>
    //        {
    //            action(p);
    //            return p;
    //        });
    //        return this;
    //    }
    //}
    #endregion
    public static class PersonBuilderExtensions
    {
        public static PersonBuilder WorksAsA(this PersonBuilder builder,string position) =>
            builder.Do(p => p.Position = position);
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var person = new PersonBuilder()
                .Called("Sarah")
                .WorksAsA("Developer")
                .Build();
        }
    }
}