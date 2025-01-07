using HandlebarsDotNet;
using MessageTemplate.Examples.Models.Create;
using Newtonsoft.Json;

namespace MessageTemplate.Examples;

public class Program
{
    private static void Main()
    {
        var inputJson = @"{
     ""ChainId"":1,
     ""PoolId"":1,
     ""Users"":[
        {
           ""UserAddress"":""0x0000000000000000000000000000000000000001"",
           ""WeiAmount"":""50000000000000000000""
        },
        {
           ""UserAddress"":""0x0000000000000000000000000000000000000002"",
           ""WeiAmount"":""25000000000000000000""
        }
     ],
     ""Schedules"":[
        {
           ""ProviderAddress"":""0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF"",
           ""Ratio"":0.5,
           ""StartTime"":1763486000
        },
        {
           ""ProviderAddress"":""0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF"",
           ""Ratio"":0.3,
           ""StartTime"":1763586000
        },
        {
           ""ProviderAddress"":""0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF"",
           ""Ratio"":0.2,
           ""StartTime"":1763586000,
           ""FinishTime"":1763758800
        }
     ],
     ""Refund"":{
        ""ChainId"":56,
        ""PoolId"":1,
        ""Ratio"":0.8,
        ""DealProvider"":""0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF"",
        ""FinishTime"":1763544530
     }
}";

        var data = JsonConvert.DeserializeObject<CreateMessage>(inputJson);

        var templateString = @"## Withdrawn Information:
ChainId: {{ChainId}}
PoolId: {{PoolId}}
Schedules:
{{#each Schedules}}
  - ProviderAddress: {{ProviderAddress}}
    Ratio: {{Ratio}}
    StartTime: {{StartTime}}
    {{#if FinishTime}}
    FinishTime: {{FinishTime}}
    {{/if}}
	
{{/each}}

{{#if Refund}}
## Refund Information:
ChainId: {{Refund.ChainId}}
PoolId: {{Refund.PoolId}}
Ratio: {{Refund.Ratio}}
DealProvider: {{Refund.DealProvider}}
FinishTime: {{Refund.FinishTime}}
{{/if}}

## Users:
{{#each Users}}
  - Address: {{UserAddress}}
    WeiAmount: {{WeiAmount}}

{{/each}}";

        var template = Handlebars.Compile(templateString);

        var result = template(data);

        Console.WriteLine(result);
    }
}