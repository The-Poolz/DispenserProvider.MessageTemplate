# DispenserProvider.MessageTemplate

## Template

```
## Withdrawn Information:
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

{{/each}}
```