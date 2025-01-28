# DispenserProvider.MessageTemplate

In the DispenserProvider system, a key requirement is for an administrator to sign any creation or deletion operation with their wallet.
For signing we use EIP-712 standart.

### Other docs:
- [eip-712](https://eips.ethereum.org/EIPS/eip-712)
- [eth_signTypedData_v4](https://docs.metamask.io/wallet/reference/json-rpc-methods/eth_signtypeddata_v4/)

We build the scheme dynamically, based on the presence or absence of **Refund**.
> **Note:** It is also important to note that EIP-712 does not support nullable/optional parameters, so in `schedules` for `finishTime` we set `0` if it is missing.
