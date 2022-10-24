using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TriplePlayServer
{
    public class RootObject
    {
        [JsonProperty("result")]
        public Result TriplePlayResult { get; set; }
    }

    public class Result
    {
        public string Total { get; set; }
        public List<Client> clients { get; set; }
    }

    public class Client
    {
        public string ClientId { get; set; }
        public string Locale { get; set; }
        public string Location { get; set; }
        public Activity activity { get; set; }
        public string AuxiliaryId { get; set; }
        public List<Activity> activities { get; set; }
    }

    public class Activity
    {
        public string application { get; set; }
        public string lastSeen { get; set; }
        public string themeId { get; set; }
        public string page { get; set; }
        public string pageName { get; set; }
        public string pageLoaded { get; set; }
        public CurrentService currentService { get; set; }
    }

    public class CurrentService
    {
        public int id { get; set; }
        public string channelNumber { get; set; }
        public string name { get; set; }
        public bool isFavourite { get; set; }
        public string iconPath { get; set; }
        public int type { get; set; }
        public bool isWatchable { get; set; }
      
    }
}
