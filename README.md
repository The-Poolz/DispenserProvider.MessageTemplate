# DispenserProvider.MessageTemplate

In the DispenserProvider system, a key requirement is for an administrator to sign any creation or deletion operation with their wallet.
This ensures the authenticity and integrity of all such actions.
This repository provides a template that simplifies the process for both Back-end and Front-end teams by “reconstructing” the original message the administrator signed, leveraging the Handlebars library for rendering.

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
