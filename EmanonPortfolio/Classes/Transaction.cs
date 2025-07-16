﻿//   ---------------------------------------------------------------------------------------------------------
//   Bestand       : Transaction.cs
//   Doel          : Definiëren het transactie object met de bijbehorende methodes en eigenschappen.
//   Copyright (c) : Emanon BV, 2025
//   Aanpassingen  :
//   2025-06-26/001: Nieuw. (Sofie)
//   ---------------------------------------------------------------------------------------------------------

using System.Numerics;

namespace Emanon_Portfolio.Classes
{
    public class Transaction
    {
        #region Objectkenmerken
        // ---------------------------------------------------------------------------------------------------
        // Kenmerk: NumberShares
        // Doel   : Het aantal aandelen in de transactie.
        // ---------------------------------------------------------------------------------------------------
        public int NumberShares { get; private set; }


        // ---------------------------------------------------------------------------------------------------
        // Kenmerk: SharesRate
        // Doel   : De waarde per aandeel op de transactiedatum.
        // ---------------------------------------------------------------------------------------------------
        public decimal SharesRate { get; private set; }


        // ---------------------------------------------------------------------------------------------------
        // Kenmerk: TransactionDate
        // Doel   : De datum waarop de transactie heeft plaatsgevonden.
        // ---------------------------------------------------------------------------------------------------
        public DateTime TransactionDate { get; private set; }


        // ---------------------------------------------------------------------------------------------------
        // Kenmerk: ShareType
        // Doel   : Het type aandeel dat in de transactie is opgenomen.
        // ---------------------------------------------------------------------------------------------------
        public Constants.ShareType ShareType { get; private set; }
        #endregion


        #region Afgeleide kenmerken
        // ---------------------------------------------------------------------------------------------------
        // Methode: Amount
        // Doel   : De totale waarde van de transactie.
        // TODO   : Dit kenmerk kent een optionele parameter pNumberDecimals die bepaalt op hoeveel decimalen
        //          de waarde wordt afgerond, indien null wordt de waarde niet afgerond.
        // ---------------------------------------------------------------------------------------------------
        public decimal Amount(int? pNumberDecimals = 2)
        {
            // totalValue: totale waarde van de transactie
            decimal totalValue = NumberShares * SharesRate;

            /* controleer of pNumberDecimals een value heeft
             * zo ja, geef de totalValue terug afgerond op het gegeven aantal decimalen
             * zo nee, geef de totalValue terug zoals normaal */
            if (pNumberDecimals.HasValue)
            {
                return Math.Round(totalValue, pNumberDecimals.Value);
            }
            else
            {
                return totalValue;
            }
        }
        #endregion


        #region Constructor
        // ---------------------------------------------------------------------------------------------------
        // Methode   : Transaction
        // Doel      : Het initieren van een nieuw transactie object met de opgegeven kenmerken.
        // ---------------------------------------------------------------------------------------------------
        public Transaction(int pNumberShares
                         , decimal pSharesRate
                         , DateTime pTransactionDate
                         , Constants.ShareType pShareType)
        {
            NumberShares = pNumberShares;
            SharesRate = pSharesRate;
            TransactionDate = pTransactionDate;
            ShareType = pShareType;
        }
        #endregion
    }
}
