/** @OnlyCurrentDoc */

function Pokemon_Preis_Sortierer() {
  //Das aktive Spreadsheet festlegen
  var spreadsheet = SpreadsheetApp.getActive();

  //Einen bestimmten Abteil makieren
  spreadsheet.getRange('B1').activate();

  //Den zuvor makierten Abteil sortieren
  spreadsheet.getActiveSheet().getFilter().sort(2, false);
};

function Zur_Liste_hinzufuegen() {
  //Das aktive Spreadsheet festlegen
  var spreadsheet = SpreadsheetApp.getActive();

  //Einbinden der Tabelle "Liste aller Pokemons"
  var form = spreadsheet.getSheetByName("Liste aller Pokemons");

  //Slots des Eingabe Feldes
  var values =   [[form.getRange("M1").getValue(),
    form.getRange("M2").getValue(),
    form.getRange("M3").getValue(),
    form.getRange("M4").getValue(),
    form.getRange("M5").getValue(),
    form.getRange("M6").getValue(),
    form.getRange("M7").getValue(),
    form.getRange("M8").getValue(), 1]];

  //Einen Bool welcher aussagt ob das eingefügte Element schon vorhanden ist
  var exists = false;

  //Checken ob die Werte schon existieren
  for (var zaehler = 2; zaehler < 1001; zaehler++)
  {
    //Checken ob diese bestimmte Werte übereinstimmen
    if (form.getRange(zaehler,1).getValue() == form.getRange("M1").getValue() &&
     form.getRange(zaehler,4).getValue() == form.getRange("M4").getValue() &&
     form.getRange(zaehler,5).getValue() == form.getRange("M5").getValue() &&
     form.getRange(zaehler,8).getValue() == form.getRange("M8").getValue())
    {
      //Den vorhandenen Eintrag um 1 erhöhen
      var zaehler2 = form.getRange(zaehler, 9).getValue();
      zaehler2++;
      form.getRange(zaehler, 9).setValue(zaehler2);
      exists = true;
    }
  }

//Wenn der Eintrag nicht exestiert wird er hier zurückgesetzt
if (exists == false)
{
  var Avals = form.getRange("A1:A").getValues();
  var Alast = Avals.filter(String).length;

  form.getRange(Alast + 1, 1, 1, 9).setValues(values);

  exists = true;
}

//Alle Werte zurücksetzten
form.getRange("M1").setValue("");
form.getRange("M2").setValue("");
form.getRange("M3").setValue("");
form.getRange("M4").setValue("");

form.getRange("M5").setValue("");
form.getRange("M6").setValue("");
form.getRange("M7").setValue("");
form.getRange("M8").setValue("");
}

function Pokemon_Nr_und_Pack_Sortierer() {
  //Das Spreadsheet welches gebraucht wird als var festlegen
  var spreadsheet = SpreadsheetApp.getActive();

  //Eine bestimmte Spalte auswählen
  spreadsheet.getRange('D1').activate();
  //Den Sortierer anwenden
  spreadsheet.getActiveSheet().getFilter().sort(4, true);

  //Eine bestimmte Spalte auswählen
  spreadsheet.getRange('E1').activate();
  //Den Sotierer anwenden
  spreadsheet.getActiveSheet().getFilter().sort(5, true);
};