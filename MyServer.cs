using Crestron.SimplSharp;
using Crestron.SimplSharp.CrestronIO;
using Crestron.SimplSharp.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text;

namespace TriplePlayServer
{
    public class MyServer
    {
        RootObject rootObject = new RootObject();
        public event EventHandler<MyEventArgs> MyEventToCall;
        public string DisplayPowerFb;
        public string MyCount;
        public string CurrentChannel;
        public string CurrentChannelName;
        public ushort y = 0;
        public string json;
      
        private string _myChannel { get; set; }
        public string MyChannel
        {   
            get { return _myChannel; }
            set { _myChannel = value; }

        }
        private string _myServerIP { get; set; }
        public string MYSERVERIP
        {
            get { return _myServerIP; }
            set { _myServerIP = value; }
        }
        private string _myAuxiliaryID { get; set; }

        public string MYAUXILIARYID
        {
            get { return _myAuxiliaryID; }
            set { _myAuxiliaryID = value; }
        }

        private string _myClientID { get; set; }

        public string MYCLIENTID
        {
            get { return _myClientID; }
            set { _myClientID = value; }
        }

        //Constructor
        public MyServer()
        {
        
        }

        //Power on Connected Display
        public void DisplayPowerOn()
        {
            HttpClient client = new HttpClient();
            HttpClientRequest req = new HttpClientRequest();
            HttpClientResponse res;

            try
            {
                // Request settings
                req.KeepAlive = true;
                req.RequestType = RequestType.Get;

                // Request URL
                //string builder = Constants.SERVER_URL_PROTOCOL + MyServerIP + Constants.SERVER_HEADER + Constants.DISPLAY_ON + ":[auxiliaryId://" + MyAuxiliaryID + "]}\x0A\x0D";
                string builder = Constants.SERVER_URL_PROTOCOL + MYSERVERIP + Constants.SERVER_HEADER + Constants.DISPLAY_ON + ":[\"AuxiliaryId://" + MYAUXILIARYID + "\"]}";

                // string builder = "10.4.0.3/triplecare/JsonRpcHandler.php ?call ={ \"jsonrpc\":2.0,\"method\":\"PowerOnTv\",\"params\":[\"auxiliaryId://IPTV-110\"]}\nHTTP / 1.1\nHost: 10.4.0.3\nContent - Type: application / json\nCookie: PHPSESSID = l81rlk2ru672oktn9m5uckjov6\nContent - Length: 27\n\n{ \"query\":\"\",\"variables\":{ } }";
                // string builder = "http://10.4.0.3/triplecare/JsonRpcHandler.php?call={\"jsonrpc\":\"2.0\",\"method\":\"PowerOnTv\",\"params\":[\"AuxiliaryId://IPTV-110\"]}";
                CrestronConsole.PrintLine("url string is : {0}", builder);
                //req.Url.Parse("https://reqres.in/api/users?page=1");
                req.Url.Parse(builder);

                // Send request
                res = client.Dispatch(req);

                // Handle response and send to the processor err log as notices
                if (res.Code >= 200 && res.Code < 300) ErrorLog.Notice(res.ContentString.ToString());
                else ErrorLog.Notice($"SimplSharpHTTPClientExample --- Received error code in GetExample(): {res.Code}");

            }
            catch (Exception e)
            {
                ErrorLog.Error($"SimplSharpHTTPClientExample --- Exception in GetExample(): {e}");
              //  return string.Empty;
            }
        }

