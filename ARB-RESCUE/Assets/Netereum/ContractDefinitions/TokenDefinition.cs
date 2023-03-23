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

namespace Contracts.Contracts.Token.ContractDefinition
{


    public partial class TokenDeployment : TokenDeploymentBase
    {
        public TokenDeployment() : base(BYTECODE) { }
        public TokenDeployment(string byteCode) : base(byteCode) { }
    }

    public class TokenDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public TokenDeploymentBase() : base(BYTECODE) { }
        public TokenDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address[13]", "_contracts", 1)]
        public virtual List<string> Contracts { get; set; }
        [Parameter("address[]", "_teamAddress", 2)]
        public virtual List<string> TeamAddress { get; set; }
        [Parameter("uint256[]", "_teamMintPerSecond", 3)]
        public virtual List<BigInteger> TeamMintPerSecond { get; set; }
        [Parameter("bytes32[6]", "_testnetRoots", 4)]
        public virtual List<byte[]> TestnetRoots { get; set; }
        [Parameter("uint256[6]", "_testnetMintPerSecond", 5)]
        public virtual List<BigInteger> TestnetMintPerSecond { get; set; }
        [Parameter("uint256[6]", "_testnetNumberOfBeneficiaries", 6)]
        public virtual List<BigInteger> TestnetNumberOfBeneficiaries { get; set; }
        [Parameter("uint256[6]", "_mintPerSecond", 7)]
        public virtual List<BigInteger> MintPerSecond { get; set; }
    }

    public partial class DEBUG_mintTestTokenFunction : DEBUG_mintTestTokenFunctionBase { }

    [Function("DEBUG_mintTestToken")]
    public class DEBUG_mintTestTokenFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_amountInEther", 1)]
        public virtual BigInteger AmountInEther { get; set; }
    }

    public partial class DEBUG_setContractFunction : DEBUG_setContractFunctionBase { }

    [Function("DEBUG_setContract")]
    public class DEBUG_setContractFunctionBase : FunctionMessage
    {
        [Parameter("address", "_contractAddress", 1)]
        public virtual string ContractAddress { get; set; }
        [Parameter("uint256", "_index", 2)]
        public virtual BigInteger Index { get; set; }
    }

    public partial class DEBUG_setContractsFunction : DEBUG_setContractsFunctionBase { }

    [Function("DEBUG_setContracts")]
    public class DEBUG_setContractsFunctionBase : FunctionMessage
    {
        [Parameter("address[13]", "_contracts", 1)]
        public virtual List<string> Contracts { get; set; }
    }

    public partial class AllowanceFunction : AllowanceFunctionBase { }

    [Function("allowance", "uint256")]
    public class AllowanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
        [Parameter("address", "spender", 2)]
        public virtual string Spender { get; set; }
    }

    public partial class AllowancePerSecondFunction : AllowancePerSecondFunctionBase { }

    [Function("allowancePerSecond", "uint256")]
    public class AllowancePerSecondFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class ApproveFunction : ApproveFunctionBase { }

    [Function("approve", "bool")]
    public class ApproveFunctionBase : FunctionMessage
    {
        [Parameter("address", "spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "amount", 2)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class AvailableCommunityMintFunction : AvailableCommunityMintFunctionBase { }

    [Function("availableCommunityMint", "uint256")]
    public class AvailableCommunityMintFunctionBase : FunctionMessage
    {

    }

    public partial class AvailableDevelopmentMintFunction : AvailableDevelopmentMintFunctionBase { }

    [Function("availableDevelopmentMint", "uint256")]
    public class AvailableDevelopmentMintFunctionBase : FunctionMessage
    {

    }

    public partial class AvailableTeamMintFunction : AvailableTeamMintFunctionBase { }

    [Function("availableTeamMint", "uint256")]
    public class AvailableTeamMintFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_index", 1)]
        public virtual BigInteger Index { get; set; }
    }

    public partial class AvaliableDaoMintFunction : AvaliableDaoMintFunctionBase { }

    [Function("avaliableDaoMint", "uint256")]
    public class AvaliableDaoMintFunctionBase : FunctionMessage
    {

    }

    public partial class BackerMintFunction : BackerMintFunctionBase { }

    [Function("backerMint", "uint256")]
    public class BackerMintFunctionBase : FunctionMessage
    {

    }

    public partial class BalanceOfFunction : BalanceOfFunctionBase { }

    [Function("balanceOf", "uint256")]
    public class BalanceOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class BalanceOfAtFunction : BalanceOfAtFunctionBase { }

    [Function("balanceOfAt", "uint256")]
    public class BalanceOfAtFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
        [Parameter("uint256", "snapshotId", 2)]
        public virtual BigInteger SnapshotId { get; set; }
    }

    public partial class BurnFunction : BurnFunctionBase { }

    [Function("burn")]
    public class BurnFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "amount", 1)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class BurnFromFunction : BurnFromFunctionBase { }

    [Function("burnFrom")]
    public class BurnFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
        [Parameter("uint256", "amount", 2)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class ClaimedAllowanceFunction : ClaimedAllowanceFunctionBase { }

    [Function("claimedAllowance", "uint256")]
    public class ClaimedAllowanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class ClanMintFunction : ClanMintFunctionBase { }

    [Function("clanMint", "uint256")]
    public class ClanMintFunctionBase : FunctionMessage
    {

    }

    public partial class CommunityMintFunction : CommunityMintFunctionBase { }

    [Function("communityMint", "bool")]
    public class CommunityMintFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_amount", 1)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class CommunityTGEreleaseFunction : CommunityTGEreleaseFunctionBase { }

    [Function("communityTGErelease", "uint256")]
    public class CommunityTGEreleaseFunctionBase : FunctionMessage
    {

    }

    public partial class ContractsFunction : ContractsFunctionBase { }

    [Function("contracts", "address")]
    public class ContractsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class CurrentTotalMintPerSecFunction : CurrentTotalMintPerSecFunctionBase { }

    [Function("currentTotalMintPerSec", "uint256")]
    public class CurrentTotalMintPerSecFunctionBase : FunctionMessage
    {

    }

    public partial class DaoMintFunction : DaoMintFunctionBase { }

    [Function("daoMint", "bool")]
    public class DaoMintFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_amount", 1)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class DecimalsFunction : DecimalsFunctionBase { }

    [Function("decimals", "uint8")]
    public class DecimalsFunctionBase : FunctionMessage
    {

    }

    public partial class DecreaseAllowanceFunction : DecreaseAllowanceFunctionBase { }

    [Function("decreaseAllowance", "bool")]
    public class DecreaseAllowanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "subtractedValue", 2)]
        public virtual BigInteger SubtractedValue { get; set; }
    }

    public partial class DeploymentTimeFunction : DeploymentTimeFunctionBase { }

    [Function("deploymentTime", "uint256")]
    public class DeploymentTimeFunctionBase : FunctionMessage
    {

    }

    public partial class DevelopmentMintFunction : DevelopmentMintFunctionBase { }

    [Function("developmentMint", "bool")]
    public class DevelopmentMintFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_amount", 1)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class ExecuteContractAddressUpdateProposalFunction : ExecuteContractAddressUpdateProposalFunctionBase { }

    [Function("executeContractAddressUpdateProposal")]
    public class ExecuteContractAddressUpdateProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_proposalID", 1)]
        public virtual BigInteger ProposalID { get; set; }
    }

    public partial class ExecuteFunctionsProposalTypesUpdateProposalFunction : ExecuteFunctionsProposalTypesUpdateProposalFunctionBase { }

    [Function("executeFunctionsProposalTypesUpdateProposal")]
    public class ExecuteFunctionsProposalTypesUpdateProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_proposalID", 1)]
        public virtual BigInteger ProposalID { get; set; }
    }

    public partial class ExecuteMintPerSecondProposalFunction : ExecuteMintPerSecondProposalFunctionBase { }

    [Function("executeMintPerSecondProposal")]
    public class ExecuteMintPerSecondProposalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_proposalID", 1)]
        public virtual BigInteger ProposalID { get; set; }
    }

    public partial class FunctionsProposalTypesFunction : FunctionsProposalTypesFunctionBase { }

    [Function("functionsProposalTypes", "uint256")]
    public class FunctionsProposalTypesFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class IncreaseAllowanceFunction : IncreaseAllowanceFunctionBase { }

    [Function("increaseAllowance", "bool")]
    public class IncreaseAllowanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "addedValue", 2)]
        public virtual BigInteger AddedValue { get; set; }
    }

    public partial class MintPerSecondFunction : MintPerSecondFunctionBase { }

    [Function("mintPerSecond", "uint256")]
    public class MintPerSecondFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class NameFunction : NameFunctionBase { }

    [Function("name", "string")]
    public class NameFunctionBase : FunctionMessage
    {

    }

    public partial class OneYearLaterFunction : OneYearLaterFunctionBase { }

    [Function("oneYearLater", "uint256")]
    public class OneYearLaterFunctionBase : FunctionMessage
    {

    }

    public partial class PausedFunction : PausedFunctionBase { }

    [Function("paused", "bool")]
    public class PausedFunctionBase : FunctionMessage
    {

    }

    public partial class ProposalsFunction : ProposalsFunctionBase { }

    [Function("proposals", typeof(ProposalsOutputDTO))]
    public class ProposalsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class ProposeContractAddressUpdateFunction : ProposeContractAddressUpdateFunctionBase { }

    [Function("proposeContractAddressUpdate")]
    public class ProposeContractAddressUpdateFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_contractIndex", 1)]
        public virtual BigInteger ContractIndex { get; set; }
        [Parameter("address", "_newAddress", 2)]
        public virtual string NewAddress { get; set; }
    }

    public partial class ProposeFunctionsProposalTypesUpdateFunction : ProposeFunctionsProposalTypesUpdateFunctionBase { }

    [Function("proposeFunctionsProposalTypesUpdate")]
    public class ProposeFunctionsProposalTypesUpdateFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_functionIndex", 1)]
        public virtual BigInteger FunctionIndex { get; set; }
        [Parameter("uint256", "_newIndex", 2)]
        public virtual BigInteger NewIndex { get; set; }
    }

    public partial class ProposeMintPerSecondUpdateFunction : ProposeMintPerSecondUpdateFunctionBase { }

    [Function("proposeMintPerSecondUpdate")]
    public class ProposeMintPerSecondUpdateFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_mintIndex", 1)]
        public virtual BigInteger MintIndex { get; set; }
        [Parameter("uint256", "_newMintPerSecond", 2)]
        public virtual BigInteger NewMintPerSecond { get; set; }
    }

    public partial class SnapshotFunction : SnapshotFunctionBase { }

    [Function("snapshot")]
    public class SnapshotFunctionBase : FunctionMessage
    {

    }

    public partial class StakingMintFunction : StakingMintFunctionBase { }

    [Function("stakingMint", "uint256")]
    public class StakingMintFunctionBase : FunctionMessage
    {

    }

    public partial class SymbolFunction : SymbolFunctionBase { }

    [Function("symbol", "string")]
    public class SymbolFunctionBase : FunctionMessage
    {

    }

    public partial class TeamAndTestnetCapFunction : TeamAndTestnetCapFunctionBase { }

    [Function("teamAndTestnetCap", "uint256")]
    public class TeamAndTestnetCapFunctionBase : FunctionMessage
    {

    }

    public partial class TeamMintFunction : TeamMintFunctionBase { }

    [Function("teamMint")]
    public class TeamMintFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_index", 1)]
        public virtual BigInteger Index { get; set; }
        [Parameter("uint256", "_amount", 2)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class TestnetMintFunction : TestnetMintFunctionBase { }

    [Function("testnetMint")]
    public class TestnetMintFunctionBase : FunctionMessage
    {
        [Parameter("bytes32[]", "_merkleProof", 1)]
        public virtual List<byte[]> MerkleProof { get; set; }
    }

    public partial class TestnetMintPerSecondFunction : TestnetMintPerSecondFunctionBase { }

    [Function("testnetMintPerSecond", "uint256")]
    public class TestnetMintPerSecondFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class TestnetRootsFunction : TestnetRootsFunctionBase { }

    [Function("testnetRoots", "bytes32")]
    public class TestnetRootsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class TestnetTGEreleaseFunction : TestnetTGEreleaseFunctionBase { }

    [Function("testnetTGErelease", "uint256")]
    public class TestnetTGEreleaseFunctionBase : FunctionMessage
    {

    }

    public partial class TotalMintsFunction : TotalMintsFunctionBase { }

    [Function("totalMints", "uint256")]
    public class TotalMintsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class TotalSupplyFunction : TotalSupplyFunctionBase { }

    [Function("totalSupply", "uint256")]
    public class TotalSupplyFunctionBase : FunctionMessage
    {

    }

    public partial class TotalSupplyAtFunction : TotalSupplyAtFunctionBase { }

    [Function("totalSupplyAt", "uint256")]
    public class TotalSupplyAtFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "snapshotId", 1)]
        public virtual BigInteger SnapshotId { get; set; }
    }

    public partial class TransferFunction : TransferFunctionBase { }

    [Function("transfer", "bool")]
    public class TransferFunctionBase : FunctionMessage
    {
        [Parameter("address", "to", 1)]
        public virtual string To { get; set; }
        [Parameter("uint256", "amount", 2)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class TransferFromFunction : TransferFromFunctionBase { }

    [Function("transferFrom", "bool")]
    public class TransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "amount", 3)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class TwoYearsLaterFunction : TwoYearsLaterFunctionBase { }

    [Function("twoYearsLater", "uint256")]
    public class TwoYearsLaterFunctionBase : FunctionMessage
    {

    }

    public partial class UpdatePauseStatusFunction : UpdatePauseStatusFunctionBase { }

    [Function("updatePauseStatus")]
    public class UpdatePauseStatusFunctionBase : FunctionMessage
    {
        [Parameter("bool", "_pauseToken", 1)]
        public virtual bool PauseToken { get; set; }
    }

    public partial class ApprovalEventDTO : ApprovalEventDTOBase { }

    [Event("Approval")]
    public class ApprovalEventDTOBase : IEventDTO
    {
        [Parameter("address", "owner", 1, true )]
        public virtual string Owner { get; set; }
        [Parameter("address", "spender", 2, true )]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "value", 3, false )]
        public virtual BigInteger Value { get; set; }
    }

    public partial class PausedEventDTO : PausedEventDTOBase { }

    [Event("Paused")]
    public class PausedEventDTOBase : IEventDTO
    {
        [Parameter("address", "account", 1, false )]
        public virtual string Account { get; set; }
    }

    public partial class SnapshotEventDTO : SnapshotEventDTOBase { }

    [Event("Snapshot")]
    public class SnapshotEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "id", 1, false )]
        public virtual BigInteger Id { get; set; }
    }

    public partial class TransferEventDTO : TransferEventDTOBase { }

    [Event("Transfer")]
    public class TransferEventDTOBase : IEventDTO
    {
        [Parameter("address", "from", 1, true )]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2, true )]
        public virtual string To { get; set; }
        [Parameter("uint256", "value", 3, false )]
        public virtual BigInteger Value { get; set; }
    }

    public partial class UnpausedEventDTO : UnpausedEventDTOBase { }

    [Event("Unpaused")]
    public class UnpausedEventDTOBase : IEventDTO
    {
        [Parameter("address", "account", 1, false )]
        public virtual string Account { get; set; }
    }







    public partial class AllowanceOutputDTO : AllowanceOutputDTOBase { }

    [FunctionOutput]
    public class AllowanceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class AllowancePerSecondOutputDTO : AllowancePerSecondOutputDTOBase { }

    [FunctionOutput]
    public class AllowancePerSecondOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class AvailableCommunityMintOutputDTO : AvailableCommunityMintOutputDTOBase { }

    [FunctionOutput]
    public class AvailableCommunityMintOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class AvailableDevelopmentMintOutputDTO : AvailableDevelopmentMintOutputDTOBase { }

    [FunctionOutput]
    public class AvailableDevelopmentMintOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class AvailableTeamMintOutputDTO : AvailableTeamMintOutputDTOBase { }

    [FunctionOutput]
    public class AvailableTeamMintOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class AvaliableDaoMintOutputDTO : AvaliableDaoMintOutputDTOBase { }

    [FunctionOutput]
    public class AvaliableDaoMintOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class BalanceOfOutputDTO : BalanceOfOutputDTOBase { }

    [FunctionOutput]
    public class BalanceOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class BalanceOfAtOutputDTO : BalanceOfAtOutputDTOBase { }

    [FunctionOutput]
    public class BalanceOfAtOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }





    public partial class ClaimedAllowanceOutputDTO : ClaimedAllowanceOutputDTOBase { }

    [FunctionOutput]
    public class ClaimedAllowanceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }





    public partial class CommunityTGEreleaseOutputDTO : CommunityTGEreleaseOutputDTOBase { }

    [FunctionOutput]
    public class CommunityTGEreleaseOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class ContractsOutputDTO : ContractsOutputDTOBase { }

    [FunctionOutput]
    public class ContractsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class CurrentTotalMintPerSecOutputDTO : CurrentTotalMintPerSecOutputDTOBase { }

    [FunctionOutput]
    public class CurrentTotalMintPerSecOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class DecimalsOutputDTO : DecimalsOutputDTOBase { }

    [FunctionOutput]
    public class DecimalsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }



    public partial class DeploymentTimeOutputDTO : DeploymentTimeOutputDTOBase { }

    [FunctionOutput]
    public class DeploymentTimeOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }









    public partial class FunctionsProposalTypesOutputDTO : FunctionsProposalTypesOutputDTOBase { }

    [FunctionOutput]
    public class FunctionsProposalTypesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class MintPerSecondOutputDTO : MintPerSecondOutputDTOBase { }

    [FunctionOutput]
    public class MintPerSecondOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class NameOutputDTO : NameOutputDTOBase { }

    [FunctionOutput]
    public class NameOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class OneYearLaterOutputDTO : OneYearLaterOutputDTOBase { }

    [FunctionOutput]
    public class OneYearLaterOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class PausedOutputDTO : PausedOutputDTOBase { }

    [FunctionOutput]
    public class PausedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class ProposalsOutputDTO : ProposalsOutputDTOBase { }

    [FunctionOutput]
    public class ProposalsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "status", 1)]
        public virtual byte Status { get; set; }
        [Parameter("uint256", "updateCode", 2)]
        public virtual BigInteger UpdateCode { get; set; }
        [Parameter("bool", "isExecuted", 3)]
        public virtual bool IsExecuted { get; set; }
        [Parameter("uint256", "index", 4)]
        public virtual BigInteger Index { get; set; }
        [Parameter("uint256", "newUint", 5)]
        public virtual BigInteger NewUint { get; set; }
        [Parameter("address", "newAddress", 6)]
        public virtual string NewAddress { get; set; }
        [Parameter("bytes32", "newBytes32", 7)]
        public virtual byte[] NewBytes32 { get; set; }
        [Parameter("bool", "newBool", 8)]
        public virtual bool NewBool { get; set; }
    }











    public partial class SymbolOutputDTO : SymbolOutputDTOBase { }

    [FunctionOutput]
    public class SymbolOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class TeamAndTestnetCapOutputDTO : TeamAndTestnetCapOutputDTOBase { }

    [FunctionOutput]
    public class TeamAndTestnetCapOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }





    public partial class TestnetMintPerSecondOutputDTO : TestnetMintPerSecondOutputDTOBase { }

    [FunctionOutput]
    public class TestnetMintPerSecondOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class TestnetRootsOutputDTO : TestnetRootsOutputDTOBase { }

    [FunctionOutput]
    public class TestnetRootsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class TestnetTGEreleaseOutputDTO : TestnetTGEreleaseOutputDTOBase { }

    [FunctionOutput]
    public class TestnetTGEreleaseOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class TotalMintsOutputDTO : TotalMintsOutputDTOBase { }

    [FunctionOutput]
    public class TotalMintsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class TotalSupplyOutputDTO : TotalSupplyOutputDTOBase { }

    [FunctionOutput]
    public class TotalSupplyOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class TotalSupplyAtOutputDTO : TotalSupplyAtOutputDTOBase { }

    [FunctionOutput]
    public class TotalSupplyAtOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }





    public partial class TwoYearsLaterOutputDTO : TwoYearsLaterOutputDTOBase { }

    [FunctionOutput]
    public class TwoYearsLaterOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }


}
