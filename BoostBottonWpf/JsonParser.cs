using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Dynamic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows;
using Path = System.IO.Path;

namespace BoostBottonWpf
{
    /*

      TODO add generated interface 

     */

    class JsonParser : Extento
    {
        Dictionary<String, Dictionary<String, dynamic>> jsonparse = new Dictionary<string, Dictionary<string, dynamic>>();
        Dictionary<String, dynamic> jsonobj = new Dictionary<string, dynamic>();
        Dictionary<String, Dictionary<String, dynamic>> lastjson = new Dictionary<string, Dictionary<String, dynamic>>();

        Dictionary<String, Object> jsonDict = new Dictionary<string, object>();
        List<Object> json = new List<Object>();
        List<String> jsonout = new List<string>();
        private bool issaved = false;

        string curdir = System.Reflection.Assembly.GetEntryAssembly().Location;



        public JsonParser()
        {


            Get = new List<dynamic>();
            Type = new List<Type>();
            KEY = new List<string>();
            Count = new Dictionary<String, int>();
            jsonobj["get"] = new List<dynamic>();
            jsonobj["type"] = new List<Type>();
            jsonobj["key"] = new List<String>();
            this["get"] = Get;
            this["type"] = Type;
            this["key"] = KEY;
            this["count"] = Count;
            this["path"] = FilePath;



            /*es.Add("yellow", "dfadf");

            //Console.WriteLine(es.yellow);*/

        }


        public JsonParser(String path)
        {

            FilePath = path;
            Get = new List<dynamic>();
            Type = new List<Type>();
            KEY = new List<string>();
            Count = new Dictionary<String, int>();
            Length = File.ReadAllText(FilePath).Length;
            jsonobj["get"] = new List<dynamic>();
            jsonobj["type"] = new List<Type>();
            jsonobj["key"] = new List<String>();
            this["get"] = Get;
            this["type"] = Type;
            this["key"] = KEY;
            this["count"] = Count;
            this["path"] = FilePath;
            this["length"] = Length;


            /*es.Add("yellow", "dfadf");

            //Console.WriteLine(es.yellow);*/

        }
        public Dictionary<String, Dictionary<String, dynamic>> Json
        {
            get
            {
                return jsonparse;
            }
            set
            {
                jsonparse = value;
            }
        }

        public JsonParser(dynamic strobj)
        {

            if (strobj is String)
            {
                strobj = (strobj as String);
                if (strobj.Contains("\\"))
                {

                }
                else if (strobj.Contains("{") && strobj.Contains(":") && strobj.Contains("}"))
                {

                }
            }

            if (strobj is object)
            {
                strobj = (strobj as Object);

                Dictionary<String, object> sd = new Dictionary<string, object>();

                sd.Add("yellow", 2);


                foreach (var k in sd)
                {
                    if (k.Key is String)
                    {
                        this[k.Key] = k.Value;


                    }
                }


            }

        }


        int filecount = 0;


        public StringBuilder LastStringBuilt
        {
            get;
            set;
        }
        public int Length
        {
            get;
            set;
        }

        public String FilePath
        {
            get; set;
        }

        public new Dictionary<String, int> Count
        {
            get;
            set;
        }

        public List<String> KEY
        {
            get;
            set;
        }

        public List<dynamic> Get
        {
            get;
            set;
        }

        public List<Type> Type
        {
            get; set;
        }
        public bool Issaved { get => issaved; set => issaved = value; }
        public int Filecount { get => filecount; set => filecount = value; }

        public void Add(String val)
        {

            json.Add(val);
            //parse();
            /*foreach(var i in this)
            {
                //Console.WriteLine(i);
            }*/
            /*if (jsonparse.Count > 0)*/
            //jsonpars["Get"] = jsonparse;

        }
        public void AddDict(String key, String val)
        {
            jsonDict.Add(key, val);
        }

        public void AddDict(String key, Object val)
        {
            jsonDict.Add(key, val);
        }


        public void Add(Object val)
        {

            json.Add(val);
            //parse();
            /*foreach(var i in this)
            {
                //Console.WriteLine(i);
            }*/
            /*if (jsonparse.Count > 0)*/
            //jsonpars["Get"] = jsonparse;

        }
        int counts = 0;
        public Dictionary<String, Dictionary<String, dynamic>> ToObj(String key, dynamic value)
        {



            if (value is Object)
            {
                Object c = ((Object)value);
                ((List<dynamic>)jsonobj["get"]).Add(c);
                jsonobj["type"].Add(c.GetType());

            }
            else
            if (value is Boolean)
            {
                Boolean c = ((Boolean)value);
                jsonobj["get"].Add(c);
                jsonobj["type"].Add(c.GetType());
            }
            else
            if (value is String)
            {
                String c = (value as String);
                jsonobj["get"].Add(c);
                jsonobj["type"].Add(c.GetType());
            }
            else
            if (value is int)
            {
                int c = ((int)value);
                jsonobj["get"].Add(c);
                jsonobj["type"].Add(c.GetType());
            }
            else
            if (value is double)
            {
                double c = ((double)value);
                jsonobj["get"].Add(c);
                jsonobj["type"].Add(c.GetType());
            }
            else
            if (value is float)
            {
                float c = ((float)value);
                jsonobj["get"].Add(c);
                jsonobj["type"].Add(c.GetType());
            }
            else
            if (value is decimal)
            {
                decimal c = ((decimal)value);
                jsonobj["get"].Add(c);
                jsonobj["type"].Add(c.GetType());
            }

            jsonobj["key"].Add(key);

            Get = jsonobj["get"];


            //Console.WriteLine(counts+"heerere");

            Type = jsonobj["type"];

            KEY.Add(key);
            jsonparse[key] = jsonobj;

            if (counts >= Length)
            {
                counts = 0;
            }
            counts++;
            Count[key] = counts;

            return jsonparse;
        }

