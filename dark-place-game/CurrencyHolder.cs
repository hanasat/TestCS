using System;

namespace dark_place_game
{

    [System.Serializable]
    /// Une Exeption Custom
    public class NotEnoughtSpaceInCurrencyHolderExeption : System.Exception {}
    public class NotCurrencyHolderWithNegativeCapacity : System.Exception {}
    public class NotStoreNullAmountInCurrencyHolderExeption : System.Exception {}
    public class NotCreatingCurrencyHolderWithFirstIsA : System.Exception {}
    public class NotStoreNagativeAmountCurrency : System.Exception{}
    public class NotWithDrawWithNullCurrentAmountException : System.Exception{}
    public class NotCreatingCurrencyHolderWithFirstCharIsa : System.Exception{}
    public class LengthNameException : System.Exception{  public LengthNameException (String msg){}}
    public class CurrencyHolder
    {
        public static readonly string CURRENCY_DEFAULT_NAME = "Unnamed";

        /// Le nom de la monnaie
        public string CurrencyName {
            get {return currencyName;}
            private set {
                currencyName = value;
            }
        }
        // Le champs interne de la property
        private string currencyName = CURRENCY_DEFAULT_NAME;

        /// Le montant actuel
        public int CurrentAmount {
            get {return currentAmount;}
            private set {
                currentAmount = value;
            }
        }
        // Le champs interne de la property
        private int currentAmount = 0;

        /// La contenance maximum du conteneur
        public int Capacity {
            get {return capacity;}
            private set {
                capacity = value;
            }
        }
        // Le champs interne de la property
        private int capacity = 0;

        public CurrencyHolder(string name,int capacity, int amount) {
            
            if (amount < 0 ){

                throw new ArgumentException("Argument invalide");

            }if(name == null || name =="" ){
                 throw new ArgumentException("Argument invalide");
                 
            }if( name.Length < 4 || name.Length > 10){
                
                throw new LengthNameException("Argument invalide");
            }
            if(capacity < 1 )
            {
                throw new NotCurrencyHolderWithNegativeCapacity();
            }if (name[0]=='A'){
                throw new NotCreatingCurrencyHolderWithFirstIsA();
            }if (name[0]=='a'){
                throw new NotCreatingCurrencyHolderWithFirstCharIsa();
            }
                    Capacity = capacity;
                     CurrencyName = name;
                    CurrentAmount = amount;
            
                     
        }

        public bool IsEmpty() {
            if(this.currentAmount == 0 )
                return true;
            else 
            return false;
        }

        public bool IsFull() {
            if(this.currentAmount == this.capacity)
                return true;
            else 
                return false;
        }

        public void Store(int amount) {
            if(amount > 0 )
            {
                if(this.currentAmount + amount > this.Capacity){
                 throw new NotEnoughtSpaceInCurrencyHolderExeption();
                 }
                  else {
                      this.currentAmount += amount;
                   }
            }else if(amount == 0)
            {
                throw new NotStoreNullAmountInCurrencyHolderExeption();

            }else if (amount < 0 ){
                throw new NotStoreNagativeAmountCurrency();
            }
                
            
            
        }

        public void Withdraw(int amount) {
            if( amount < 0 )
            {
                throw new CantWithDrawMoreThanCurrentAmountException("Argument invalide");
            }else if(amount == 0){
                throw new NotWithDrawWithNullCurrentAmountException();
            }else
            {
                this.currentAmount -= amount ;
            }


        }

    }

public class CantWithDrawMoreThanCurrentAmountException : System.Exception{

    public CantWithDrawMoreThanCurrentAmountException(String msg) : base ("impossible de retirer un nombre négative"){

    }
    

}
}