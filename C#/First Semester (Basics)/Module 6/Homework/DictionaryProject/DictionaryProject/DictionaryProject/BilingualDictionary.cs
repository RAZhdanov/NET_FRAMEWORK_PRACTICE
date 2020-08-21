using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryProject
{
    //Функциональность двустороннего перевода должна быть реализована в виде отдельного класса,
    // а программа должна предоставлять к этому классу внешний пользовательский интерфейс.
    class BilingualDictionary
    {
        private readonly Dictionary<string, HashSet<string>> dictionary = new Dictionary<string, HashSet<string>>();

        public BilingualDictionary()
        {
        }

        public void Add(string word, string translation)
        {
            HashSet<string> hashSet = new HashSet<string>();
            if (!ReferenceEquals(translation, null))
            {
                hashSet.Add(translation.Trim().ToLower());

                if (dictionary.ContainsKey(word.Trim().ToLower()))
                {
                    foreach (KeyValuePair<string, HashSet<string>> iter in dictionary)
                    {
                        if (iter.Key == word)
                        {
                            iter.Value.Add(translation.Trim().ToLower());
                        }
                    }
                }
                else
                {
                    dictionary.Add(word.Trim().ToLower(), hashSet);
                }
            }
        }

        public void Add(string word, List<string> translations)
        {
            foreach (string iter in translations)
            {
                if(!ReferenceEquals(iter, null))
                    Add(word, iter);
            }
            translations.RemoveRange(0, translations.Count);
        }

        public List<string> GetTranslations(string word)
        {
            List<string> list = new List<string>();
            if(!ReferenceEquals(word, null))
            {
                if (dictionary.ContainsKey(word.Trim().ToLower()))
                {
                    foreach (string translation in dictionary[word.Trim().ToLower()])
                    {
                        list.Add(translation);
                    }
                }
                else
                {
                    foreach (KeyValuePair<string, HashSet<string>> translations in dictionary)
                    {
                        if (!translations.Value.Contains(word.Trim().ToLower()))
                        {
                            continue;
                        }
                        list.Add(translations.Key);
                    }
                }
            }
            return list;
        }

        public void PrintTranslations()
        {
            foreach (KeyValuePair<string, HashSet<string>> word in dictionary)
            {
                System.Console.WriteLine($"Translations for the word \" {word.Key} \"");
                foreach(var translation in word.Value)
                {
                    System.Console.WriteLine($"- {translation}");
                }
            }
        }
    }
}
