using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CollectionsAndGenerics
{
    class Program
    {
        /*
        static Hashtable GetHashtable()
        {
            // Create and return new Hashtable.
            Hashtable hashtable = new Hashtable();
            hashtable.Add("Area", 1000);
            hashtable.Add("Perimeter", 55);
            hashtable.Add("Mortgage", 540);
            return hashtable;
        }
        public static void Main()
        {
            Hashtable hashtable = GetHashtable();
            // See if the Hashtable contains this key.
            Console.WriteLine(hashtable.ContainsKey("Perimeter"));
            // Test the Contains method. It works the same way.
            Console.WriteLine(hashtable.Contains("Area"));
            // Get value of Area with indexer.
            int value = (int)hashtable["Area"];
            // Write the value of Area.
            Console.WriteLine(value);
        }
        */
        static void Main(string[] args)
        {
           /*
              Dictionary<string, int> d = new Dictionary<string, int>()
       
           {"Lion", 2},  {"dog", 1}};
           // Loop over pairs with foreach
           foreach (KeyValuePair<string, int> pair in d)
           {
               Console.WriteLine ("{0}, {1}",pair.Key,  pair.Value);
           }
           foreach (var pair in d)
           {
               Console.WriteLine("{0}, {1}", pair.Key, pair.Value);
           }
             */

            // 1.	максимальная скорость поиска и извлечения искомой строки  
            var searchValue = "as;dkfjaoisdhg osdgosdbga";
            Hashtable table = new Hashtable();
            var oldTime0 = DateTime.Now;
            table.Add( 1, "fdhkhdk sdhkhdfsksdfhkhdkdskhhasgdhoaweiuyaowqerrtoert49325034043 434m34n63m6m34n6m34n6346346 634 6 63 4634 634 6n34");
            table.Add( 2, "a aqeoianv qewuqawecu09 09nnnnnnnnnn2347m 732 8");
            table.Add( 3, " izsddfhdfsdhgsdfhdsfhhdfghfgh  h gdglhlhgldfkhdfhlhdfdf   hldgldf");
            table.Add( 4, "дыфвол ывывыврырвп пв ап двар пдварпдварпрвадпврп вапрва прдр 3д4 р6д34р6др36шр6шдр436р346  ц реуц редцудуцре");
            table.Add( 5, "   ва ваиваилва и вл аофыв оыв и ламфвалоы шгпфыыыфвпффыпывшгпышгпфвгшпгш фы  ы ывшгы ыышыфшышыфшы ы ыш шыгшыг фышы шыга шгыашгы");
            table.Add( 6, "фйц цйуец5445нкекгеншен нн кгнш н  г гн екдкумр ишгкмшгнкмиы ф гффгг куыфкгп шггкшг ыкшг ышык шыгпыкшгркдггпри");
            table.Add( 7, "ы дваыв ывгаыв щыва щ aesfou ffsi oseoufoeisefoo eafofaeo aesfohasef ohsefpigaeshaewt4p4e[98y984y49teeut94t84 8 perp8 tpe4tp");
            table.Add( 8, "]wqp][po23-9i423-852=3495=039460ut mwn b [wq v w[aa jvsg0naaerh ew98u[t [98hta8[[hgte[g7t7e8wtgtvf aewiue t tw ");
            table.Add( 9, searchValue);
            table.Add(10, "a;peimt4079 n6q3-y478a nqt-4v-7889-5-43-1342y-893465a");
            table.Add(11, "aso aufda9ew[u-2347523[.423,2l3;k j5io h23y587qt833333333333333333333349r33255");
            table.Add(12, "afsdijf9807e4t nv078y4y 0340 y4309y 043y08 43y0y6983y3984y4930 y8043");
            table.Add(13, "z 9sdrau 8ey498v8943 v943 7v790v37985384b04980 b43098b480770");
            table.Add(14, "apeoru tm093478 v-493-8437-4 8-9837-3487 5-34987 5-984763-487-39847-3498");
            table.Add(15, "a uea89439848949835v893457348y8 y8b3-89 afdsjabgv dsgjhiewhgte uehahaesg gdg 8dy8yd9yd8yg 9y98y98y9 ty76 r5er ");
            var oldTime1 = DateTime.Now;
            var addTime = oldTime1 - oldTime0;
            var res = table.ContainsValue(searchValue);
            var newTime = DateTime.Now;
            var searchTime = newTime - oldTime1;
            if (res) { Console.WriteLine("Binago!!! Search Value '{0}' exists in table. Adding Time is {1} sec. Search Time is {2} sec", searchValue, addTime, searchTime); }
            else { Console.WriteLine("Error!!! Search Value '{0}' not exists in table", searchValue); }
             
            // 2.	максимальная скорость сохранения данных в коллекции 
            IDictionary dict = new Dictionary<int, string>();
            dict.Add(1, "fdhkhdk sdhkhdfsksdfhkhdkdskhhasgdhoaweiuyaowqerrtoert49325034043 434m34n63m6m34n6m34n6346346 634 6 63 4634 634 6n34");
            dict.Add(2, "a aqeoianv qewuqawecu09 09nnnnnnnnnn2347m 732 8");
            dict.Add(3, " izsddfhdfsdhgsdfhdsfhhdfghfgh  h gdglhlhgldfkhdfhlhdfdf   hldgldf");
            dict.Add(4, "дыфвол ывывыврырвп пв ап двар пдварпдварпрвадпврп вапрва прдр 3д4 р6д34р6др36шр6шдр436р346  ц реуц редцудуцре");
            dict.Add(5, "   ва ваиваилва и вл аофыв оыв и ламфвалоы шгпфыыыфвпффыпывшгпышгпфвгшпгш фы  ы ывшгы ыышыфшышыфшы ы ыш шыгшыг фышы шыга шгыашгы");
            dict.Add(6, "фйц цйуец5445нкекгеншен нн кгнш н  г гн екдкумр ишгкмшгнкмиы ф гффгг куыфкгп шггкшг ыкшг ышык шыгпыкшгркдггпри");
            dict.Add(7, "ы дваыв ывгаыв щыва щ aesfou ffsi oseoufoeisefoo eafofaeo aesfohasef ohsefpigaeshaewt4p4e[98y984y49teeut94t84 8 perp8 tpe4tp");
            dict.Add(8, "]wqp][po23-9i423-852=3495=039460ut mwn b [wq v w[aa jvsg0naaerh ew98u[t [98hta8[[hgte[g7t7e8wtgtvf aewiue t tw ");
            dict.Add(9, searchValue);
            dict.Add(10, "a;peimt4079 n6q3-y478a nqt-4v-7889-5-43-1342y-893465a");
            dict.Add(11, "aso aufda9ew[u-2347523[.423,2l3;k j5io h23y587qt833333333333333333333349r33255");
            dict.Add(12, "afsdijf9807e4t nv078y4y 0340 y4309y 043y08 43y0y6983y3984y4930 y8043");
            dict.Add(13, "z 9sdrau 8ey498v8943 v943 7v790v37985384b04980 b43098b480770");
            dict.Add(14, "apeoru tm093478 v-493-8437-4 8-9837-3487 5-34987 5-984763-487-39847-3498");
            dict.Add(15, "a uea89439848949835v893457348y8 y8b3-89 afdsjabgv dsgjhiewhgte uehahaesg gdg 8dy8yd9yd8yg 9y98y98y9 ty76 r5er ");
            oldTime1 = DateTime.Now;
            addTime = oldTime1 - oldTime0;
            res = dict.Contains(searchValue);
            newTime = DateTime.Now;
            searchTime = newTime - oldTime1;
            if (res) { Console.WriteLine("Binago!!! Search Value '{0}' exists in table. Adding Time is {1} sec. Search Time is {2} sec", searchValue, addTime, searchTime); }
            else { Console.WriteLine("Error!!! Search Value '{0}' not exists in table", searchValue); }

        }

    }
}
