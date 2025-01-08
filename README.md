# DispenserProvider.MessageTemplate

In the DispenserProvider system, a key requirement is for an administrator to sign any creation or deletion operation with their wallet.

## Templates

### Create asset (With Refund)


We build the scheme dynamically, based on the presence or absence of **Refund**.
> **Note:** It is also important to note that EIP712 does not support nullable/optional parameters, so in `schedules` for `finishTime` we set `0` if it is missing.

If **Refund** is available, the diagram will look like this:
```js
const typedData = {
  types: {
    EIP712Domain: [{ name: "name", type: "string" }],
    SignMessage: [
      { name: "chainId", type: "uint256" },
      { name: "poolId", type: "uint256" },
      { name: "schedules", type: "Schedule[]" },
      { name: "users", type: "User[]" },
      { name: "refund", type: "Refund" },
    ],
    Schedule: [
      { name: "providerAddress", type: "address" },
      { name: "ratio", type: "uint256" },
      { name: "startTime", type: "uint256" },
      { name: "finishTime", type: "uint256" },
    ],
    User: [
      { name: "userAddress", type: "address" },
      { name: "weiAmount", type: "uint256" },
    ],
    Refund: [
      { name: "chainId", type: "uint256" },
      { name: "poolId", type: "uint256" },
      { name: "ratio", type: "uint256" },
      { name: "dealProvider", type: "address" },
      { name: "finishTime", type: "uint256" },
    ],
  },
  primaryType: "SignMessage",
  domain: {
    name: "Poolz - Create dispenser",
  },
  message: {
    chainId: 1,
    poolId: 1,
    schedules: [
      {
        providerAddress: "0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
        ratio: "500000000000000000",
        startTime: 1763486000,
        finishTime: 0,
      },
      {
        providerAddress: "0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
        ratio: "300000000000000000",
        startTime: 1763586000,
        finishTime: 0,
      },
      {
        providerAddress: "0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
        ratio: "200000000000000000",
        startTime: 1763486000,
        finishTime: 1763758800,
      },
    ],
    users: [
      {
        userAddress: "0x0000000000000000000000000000000000000001",
        weiAmount: "50000000000000000000",
      },
      {
        userAddress: "0x0000000000000000000000000000000000000002",
        weiAmount: "25000000000000000000",
      },
    ],
    refund: {
      chainId: 56,
      poolId: 1,
      ratio: "800000000000000000",
      dealProvider: "0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
      finishTime: 1763544530,
    },
  },
};
```

### Create asset (Without Refund)
If **Refund** is missing, the diagram will look like this:
```js
const typedData = {
  types: {
    EIP712Domain: [{ name: "name", type: "string" }],
    SignMessage: [
      { name: "chainId", type: "uint256" },
      { name: "poolId", type: "uint256" },
      { name: "schedules", type: "Schedule[]" },
      { name: "users", type: "User[]" },
    ],
    Schedule: [
      { name: "providerAddress", type: "address" },
      { name: "ratio", type: "uint256" },
      { name: "startTime", type: "uint256" },
      { name: "finishTime", type: "uint256" },
    ],
    User: [
      { name: "userAddress", type: "address" },
      { name: "weiAmount", type: "uint256" },
    ],
  },
  primaryType: "SignMessage",
  domain: {
    name: "Poolz - Create dispenser",
  },
  message: {
    chainId: 1,
    poolId: 1,
    schedules: [
      {
        providerAddress: "0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
        ratio: "500000000000000000",
        startTime: 1763486000,
        finishTime: 0,
      },
      {
        providerAddress: "0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
        ratio: "300000000000000000",
        startTime: 1763586000,
        finishTime: 0,
      },
      {
        providerAddress: "0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF",
        ratio: "200000000000000000",
        startTime: 1763486000,
        finishTime: 1763758800,
      },
    ],
    users: [
      {
        userAddress: "0x0000000000000000000000000000000000000001",
        weiAmount: "50000000000000000000",
      },
      {
        userAddress: "0x0000000000000000000000000000000000000002",
        weiAmount: "25000000000000000000",
      },
    ],
  },
};
```
