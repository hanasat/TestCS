using System;
using Xunit;

namespace dark_place_game.tests
{
    
    /// Cette classe contient tout un ensemble de tests unitaires pour la classe CurrencyHolder
    public class CurrencyHolderTest
    {
        public static readonly int EXEMPLE_CAPACITE_VALIDE = 2748;
        public static readonly int EXEMPLE_CONTENANCE_INITIALE_VALIDE = 978;
        public static readonly string EXEMPLE_NOM_MONNAIE_VALIDE = "Brouzouf";
        public static readonly string EXEMPLE_NOM_MONNAIE_DOLLARD = "dollard";
        public static readonly string EXEMPLE_NOM_MONNAIE_INFQUATRE ="abc"; 
        
        
        [Fact]
        public void VraiShouldBeTrue()
        {
            var vrai = true;
            Assert.True(vrai, "Erreur, vrai vaut false. Le test est volontairement mal écrit, corrigez le.");
        }

        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf10ShouldContain10Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE , 10);
            var result = ch.CurrentAmount == 10;
            Assert.True(result);
        }

        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf25ShouldContain25Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, 25);
            var result = ch.CurrentAmount == 25;
            Assert.True(result);
        }

        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf0ShouldContain0Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE, 0);
            var result = ch.CurrentAmount == 0;
            Assert.True(result);
        }

        [Fact]
        public void CreatingCurrencyHolderWithNegativeContentThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE , -10);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CreatingCurrencyHolderWithNullNameThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder(null,EXEMPLE_CAPACITE_VALIDE , EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CreatingCurrencyHolderWithEmptyNameThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder("",EXEMPLE_CAPACITE_VALIDE , EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

       
        [Fact]
        public void BrouzoufIsAValidCurrencyName ()
        {
            // A vous d'écrire un test qui vérife qu'on peut créer un CurrencyHolder contenant une monnaie dont le nom est Brouzouf
            CurrencyHolder currencyHolder = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE,EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            var result = currencyHolder.CurrencyName == EXEMPLE_NOM_MONNAIE_VALIDE;
            Assert.True(result,"le nom n'est pas Brouzouf");
            
        }

        [Fact]
        public void DollardIsAValidCurrencyName ()
        {
            // A vous d'écrire un test qui vérife qu'on peut créer un CurrencyHolder contenant une monnaie dont le nom est Dollard
            CurrencyHolder currencyHolder = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_DOLLARD,EXEMPLE_CAPACITE_VALIDE,EXEMPLE_CONTENANCE_INITIALE_VALIDE);
             var result = currencyHolder.CurrencyName == EXEMPLE_NOM_MONNAIE_DOLLARD;
            Assert.True(result,"le nom n'est pas dollard");
        
            
        }

        [Fact]
        public void TestPut10CurrencyInNonFullCurrencyHolder()
        {
            // A vous d'écrire un test qui vérifie que si on ajoute via la methode Store 10 (int amount)currency à un sac(CurrecyHolder) a moité plein(capacity/2), il contient maintenant la bonne quantité de currency
           CurrencyHolder currencyHolder = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE/2,EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            currencyHolder.Store(10);
             var result = currencyHolder.CurrentAmount == 988;
            Assert.True(result,"le sac ne contient pas la bonne quantité");
            
                    
        }

        [Fact]
        public void TestStore10CurrencyInNearlyFullCurrencyHolder()
        {
            // A vous d'écrire un test qui vérifie que si on ajoute via la methode put 10 currency à un sac quasiement plein, une exeption NotEnoughtSpaceInCurrencyHolderExeption est levée.
            Action capaciteMax = () =>  { 
              CurrencyHolder currencyHolder =   new  CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,400,399);
                currencyHolder.Store(10);
       
            };
           Assert.Throws<NotEnoughtSpaceInCurrencyHolderExeption>(capaciteMax);
                   
            
        }

        
        [Fact]
        public void TestStoreNagativeAmountCurrencyInNearlyFullCurrencyHolder()
        {
            Action capaciteNegative = () =>  { 
              CurrencyHolder currencyHolder =   new  CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,400,399);
              currencyHolder.Store(-54);
            };
              Assert.Throws<NotStoreNagativeAmountCurrency>(capaciteNegative);

        }

        [Fact]
        public void TestStorenNullAmountCurrencyInNearlyFullCurrencyHolder()
        {
            Action capaciteNegative = () =>  { 
              CurrencyHolder currencyHolder =   new  CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,400,399);
              currencyHolder.Store(0);
            };
              Assert.Throws<NotStoreNullAmountInCurrencyHolderExeption>(capaciteNegative);

        }

        [Fact]
        public void CreatingCurrencyHolderWithNameShorterThan4CharacterThrowExeption(){
            // A vous d'écrire un test qui doit échouer s'il es possible de créer un CurrencyHolder dont Le Nom De monnaie est inférieur a 4 lettres
          Action lengthName4= () => new CurrencyHolder(EXEMPLE_NOM_MONNAIE_INFQUATRE,EXEMPLE_CAPACITE_VALIDE,EXEMPLE_CONTENANCE_INITIALE_VALIDE);
          Assert.Throws<LengthNameException>(lengthName4);
        }

        [Fact]
        public void CreatingCurrencyHolderWith12Chars(){
            Action lengthName10= () => new CurrencyHolder("RBCDEFRGTHYJ",EXEMPLE_CAPACITE_VALIDE,EXEMPLE_CONTENANCE_INITIALE_VALIDE);
          Assert.Throws<LengthNameException>(lengthName10);
        }

        [Fact]
        public void CreatingCurrencyHolderWithFirstIsA(){
            Action lengthNameUpper = () => new CurrencyHolder("ABCDEFRGTH",EXEMPLE_CAPACITE_VALIDE,EXEMPLE_CONTENANCE_INITIALE_VALIDE);
        Assert.Throws<NotCreatingCurrencyHolderWithFirstIsA>(lengthNameUpper);
        }

        [Fact]
        public void CreatinCurrencyHolderNameWhitFirstCharIsLower(){
             Action lengthNameMin= () => new CurrencyHolder("aBCDEFRG",EXEMPLE_CAPACITE_VALIDE,EXEMPLE_CONTENANCE_INITIALE_VALIDE);
        Assert.Throws<NotCreatingCurrencyHolderWithFirstCharIsa>(lengthNameMin);

        }
    

        [Fact]
        public void WithdrawMoreThanCurrentAmountInCurrencyHolderThrowExeption()
        {
            // A vous d'écrire un test qui vérifie que retirer (methode withdraw) une quantité negative de currency leve une exeption CantWithDrawNegativeCurrencyAmountExeption.
            // Asruce : dans ce cas prévu avant même de pouvoir compiler le test, vous allez être obligé de créer la classe CantWithDrawMoreThanCurrentAmountExeption (vous pouvez la mettre dans le meme fichier que CurrencyHolder)
             Action AmountNegative = () => {
               CurrencyHolder currencyHolder =  new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,EXEMPLE_CAPACITE_VALIDE,EXEMPLE_CONTENANCE_INITIALE_VALIDE);
                 currencyHolder.Withdraw(-9);
             };
            Assert.Throws<CantWithDrawMoreThanCurrentAmountException>(AmountNegative);
            
        }
       [Fact]
        public void CurrencyHolderWithNegativeCapacity()
        {
            Action ch = () => new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,-9,450 );
           Assert.Throws<NotCurrencyHolderWithNegativeCapacity>(ch);
            
        }
      
        [Fact]
        public void WithDrawWithNullCurrentAmount(){
            Action ch = () => {
                CurrencyHolder cHolder = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,600,450 );
                cHolder.Withdraw(0);
            };
           Assert.Throws<NotWithDrawWithNullCurrentAmountException>(ch);
        }

        [Fact]
        public void CurrencyHolderIsEmpty1(){
            CurrencyHolder ch = new CurrencyHolder("hanane",400,0);
            var result = ch.IsEmpty();
            Assert.True(result);
        }
        [Fact]
        public void CurrencyHolderIsEmpty2(){
            CurrencyHolder ch = new CurrencyHolder("hanane",400,14);
            var result = ch.IsEmpty();
            Assert.False(result);
        }

         [Fact]
        public void CurrencyHolderIsFull1(){
            CurrencyHolder ch = new CurrencyHolder("hanane",400,400);
            var result = ch.IsFull();
            Assert.True(result);
        }

         [Fact]
        public void CurrencyHolderIsFull2(){
            CurrencyHolder ch = new CurrencyHolder("hanane",400,10);
            ch.Store(390);
            var result = ch.IsFull();
            Assert.True(result);
        }

         [Fact]
        public void CurrencyHolderIsFull3(){
            CurrencyHolder ch = new CurrencyHolder("hanane",400,40);
            var result = ch.IsFull();
            Assert.False(result);
        }

         [Fact]
        public void CurrencyHolderIsFull4(){
            CurrencyHolder ch = new CurrencyHolder("hanane",400,10);
            ch.Store(39);
            var result = ch.IsFull();
            Assert.False(result);
        }
    }
}