        public Dictionary<String, Dictionary<String, dynamic>> ToObj(String key, dynamic value, bool update = false)
        {

            /*TODO Turn jsonobject into Dictionay<string,Dictionary<string,object>>*/

            if (value is Object)
            {
                Object c = ((Object)value);
                ((List<dynamic>)jsonobj["get"]).Add(c);
                jsonobj["type"].Add(c.GetType());

            }
            else
            if (value is Boolean)
            {
                Boolean c = ((Boolean)value);
                jsonobj["get"].Add(c);
                jsonobj["type"].Add(c.GetType());
            }
            else
            if (value is String)
            {
                String c = (value as String);
                jsonobj["get"].Add(c);
                jsonobj["type"].Add(c.GetType());
            }
            else
            if (value is int)
            {
                int c = ((int)value);
                jsonobj["get"].Add(c);
                jsonobj["type"].Add(c.GetType());
            }
            else
            if (value is double)
            {
                double c = ((double)value);
                jsonobj["get"].Add(c);
                jsonobj["type"].Add(c.GetType());
            }
            else
            if (value is float)
            {
                float c = ((float)value);
                jsonobj["get"].Add(c);
                jsonobj["type"].Add(c.GetType());
            }
            else
            if (value is decimal)
            {
                decimal c = ((decimal)value);
                jsonobj["get"].Add(c);
                jsonobj["type"].Add(c.GetType());
            }

            jsonobj["key"].Add(key);

            Get = jsonobj["get"];


            //Console.WriteLine(counts +"Affffff");

            Type = jsonobj["type"];

            KEY.Add(key);
            jsonparse[key] = jsonobj;

            if (counts >= Length)
                counts = 0;
            counts++;
            Count[key] = counts;

            return jsonparse;
        }

        public Dictionary<String, dynamic> find(String key)
        {

            return Json["\"" + key + "\""];
            /* //Console.WriteLine(key.ToString());
             Dictionary<String, dynamic> outs = new Dictionary<string, dynamic>();
             return outs;*/
        }


        public Object find(String key, String type = "get", int index = -1)
        {
            Object outs = new object();
            if (index != -1)
                outs = Json["\"" + key + "\""][type][index];
            else
                outs = Json["\"" + key + "\""][type];
            return outs;
        }

        public Object getElement(String key, String type = "get")
        {
            return find(key, type);
        }

        public dynamic getElement(int key, int index, String type = "get")
        {
            return find(key, index, type);
        }

        public void changeIndex(int key, Object newval)
        {
            jsonparse[this.KEY[key]]["get"][key] = "v";


        }
        public void changeIndex(String key, Object newval)
        {

            ////Console.WriteLine(this.KEY[this.Count["\"" + key + "\""] - 1] + " " + key);
            if (!key.Contains("\""))
            {
                if (this.KEY[this.Count["\"" + key + "\""] - 1] == "\"" + key + "\"")
                    jsonparse["\"" + key + "\""]["get"][Count["\"" + key + "\""] - 1] = newval;
            }
            else
            {
                if (key.Contains("\""))
                {
                    jsonparse[key]["get"][Count[key] - 1] = newval;
                }
                else
                if (this.KEY[this.Count[key] - 1] == "\"" + key + "\"")
                    jsonparse[key]["get"][Count["\"" + key + "\""] - 1] = newval;
            }


        }

        public void Delete(String key)
        {
            jsonparse.Remove("\"" + key + "\"");
            counts--;
        }
        public Dictionary<String, dynamic> find(int key)
        {
            Dictionary<String, dynamic> outs = new Dictionary<string, dynamic>();
            for (int i = 0; i < Json.Count; i++)
            {
                foreach (var j in Json)
                {
                    if (key == i)
                    {
                        outs = j.Value;
                        break;
                    }
                }
            }
            return outs;
        }




        public Dictionary<String, dynamic> find(int key, int index = -1, String type = "get")
        {

            int getc = 0;
            int count = 0;
            bool innerfoo = false;
            Dictionary<String, dynamic> outs = new JsonParser();





            var s = new { d = new List<String>() };


            s.d.Add("afdasdf");

            //Console.WriteLine(s.d);


            //Console.WriteLine(Json[this.KEY[key]][type]);
            if (index == -1)
            {
                outs["get"] = (Json[this.KEY[key]][type]);
            }
            else
            {
                outs["index"] = (Json[this.KEY[key]][type][index]);

            }






            return outs;
        }
        public void addElement(String key, Object obj)
        {
            if (obj is String)
                Json = ToObj("\"" + key + "\"", "\"" + obj + "\"");
            else if (obj is float)
                Json = ToObj("\"" + key + "\"", String.Format("{0:0.00}", obj));
            else if (obj is double)
                Json = ToObj("\"" + key + "\"", String.Format("{0:0.000}", obj));
            else if (obj is decimal)
                Json = ToObj("\"" + key + "\"", String.Format("{0:0.0000}", obj));
            else
                Json = ToObj("\"" + key + "\"", obj);



        }

        /*

          TODO: check for user input spelling before parsing 
                check for empty strings


         */

        public void Update()
        {
            String roming;
            String filepath;
            FileStream configfile;
            StreamReader streamReader;
            String line;
            List<String> json;
            List<String> jsonout;
            roming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            json = new List<String>();
            jsonout = new List<String>();

            var ia = curdir.Replace('/', ',');
            ia = ia.Replace('\\', ',');
            //Console.WriteLine(ia);
            var ial = ia.Split(',');
            List<string> outs = new List<string>();
            List<String> toLocalHost = new List<string>();
            List<String> ttos = new List<string>();
            Dictionary<String, List<Object>> gh = new Dictionary<string, List<object>>();


            if (ia.Contains("BoostMode"))
            {
                for (int i = 0; i < ial.Length; i++)
                {
                    if (i <= 6)
                    {
                        toLocalHost.Add(ial[i]);

                    }




                }
                for (int i = 0; i < ial.Length; i++)
                {
                    if (i <= 11)
                    {
                        outs.Add(ial[i]);
                        ttos.Add(ial[i]);
                    }




                }

            }
            else
            {

                for (int i = 0; i < ial.Length; i++)
                {

                    if (i <= 6)
                    {
                        outs.Add(ial[i]);
                    }


                }


            }

            outs.Add("config.json");


            int counst = 0;

            var s = String.Join("/", outs);

            var local = String.Join("/", toLocalHost) + "/config.json";
            if (!local.Contains("BoostMode"))
            {
                local = s;
            }


            if (File.Exists(new Uri(local).LocalPath.ToString()))
            {

                try
                {

                    streamReader = new StreamReader(path: new Uri(local).LocalPath.ToString());

                    line = streamReader.ReadLine();

                    while (line != null)
                    {
                        ////Console.WriteLine(line);
                        if (!line.Contains("{") || !line.Contains("}"))
                        {

                            //Add(line);
                            //MessageBox.Show(line);
                            RecursiveParse(line, streamReader.EndOfStream);
                        }

                        line = streamReader.ReadLine();


                    }


                    streamReader.Close();


                }
                catch (Exception ex)
                {

                    //MessageBox.Show("Exception: " + ex.Message);
                }
                finally
                {

                }
            }
            //parse();
            //Issaved = false;
          
        }

