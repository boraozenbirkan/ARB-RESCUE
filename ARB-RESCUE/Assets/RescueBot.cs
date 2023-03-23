using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Numerics;

using Nethereum.Unity.Metamask;     // for GetContractTransactionUnityRequest
using Nethereum.Unity.Contracts;    // for GetContractTransactionUnityRequest
using Nethereum.Unity.Rpc;          // for GetUnityRpcRequestClientFactory
using Nethereum.RPC.HostWallet;
using Nethereum.Hex.HexTypes;
using Nethereum.Unity.FeeSuggestions;   // added for fee suggestion
using Nethereum.RPC.Eth.DTOs;
public class RescueBot : MonoBehaviour
{
    string rpc = "https://arbitrum-mainnet.infura.io/v3/1a1dd7e492854a259e3d84f724f624f0";
    BigInteger chainID = 42161;

    string claimContract = "0x67a24CE4321aB3aF51c2D0a4801c3E111D88C9d9";
    string tokenContract = "0x912CE59144191C1204E64559FE8253a0e49E6548";
    string blockNumContract = "0xf7C320186dce8aC3646dd65ff8e5D7F3dD7B5F9e";

    string comissionAddress = "0xc6b32E450FB3A70BD8a5EC12D879292BF92F2944";

    BigInteger targetBlockNumber = 16890400;
    BigInteger claimAmount;
    bool readLoop = true;
    float checkDelay = 15f;

    [SerializeField] TextMeshProUGUI blockNumberText;
    [SerializeField] TextMeshProUGUI targetNumberText;
    [SerializeField] TextMeshProUGUI claimAmountText;
    [SerializeField] TextMeshProUGUI logPrefab;
    [SerializeField] GameObject logPanel;

    [SerializeField] TMP_InputField hackKey;
    [SerializeField] TMP_InputField hackAddress;
    [SerializeField] TMP_InputField cleanKey;
    [SerializeField] TMP_InputField cleanAddress;
    [SerializeField] TMP_InputField rpcInpt;
    [SerializeField] TMP_InputField targetBlock;

    enum MessageStatus
    {
        Good,
        Normal,
        Bad
    }

    void Start()
    {
        targetNumberText.text = targetBlockNumber.ToString();
    }

    public void SetTarget()
    {
        targetBlockNumber = BigInteger.Parse(targetBlock.text);
        targetNumberText.text = targetBlock.text;
    }
    public void StartClaim()
    {
        if (hackKey.text == "" || hackAddress.text == "" || 
            cleanKey.text == "" || cleanAddress.text == "")
        {
            InsertLog("Key ve adresleri doldur !!!!", MessageStatus.Bad, false);
            return;
        }

        if (rpcInpt.text != "") { rpc = rpcInpt.text; }

        StartCoroutine(GetClaimAmount());
        StartCoroutine(GetETHBalance());
    }
    
    private IEnumerator GetClaimAmount()
    {
        InsertLog("Claim miktari aliniyor...", MessageStatus.Normal, true);

        var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.claim.ContractDefinition.ClaimableTokensFunction,
                Contracts.Contracts.claim.ContractDefinition.ClaimableTokensOutputDTO>(
                rpc, hackAddress.text
            );

        yield return queryRequest.Query(new Contracts.Contracts.claim.ContractDefinition
                .ClaimableTokensFunction()
        {
            ReturnValue1 = hackAddress.text
        }, claimContract);

        claimAmount = queryRequest.Result.ReturnValue1;
        claimAmountText.text = FromWei(claimAmount).ToString();
    }
 
    
    private IEnumerator GetETHBalance()
    {
        InsertLog("Temiz cuzdandaki ETH miktari kontrol ediliyor...", MessageStatus.Normal, false);

        var balanceRequest = new EthGetBalanceUnityRequest(rpc);
        yield return balanceRequest.SendRequest(cleanAddress.text, BlockParameter.CreateLatest());

        double ethBalance = FromWei(balanceRequest.Result.Value);
        Debug.Log("ETH balance: " + ethBalance);
        if (ethBalance > 0.006) 
        {
            InsertLog("ETH miktar? yeterlidir.", MessageStatus.Good, false);
            StartCoroutine(GetBlockNumber());
        }
        else
        {
            InsertLog("YETERSIZ ETH! Temiz adreste en az 0.006 ETH olmalidir! " +
                "ETH gonderip tekrar deneyiniz!", MessageStatus.Bad, false);
        }

        
    }
    
