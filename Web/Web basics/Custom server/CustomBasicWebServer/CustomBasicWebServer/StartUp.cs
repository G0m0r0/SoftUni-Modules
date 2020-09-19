namespace CustomBasicWebServer
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    class StartUp
    {
        const string NewLine = "\r\n";
        static async Task Main()
        {
            //await ReadData();
            var tcpListener = new TcpListener(IPAddress.Loopback, 12345); //loopback= localhost= 127.0.0.1::1=My IP
            tcpListener.Start();

            //deamon //service
            while (true)
            {
                var client = tcpListener.AcceptTcpClient();
                using var stream=client.GetStream();

                 byte[] buffer = new byte[1000000];
                 var lenght=stream.Read(buffer, 0, buffer.Length);

                string requestStr=Encoding.UTF8.GetString(buffer, 0, lenght);

                var Username = GetUsername(requestStr);
                //var tweet = GetTweet(requestStr);

                Console.WriteLine(requestStr);
                Console.WriteLine(new string('-',70));

                string html = $"<h1>Hello Dido {DateTime.Now}</h1><form method=post><Label>Username:     </Label><input name=username><br><Label>Tweet:    </Label><input name=tweet><br><input type=submit></form>";

                  //Content-Type can be application/xml, text/plain, image/png, text/json
                  //Content-Disposition: attachment; filename=dido.txt     it will save as txt file
                  string response = "HTTP/1.1 200 OK"+NewLine+"Server: DidoServer 2020"
                    +NewLine+"Content-Type: text/html; charset=utf-8"
                    +NewLine+"Content-Lenght: "+html.Length+NewLine+NewLine+html+NewLine;  //html.length bcs of latin letters and utf 8

                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                stream.Write(responseBytes);

                Console.WriteLine(response);
                Console.WriteLine(new string('-',70));
            }
        }

        private static object GetUsername(string requestStr)
        {
            var tokens = requestStr.Split(Environment.NewLine);

            return "";
        }

        private static object GetTweet(string requestStr)
        {
            throw new NotImplementedException();
        }

        public static async Task ReadData()
        {
            string url = "https://softuni.bg/";
            HttpClient httpClient = new HttpClient();
            //var html = await httpClient.GetStringAsync(url);
            //Console.WriteLine(html);
            //or
            var response = await httpClient.GetAsync(url);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(string.Join
                (Environment.NewLine, response.Headers.Select(x=>x.Key+":"+x.Value.First())));            
        }

    }
}