       /* public void Update()
        {


            String roming;
            String filepath;
            FileStream configfile;
            StreamReader streamReader;
            String line;
            List<String> json;
            List<String> jsonout;
            roming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            json = new List<String>();
            jsonout = new List<String>();

            var ia = curdir.Replace('/', ',');
            ia = ia.Replace('\\', ',');
            //Console.WriteLine(ia);
            var ial = ia.Split(',');
            List<string> outs = new List<string>();
            List<String> toLocalHost = new List<string>();
            List<String> ttos = new List<string>();
            Dictionary<String, List<Object>> gh = new Dictionary<string, List<object>>();


            if (ia.Contains("BoostMode"))
            {
                for (int i = 0; i < ial.Length; i++)
                {
                    if (i <= 6)
                    {
                        toLocalHost.Add(ial[i]);

                    }




                }
                for (int i = 0; i < ial.Length; i++)
                {
                    if (i <= 11)
                    {
                        outs.Add(ial[i]);
                        ttos.Add(ial[i]);
                    }




                }

            }
            else
            {

                for (int i = 0; i < ial.Length; i++)
                {

                    if (i <= 6)
                    {
                        outs.Add(ial[i]);
                    }


                }


            }

            outs.Add("config.json");


            int counst = 0;

            var s = String.Join("/", outs);

            var local = String.Join("/", toLocalHost) + "/config.json";
            if (!local.Contains("BoostMode"))
            {
                local = s;
            }


            if (File.Exists(new Uri(local).LocalPath.ToString()))
            {

                try
                {

                    streamReader = new StreamReader(path: new Uri(local).LocalPath.ToString());

                    line = streamReader.ReadLine();

                    while (line != null)
                    {
                        ////Console.WriteLine(line);
                        if (!line.Contains("{") || !line.Contains("}"))
                        {

                            //Add(line);
                            RecursiveParse(line, streamReader.EndOfStream);
                        }

                        line = streamReader.ReadLine();


                    }


                    streamReader.Close();


                }
                catch (Exception ex)
                {

                    //MessageBox.Show("Exception: " + ex.Message);
                }
                finally
                {

                }
            }
            parse();
            Issaved = false;

            *//* String sd = File.ReadAllText((Path.Combine(roming, "BoostbtnConfig\\config.json"as String)));


             if (File.Exists(Path.Combine(roming, "BoostbtnConfig\\config.json")))
             {


                 filepath = Path.Combine(roming, "BoostbtnConfig\\config.json");

                 try
                 {

                     streamReader = new StreamReader(path: filepath);

                     line = streamReader.ReadLine();

                     while (line != null)
                     {
                         ////Console.WriteLine(line);
                         if (!line.Contains("{") || !line.Contains("}"))
                         {

                             //Add(line);
                             RecursiveParse(line,streamReader.EndOfStream);
                         }

                         line = streamReader.ReadLine();


                     }


                     streamReader.Close();


                 }
                 catch (Exception ex)
                 {

                     //MessageBox.Show("Exception: " + ex.Message);
                 }
                 finally
                 {

                 }

             }

             //parse();
             Issaved = false;*/

            /*
            JsonParseThread threadAction = new JsonParseThread(new List<object>() { this, Issaved});
            Thread thread = new Thread(new ThreadStart(threadAction.update));
            thread.Start();

            thread.Join();*//*
        }
*/

        public void Update(bool on)
        {
            /*JsonParseThread threadAction = new JsonParseThread(new List<object>() { this,Issaved,on});
            Thread thread = new Thread(new ThreadStart(threadAction.update));
            thread.Start();

            thread.Join();*/

        }

        public Dictionary<String, Dictionary<String, dynamic>> parse()
        {

            Dictionary<String, Dictionary<String, dynamic>> outs = jsonparse;
            if (json.Count > 0)
            {
                foreach (String s in json)
                {
                    String val = s;

                    if (!s.Contains("{"))
                    {
                        if (!s.Contains("}"))
                        {
                            jsonout.Add(s);
                        }
                    }

                }
                foreach (String s in jsonout)
                {
                    String val = s;

                    if (val.Contains(","))
                    {
                        val = val.Replace(",", "");
                    }
                    val = val.Trim();

                    String valueout = val.Substring((val.LastIndexOf(":") + 1), (val.Length - (val.LastIndexOf(":") + 1)));
                    String keyout = val.Substring(0, val.IndexOf(":"));



                }
                foreach (String s in jsonout)
                {
                    String val = s;

                    if (val.Contains(","))
                    {
                        val = val.Replace(",", "");
                    }
                    val = val.Trim();

                    String valueout = val.Substring((val.LastIndexOf(":") + 1), (val.Length - (val.LastIndexOf(":") + 1)));
                    String keyout = val.Substring(0, val.IndexOf(":"));
                    if (val.Contains("AM") ||
                       val.Contains("Am") ||
                       val.Contains("am") ||
                       val.Contains("PM") ||
                       val.Contains("Pm") ||
                       val.Contains("pm"))
                    {
                        valueout = val.Substring((val.LastIndexOf(":") - 1), (val.Length - (val.LastIndexOf(":"))));
                    }


                    //Console.WriteLine(valueout);

                    int k;
                    float k2;
                    double k3;
                    decimal k4;
                    bool v;

                    bool valout = false;
                    bool valout2 = false;
                    bool valout3 = false;
                    bool valout4 = false;







                    if (int.TryParse(valueout, out k))
                    {
                        outs = ToObj(keyout, k);
                    }
                    else if (float.TryParse(valueout, out k2))
                    {
                        outs = ToObj(keyout, k2);
                    }
                    else if (double.TryParse(valueout, out k3))
                    {
                        outs = ToObj(keyout, k3);
                    }
                    else if (decimal.TryParse(valueout, out k4))
                    {
                        outs = ToObj(keyout, k4);
                    }
                    else if (bool.TryParse(valueout, out v))
                    {
                        outs = ToObj(keyout, v);
                    }
                    else
                    {
                        outs = ToObj(keyout, valueout);

                    }




                }
            }




            this["get"] = (Get as List<dynamic>);
            this["type"] = (Type as List<Type>);
            this["json"] = (outs as Dictionary<String, Dictionary<String, dynamic>>);
            lastjson = (outs as Dictionary<String, Dictionary<String, dynamic>>);

            ////MessageBox.Show(outs["\"helpinit\""]["get"][0].ToString());
            return outs;
        }


