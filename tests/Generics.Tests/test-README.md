# TEST README

Run this command in the terminal to run the tests: 

```bash
dotnet test
```

### Available tests

**Repository:**
- Add_ShouldIncreaseCount
- Add_ShouldStoreItem
- Remove_ShouldReturnTrue_WhenItemExists
- Remove_ShouldReturnFalse_WhenItemDoesNotExist
- Get_ShouldReturn_MatchingItem
- GetAll_ShouldReturn_AllItems
- Add_NullItem_ShouldThrowArgumentNullException *// Denne testen feiler da det ikke er noen constraints på T for nullverdier*
- Add_NullItem_ShouldBeStoredAsTAllowsNull *// Samme som testen over, men viser at nullverdi godtas.*
- Get_NullPredicate_ShouldThrowArgumentNullException
- Add_Duplicates_ShouldStoreAll
- Remove_OnEmptyRepo_ShouldReturnFalse
- Get_OnEmptyRepo_ShouldReturnNull
- Get_ShouldReturnFirstMatch_WhenMultipleMatches
- GetAll_ShouldReturnCopy_NotAllowExternalMutation

**Interface:**
- Repository_Implements_IRepositoryInterface
- IRepository_InterfaceMethods_Exist

**Generics:**
- Repository_ShouldStoreObject
- Get_ShouldFindObjectByPredicate


### Oppgavespørsmål:

**Hvorfor laget du de testene du har laget, føler du at du har dekket alt grunnfunksjonalitet i din class?**

Har fokusert på oppgavekravene og å teste repository/interface - kunne  testet models og beverageinitializer dersom jeg hadde tid. Føler jeg har dekket de viktigste elementene.

**Kunne en annen utvikler forstått hvordan de bruker din class / implementasjon via testene dine?** 

Forhåpentligvis ja. Selv om det er en del tester som bruker string/int er det også synlig hvordan jeg har brukt den generiske klassen med beverages. 