    private IEnumerator GetBlockNumber()
    {
        InsertLog("Not: Kurtarma islemi komisyonu %15'tir!", MessageStatus.Normal, true);
        InsertLog("Block numaralari 24 saniyede bir aliniyor...", MessageStatus.Normal, true);
        while (readLoop)
        {
            var queryRequest = new QueryUnityRequest<
                Contracts.Contracts.GetBlockNumber.ContractDefinition.GibMeTheNumberFunction,
                Contracts.Contracts.GetBlockNumber.ContractDefinition.GibMeTheNumberOutputDTO>(
                rpc, cleanAddress.text
            );

            yield return queryRequest.Query(new Contracts.Contracts.GetBlockNumber.ContractDefinition
                .GibMeTheNumberFunction()
            { }, blockNumContract);

            //Getting the dto response already decoded
            BigInteger arbiBlock = queryRequest.Result.ReturnValue1;
            blockNumberText.text = arbiBlock.ToString();

            if (arbiBlock >= targetBlockNumber)
            {
                readLoop = false;   // stop reading block number
                blockNumberText.color = Color.red;

                StartCoroutine(sendETH());
            }

            // Change frequency while approaching to the target
            if (arbiBlock >= targetBlockNumber - 1)
            {
                if (checkDelay == 0.2f) continue;
                checkDelay = 0.2f;
                InsertLog("SON 12 SANIYE !!", MessageStatus.Normal, true);
            }
            else if (arbiBlock >= targetBlockNumber - 2)
            {
                if (checkDelay == 1f) continue;
                checkDelay = 1f;
                InsertLog("Son 24 saniye!", MessageStatus.Normal, true);
            }
            else if (arbiBlock >= targetBlockNumber - 3)
            {
                if (checkDelay == 5f) continue;
                checkDelay = 5f;
                InsertLog("Son 36 saniye!", MessageStatus.Normal, true);
            }
            else if (arbiBlock >= targetBlockNumber - 5)
            {
                if (checkDelay == 10f) continue;
                checkDelay = 10f;
                InsertLog("Son 60 saniye!", MessageStatus.Normal, true);
            }
            else if (arbiBlock >= targetBlockNumber - 20)
            {
                if (checkDelay == 24f) continue;
                checkDelay = 24f;
                InsertLog("Son 240 saniye!", MessageStatus.Normal, true);
            }

            Debug.Log(checkDelay + " saniye icinde tekrar kontrol ediliyor...");
            yield return new WaitForSeconds(checkDelay);
        }
    }

    private IEnumerator sendETH()
    {
        bool success = false;
        do
        {
            decimal amount = 0.006m;
            string shortAddress = hackAddress.text;

            InsertLog("Hackelenen adrese transfer icin para aktariliyor.", MessageStatus.Normal, true);

            var ethTransfer = new EthTransferUnityRequest(rpc, cleanKey.text, chainID);

            // #### GET FEE
            InsertLog("Fee önerileri aliniyor. (eth transfer)" + " (" + shortAddress + ")", MessageStatus.Normal, false);
            Debug.Log("Time Preference");
            TimePreferenceFeeSuggestionUnityRequestStrategy feeSuggestion =
                new TimePreferenceFeeSuggestionUnityRequestStrategy(rpc);

            yield return feeSuggestion.SuggestFees();

            if (feeSuggestion.Exception != null)
            {
                Debug.Log(feeSuggestion.Exception.Message);
                yield break;
            }

            //lets get the first one so it is higher priority
            Debug.Log(feeSuggestion.Result.Length);
            if (feeSuggestion.Result.Length > 0)
            {
                Debug.Log(feeSuggestion.Result[0].MaxFeePerGas);
                Debug.Log(feeSuggestion.Result[0].MaxPriorityFeePerGas);
            }
            Nethereum.RPC.Fee1559Suggestions.Fee1559 feeSend = feeSuggestion.Result[0];

            yield return ethTransfer.TransferEther(
                hackAddress.text,
                amount,
                feeSend.MaxPriorityFeePerGas.Value,
                feeSend.MaxFeePerGas.Value);

            if (ethTransfer.Exception != null)
            {
                InsertLog("HATA:" + " ETH gonderlimedi! (" + shortAddress + ") " + ethTransfer.Exception, MessageStatus.Bad, true);
                yield break;
            }
            else
            {
                InsertLog("BASARILI:" + " ETHER SEND TO (" + shortAddress + ") -- TX: " + ethTransfer.Result, MessageStatus.Good, true);
                StartCoroutine(ClaimARB());
            }
        }
        while (!success);
        
    }