        List<String> dicouts = new List<string>();
        int discount = 0;
        bool issame = false;
        int lastdiscount = 0;

        private Dictionary<String, Object> RecursiveParse(string value, bool endOfStream)
        {


            Dictionary<String, Object> outs = new Dictionary<string, object>();


            /*TODO Clear Discouts at end*/

            if (value is String)
            {
                String valk = "";
                String cs = "";


                if (!value.Contains("{"))
                {
                    if (!value.Contains("}"))
                    {

                        /*valk = value.Replace("{", "");
                        cs = valk.Replace("}", "");*/
                        dicouts.Add(value);
                        ////MessageBox.Show(value);
                        discount++;
                    }
                }








                if (endOfStream)
                {

                    int counts = 0;

                    ////MessageBox.Show(dicouts.Count.ToString());

                    foreach (String s in dicouts)
                    {
                        String val = s;

                        if (val.Contains(","))
                        {
                            val = val.Replace(",", "");
                        }
                        val = val.Trim();
                        ////MessageBox.Show(val);

                        String valueout = val.Substring((val.LastIndexOf(":") + 1), (val.Length - (val.LastIndexOf(":") + 1)));
                        String keyout = val.Substring(0, val.IndexOf(":"));
                        if (val.Contains("AM") ||
                           val.Contains("Am") ||
                           val.Contains("am") ||
                           val.Contains("PM") ||
                           val.Contains("Pm") ||
                           val.Contains("pm"))
                        {
                            valueout = val.Substring((val.LastIndexOf(":") - 1), (val.Length - (val.LastIndexOf(":"))));
                        }

                        //String keyout = val.Substring(0, val.IndexOf(":")+1);

                        ////Console.WriteLine(val.Substring((val.LastIndexOf(":")+ 1))+ "In recurrisve parse");





                        foreach (var i in outs)
                        {


                        };
                        if (counts >= Length)
                        {
                            counts = 0;
                        }
                        //Get[0] = i;


                        //Console.WriteLine(counts+" "+Get[counts]);

                        int k;
                        float k2;
                        double k3;
                        decimal k4;
                        bool v;

                        if (int.TryParse(valueout, out k))
                        {
                            Get[counts] = k;
                            //changeIndex(keyout, k);
                        }
                        else if (float.TryParse(valueout, out k2))
                        {
                            Get[counts] = k2;
                            //changeIndex(keyout, k);
                        }
                        else if (double.TryParse(valueout, out k3))
                        {
                            Get[counts] = k3;
                            //changeIndex(keyout, k);
                        }
                        else if (decimal.TryParse(valueout, out k4))
                        {
                            Get[counts] = k4;
                            //changeIndex(keyout, k);
                        }
                        else if (bool.TryParse(valueout, out v))
                        {
                            Get[counts] = v;
                            //changeIndex(keyout, k);
                        }
                        else
                        {
                            Get[counts] = valueout;
                            //changeIndex(keyout, valueout);

                        }

                        //MessageBox.Show(Get[counts].ToString());

                       
                        
                        counts++;





                        //Get = jsonparse["\"" + keyout + "\""]["get"];

                    }
                    jsonobj["get"] = (Get as List<dynamic>);
                   
                    //Save();
                    dicouts = new List<String>();
                    discount = 0;
                }





            }

            return jsonobj;
        }


        public Dictionary<String, Object> RecursiveParse(String value, int Length = 0)
        {
            Dictionary<String, Object> outs = new Dictionary<string, object>();


            /*TODO Clear Discouts at end*/

            if (value is String)
            {
                String valk = value.Replace("{", "");

                String cs = valk.Replace("}", "");




                String val = cs;

                if (val.Contains(","))
                {
                    val = val.Replace(",", "");
                }
                val = val.Trim();

                String valueout = val.Substring((val.LastIndexOf(":") + 1));
                String keyout = val.Substring(0, val.IndexOf(":") + 1);
                if (val.Contains("AM") ||
                   val.Contains("Am") ||
                   val.Contains("am") ||
                   val.Contains("PM") ||
                   val.Contains("Pm") ||
                   val.Contains("pm"))
                {
                    valueout = val.Substring((val.LastIndexOf(":") - 1), (val.Length - (val.LastIndexOf(":"))));
                }

                //String keyout = val.Substring(0, val.IndexOf(":")+1);

                ////Console.WriteLine(val.Substring((val.LastIndexOf(":")+ 1))+ "In recurrisve parse");
                //Console.WriteLine(keyout+ "In recurrisve parse");
                //Console.WriteLine(valueout+ "In recurrisve parse");





                if (dicouts.Count == Length)
                {
                    dicouts = new List<String>();
                }


                // //Console.WriteLine(cs + "In recurrisve parse");
                /*
                                    if(discount >= )
                                    discount++;*/
                //disssssssssssssssssssssssssssssssssssssssssssssssssssssss
                ////Console.WriteLine(value+"In recurrisve parse");


            }

            return outs;

        }
        public Dictionary<String, Dictionary<String, dynamic>> parse(bool update = false)
        {

            Dictionary<String, Dictionary<String, dynamic>> outs = jsonparse;
            if (json.Count > 0)
            {
                foreach (String s in json)
                {
                    String val = s;

                    if (!s.Contains("{"))
                    {
                        if (!s.Contains("}"))
                        {
                            jsonout.Add(s);
                        }
                    }



                }
                foreach (String s in jsonout)
                {
                    String val = s;

                    if (val.Contains(","))
                    {
                        val = val.Replace(",", "");
                    }
                    val = val.Trim();

                    String valueout = val.Substring((val.LastIndexOf(":") + 1), (val.Length - (val.LastIndexOf(":") + 1)));
                    String keyout = val.Substring(0, val.IndexOf(":"));



                }
                foreach (String s in jsonout)
                {
                    String val = s;

                    if (val.Contains(","))
                    {
                        val = val.Replace(",", "");
                    }
                    val = val.Trim();

                    String valueout = val.Substring((val.LastIndexOf(":") + 1), (val.Length - (val.LastIndexOf(":") + 1)));
                    String keyout = val.Substring(0, val.IndexOf(":"));
                    if (val.Contains("AM") ||
                       val.Contains("Am") ||
                       val.Contains("am") ||
                       val.Contains("PM") ||
                       val.Contains("Pm") ||
                       val.Contains("pm"))
                    {
                        valueout = val.Substring((val.LastIndexOf(":") - 1), (val.Length - (val.LastIndexOf(":"))));
                    }


                    //Console.WriteLine(valueout);

                    int k;
                    float k2;
                    double k3;
                    decimal k4;
                    bool v;

                    bool valout = false;
                    bool valout2 = false;
                    bool valout3 = false;
                    bool valout4 = false;







                    if (int.TryParse(valueout, out k))
                    {
                        outs = ToObj(keyout, k, update);
                    }
                    else if (float.TryParse(valueout, out k2))
                    {
                        outs = ToObj(keyout, k2, update);
                    }
                    else if (double.TryParse(valueout, out k3))
                    {
                        outs = ToObj(keyout, k3, update);
                    }
                    else if (decimal.TryParse(valueout, out k4))
                    {
                        outs = ToObj(keyout, k4, update);
                    }
                    else if (bool.TryParse(valueout, out v))
                    {
                        outs = ToObj(keyout, v, update);
                    }
                    else
                    {
                        outs = ToObj(keyout, valueout, update);

                    }




                }
            }




            this["get"] = (Get as List<dynamic>);
            this["type"] = (Type as List<Type>);
            this["json"] = (outs as Dictionary<String, Dictionary<String, dynamic>>);
            lastjson = (outs as Dictionary<String, Dictionary<String, dynamic>>);

            ////MessageBox.Show(outs["\"helpinit\""]["get"][0].ToString());
            return outs;
        }

