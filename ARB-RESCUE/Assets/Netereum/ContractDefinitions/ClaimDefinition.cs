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

namespace Contracts.Contracts.claim.ContractDefinition
{


    public partial class ClaimDeployment : ClaimDeploymentBase
    {
        public ClaimDeployment() : base(BYTECODE) { }
        public ClaimDeployment(string byteCode) : base(byteCode) { }
    }

    public class ClaimDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b5060c08061001f6000396000f3fe6080604052348015600f57600080fd5b506004361060285760003560e01c806384d2422614602d575b600080fd5b604a6038366004605c565b60006020819052908152604090205481565b60405190815260200160405180910390f35b600060208284031215606d57600080fd5b81356001600160a01b0381168114608357600080fd5b939250505056fea26469706673582212202fcf09c2e514e6102b0198bf6bc43476aa82e8f7ec5b8ac4931b979cbfd7d04c64736f6c63430008130033";
        public ClaimDeploymentBase() : base(BYTECODE) { }
        public ClaimDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class ClaimableTokensFunction : ClaimableTokensFunctionBase { }

    [Function("claimableTokens", "uint256")]
    public class ClaimableTokensFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class ClaimableTokensOutputDTO : ClaimableTokensOutputDTOBase { }

    [FunctionOutput]
    public class ClaimableTokensOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }
}
