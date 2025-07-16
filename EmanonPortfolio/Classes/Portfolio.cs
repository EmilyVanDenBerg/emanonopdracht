//   ---------------------------------------------------------------------------------------------------------
//   Bestand       : Portfolio.cs
//   Doel          : Definiëren het porfolio object met de bijbehorende methodes en eigenschappen.
//   Copyright (c) : Emanon BV, 2025
//   Aanpassingen  :
//   2025-06-26/001: Nieuw. (Sofie)
//   ---------------------------------------------------------------------------------------------------------

namespace Emanon_Portfolio.Classes
{
    public class Portfolio
    {
        #region Objectkenmerken
        // ---------------------------------------------------------------------------------------------------
        // Kenmerk: Transactions
        // Doel   : De lijst met transacties binnen het portfolio.
        // ---------------------------------------------------------------------------------------------------
        public List<Transaction> Transactions { get; private set; }
        #endregion


        #region Afgeleide kenmerken
        // ---------------------------------------------------------------------------------------------------
        // Kenmerk: TotalNumber
        // Doel   : Opleveren van het totaal aantal aandelen in het portfolio op basis van de bovenstaande
        //          lijst met transacties, onafhankelijk van transactiedatum.
        // ---------------------------------------------------------------------------------------------------
        public int TotalNumber
        {
            get
            {
                // totalShares: totale aantal aandelen
                int totalShares = 0;

                /* tel van elke transactie de waarde bij het totale aantal aandelen tot de laatste transactie
                 * en geef de waarde van totalShares terug */
                for (int i = 0; i < Transactions.Count(); i++)
                {
                    totalShares += Transactions[i].NumberShares;
                }
                return totalShares;
            }
        }


        // ---------------------------------------------------------------------------------------------------
        // Methode: TotalValue
        // Doel   : Opleveren van de totale waarde van alle aandelen in het portfolio op basis van de
        //          bovenstaande lijst met transacties, onafhankelijk van transactiedatum.
        // TODO   : Dit kenmerk kent een optionele parameter pNumberDecimals die bepaalt op hoeveel decimalen
        //          de waarde wordt afgerond, indien null wordt de waarde niet afgerond.
        // ---------------------------------------------------------------------------------------------------
        public decimal TotalValue(int? pNumberDecimals = 2)
        {
            // totalAmount: totale waarde van alle aandelen
            decimal totalAmount = 0;

            /* voor elke transactie tel de waarde van de transactie (aantal aandelen * waarde ervan) erbij op
             * rond deze waarde af op het einde indien pNumberDecimals een waarde heeft
             * en geef deze waarde terug */
            for (int i = 0; i < Transactions.Count(); i++)
            {
                totalAmount += Transactions[i].NumberShares * Transactions[i].SharesRate;
            }
            if (pNumberDecimals.HasValue)
            {
                totalAmount = Math.Round(totalAmount, pNumberDecimals.Value);
            }
            return totalAmount;
        }


        // ---------------------------------------------------------------------------------------------------
        // Methode: NumberOnDate
        // Doel   : Opleveren van het aantal aandelen in het portfolio op de gegeven datum.
        // TODO   : Dit kenmerk kent een optionele parameter pShareTypes, indien deze parameter gevuld is
        //          dienen alleen transacties met een ShareType in de lijst meegenomen te worden in
        //          de berekening van het aantal aandelen.
        // ---------------------------------------------------------------------------------------------------
        public int NumberOnDate(DateTime pSelectionDate
                              , List<Constants.ShareType>? pShareTypes = null)
        {
            // totalShares: totale aantal aandelen
            int totalShares = 0;

            /* voor elke transactie voor de geselecteerde datum van de unittest
             * tel van elke transactie de waarde bij het totale aantal aandelen tot de laatste transactie
             * en geef de waarde van totalShares terug */
            for (int i = 0; i < Transactions.Count(); i++)
            {
                if (pShareTypes != null && Transactions[i].TransactionDate <= pSelectionDate)
                {
                    if (pShareTypes.Contains(Transactions[i].ShareType))
                    {
                        totalShares += Transactions[i].NumberShares;
                    }
                }
                else
                {
                    if (Transactions[i].TransactionDate <= pSelectionDate)
                    {
                        totalShares += Transactions[i].NumberShares;
                    }
                }
            }
            return totalShares;
        }


        // ---------------------------------------------------------------------------------------------------
        // Methode: ValueOnDate
        // Doel   : Opleveren van de waarde van de aandelen in het portfolio op de gegeven datum.
        // TODO   : Dit kenmerk kent een optionele parameter pNumberDecimals die bepaalt op hoeveel decimalen
        //          de waarde wordt afgerond, indien null wordt de waarde niet afgerond.
        //          Ook kent het kenmerk een optionele parameter pShareTypes, indien deze parameter gevuld is
        //          dienen alleen transacties met een ShareType in de lijst meegenomen te worden
        //          in de berekening van de waarde van de aandelen.
        // ---------------------------------------------------------------------------------------------------
        public decimal ValueOnDate(DateTime pSelectionDate
                                 , int? pNumberDecimals = 2
                                 , List<Constants.ShareType>? pShareTypes = null)
        {
            // totalAmount: totale waarde van de aandelen
            decimal totalAmount = 0;

            /* voor elke transactie voor de geselecteerde datum van de unittest
             * tel de waarde van de transactie (aantal aandelen * waarde ervan) bij de totalAmount op
             * rond deze waarde af op het einde indien pNumberDecimals een waarde heeft
             * en geef deze waarde terug */
            for (int i = 0; i < Transactions.Count(); i++)
            {
                if (pShareTypes != null && Transactions[i].TransactionDate <= pSelectionDate)
                {
                    if (pShareTypes.Contains(Transactions[i].ShareType))
                    {
                        totalAmount += Transactions[i].NumberShares * Transactions[i].SharesRate;
                    }
                }
                else if (Transactions[i].TransactionDate <= pSelectionDate)
                {
                    totalAmount += Transactions[i].NumberShares * Transactions[i].SharesRate;
                }
            }
            if (pNumberDecimals.HasValue)
            {
                totalAmount = Math.Round(totalAmount, pNumberDecimals.Value);
            }
            return totalAmount;
        }
        #endregion


        #region Constructor
        // ---------------------------------------------------------------------------------------------------
        // Methode   : Portfolio
        // Doel      : Het initieren van een nieuw Portfolio object met de meegegeven transacties.
        // ---------------------------------------------------------------------------------------------------
        public Portfolio(List<Transaction> pTransactions)
        {
            Transactions = pTransactions;
        }
        #endregion
    }
}