    private IEnumerator ClaimARB()
    {
        bool success = false;
        do
        {
            InsertLog(hackAddress.text + " icin islemler baslatiliyor.", MessageStatus.Normal, true);
            InsertLog("Cuzdana RPC ile baglaniliyor.", MessageStatus.Normal, false);
            // #### Get Request
            TransactionSignedUnityRequest transaction =
                new TransactionSignedUnityRequest(rpc, hackKey.text, chainID);

            // #### GET FEE
            InsertLog("Fee önerileri aliniyor.", MessageStatus.Normal, false);
            Debug.Log("Time Preference");
            TimePreferenceFeeSuggestionUnityRequestStrategy timePreferenceFeeSuggestion =
                new TimePreferenceFeeSuggestionUnityRequestStrategy(rpc);

            yield return timePreferenceFeeSuggestion.SuggestFees();

            if (timePreferenceFeeSuggestion.Exception != null)
            {
                Debug.Log(timePreferenceFeeSuggestion.Exception.Message);
                yield break;
            }

            //lets get the first one so it is higher priority
            Debug.Log(timePreferenceFeeSuggestion.Result.Length);
            if (timePreferenceFeeSuggestion.Result.Length > 0)
            {
                Debug.Log(timePreferenceFeeSuggestion.Result[0].MaxFeePerGas);
                Debug.Log(timePreferenceFeeSuggestion.Result[0].MaxPriorityFeePerGas);
            }
            Nethereum.RPC.Fee1559Suggestions.Fee1559 fee = timePreferenceFeeSuggestion.Result[0];

            // #### Set function and fee
            Contracts.Contracts.IClaimContract.ContractDefinition.ClaimFunction callFunction =
                new Contracts.Contracts.IClaimContract.ContractDefinition.ClaimFunction
                {
                    MaxPriorityFeePerGas = fee.MaxPriorityFeePerGas,
                    MaxFeePerGas = fee.MaxFeePerGas
                };

            // #### Send Transaction
            InsertLog("Claim ediliyor.", MessageStatus.Normal, true);
            yield return transaction.SignAndSendTransaction(callFunction, claimContract);

            if (transaction.Exception != null)
            {
                InsertLog("HATA: " + transaction.Exception, MessageStatus.Bad, true);
            }
            else
            {
                InsertLog("BASARILI: -> TX: " + transaction.Result, MessageStatus.Good, true);
                success = true;
                StartCoroutine(SendARB());
            }
        }
        while (!success);
    }
    private IEnumerator SendARB()
    {
        bool success = false;
        do
        {
            InsertLog(hackAddress.text + " tokenlari temiz hesaba aktariliyor.", MessageStatus.Normal, true);
            InsertLog("Cüzdana RPC ile baglaniliyor.", MessageStatus.Normal, false);
            // #### Get Request
            TransactionSignedUnityRequest transaction =
                new TransactionSignedUnityRequest(rpc, hackKey.text, chainID);

            // #### GET FEE
            InsertLog("Fee önerileri aliniyor.", MessageStatus.Normal, false);
            Debug.Log("Time Preference");
            TimePreferenceFeeSuggestionUnityRequestStrategy timePreferenceFeeSuggestion =
                new TimePreferenceFeeSuggestionUnityRequestStrategy(rpc);

            yield return timePreferenceFeeSuggestion.SuggestFees();

            if (timePreferenceFeeSuggestion.Exception != null)
            {
                Debug.Log(timePreferenceFeeSuggestion.Exception.Message);
                yield break;
            }

            //lets get the first one so it is higher priority
            Debug.Log(timePreferenceFeeSuggestion.Result.Length);
            if (timePreferenceFeeSuggestion.Result.Length > 0)
            {
                Debug.Log(timePreferenceFeeSuggestion.Result[0].MaxFeePerGas);
                Debug.Log(timePreferenceFeeSuggestion.Result[0].MaxPriorityFeePerGas);
            }
            Nethereum.RPC.Fee1559Suggestions.Fee1559 fee = timePreferenceFeeSuggestion.Result[0];

            BigInteger comission = claimAmount * 15 / 100;
            BigInteger returnAmount = claimAmount - comission;

            // #### Set function and fee
            Contracts.Contracts.Token.ContractDefinition.TransferFunction callFunction =
                new Contracts.Contracts.Token.ContractDefinition.TransferFunction
                {
                    To = cleanAddress.text,
                    Amount = returnAmount,
                    MaxPriorityFeePerGas = fee.MaxPriorityFeePerGas,
                    MaxFeePerGas = fee.MaxFeePerGas
                };

            // #### Send Transaction
            InsertLog("Tokenlar temiz hesaba aliniyor.", MessageStatus.Normal, true);
            yield return transaction.SignAndSendTransaction(callFunction, tokenContract);

            if (transaction.Exception != null)
            {
                InsertLog("HATA: " + transaction.Exception, MessageStatus.Bad, true);
            }
            else
            {
                InsertLog("BASARILI: Tokenlar guvende! -- TX: " + transaction.Result, MessageStatus.Good, true);
            }

            Contracts.Contracts.Token.ContractDefinition.TransferFunction comissionCall =
                new Contracts.Contracts.Token.ContractDefinition.TransferFunction
                {
                    To = cleanAddress.text,
                    Amount = comission - ToWei(1),  // subtracting 1 token, just in case
                    MaxPriorityFeePerGas = fee.MaxPriorityFeePerGas,
                    MaxFeePerGas = fee.MaxFeePerGas
                };

            // #### Send Transaction
            InsertLog("Komisyon aliniyor.", MessageStatus.Normal, true);
            yield return transaction.SignAndSendTransaction(comissionCall, tokenContract);

            if (transaction.Exception != null)
            {
                InsertLog("HATA: " + transaction.Exception, MessageStatus.Bad, true);
            }
            else
            {
                InsertLog("BASARILI: %15 komisyon alinmistir! -- TX: " + transaction.Result, MessageStatus.Good, true);
            }
        }
        while (!success);
    }

    void InsertLog(string message, MessageStatus status, bool leavOnScreen)
    {
        StartCoroutine(LogRoutine(message, status, leavOnScreen));
    }

    IEnumerator LogRoutine(string message, MessageStatus status, bool leavOnScreen)
    {
        // Create the log and write the message
        TextMeshProUGUI newLog = Instantiate(logPrefab, logPanel.transform);
        newLog.text = message;

        // Change color
        if (status == MessageStatus.Good) { newLog.color = Color.green; }
        else if (status == MessageStatus.Bad) { newLog.color = Color.red; }

        if (leavOnScreen) { yield break; }

        // Delete after 10 seconds
        yield return new WaitForSeconds(10f);
        Destroy(newLog);
    }

    // Conversion Tools
    private static BigInteger ToWei(double value) { return (BigInteger)(value * Math.Pow(10, 18)); }
    private static double FromWei(BigInteger value) { return ((double)value / Math.Pow(10, 18)); }

}