        public StringBuilder jsonbuilder()
        {
            StringBuilder stringBuilder = new StringBuilder();





            stringBuilder.Append("{\n");
            int count = 0;
            foreach (var i in this.Json)
            {

                if (count < (Json.Count - 1))
                {
                    //Console.WriteLine(i.Value["get"][count] is String);

                    if ((i.Value["get"][count] is String))
                    {
                        if ((i.Value["get"][count] as String).Contains("AM") || (i.Value["get"][count] as String).Contains("Am") ||
                            (i.Value["get"][count] as String).Contains("am") ||
                            (i.Value["get"][count] as String).Contains("PM") || (i.Value["get"][count] as String).Contains("Pm") ||
                            (i.Value["get"][count] as String).Contains("pm"))
                        {
                            if (!(i.Value["get"][count] as String).Contains("\""))
                            {
                                stringBuilder.AppendLine("\t" + i.Key + ": \"" + i.Value["get"][count] + "\",");

                            }
                            else
                                stringBuilder.AppendLine("\t" + i.Key + ":" + i.Value["get"][count] + ",");




                        }
                        else
                        {
                            stringBuilder.AppendLine("\t" + i.Key + ":" + i.Value["get"][count] + ",");
                        }

                    }
                    else
                        stringBuilder.AppendLine("\t" + i.Key + ":" + i.Value["get"][count] + ",");
                }
                else
                {
                    //Console.WriteLine("akjhgfjhgadf");

                    if ((i.Value["get"][count] is String))
                    {
                        if ((i.Value["get"][count] as String).Contains("AM") || (i.Value["get"][count] as String).Contains("Am") ||
                            (i.Value["get"][count] as String).Contains("am") ||
                            (i.Value["get"][count] as String).Contains("PM") || (i.Value["get"][count] as String).Contains("Pm") ||
                            (i.Value["get"][count] as String).Contains("pm"))
                        {

                            if (!(i.Value["get"][count] as String).Contains("\""))
                            {
                                stringBuilder.AppendLine("\t" + i.Key + ": \"" + i.Value["get"][count] + "\"");

                            }
                            else
                                stringBuilder.AppendLine("\t" + i.Key + ":" + i.Value["get"][count] + "");

                        }
                        else
                        {
                            stringBuilder.AppendLine("\t" + i.Key + ":" + i.Value["get"][count] + "");
                        }

                    }
                    else
                        stringBuilder.AppendLine("\t" + i.Key + ":" + i.Value["get"][count] + "");


                }

                if (count >= Json.Count)
                {
                    count = 0;
                }
                count++;
            }

            stringBuilder.Append("}");

            LastStringBuilt = stringBuilder;

            Length = stringBuilder.Capacity;


            ////Console.WriteLine(stringBuilder.ToString());

            return stringBuilder;

        }
        public StringBuilder jsonbuilder(String key)
        {
            StringBuilder stringBuilder = new StringBuilder();





            stringBuilder.Append("{\n");
            int count = 0;
            foreach (var i in this.Json)
            {

                if (count < (Json.Count - 1))
                {
                    //Console.WriteLine(i.Value["get"][count] is String);

                    // MessageBox.Show(i.Key.ToString());
                    if (i.Key == key)
                    {
                        if ((i.Value["get"][count] is String))
                        {
                            if ((i.Value["get"][count] as String).Contains("AM") || (i.Value["get"][count] as String).Contains("Am") ||
                                (i.Value["get"][count] as String).Contains("am") ||
                                (i.Value["get"][count] as String).Contains("PM") || (i.Value["get"][count] as String).Contains("Pm") ||
                                (i.Value["get"][count] as String).Contains("pm"))
                            {
                                if (!(i.Value["get"][count] as String).Contains("\""))
                                {
                                    stringBuilder.AppendLine("\t" + i.Key + ": \"" + i.Value["get"][count] + "\",");

                                }
                                else
                                    stringBuilder.AppendLine("\t" + i.Key + ":" + i.Value["get"][count] + ",");




                            }
                            else
                            {
                                stringBuilder.AppendLine("\t" + i.Key + ":" + i.Value["get"][count] + ",");
                            }

                        }
                        else
                            stringBuilder.AppendLine("\t" + i.Key + ":" + i.Value["get"][count] + ",");
                    }
                    else
                    {
                        if ((i.Value["get"][count] is String))
                        {
                            if ((i.Value["get"][count] as String).Contains("AM") || (i.Value["get"][count] as String).Contains("Am") ||
                                (i.Value["get"][count] as String).Contains("am") ||
                                (i.Value["get"][count] as String).Contains("PM") || (i.Value["get"][count] as String).Contains("Pm") ||
                                (i.Value["get"][count] as String).Contains("pm"))
                            {
                                if (!(i.Value["get"][count] as String).Contains("\""))
                                {
                                    stringBuilder.AppendLine("\t" + i.Key + ": \"" + i.Value["get"][count] + "\",");

                                }
                                else
                                    stringBuilder.AppendLine("\t" + i.Key + ":" + i.Value["get"][count] + ",");




                            }
                            else
                            {
                                stringBuilder.AppendLine("\t" + i.Key + ":" + i.Value["get"][count] + ",");
                            }

                        }
                        else
                            stringBuilder.AppendLine("\t" + i.Key + ":" + i.Value["get"][count] + ",");

                    }
                }
                else
                {
                    //Console.WriteLine("akjhgfjhgadf");
                    if (i.Key == key)
                    {
                        if ((i.Value["get"][count] is String))
                        {
                            if ((i.Value["get"][count] as String).Contains("AM") || (i.Value["get"][count] as String).Contains("Am") ||
                                (i.Value["get"][count] as String).Contains("am") ||
                                (i.Value["get"][count] as String).Contains("PM") || (i.Value["get"][count] as String).Contains("Pm") ||
                                (i.Value["get"][count] as String).Contains("pm"))
                            {

                                if (!(i.Value["get"][count] as String).Contains("\""))
                                {
                                    stringBuilder.AppendLine("\t" + i.Key + ": \"" + i.Value["get"][count] + "\"");

                                }
                                else
                                    stringBuilder.AppendLine("\t" + i.Key + ":" + i.Value["get"][count] + "");

                            }
                            else
                            {
                                stringBuilder.AppendLine("\t" + i.Key + ":" + i.Value["get"][count] + "");
                            }

                        }
                        else
                            stringBuilder.AppendLine("\t" + i.Key + ":" + i.Value["get"][count] + "");
                    }
                    else
                    {
                        if ((i.Value["get"][count] is String))
                        {
                            if ((i.Value["get"][count] as String).Contains("AM") || (i.Value["get"][count] as String).Contains("Am") ||
                                (i.Value["get"][count] as String).Contains("am") ||
                                (i.Value["get"][count] as String).Contains("PM") || (i.Value["get"][count] as String).Contains("Pm") ||
                                (i.Value["get"][count] as String).Contains("pm"))
                            {

                                if (!(i.Value["get"][count] as String).Contains("\""))
                                {
                                    stringBuilder.AppendLine("\t" + i.Key + ": \"" + i.Value["get"][count] + "\"");

                                }
                                else
                                    stringBuilder.AppendLine("\t" + i.Key + ":" + i.Value["get"][count] + "");

                            }
                            else
                            {
                                stringBuilder.AppendLine("\t" + i.Key + ":" + i.Value["get"][count] + "");
                            }

                        }
                        else
                            stringBuilder.AppendLine("\t" + i.Key + ":" + i.Value["get"][count] + "");

                    }


                }

                if (count >= Json.Count)
                {
                    count = 0;
                }
                count++;
            }

            stringBuilder.Append("}");

            LastStringBuilt = stringBuilder;

            Length = stringBuilder.Capacity;


            ////Console.WriteLine(stringBuilder.ToString());

            return stringBuilder;

        }