        public void DisplayPowerOff()
        {
            HttpClient client = new HttpClient();
            HttpClientRequest req = new HttpClientRequest();
            HttpClientResponse res;

            try
            {
                // Request settings
                req.KeepAlive = true;
                req.RequestType = RequestType.Get;

                // Request URL
                string builder = Constants.SERVER_URL_PROTOCOL + MYSERVERIP + Constants.SERVER_HEADER + Constants.DISPLAY_OFF + ":[\"AuxiliaryId://" + MYAUXILIARYID + "\"]}";

                //string builder = "10.4.0.3/triplecare/JsonRpcHandler.php ?call ={ \"jsonrpc\":2.0,\"method\":\"PowerOffTv\",\"params\":[\"auxiliaryId://IPTV-110\"]}\nHTTP / 1.1\nHost: 10.4.0.3\nContent - Type: application / json\nCookie: PHPSESSID = l81rlk2ru672oktn9m5uckjov6\nContent - Length: 27\n\n{ \"query\":\"\",\"variables\":{ } }";
                //string builder = "http://10.4.0.3/triplecare/JsonRpcHandler.php?call={\"jsonrpc\":\"2.0\",\"method\":\"PowerOffTv\",\"params\":[\"AuxiliaryId://IPTV-110\"]}";

                CrestronConsole.PrintLine("url string is : {0}", builder);
                //req.Url.Parse("https://reqres.in/api/users?page=1");
                req.Url.Parse(builder);

                // Send request
                res = client.Dispatch(req);

                // Handle response and send to the processor err log as notices
                if (res.Code >= 200 && res.Code < 300) ErrorLog.Notice(res.ContentString.ToString());
                else ErrorLog.Notice($"SimplSharpHTTPClientExample --- Received error code in GetExample(): {res.Code}");

                // Return the response string to Simpl+
                // return res.ContentString.ToString();
            }
            catch (Exception e)
            {
                ErrorLog.Error($"SimplSharpHTTPClientExample --- Exception in GetExample(): {e}");
                //  return string.Empty;
            }
        }

        public void DisplayHDMI1()
        {
            HttpClient client = new HttpClient();
            HttpClientRequest req = new HttpClientRequest();
            HttpClientResponse res;

            try
            {
                // Request settings
                req.KeepAlive = true;
                req.RequestType = RequestType.Get;

            // Request URL
           // http://10.4.0.3/triplecare/JsonRpcHandler.php?call={%22jsonrpc%22:%222.0%22,%22method%22:%22SelectTVInput%22,%22params%22:[%22AuxiliaryId://IPTV-110%22,%20154]}
                string builder = Constants.SERVER_URL_PROTOCOL + MYSERVERIP + Constants.SERVER_HEADER + Constants.DISPLAY_INPUT + ":[\"AuxiliaryId://" + MYAUXILIARYID + "\", 153]}";


                CrestronConsole.PrintLine("url string is : {0}", builder);
                //req.Url.Parse("https://reqres.in/api/users?page=1");
                req.Url.Parse(builder);

                // Send request
                res = client.Dispatch(req);

                // Handle response and send to the processor err log as notices
                if (res.Code >= 200 && res.Code < 300) ErrorLog.Notice(res.ContentString.ToString());
                else ErrorLog.Notice($"SimplSharpHTTPClientExample --- Received error code in GetExample(): {res.Code}");

                // Return the response string to Simpl+
                // return res.ContentString.ToString();
                
                
               
            }
            catch (Exception e)
            {
                ErrorLog.Error($"SimplSharpHTTPClientExample --- Exception in GetExample(): {e}");
                //  return string.Empty;
            }
        }

        public void DisplayHDMI2()
        {
            HttpClient client = new HttpClient();
            HttpClientRequest req = new HttpClientRequest();
            HttpClientResponse res;

            try
            {
                // Request settings
                req.KeepAlive = true;
                req.RequestType = RequestType.Get;

                // Request URL
                string builder = Constants.SERVER_URL_PROTOCOL + MYSERVERIP + Constants.SERVER_HEADER + Constants.DISPLAY_INPUT + ":[\"AuxiliaryId://" + MYAUXILIARYID + "\", 154]}";

                CrestronConsole.PrintLine("url string is : {0}", builder);
                //req.Url.Parse("https://reqres.in/api/users?page=1");
                req.Url.Parse(builder);

                // Send request
                res = client.Dispatch(req);

             
                // Handle response and send to the processor err log as notices
                if (res.Code >= 200 && res.Code < 300) ErrorLog.Notice(res.ContentString.ToString());
                else ErrorLog.Notice($"SimplSharpHTTPClientExample --- Received error code in GetExample(): {res.Code}");

                // Return the response string to Simpl+
                // return res.ContentString.ToString();

            }
            catch (Exception e)
            {
                ErrorLog.Error($"SimplSharpHTTPClientExample --- Exception in GetExample(): {e}");
                //  return string.Empty;
            }
        }

