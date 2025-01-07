# MessageTemplate.Examples

Here you can find example C# code that takes JSON, converts it to an object, and then uses a message template to "fill in" all the required values.

## Input JSON:
This JSON will be converted into a formatted message.
```json
{
   "ChainId":1,
   "PoolId":1,
   "Users":[
      {
         "UserAddress":"0x0000000000000000000000000000000000000001",
         "WeiAmount":"50000000000000000000"
      },
      {
         "UserAddress":"0x0000000000000000000000000000000000000002",
         "WeiAmount":"25000000000000000000"
      }
   ],
   "Schedules":[
      {
         "ProviderAddress":"0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
         "Ratio":0.5,
         "StartTime":1763486000
      },
      {
         "ProviderAddress":"0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
         "Ratio":0.3,
         "StartTime":1763586000
      },
      {
         "ProviderAddress":"0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
         "Ratio":0.2,
         "StartTime":1763586000,
         "FinishTime":1763758800
      }
   ],
   "Refund":{
      "ChainId":56,
      "PoolId":1,
      "Ratio":0.8,
      "DealProvider":"0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
      "FinishTime":1763544530
   }
}
```

## Output result:
Already formatted message based on JSON above.
```
## Withdrawn Information:
ChainId: 1
PoolId: 1
Schedules:
  - ProviderAddress: 0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
    Ratio: 0.5
    StartTime: 2025-11-18T17:13:20.0000000Z

  - ProviderAddress: 0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
    Ratio: 0.3
    StartTime: 2025-11-19T21:00:00.0000000Z

  - ProviderAddress: 0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
    Ratio: 0.2
    StartTime: 2025-11-19T21:00:00.0000000Z
    FinishTime: 2025-11-21T21:00:00.0000000Z


## Refund Information:
ChainId: 56
PoolId: 1
Ratio: 0.8
DealProvider: 0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
FinishTime: 2025-11-19T09:28:50.0000000Z

## Users:
  - Address: 0x0000000000000000000000000000000000000001
    WeiAmount: 50000000000000000000

  - Address: 0x0000000000000000000000000000000000000002
    WeiAmount: 25000000000000000000
```