        public void Save()
        {
            Thread.Sleep(1);
            String roming;
            String filepath;
            FileStream configfile;
            roming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            filepath = Path.Combine(roming, "BoostbtnConfig");
            FilePath = filepath + "\\config.json";
            var ia = curdir.Replace('/', ',');
            ia = ia.Replace('\\', ',');
            //Console.WriteLine(ia);
            var ial = ia.Split(',');
            List<string> outs = new List<string>();
            List<String> toLocalHost = new List<string>();
            List<String> ttos = new List<string>();
            Dictionary<String, List<Object>> gh = new Dictionary<string, List<object>>();


            if (ia.Contains("BoostMode"))
            {
                for (int i = 0; i < ial.Length; i++)
                {
                    if (i <= 6)
                    {
                        toLocalHost.Add(ial[i]);

                    }




                }
                for (int i = 0; i < ial.Length; i++)
                {
                    if (i <= 11)
                    {
                        outs.Add(ial[i]);
                        ttos.Add(ial[i]);
                    }




                }

            }
            else
            {

                for (int i = 0; i < ial.Length; i++)
                {

                    if (i <= 6)
                    {
                        outs.Add(ial[i]);
                    }


                }


            }

            outs.Add("config.json");


            int counst = 0;

            var s = String.Join("/", outs);
            var local = String.Join("/", toLocalHost) + "/config.json";
            if (!local.Contains("BoostMode"))
            {
                local = s;
            }
            //Console.WriteLine("over here");
            if (FilePath != "")
            {

                if (File.Exists(local))
                {
                    try
                    {

                        StreamWriter streamWriter = new StreamWriter(local);
                        //Console.WriteLine(jsonbuilder().ToString());

                        streamWriter.WriteLine(jsonbuilder().ToString());


                        streamWriter.Close();




                    }
                    catch (Exception e)
                    {

                        //MessageBox.Show(e.Message);
                    }
                }
            }

            Issaved = true;
            //MyEvent myEvent = new MyEvent();

            //myEvent.SampleEvent += new EventHandler(thistest);


        }
        public void Save(String savethis,Object obj)
        {
            Thread.Sleep(1);
            String roming;
            String filepath;
            FileStream configfile;
            roming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            filepath = Path.Combine(roming, "BoostbtnConfig");
            FilePath = filepath + "\\config.json";
            var ia = curdir.Replace('/', ',');
            ia = ia.Replace('\\', ',');
            //Console.WriteLine(ia);
            var ial = ia.Split(',');
            List<string> outs = new List<string>();
            List<String> toLocalHost = new List<string>();
            List<String> ttos = new List<string>();
            Dictionary<String, List<Object>> gh = new Dictionary<string, List<object>>();


            changeIndex(savethis, obj);

            if (ia.Contains("BoostMode"))
            {
                for (int i = 0; i < ial.Length; i++)
                {
                    if (i <= 6)
                    {
                        toLocalHost.Add(ial[i]);

                    }




                }
                for (int i = 0; i < ial.Length; i++)
                {
                    if (i <= 11)
                    {
                        outs.Add(ial[i]);
                        ttos.Add(ial[i]);
                    }




                }

            }
            else
            {

                for (int i = 0; i < ial.Length; i++)
                {

                    if (i <= 6)
                    {
                        outs.Add(ial[i]);
                    }


                }


            }

            outs.Add("config.json");


            int counst = 0;

            var s = String.Join("/", outs);
            var local = String.Join("/", toLocalHost) + "/config.json";
            if (!local.Contains("BoostMode"))
            {
                local = s;
            }
            //Console.WriteLine("over here");
            if (FilePath != "")
            {

                if (File.Exists(local))
                {
                    try
                    {

                        StreamWriter streamWriter = new StreamWriter(local);
                        //Console.WriteLine(jsonbuilder().ToString());

                        streamWriter.WriteLine(jsonbuilder(savethis).ToString());


                        streamWriter.Close();




                    }
                    catch (Exception e)
                    {

                        //MessageBox.Show(e.Message);
                    }
                }
            }

            Issaved = true;
            //MyEvent myEvent = new MyEvent();

            //myEvent.SampleEvent += new EventHandler(thistest);


        }

