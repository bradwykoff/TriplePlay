using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriplePlayServer
{
    public static class Constants
    {
        public const string CONFIG_DIRECTORY = "/NVRAM/myJson/";
        public const string Filename = "TriplePlayServerJson.json";
        public const string SERVER_URL_PROTOCOL = "http://";
        public const string SERVER_HEADER = "/triplecare/JsonRpcHandler.php?call=";
        public const string CLIENT_QUERY = "{\"jsonrpc\":\"2.0\",\"method\":\"GetAllServices\",\"params\"";
        public const string DISPLAY_ON = "{\"jsonrpc\":\"2.0\",\"method\":\"PowerOnTv\",\"params\"";
        public const string DISPLAY_OFF = "{\"jsonrpc\":\"2.0\",\"method\":\"PowerOffTv\",\"params\"";
        public const string DISPLAY_INPUT = "{\"jsonrpc\":\"2.0\",\"method\":\"SelectTVInput\",\"params\"";
        public const string SELECT_CHANNEL = "{\"jsonrpc\":\"2.0\",\"method\":\"SelectChannel\",\"params\"";
        public const string CHANNELUP = "{\"jsonrpc\":\"2.0\",\"method\":\"ChannelUp\",\"params\"";
        public const string CHANNELDOWN = "{\"jsonrpc\":\"2.0\",\"method\":\"ChannelDown\",\"params\"";
        public const string GETPOWERSTATUS = "{\"jsonrpc\":\"2.0\",\"method\":\"GetPowerStatus\",\"params\"";
        // public const string PLAYER_CLIENT = ""
    }
}
