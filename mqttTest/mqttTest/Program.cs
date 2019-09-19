
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Extensions.ManagedClient;
using System;
using System.Threading;
using System.Threading.Tasks;



namespace mqttTest
{
    class Program { 
  
        static void Main(string[] args)
        {
            
              Example().Wait();
        }
        static async Task Example()
        {

           
                //first test
                string clientID = Guid.NewGuid().ToString();
                var factory = new MqttFactory();
                var mqttClient = factory.CreateMqttClient();


                var options = new MqttClientOptionsBuilder()
            .WithClientId(clientID)
            .WithTcpServer("m16.cloudmqtt.com", 11588)
            .WithCredentials("jhfsrkth", "LeA8c8Q7ZPoH")
            .WithCleanSession()
            .Build();

                var message = new MqttApplicationMessageBuilder()
                      .WithTopic("my Topic")
                      .WithPayload("123")
                      .WithExactlyOnceQoS()
                      .WithRetainFlag()
                      .Build();



                await mqttClient.ConnectAsync(options, CancellationToken.None);
                await mqttClient.PublishAsync(message);


            
           

    
        }


    }
}