        private void thistest(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public JsonParser getParser()
        {
            String roming;
            String filepath;
            FileStream configfile;
            StreamReader streamReader;
            String line;
            List<String> json;
            List<String> jsonout;
            roming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            json = new List<String>();
            jsonout = new List<String>();
            var ia = curdir.Replace('/', ',');
            ia = ia.Replace('\\', ',');
            //Console.WriteLine(ia);
            var ial = ia.Split(',');
            List<string> outs = new List<string>();
            List<String> toLocalHost = new List<string>();
            List<String> ttos = new List<string>();
            Dictionary<String, List<Object>> gh = new Dictionary<string, List<object>>();


            if (ia.Contains("BoostMode"))
            {
                for (int i = 0; i < ial.Length; i++)
                {
                    if (i <= 6)
                    {
                        toLocalHost.Add(ial[i]);

                    }




                }
                for (int i = 0; i < ial.Length; i++)
                {
                    if (i <= 11)
                    {
                        outs.Add(ial[i]);
                        ttos.Add(ial[i]);
                    }




                }

            }
            else
            {

                for (int i = 0; i < ial.Length; i++)
                {

                    if (i <= 6)
                    {
                        outs.Add(ial[i]);
                    }


                }


            }

            outs.Add("config.json");


            int counst = 0;

            var s = String.Join("/", outs);
            var local = String.Join("/", toLocalHost) + "/config.json";
            if (!local.Contains("BoostMode"))
            {
                local = s;
            }

            //Console.WriteLine("in getParse");

            if (File.Exists(local))
            {

                filepath = new Uri(local).LocalPath.ToString();
                try
                {
                    streamReader = new StreamReader(path: filepath);

                    line = streamReader.ReadLine();

                    while (line != null)
                    {
                        ////Console.WriteLine(line);
                        if (!line.Contains("{") || !line.Contains("}"))
                        {

                            Add(line);
                        }

                        line = streamReader.ReadLine();


                    }


                    streamReader.Close();


                }
                catch (Exception ex)
                {

                    //MessageBox.Show("Exception: " + ex.Message);
                }
                finally
                {

                }

            }

            parse();

            return this;

        }
        int fileiter = 0;
        public void Load()
        {
            String roming;
            String filepath;
            FileStream configfile;
            StreamReader streamReader;
            String line;
            List<String> json;
            List<String> jsonout;
            roming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            json = new List<String>();
            jsonout = new List<String>();

            var ia = curdir.Replace('/', ',');
            ia = ia.Replace('\\', ',');
            //Console.WriteLine(ia);
            var ial = ia.Split(',');
            List<string> outs = new List<string>();
            List<String> toLocalHost = new List<string>();
            List<String> ttos = new List<string>();
            Dictionary<String, List<Object>> gh = new Dictionary<string, List<object>>();


            if (ia.Contains("BoostMode"))
            {
                for (int i = 0; i < ial.Length; i++)
                {
                    if (i <= 6)
                    {
                        toLocalHost.Add(ial[i]);

                    }




                }
                for (int i = 0; i < ial.Length; i++)
                {
                    if (i <= 11)
                    {
                        outs.Add(ial[i]);
                        ttos.Add(ial[i]);
                    }




                }

            }
            else
            {

                for (int i = 0; i < ial.Length; i++)
                {

                    if (i <= 6)
                    {
                        outs.Add(ial[i]);
                    }


                }


            }

            outs.Add("config.json");


            int counst = 0;

            var s = String.Join("/", outs);
            //MessageBox.Show(s);
            var local = String.Join("/", toLocalHost) + "/config.json";
            if (!local.Contains("BoostMode"))
            {
                local = s;
            }
            if (File.Exists(new Uri(local).LocalPath.ToString()))
            {
                try
                {
                    //MessageBox.Show("sdkjfhakhdakjkskjsikfhskjlhkjslhfsdalfhsdakf");
                    filepath = new Uri(local).LocalPath.ToString();

                    Length = File.ReadAllLines(local).Length;



                    streamReader = new StreamReader(path: local);

                    line = streamReader.ReadLine();

                    while (line != null)
                    {
                        ////Console.WriteLine(line);
                        if (!line.Contains("{") || !line.Contains("}"))
                        {

                            Add(line);
                            //MessageBox.Show(line);
                        }

                        line = streamReader.ReadLine();


                    }


                    streamReader.Close();


                }
                catch (Exception ex)
                {

                    MessageBox.Show("Exception: " + ex.Message);
                }
                finally
                {

                }
                //MessageBox.Show("skjahfkjhalkjhfdsaf");

            }
            parse();
            /* roming = Environment.GetFolderPath(Environment.SpecialFol

           /* 

            if (File.Exists(Path.Combine(roming, "BoostbtnConfig\\config.json")))
            {
                

                filepath = Path.Combine(roming, "BoostbtnConfig\\config.json");
                try
                {
                    streamReader = new StreamReader(path: filepath);

                    line = streamReader.ReadLine();

                    while (line != null)
                    {
                        ////Console.WriteLine(line);
                        if (!line.Contains("{") || !line.Contains("}"))
                        {

                            Add(line);


                            if (streamReader.EndOfStream){


                                Filecount = fileiter;
                                fileiter = 0;


                            }

                            fileiter++;
                            ////Console.WriteLine();
                            //AddDict()
                            
                        }

                        line = streamReader.ReadLine();


                    }


                    streamReader.Close();

                    
                }
                catch (Exception ex)
                {

                    //MessageBox.Show("Exception: " + ex.Message);
                }
                finally
                {

                }

            }

            parse();*/
            Issaved = false;

        }

        public void Load(bool update)
        {

            String roming;
            String filepath;
            FileStream configfile;
            StreamReader streamReader;
            String line;
            List<String> json;
            List<String> jsonout;
            roming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            json = new List<String>();
            jsonout = new List<String>();




            var ia = curdir.Replace('/', ',');
            ia = ia.Replace('\\', ',');
            //Console.WriteLine(ia);
            var ial = ia.Split(',');
            List<string> outs = new List<string>();
            List<String> toLocalHost = new List<string>();
            List<String> ttos = new List<string>();
            Dictionary<String, List<Object>> gh = new Dictionary<string, List<object>>();


            if (ia.Contains("BoostMode"))
            {
                for (int i = 0; i < ial.Length; i++)
                {
                    if (i <= 6)
                    {
                        toLocalHost.Add(ial[i]);

                    }




                }
                for (int i = 0; i < ial.Length; i++)
                {
                    if (i <= 11)
                    {
                        outs.Add(ial[i]);
                        ttos.Add(ial[i]);
                    }




                }

            }
            else
            {

                for (int i = 0; i < ial.Length; i++)
                {

                    if (i <= 6)
                    {
                        outs.Add(ial[i]);
                    }


                }


            }

            outs.Add("config.json");


            int counst = 0;

            var s = String.Join("/", outs);
            var local = String.Join("/", toLocalHost) + "/config.json";
            if (!local.Contains("BoostMode"))
            {
                local = s;
            }
            //MessageBox.Show(s);
            if (File.Exists(new Uri(local).LocalPath.ToString()))
            {
                try
                {
                    //MessageBox.Show("sdkjfhakhdakjkskjsikfhskjlhkjslhfsdalfhsdakf");
                    filepath = new Uri(local).LocalPath.ToString();

                    int len = File.ReadAllLines(local).Length;



                    streamReader = new StreamReader(path: local);

                    line = streamReader.ReadLine();

                    while (line != null)
                    {
                        ////Console.WriteLine(line);
                        if (!line.Contains("{") || !line.Contains("}"))
                        {

                            Add(line);
                            //MessageBox.Show(line);
                        }

                        line = streamReader.ReadLine();


                    }


                    streamReader.Close();


                }
                catch (Exception ex)
                {

                    MessageBox.Show("Exception: " + ex.Message);
                }
                finally
                {

                }
                //MessageBox.Show("skjahfkjhalkjhfdsaf");

            }
            parse();
            /* roming = Environment.GetFolderPath(Environment.SpecialFol

/*

            if (File.Exists(Path.Combine(roming, "BoostbtnConfig\\config.json")))
            {


                filepath = Path.Combine(roming, "BoostbtnConfig\\config.json");
                try
                {
                    streamReader = new StreamReader(path: filepath);

                    line = streamReader.ReadLine();

                    while (line != null)
                    {
                        ////Console.WriteLine(line);
                        if (!line.Contains("{") || !line.Contains("}"))
                        {

                            Add(line);
                        }

                        line = streamReader.ReadLine();


                    }


                    streamReader.Close();


                }
                catch (Exception ex)
                {

                    //MessageBox.Show("Exception: " + ex.Message);
                }
                finally
                {

                }

            }

            parse();*/
            Issaved = false;

        }
        public void Load(string path)
        {

        }





    }

