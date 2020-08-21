using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DictionaryProject
{
  
    class Program
    {
        static void Main(string[] args)
        {
            //Словарь не должен напрямую взаимодействовать с пользователем.
            BilingualDictionary dict = new BilingualDictionary();

            //4. Желательно, некоторое первоначальное количество пар слов завести в программе.
            List<string> list = new List<string>();
            list.Add(null);
            list.Add("     суматоха");
            list.Add("    суета");
            list.Add("   спешка");
            list.Add("   поспешность");
            list.Add(" торопливость ");
            list.Add("   нетерпение    ");
            list.Add("   торопить    ");
            list.Add("   подгонять            ");
            list.Add("    ускорять");
            list.Add("   торопиться");


            dict.Add("hurry", list);


            list.Add("     бежать");
            list.Add("     идти");

            string str = null;
            dict.Add("go", str);
            dict.Add("go", "бежать");
            dict.Add("go", "бежать");
            dict.Add("go", "бежать");



            List<string> variable1 = dict.GetTranslations("торопливость");
            List<string> variable2 = dict.GetTranslations("  go            ");

            dict.PrintTranslations();

            ;
        }
    }
}
