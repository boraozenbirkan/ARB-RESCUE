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

namespace Contracts.Contracts.GetBlockNumber.ContractDefinition
{


    public partial class GetBlockNumberDeployment : GetBlockNumberDeploymentBase
    {
        public GetBlockNumberDeployment() : base(BYTECODE) { }
        public GetBlockNumberDeployment(string byteCode) : base(byteCode) { }
    }

    public class GetBlockNumberDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "6080604052348015600f57600080fd5b50607680601d6000396000f3fe6080604052348015600f57600080fd5b506004361060285760003560e01c806334e69b9114602d575b600080fd5b4360405190815260200160405180910390f3fea26469706673582212203288efb3d4ac026ad6c830f90d8383c3fe6af00463cb1381b40d862527fe8bdb64736f6c63430008130033";
        public GetBlockNumberDeploymentBase() : base(BYTECODE) { }
        public GetBlockNumberDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class GibMeTheNumberFunction : GibMeTheNumberFunctionBase { }

    [Function("GibMeTheNumber", "uint256")]
    public class GibMeTheNumberFunctionBase : FunctionMessage
    {

    }

    public partial class GibMeTheNumberOutputDTO : GibMeTheNumberOutputDTOBase { }

    [FunctionOutput]
    public class GibMeTheNumberOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }
}