    public class JsonParseThread
    {
        List<Object> args;
        public JsonParseThread(List<object> lists)
        {
            args = lists;
        }
        public void update()
        {
            if ((args[0] as JsonParser).Issaved)
            {

                (args[0] as JsonParser).Load();

                // //MessageBox.Show("asdfhkajhdskflhasf");
                Thread.Sleep(10);

                (args[0] as JsonParser).Issaved = false;



            }
        }

        public void load()
        {
        }
    }

    public class MyEventArgs
    {
        public MyEventArgs(String text) { Text = text; }
        public string Text { get; }
    }

    public class MyEvent : EventListener
    {
        public MyEvent()
        {
        }

        public delegate EventHandler SampleEventHandler(object sender, MyEventArgs e);

        public event SampleEventHandler SampleEvent;

        protected virtual void RaiseEvent()
        {
            SampleEvent?.Invoke(this, new MyEventArgs("hello"));
        }

    }

    /*
        public class MySaveAction
        {
            public static readonly RoutedEvent SaveEvent = EventManager.RegisterRoutedEvent("Save", RoutingStrategy.Tunnel,
                typeof(RoutedEventHandler), typeof(MyEvent));

            public event RoutedEventHandler Save
            {
                add { AddHadler(SaveEvent, value); }
            }
        }

        public partial class MyEventHandler
        {
            void DoAction(object sender,RoutedEventArgs e)
            {
                MyEvent myEvent = new MyEvent();

                myEvent.SampleEvent += new RoutedEventHandler(Action);
            }

            void Action(object sender,RoutedEventArgs e)
            {

            }
        }

    */
    public class Extento : Dictionary<String, dynamic>
    {
        public String Test
        {
            get; set;
        }

        public static String f(Extento d)
        {
            return "ok";
        }


    }


    public static class Testthis
    {
        public static Dictionary<String, dynamic> o;



        public static String Passing
        {
            get;
            set;

        }

        public static Object changethis(this ExpandoObject expendo)
        {

            return expendo;
        }

        public static ExpandoObject changethis(this Dictionary<String, dynamic> expendo)
        {


            return new ExpandoObject();
        }


    }


}
