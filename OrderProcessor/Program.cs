using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OrderServices.Models;

Console.WriteLine("Order Processor");
IConfiguration configuration = new ConfigurationBuilder()
.AddJsonFile("appsettings.json", true, true)
.Build();



var config = new ConsumerConfig
{
    BootstrapServers = configuration.GetSection("KafkaSettings").GetSection("Server").Value,
    GroupId = "tester",
    AutoOffsetReset = AutoOffsetReset.Earliest
};



//Connect to Kafka
var topic = "SubmitOrder";
CancellationTokenSource cts = new CancellationTokenSource();
Console.CancelKeyPress += (_, e) =>
{
    e.Cancel = true;
    cts.Cancel();
};



using (var consumer = new ConsumerBuilder<string, string>(config).Build())
{



    Console.WriteLine("Connected");
    consumer.Subscribe(topic);
    try
    {
        while (true)
        {
            var cr = consumer.Consume(cts.Token);
            Console.WriteLine($"Consumed record with key: {cr.Message.Key} and value: {cr.Message.Value}");



            using (var context = new ProductQLContext())
            {
                Order order = JsonConvert.DeserializeObject<Order>(cr.Message.Value);
                order.Code = cr.Message.Key;



                context.Orders.Add(order);
                context.SaveChanges();
                Console.WriteLine("Order Submitted");
            }



        }
    }
    catch (OperationCanceledException)
    {
        // Ctrl-C was pressed.
    }
    finally
    {
        consumer.Close();
    }
}