        public void ChannelDown()
        {
            HttpClient client = new HttpClient();
            HttpClientRequest req = new HttpClientRequest();
            HttpClientResponse res;

            try
            {
                // Request settings
                req.KeepAlive = true;
                req.RequestType = RequestType.Get;

                // Request URL
                string builder = Constants.SERVER_URL_PROTOCOL + MYSERVERIP + Constants.SERVER_HEADER + Constants.CHANNELDOWN + ":[\"AuxiliaryId://" + MYAUXILIARYID + "\"]}";

                CrestronConsole.PrintLine("url string is : {0}", builder);
                //req.Url.Parse("https://reqres.in/api/users?page=1");
                req.Url.Parse(builder);

                // Send request
                res = client.Dispatch(req);

              
                // Handle response and send to the processor err log as notices
                if (res.Code >= 200 && res.Code < 300) ErrorLog.Notice(res.ContentString.ToString());
                else ErrorLog.Notice($"SimplSharpHTTPClientExample --- Received error code in GetExample(): {res.Code}");

                // Return the response string to Simpl+
                // return res.ContentString.ToString();
          
            }
            catch (Exception e)
            {
                ErrorLog.Error($"SimplSharpHTTPClientExample --- Exception in GetExample(): {e}");
                //  return string.Empty;
            }
        }

        public void ChannelUp()
        {
            HttpClient client = new HttpClient();
            HttpClientRequest req = new HttpClientRequest();
            HttpClientResponse res;

            try
            {
                // Request settings
                req.KeepAlive = true;
                req.RequestType = RequestType.Get;

                // Request URL
                string builder = Constants.SERVER_URL_PROTOCOL + MYSERVERIP + Constants.SERVER_HEADER + Constants.CHANNELUP + ":[\"AuxiliaryId://" + MYAUXILIARYID + "\"]}";

                CrestronConsole.PrintLine("url string is : {0}", builder);
                //req.Url.Parse("https://reqres.in/api/users?page=1");
                req.Url.Parse(builder);

                // Send request
                res = client.Dispatch(req);


                // Handle response and send to the processor err log as notices
                if (res.Code >= 200 && res.Code < 300) ErrorLog.Notice(res.ContentString.ToString());
                else ErrorLog.Notice($"SimplSharpHTTPClientExample --- Received error code in GetExample(): {res.Code}");

                // Return the response string to Simpl+
                // return res.ContentString.ToString();
            }
            catch (Exception e)
            {
                ErrorLog.Error($"SimplSharpHTTPClientExample --- Exception in GetExample(): {e}");
                //  return string.Empty;
            }
        }

        public void SelectChannel()
        {
            HttpClient client = new HttpClient();
            HttpClientRequest req = new HttpClientRequest();
            HttpClientResponse res;

            try
            {
                // Request settings
                req.KeepAlive = true;
                req.RequestType = RequestType.Get;

                // Request URL
                string builder = Constants.SERVER_URL_PROTOCOL + MYSERVERIP + Constants.SERVER_HEADER + Constants.SELECT_CHANNEL + ":[\"AuxiliaryId://" + MYAUXILIARYID + "\"," + MyChannel + "]}";
                CrestronConsole.PrintLine("url string is : {0}", builder);
                //req.Url.Parse("https://reqres.in/api/users?page=1");
                req.Url.Parse(builder);

                // Send request
                res = client.Dispatch(req);
                

                // Handle response and send to the processor err log as notices
                if (res.Code >= 200 && res.Code < 300)
                {
                    ErrorLog.Notice(res.ContentString.ToString());
                }    
                    
                else ErrorLog.Notice($"SimplSharpHTTPClientExample --- Received error code in GetExample(): {res.Code}");

               // Set json to Return String
                json = res.ContentString.ToString();
                
               
            }
            catch (Exception e)
            {
                ErrorLog.Error($"SimplSharpHTTPClientExample --- Exception in GetExample(): {e}");
                //  return string.Empty;
            }
        }

