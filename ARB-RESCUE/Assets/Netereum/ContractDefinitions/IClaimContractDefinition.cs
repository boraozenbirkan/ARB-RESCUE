using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace Contracts.Contracts.IClaimContract.ContractDefinition
{


    public partial class IClaimContractDeployment : IClaimContractDeploymentBase
    {
        public IClaimContractDeployment() : base(BYTECODE) { }
        public IClaimContractDeployment(string byteCode) : base(byteCode) { }
    }

    public class IClaimContractDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "";
        public IClaimContractDeploymentBase() : base(BYTECODE) { }
        public IClaimContractDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class ClaimFunction : ClaimFunctionBase { }

    [Function("claim")]
    public class ClaimFunctionBase : FunctionMessage
    {

    }


}
