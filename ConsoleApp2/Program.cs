using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MyLL1
{
    public interface IRule
    {
        string Name { get; }
    }

    public class Token : IRule
    {
        public string Name { get; }

        public Token(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public static Token Eof = new Token("$");
        public static Token Empty = new Token("ε");
    }

    public class Rule : IRule
    {
        public string Name { get; }

        public IEnumerable<IEnumerable<IRule>> Definitions { get; }

        public Rule(string name, IEnumerable<IEnumerable<IRule>> definitions)
        {
            Name = name;
            Definitions = definitions;
        }

        public override string ToString()
        {
            return $"{Name}->" + string.Join("/", Definitions.Select(definition =>
                string.Join("", definition.Select(rule => rule.Name))
                ));
        }
    }

    public class RuleManager
    {
        public List<Rule> Rules { get; } = new List<Rule>();

        private Dictionary<string, Token> TokenMap = new Dictionary<string, Token>();

        private Token GetOrCreateToken(string tokenName)
        {
            if (tokenName == "$")
                return Token.Eof;
            if (tokenName == "ε")
                return Token.Empty;
            if (!TokenMap.ContainsKey(tokenName))
                TokenMap.Add(tokenName, new Token(tokenName));
            return TokenMap[tokenName];
        }

        public Rule CreateTextRule(string text)
        {
            var segments = text.Split(new[] { "->" }, StringSplitOptions.None);
            var name = segments[0];
            var ruleText = segments[1];

            var ruleDefinitions = ruleText
                .Split('/')
                .Select(ruleSequenceText =>
                {
                    return ruleSequenceText.Select(token =>
                    {
                        return char.IsUpper(token) ?
                            Rules.First(x => x.Name == token.ToString()) :
                            (IRule)GetOrCreateToken(token.ToString());
                    });
                });
            return new Rule(name, ruleDefinitions);
        }

        public IEnumerable<Token> First(IEnumerable<IEnumerable<IRule>> definitions)
        {
            return definitions.SelectMany(ruleSequence =>
            {
                var tokens = new List<Token>();
                var hasEmpty = true;
                foreach (var item in ruleSequence)
                {
                    if (item is Token token)
                    {
                        if (token != Token.Empty)
                        {
                            hasEmpty = false;
                            tokens.Add(token);
                            break;
                        }
                    }
                    else if (item is Rule rule)
                    {
                        var ruleFirsts = First(rule.Definitions);
                        if (!ruleFirsts.Contains(Token.Empty))
                        {
                            hasEmpty = false;
                            tokens.AddRange(ruleFirsts);
                            break;
                        }
                        else
                        {
                            tokens.AddRange(ruleFirsts.Where(x => x != Token.Empty));
                        }
                    }
                }
                if (hasEmpty) tokens.Add(Token.Empty);
                return tokens;
            })
            .Distinct();
        }

        public IEnumerable<Token> Follow(Rule theRule)
        {
            return Rules
                .SelectMany(knownRule =>
                {
                    return knownRule.Definitions
                        .Where(ruleSequence => ruleSequence.Contains(theRule))
                        .SelectMany(relatedSequence =>
                        {
                            var tokens = new List<Token>();
                            do
                            {
                                relatedSequence = relatedSequence
                                    .SkipWhile(x => x != theRule)
                                    .Skip(1);

                                if (relatedSequence.Any())
                                {
                                    var firsts = First(new[] { relatedSequence });
                                    tokens.AddRange(firsts.Where(x => x != Token.Empty));
                                    if (firsts.Contains(Token.Empty))
                                    {
                                        tokens.AddRange(Follow(knownRule));
                                    }
                                }
                                else if (knownRule != theRule)
                                {
                                    tokens.AddRange(Follow(knownRule));
                                }
                            } while (relatedSequence.Contains(theRule));
                            return tokens;
                        });
                })
                .DefaultIfEmpty(Token.Eof)
                .Distinct();
        }

        public void DumpFF()
        {
            foreach (Rule rule in Rules)
            {
                Console.Write($"{rule,-15}");
                Console.Write("{0, -15}", string.Join(",", First(rule.Definitions)));
                Console.Write("{0, -15}", string.Join(",", Follow(rule)));
                Console.WriteLine();
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome! \n ******************************************************Abdul Basit*************************************************");
            var basit = new RuleManager();
           
            basit.Rules.Add(basit.CreateTextRule("S->ACB/CbB/Ba"));
            basit.Rules.Add(basit.CreateTextRule("A->da/BC"));
            basit.Rules.Add(basit.CreateTextRule("B->g/ε"));
            basit.Rules.Add(basit.CreateTextRule("C->h/ε"));



            basit.DumpFF();
            Console.ReadLine();
        }
    }
}