        public void QueryServer()
        {
            HttpClient client = new HttpClient();
            HttpClientRequest req = new HttpClientRequest();
            HttpClientResponse res;

            try
            {
                // Request settings
                req.KeepAlive = true;
                req.RequestType = RequestType.Get;

                // Request URL
                string builder = "http://10.4.0.3/triplecare/JsonRpcHandler.php?call={\"jsonrpc\":2.0,\"method\":\"QueryClients\",\"params\":[[{\"field\":\"clientType\",\"operator\":\"is\",\"value\":\"STB\"}],{\"hardware\":true,\"network\":true,\"activity\":false,\"services\":false,\"configuration\":false},\"ipAddress\",300,1]}";
                //string builder = Constants.SERVER_URL_PROTOCOL + MyServerIP + Constants.SERVER_HEADER + Constants.CLIENT_QUERY + ":[" + MyAuxiliaryID + "]}";
                CrestronConsole.PrintLine("url string is : {0}", builder);
                //req.Url.Parse("https://reqres.in/api/users?page=1");
                req.Url.Parse(builder);

                // Send request
                res = client.Dispatch(req);

                // Handle response and send to the processor err log as notices
                if (res.Code >= 200 && res.Code < 300) ErrorLog.Notice(res.ContentString.ToString());
                else ErrorLog.Notice($"SimplSharpHTTPClientExample --- Received error code in GetExample(): {res.Code}");

                // Set json to Return String
                 json =  res.ContentString.ToString();

                DeserializeJson();
            }
            catch (Exception e)
            {
                ErrorLog.Error($"SimplSharpHTTPClientExample --- Exception in GetExample(): {e}");
                //  return string.Empty;
            }
        }

        public void QueryClient()
        {
            HttpClient client = new HttpClient();
            HttpClientRequest req = new HttpClientRequest();
            HttpClientResponse res;

            try
            {
                // Request settings
                req.KeepAlive = true;
                req.RequestType = RequestType.Get;

                // Request URL
                string builder = "http://10.4.0.3/triplecare/JsonRpcHandler.php?call={\"jsonrpc\":2.0,\"method\":\"QueryClients\",\"params\":[[{\"field\":\"auxiliaryId\",\"operator\":\"is\",\"value\":\"" + MYAUXILIARYID + "\"}],{\"hardware\":false,\"network\":true,\"activity\":true,\"services\":false,\"configuration\":false},\"location\",1000,1]}";

                CrestronConsole.PrintLine("url string is : {0}", builder);
                //req.Url.Parse("https://reqres.in/api/users?page=1");
                req.Url.Parse(builder);

                // Send request
                res = client.Dispatch(req);

                // Handle response and send to the processor err log as notices
                if (res.Code >= 200 && res.Code < 300)
                {
                    ErrorLog.Notice(res.ContentString.ToString());
                }
                else ErrorLog.Notice($"SimplSharpHTTPClientExample --- Received error code in GetExample(): {res.Code}");

                // Set json to Return String
                json = res.ContentString.ToString();

                DeserializeClientQueryJson();
            }
            catch (Exception e)
            {
                ErrorLog.Error($"SimplSharpHTTPClientExample --- Exception in GetExample(): {e}");
                //  return string.Empty;
            }
        }

        public void QueryDisplayPower()
        {
            HttpClient client = new HttpClient();
            HttpClientRequest req = new HttpClientRequest();
            HttpClientResponse res;

            try
            {
                // Request settings
                req.KeepAlive = true;
                req.RequestType = RequestType.Get;

                // Request URL   http://10.4.0.3/triplecare/JsonRpcHandler.php?call={"jsonrpc":"2.0"," GetPowerStatus ","params":[1]}
                string builder = Constants.SERVER_URL_PROTOCOL + MYSERVERIP + Constants.SERVER_HEADER + Constants.GETPOWERSTATUS + ":[\"AuxiliaryId://" + MYAUXILIARYID + "\"]}";

                CrestronConsole.PrintLine("url string is : {0}", builder);
                //req.Url.Parse("https://reqres.in/api/users?page=1");
                req.Url.Parse(builder);

                // Send request
                res = client.Dispatch(req);

                // Handle response and send to the processor err log as notices
                if (res.Code >= 200 && res.Code < 300)
                {
                    ErrorLog.Notice(res.ContentString.ToString());
                }
                else ErrorLog.Notice($"SimplSharpHTTPClientExample --- Received error code in GetExample(): {res.Code}");

                // Set json to Return String
                json = res.ContentString.ToString();

                DeserializeClientDisplayPower();
            }
            catch (Exception e)
            {
                ErrorLog.Error($"SimplSharpHTTPClientExample --- Exception in GetExample(): {e}");
                //  return string.Empty;
            }
        }

        public void DeserializeClientQueryJson()
        {
            try
            {
                // var json = File.ReadToEnd(Constants.CONFIG_DIRECTORY + Constants.Filename, Encoding.UTF8);
                var filecontents = new StringReader(json);
                var jsonTextReader = new JsonTextReader(filecontents);
                var jsonSerializer = new JsonSerializer();
                rootObject = jsonSerializer.Deserialize<RootObject>(jsonTextReader);
                GetChannel();
            }
            catch (Exception e)
            {
                ErrorLog.Error("Error Converting File Contents to RootObject = {0}", e.Message);
            }
        }
            
        public void DeserializeClientDisplayPower()
        {
            try
            {
                // var json = File.ReadToEnd(Constants.CONFIG_DIRECTORY + Constants.Filename, Encoding.UTF8);
                var filecontents = new StringReader(json);
                var jsonTextReader = new JsonTextReader(filecontents);
                var jsonSerializer = new JsonSerializer();
                rootObject = jsonSerializer.Deserialize<RootObject>(jsonTextReader);

                CrestronConsole.Print("Returned Power status as Json: {0}", rootObject);



                GetPowerStatus();
            }
            catch (Exception e)
            {
                ErrorLog.Error("Error Converting File Contents to RootObject = {0}", e.Message);
            }
        }

        public void DeserializeJson()
        {
            try
            {
                // var json = File.ReadToEnd(Constants.CONFIG_DIRECTORY + Constants.Filename, Encoding.UTF8);
                var filecontents = new StringReader(json);
                var jsonTextReader = new JsonTextReader(filecontents);
                var jsonSerializer = new JsonSerializer();
                rootObject = jsonSerializer.Deserialize<RootObject>(jsonTextReader);
                GetClients();
                GetTotalCount();
            }
            catch (Exception e)
            {
                ErrorLog.Error("Error Converting File Contents to RootObject = {0}", e.Message);
            }
        }

        public void GetTotalCount()
        {
            MyCount = rootObject.TriplePlayResult.Total;
        }

        public void GetClients()
        {
            MyEventArgs args = new MyEventArgs();

            foreach (Client item in rootObject.TriplePlayResult.clients)
            {
                args.MyIndex = (ushort)(rootObject.TriplePlayResult.clients.IndexOf(item) + 1);
                args.MyClientId = item.ClientId;
                args.MyLocale = item.Locale;
                args.MyLocation = item.Location;
                args.MyAuxiliaryId = item.AuxiliaryId;
                MyEventToCall?.Invoke(this, args);
            }
           
        }
        public void GetChannel()
        {
            foreach (Client item in rootObject.TriplePlayResult.clients)
            {
                    //sends to Simpl+ module
                CurrentChannel = item.activity.currentService.channelNumber;
                CurrentChannelName = item.activity.currentService.name;
            }
        }
        public void GetPowerStatus()
        {
            CrestronConsole.PrintLine("Return Power Status Json:{0}", rootObject.TriplePlayResult);
            if (rootObject.TriplePlayResult.Equals("{\"jsonrpc\":\"2.0\",\"id\":null,\"result\":\"off\"}"))
            {
                DisplayPowerFb = "off";
            }  
            else if (rootObject.TriplePlayResult.Equals("{\"jsonrpc\":\"2.0\",\"id\":null,\"result\":\"on\"}"))
            {
                DisplayPowerFb = "on";
            }


        }


    }

    public class MyEventArgs : EventArgs
    {
        public ushort MyIndex { get; set; }
        public string MyClientId { get; set; }
        public string MyLocale { get; set; }
        public string MyLocation { get; set; }
        public string MyAuxiliaryId { get; set; }
      
    }
}
