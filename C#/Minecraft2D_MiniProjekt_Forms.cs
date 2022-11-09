using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;

namespace Minecraft_2D
{
    public partial class Minecraft_2D : Form
    {
        public Minecraft_2D()
        {
            InitializeComponent();
        }

        //Notizen
        //Notizen
        //Notizen
        //Es müssen folgende Variablen bei Speicherung gespeichert werden
        //Map, Position und Inventory

        //Öffentliche Variablen
        //Öffentliche Variablen
        //Öffentliche Variablen
        //Hier wird die Map gespeichert
        string[,] map_loader;

        //Variablen für die derzeitigen Postion des Players
        public int currentPlayerPosition_X = 0;
        public int currentPlayerPosition_Y = 0;

        //Map
        //Alle Hoehen auf der Map wegen Playerpostion als Public Variable
        public int[] hoechsterpunkt = new int[5121];
        //Standart Seed breitlegen
        public int StandartSeed = 300;

        //Inventar Slots
        //Welcher Slot ausgewählt wird
        public int ausgewählterslot = 0;
        //Was gespeichert wird
        public string[] InventorySlot_Save = new String[10];
        //Wie viel gespeichert wird
        public int[] InventorySlot_Number = new Int32[10];

        //Bool Werte
        //Interact with Blocks
        public bool interact_with_blocks = false;
        //Is Handcrafting Inventory loaded
        public int Is_Minecraft_Handcrafting_loaded = 1;
        //Ingame Debugging
        public bool can_go_through_blocks = false;
        //Welches CraftingFeld gerade verwendet wird
        public int welchescraftingfeld = 0;

        //Buttons
        //Buttons
        //Buttons
        public void create_World_Button(object sender, EventArgs e)
        {
            //Neue Map erstellen und laden
            map_loader = MapGenerator();

            //Postionen zurücksetzen
            currentPlayerPosition_X = 0;
            currentPlayerPosition_Y = 0;

            //Inventory Slots resetten
            //Was gespeichert wird
            InventorySlot_Save[1] = "";
            InventorySlot_Save[2] = "";
            InventorySlot_Save[3] = "";
            InventorySlot_Save[4] = "";
            InventorySlot_Save[5] = "";
            InventorySlot_Save[6] = "";
            InventorySlot_Save[7] = "";
            InventorySlot_Save[8] = "";
            InventorySlot_Save[9] = "";

            //Wie viel gespeichert wird
            InventorySlot_Number[1] = 0;
            InventorySlot_Number[2] = 0;
            InventorySlot_Number[3] = 0;
            InventorySlot_Number[4] = 0;
            InventorySlot_Number[5] = 0;
            InventorySlot_Number[6] = 0;
            InventorySlot_Number[7] = 0;
            InventorySlot_Number[8] = 0;
            InventorySlot_Number[9] = 0;

            //Auf Buttons neu anzeigen
            inventoryslot1.Text = InventorySlot_Number[1] + "x" + " " + InventorySlot_Save[1];
            inventoryslot2.Text = InventorySlot_Number[2] + "x" + " " + InventorySlot_Save[2];
            inventoryslot3.Text = InventorySlot_Number[3] + "x" + " " + InventorySlot_Save[3];

            inventoryslot4.Text = InventorySlot_Number[4] + "x" + " " + InventorySlot_Save[4];
            inventoryslot5.Text = InventorySlot_Number[5] + "x" + " " + InventorySlot_Save[5];
            inventoryslot6.Text = InventorySlot_Number[6] + "x" + " " + InventorySlot_Save[6];

            inventoryslot7.Text = InventorySlot_Number[7] + "x" + " " + InventorySlot_Save[7];
            inventoryslot8.Text = InventorySlot_Number[8] + "x" + " " + InventorySlot_Save[8];
            inventoryslot9.Text = InventorySlot_Number[9] + "x" + " " + InventorySlot_Save[9];

            //Postion neu einspeichern
            currentPlayerPosition_X = 2561 + currentPlayerPosition_X;
            currentPlayerPosition_Y = Spawnhoehe_berechenen() + currentPlayerPosition_Y;

            //Map neuladen
            Map_neuladen(map_loader);
        }

        //Buttons oder Tasten Eingabe
        public void Tasten_Eingabe(object sender, KeyEventArgs e)
        {
            string eingabe = e.KeyCode.ToString();

            //Zu PlayerMovement weitergeben
            PlayerMovement(eingabe);
        }

        //Wenn der Player sich bewegt wird die Cordinaten Position neu gespeichert
        public void PlayerMovement(string eingabe)
        {
            //Zusaätzlich wird noch eine Extension der Collision hinzugefügt
            //Buttons einlesen welche in die Nähe des Players sind und mit irgendeiner Variable deklarieren
            Button linksoben = (Button)button1;
            Button links1 = (Button)button1;
            Button links2 = (Button)button1;
            Button linksunten = (Button)button1;
            Button oben = (Button)button1;
            Button unten = (Button)button1;
            Button rechtsoben = (Button)button1;
            Button rechts1 = (Button)button1;
            Button rechts2 = (Button)button1;
            Button rechtsunten = (Button)button1;

            //Einstellen ob man durch Wände gehen kann oder nicht
            if (can_go_through_blocks)
            {
                linksoben = (Button)button1;
                links1 = (Button)button1;
                links2 = (Button)button1;
                linksunten = (Button)button1;
                oben = (Button)button1;
                unten = (Button)button1;
                rechtsoben = (Button)button1;
                rechts1 = (Button)button1;
                rechts2 = (Button)button1;
                rechtsunten = (Button)button1;
            }
            else
            {
                linksoben = (Button)Feld43;
                links1 = (Button)Feld44;
                links2 = (Button)Feld45;
                linksunten = (Button)Feld46;
                oben = (Button)Feld53;
                unten = (Button)Feld56;
                rechtsoben = (Button)Feld63;
                rechts1 = (Button)Feld64;
                rechts2 = (Button)Feld65;
                rechtsunten = (Button)Feld66;
            }

            //Gehen Links
            if (eingabe == "A")
            {
                //Collision Detection
                if (links1.Text == " " && links2.Text == " ")
                {
                    //Movement
                    currentPlayerPosition_X -= 1;
                }
            }

            //Gehen Rechts
            if (eingabe == "D")
            {
                //Collision Detection
                if (rechts1.Text == " " && rechts2.Text == " ")
                {
                    //Movement
                    currentPlayerPosition_X += 1;
                }
            }

            //Gehen Oben
            if (eingabe == "W")
            {
                //Collission Detection
                if (oben.Text == " ")
                {
                    //Movement
                    currentPlayerPosition_Y -= 1;
                }
            }

            //Gehe nach Unten
            if (eingabe == "S")
            {
                //Collission Detection
                if (unten.Text == " ")
                {
                    //Movement
                    currentPlayerPosition_Y += 1;
                }
            }

            //Gehe nach Links oben
            if (eingabe == "Q")
            {
                //Collision Detection
                if (linksoben.Text == " " && links1.Text == " " && oben.Text == " ")
                {
                    //Movement
                    currentPlayerPosition_X -= 1;
                    currentPlayerPosition_Y -= 1;
                }
            }

            //Gehe nach rechts oben
            if (eingabe == "E")
            {
                //Collision Detection
                if (rechtsoben.Text == " " && rechts1.Text == " " && oben.Text == " ")
                {
                    //Movement
                    currentPlayerPosition_X += 1;
                    currentPlayerPosition_Y -= 1;
                }
            }

            //Map neuladen
            Map_neuladen(map_loader);
        }

        //In der Welt etwas Abbauen oder Platzieren
        public void Abbauen_oder_Platzieren(object sender, EventArgs e)
        {
            //Wenn mit einem Block interagiert passiert nichts
            //Gesendeter Button einspeichern
            Button btn = (Button)sender;

            if (interact_with_blocks == false)
            {
                Button[] button_inventarslots = InventorySlotseinlesen();

                //Einen if-Anweisung um zu definieren ob etwas platziert oder abgebaut wird
                if (btn.Text == " ")
                {
                    //Ausgewählter Button zum Platzieren
                    if (InventorySlot_Number[ausgewählterslot] > 0)
                    {
                        string Speicher_Platzieren = InventorySlot_Save[ausgewählterslot];
                        InventorySlot_Number[ausgewählterslot]--;

                        //Platzieren Funktion wird aufgerufen
                        Platzieren(btn, Speicher_Platzieren);

                        //Text entfernen wenn das letzte Item gebaut wurden ist
                        if (InventorySlot_Number[ausgewählterslot] == 0)
                        {
                            InventorySlot_Save[ausgewählterslot] = "";
                        }
                    }
                }
                else
                {
                    //Ausgewählter Slot zum Abbauen
                    if (InventorySlot_Save[ausgewählterslot] == "" || InventorySlot_Save[ausgewählterslot] == btn.Text)
                    {
                        //Abbauen Funktion wird aufgerufen
                        string Speicher_Abbauen = Abbauen(btn);
                        InventorySlot_Save[ausgewählterslot] = Speicher_Abbauen;
                        InventorySlot_Number[ausgewählterslot]++;
                    }
                }

                //Auf Buttons neu anzeigen
                Inventar_neuladen();

                //Die Map neu laden
                Map_neuladen(map_loader);
            }
            else
            {
                //Checken ob man mit dem Block interagieren kann+
                Interact_with_Blocks_Worker(btn);
            }
        }

        //Buildmode betreten
        public void Enter_Buildmode(object sender, EventArgs e)
        {
            //Alle Blöcke Visible machen zum Platzieren
            Button linksoben = (Button)Feld43;
            Button links1 = (Button)Feld44;
            Button links2 = (Button)Feld45;
            Button linksunten = (Button)Feld46;
            Button oben = (Button)Feld53;
            Button unten = (Button)Feld56;
            Button rechtsoben = (Button)Feld63;
            Button rechts1 = (Button)Feld64;
            Button rechts2 = (Button)Feld65;
            Button rechtsunten = (Button)Feld66;

            linksoben.Visible = true;
            links1.Visible = true;
            links2.Visible = true;
            linksunten.Visible = true;
            oben.Visible = true;
            unten.Visible = true;
            rechtsoben.Visible = true;
            rechts1.Visible = true;
            rechts2.Visible = true;
            rechtsunten.Visible = true;

            //Wenn Interact Mode aktiviert ist wieder deaktivieren
            interact_with_blocks = false;
        }

        //Inventory Slot auswählen
        public void ausgewählter_Slot(object sender, EventArgs e)
        {
            //Button einlesen welcher geklickt worden ist
            Button geklickterButton = (Button)sender;

            //Buttons einlesen
            Button[] InventorySlots = InventorySlotseinlesen();

            //Buttons den Slots zuweisen
            if (geklickterButton == InventorySlots[0])
            {
                ausgewählterslot = 1;
            }

            if (geklickterButton == InventorySlots[1])
            {
                ausgewählterslot = 2;
            }

            if (geklickterButton == InventorySlots[2])
            {
                ausgewählterslot = 3;
            }

            if (geklickterButton == InventorySlots[3])
            {
                ausgewählterslot = 4;
            }

            if (geklickterButton == InventorySlots[4])
            {
                ausgewählterslot = 5;
            }

            if (geklickterButton == InventorySlots[5])
            {
                ausgewählterslot = 6;
            }

            if (geklickterButton == InventorySlots[6])
            {
                ausgewählterslot = 7;
            }

            if (geklickterButton == InventorySlots[7])
            {
                ausgewählterslot = 8;
            }

            if (geklickterButton == InventorySlots[8])
            {
                ausgewählterslot = 9;
            }
        }

        //Seed verändern
        public void ChangeSeed(object sender, EventArgs e)
        {
            string Seed = Interaction.InputBox("ACHTUNG: Wenn die Zahl zu groß ist stürzt das Programm ab.", "Bitte einen Seed eingeben:", "2293", 500, 300);
            StandartSeed = Int32.Parse(Seed);
        }

        //Map speichern von .txt
        public void Map_Speichern(object sender, EventArgs e)
        {
            //Variable in welcher die Map für Weiterverarbeitung gespeichert wird
            string[] maponlyhoehen = new String[91];

            //Die geladenen Map in eine .txt speichern mittels for-Schleife
            for (int zaehlermaphoehe = 0; zaehlermaphoehe < 91; zaehlermaphoehe++)
            {
                for (int zaehlerlaenge = 0; zaehlerlaenge < 5121; zaehlerlaenge++)
                {
                    maponlyhoehen[zaehlermaphoehe] += map_loader[zaehlerlaenge, zaehlermaphoehe];
                }
            }

            //Zu einer .txt schreiben
            //Dazu muss ein Checker eingefügt werden wenn die Datei schon existiert das diese gelöscht wird
            if (File.Exists("Save.txt"))
            {
                File.Delete("Save.txt");
                File.AppendAllLines("Save.txt", maponlyhoehen);
            }
            else
            {
                File.AppendAllLines("Save.txt", maponlyhoehen);
            }

            //Dazu in einer seperaten Datei Positionen und Items speichern
            //Postionen speichern
            //Variablen dafür erstellen
            string[] positions = new String[2];
            positions[0] = Convert.ToString(currentPlayerPosition_X);
            positions[1] = Convert.ToString(currentPlayerPosition_Y);

            if (File.Exists("PlayerPosition.txt"))
            {
                File.Delete("PlayerPosition.txt");
                File.AppendAllLines("PlayerPosition.txt", positions);
            }
            else
            {
                File.AppendAllLines("PlayerPosition.txt", positions);
            }

            //Items speichern
            //Was darin gespeichert ist
            if (File.Exists("Inventory_Save.txt"))
            {
                File.Delete("Inventory_Save.txt");
                File.AppendAllLines("Inventory_Save.txt", InventorySlot_Save);
            }
            else
            {
                File.AppendAllLines("Inventory_Save.txt", InventorySlot_Save);
            }

            //Wieviel darin gespeichert ist
            //Variable deklariren worin die Zahlen gespeichert werden
            string[] zahlen = new String[9];

            //Alles in einen String umwandeln
            for (int zaehler_umwandler = 1; zaehler_umwandler < 10; zaehler_umwandler++)
            {
                zahlen[zaehler_umwandler - 1] = Convert.ToString(InventorySlot_Number[zaehler_umwandler]);
            }

            //In eine .txt speichern
            if (File.Exists("Inventory_Number.txt"))
            {
                File.Delete("Inventory_Number.txt");
                File.AppendAllLines("Inventory_Number.txt", zahlen);
            }
            else
            {
                File.AppendAllLines("Inventory_Number.txt", zahlen);
            }
        }

        //Map laded von .txt
        public void Map_Laden(object sender, EventArgs e)
        {
            //Map aus der .txt laden
            string[] loadedmap = File.ReadAllLines("Save.txt");

            //Map in welche die neue 3D-Map gespeichert wird
            string[,] map = new String[5121, 91];

            //Diese dann wieder zurück in ein 3D-Array umwandeln
            for (int zaehlerhoehen = 0; zaehlerhoehen < 91; zaehlerhoehen++)
            {
                for (int zaehlerlänge = 0; zaehlerlänge < 5121; zaehlerlänge++)
                {
                    map[zaehlerlänge, zaehlerhoehen] = Convert.ToString(loadedmap[zaehlerhoehen][zaehlerlänge]);
                }
            }

            //Diese neue Map dann in eine neue Funktion einfügen welche es in die geladene Map zurückgibt
            map_loader = map;

            //Postion wieder auslesen
            string[] position = File.ReadAllLines("PlayerPosition.txt");
            currentPlayerPosition_X = Int32.Parse(position[0]);
            currentPlayerPosition_Y = Int32.Parse(position[1]);

            //Item Slots wieder herholen
            string[] Inventory_Save = File.ReadAllLines("Inventory_Save.txt");
            string[] Inventory_Number = File.ReadAllLines("Inventory_Number.txt");

            //Mit einer for-Schleife zusammenführen
            for (int zaehler_inventory = 0; zaehler_inventory < 9; zaehler_inventory++)
            {
                InventorySlot_Save[zaehler_inventory + 1] = Inventory_Save[zaehler_inventory + 1];
                InventorySlot_Number[zaehler_inventory + 1] = Int32.Parse(Inventory_Number[zaehler_inventory]);
            }

            //Auf Buttons neu anzeigen
            inventoryslot1.Text = InventorySlot_Number[1] + "x" + " " + InventorySlot_Save[1];
            inventoryslot2.Text = InventorySlot_Number[2] + "x" + " " + InventorySlot_Save[2];
            inventoryslot3.Text = InventorySlot_Number[3] + "x" + " " + InventorySlot_Save[3];

            inventoryslot4.Text = InventorySlot_Number[4] + "x" + " " + InventorySlot_Save[4];
            inventoryslot5.Text = InventorySlot_Number[5] + "x" + " " + InventorySlot_Save[5];
            inventoryslot6.Text = InventorySlot_Number[6] + "x" + " " + InventorySlot_Save[6];

            inventoryslot7.Text = InventorySlot_Number[7] + "x" + " " + InventorySlot_Save[7];
            inventoryslot8.Text = InventorySlot_Number[8] + "x" + " " + InventorySlot_Save[8];
            inventoryslot9.Text = InventorySlot_Number[9] + "x" + " " + InventorySlot_Save[9];

            //Map neuladen
            Map_neuladen(map_loader);
        }

        //Interact Button
        public void Interact_with_Blocks(object sender, EventArgs e)
        {
            //Die Public Variable auf true schalten
            interact_with_blocks = true;
        }

        //Crafting Feld anzeigen
        public void Open_Handcrafting(object sender, EventArgs e)
        {
            Is_Minecraft_Handcrafting_loaded++;
            if (Is_Minecraft_Handcrafting_loaded % 2 == 0)
            {
                //Show Crafting Button
                Handcrafting11.Visible = true;
                Handcrafting12.Visible = true;
                Handcrafting21.Visible = true;
                Handcrafting22.Visible = true;
                Handcraftingresult.Visible = true;

                //Craftingfeld 1 einspeichern
                welchescraftingfeld = 1;
            }
            else
            {
                Handcrafting11.Visible = false;
                Handcrafting12.Visible = false;
                Handcrafting21.Visible = false;
                Handcrafting22.Visible = false;
                Handcraftingresult.Visible = false;

                //Craftinfeld geschlossen speichern
                welchescraftingfeld = 0;
            }
        }

        //Crafting Buttons in welche das Rezept eingesetzt wird
        public void CraftingChecker_Button(object sender, EventArgs e)
        {
            //Den Button Sender einlesen
            Button Button_Sender = (Button)sender;

            //Inventar Buttons einlesen
            Button[] InventarSlots = InventorySlotseinlesen();

            //Wenn der Button leer ist also kein Item eigesetzt ist eines einsetzen
            if (Button_Sender.Text == "" && InventorySlot_Number[ausgewählterslot] > 0)
            {
                //Infos aus dem ausgewählten Invetory Slots speichern
                string InventoryItem = InventorySlot_Save[ausgewählterslot];

                //Aus dem Inventory entfernen
                InventorySlot_Number[ausgewählterslot]--;

                //Inventar nothings left
                Inventar_nothing_left();

                //Auf den Button einfügen
                Button_Sender.Text = InventoryItem;
            }
            else
            {
                //Wenn schon etwas auf dem Feld ist um es zurückzunehmen darauf nochmal klicken
                if (Button_Sender.Text != "" && InventorySlot_Number[ausgewählterslot] == 0 || Button_Sender.Text != "" && InventorySlot_Save[ausgewählterslot] == Button_Sender.Text)
                {
                    //Zurückgeben ins Inventar
                    string Button_Sender_Text = Button_Sender.Text;

                    //Auf diesen Inventar Slot einfügen
                    InventorySlot_Save[ausgewählterslot] = Button_Sender_Text;

                    //Die Zahl um 1x erhöhen
                    InventorySlot_Number[ausgewählterslot]++;

                    //Den Text aus Button Sender removen
                    Button_Sender.Text = "";
                }
            }

            //Wenn ein Button verändert wird muss immer ein Updater zum Ergebnis gecallt werden
            Inventar_neuladen();

            //Anzeigen wenn etwas herauskommt
            if (Handcrafting11.Text == "H" || Handcrafting12.Text == "H" || Handcrafting21.Text == "H" || Handcrafting22.Text == "H")
            {
                Handcraftingresult.Text = "P";
            }
            else
            {
                if (Handcrafting11.Text == "P" && Handcrafting21.Text == "P")
                {
                    Handcraftingresult.Text = "St";
                }
                else
                {
                    if (Handcrafting11.Text == "P" && Handcrafting21.Text == "St")
                    {
                        Handcraftingresult.Text = "Sp";
                    }
                    else
                    {
                        Handcraftingresult.Text = "";
                    }
                }
            }
        }

        //Rausnehmen wenn fertig
        public void ausCraftingFeldrausnehmen(object sender, EventArgs e)
        {
            if (welchescraftingfeld == 1 && Handcraftingresult.Text != "" && InventorySlot_Number[ausgewählterslot] == 0)
            {
                Handcrafting11.Text = "";
                Handcrafting12.Text = "";
                Handcrafting21.Text = "";
                Handcrafting22.Text = "";

                InventorySlot_Save[ausgewählterslot] = Handcraftingresult.Text;
                InventorySlot_Number[ausgewählterslot]++;

                Handcraftingresult.Text = "";

                Inventar_neuladen();
            }
        }



        //Codeblöcke und Funktionen
        //Codeblöcke und Funktionen
        //Codeblöcke und Funktionen

        //Buttons in x-Richtung einlesen
        public Button[] Buttons_einlesenx()
        {
            //Erstellen des Arrays
            Button[] buttons = new Button[72];

            //Erster Wert wird immer durchnummeriert und dann immer +9
            buttons[0] = (Button)Feld11;
            buttons[9] = (Button)Feld12;
            buttons[18] = (Button)Feld13;
            buttons[27] = (Button)Feld14;
            buttons[36] = (Button)Feld15;
            buttons[45] = (Button)Feld16;
            buttons[54] = (Button)Feld17;
            buttons[63] = (Button)Feld18;

            buttons[1] = (Button)Feld21;
            buttons[10] = (Button)Feld22;
            buttons[19] = (Button)Feld23;
            buttons[28] = (Button)Feld24;
            buttons[37] = (Button)Feld25;
            buttons[46] = (Button)Feld26;
            buttons[55] = (Button)Feld27;
            buttons[64] = (Button)Feld28;

            buttons[2] = (Button)Feld31;
            buttons[11] = (Button)Feld32;
            buttons[20] = (Button)Feld33;
            buttons[29] = (Button)Feld34;
            buttons[38] = (Button)Feld35;
            buttons[47] = (Button)Feld36;
            buttons[56] = (Button)Feld37;
            buttons[65] = (Button)Feld38;

            buttons[3] = (Button)Feld41;
            buttons[12] = (Button)Feld42;
            buttons[21] = (Button)Feld43;
            buttons[30] = (Button)Feld44;
            buttons[39] = (Button)Feld45;
            buttons[48] = (Button)Feld46;
            buttons[57] = (Button)Feld47;
            buttons[66] = (Button)Feld48;

            buttons[4] = (Button)Feld51;
            buttons[13] = (Button)Feld52;
            buttons[22] = (Button)Feld53;
            buttons[31] = (Button)Feld54;
            buttons[40] = (Button)Feld55;
            buttons[49] = (Button)Feld56;
            buttons[58] = (Button)Feld57;
            buttons[67] = (Button)Feld58;

            buttons[5] = (Button)Feld61;
            buttons[14] = (Button)Feld62;
            buttons[23] = (Button)Feld63;
            buttons[32] = (Button)Feld64;
            buttons[41] = (Button)Feld65;
            buttons[50] = (Button)Feld66;
            buttons[59] = (Button)Feld67;
            buttons[68] = (Button)Feld68;

            buttons[6] = (Button)Feld71;
            buttons[15] = (Button)Feld72;
            buttons[24] = (Button)Feld73;
            buttons[33] = (Button)Feld74;
            buttons[42] = (Button)Feld75;
            buttons[51] = (Button)Feld76;
            buttons[60] = (Button)Feld77;
            buttons[69] = (Button)Feld78;

            buttons[7] = (Button)Feld81;
            buttons[16] = (Button)Feld82;
            buttons[25] = (Button)Feld83;
            buttons[34] = (Button)Feld84;
            buttons[43] = (Button)Feld85;
            buttons[52] = (Button)Feld86;
            buttons[61] = (Button)Feld87;
            buttons[70] = (Button)Feld88;

            buttons[8] = (Button)Feld91;
            buttons[17] = (Button)Feld92;
            buttons[26] = (Button)Feld93;
            buttons[35] = (Button)Feld94;
            buttons[44] = (Button)Feld95;
            buttons[53] = (Button)Feld96;
            buttons[62] = (Button)Feld97;
            buttons[71] = (Button)Feld98;

            //Das Array wird zurückgegeben
            return buttons;
        }

        //Spawnhoehe berechnen
        public int Spawnhoehe_berechenen()
        {
            //Höhe für den Spawnpunkt anpassen
            int spawnhoehe = 0;

            for (int zaehlerhoehe = 0; zaehlerhoehe < 91; zaehlerhoehe++)
            {
                if (map_loader[2561 + 4, zaehlerhoehe] == "G")
                {
                    spawnhoehe = zaehlerhoehe;
                }
            }

            return spawnhoehe;
        }

        //Hier wird die Map generiert
        public string[,] MapGenerator()
        {
            //Eine temporäre leere Map erstellen
            string[,] GeneratorMap = new String[5121, 91];

            //Alles mit Leerzeichen füllen
            for (int zaehler = 0; zaehler < 5121; zaehler++)
            {
                for (int zaehler2 = 0; zaehler2 < 91; zaehler2++)
                {
                    GeneratorMap[zaehler, zaehler2] = " ";
                }
            }

            //Landschaft generieren
            //Vorher wird noch die Starthöhe festgelegt
            //Variablen deklarieren
            int height = 40;
            Random rnd = new Random(StandartSeed);

            //Mittel for-Schleife eine Map generieren
            for (int zaehlerlaenge = 0; zaehlerlaenge < 5121; zaehlerlaenge++)
            {
                //Veränderungen im Terrain
                int minheight = height - 1;
                int maxheight = height + 2;
                height = rnd.Next(minheight, maxheight);

                //Zurücksetzung falls das Terrain zu weit vom Startpunkt weg ist
                if (height > 60)
                    height = 40;

                if (height < 30)
                    height = 40;

                //Höhen speichern in einer Liste
                hoechsterpunkt[zaehlerlaenge] = height;

                //Terrain in die Map einsetzen
                for (int zaehlerhoehe = 90; zaehlerhoehe > height; zaehlerhoehe--)
                {
                    GeneratorMap[zaehlerlaenge, zaehlerhoehe] = "E";
                }
            }

            //Gras generieren
            for (int zaehlergras = 0; zaehlergras < 5121; zaehlergras++)
            {
                GeneratorMap[zaehlergras, hoechsterpunkt[zaehlergras]] = "G";
            }

            //Bäume generieren
            for (int zaehlerbaueme = 3; zaehlerbaueme < 5121; zaehlerbaueme++)
            {
                if (zaehlerbaueme % 21 == 0)
                {
                    //Baumstruktur aufbauen
                    GeneratorMap[zaehlerbaueme, hoechsterpunkt[zaehlerbaueme] - 1] = "H";
                    GeneratorMap[zaehlerbaueme, hoechsterpunkt[zaehlerbaueme] - 2] = "H";
                    GeneratorMap[zaehlerbaueme, hoechsterpunkt[zaehlerbaueme] - 3] = "H";
                    GeneratorMap[zaehlerbaueme, hoechsterpunkt[zaehlerbaueme] - 4] = "H";
                    GeneratorMap[zaehlerbaueme, hoechsterpunkt[zaehlerbaueme] - 5] = "H";

                    //Leavesstruktur aufbauen
                    //Unterste Lavesreihe
                    GeneratorMap[zaehlerbaueme + 1, hoechsterpunkt[zaehlerbaueme] - 3] = "L";
                    GeneratorMap[zaehlerbaueme + 2, hoechsterpunkt[zaehlerbaueme] - 3] = "L";
                    GeneratorMap[zaehlerbaueme + 3, hoechsterpunkt[zaehlerbaueme] - 3] = "L";
                    GeneratorMap[zaehlerbaueme - 1, hoechsterpunkt[zaehlerbaueme] - 3] = "L";
                    GeneratorMap[zaehlerbaueme - 2, hoechsterpunkt[zaehlerbaueme] - 3] = "L";
                    GeneratorMap[zaehlerbaueme - 3, hoechsterpunkt[zaehlerbaueme] - 3] = "L";

                    //Mittlere Leaves Reihe
                    GeneratorMap[zaehlerbaueme - 1, hoechsterpunkt[zaehlerbaueme] - 4] = "L";
                    GeneratorMap[zaehlerbaueme - 2, hoechsterpunkt[zaehlerbaueme] - 4] = "L";
                    GeneratorMap[zaehlerbaueme + 1, hoechsterpunkt[zaehlerbaueme] - 4] = "L";
                    GeneratorMap[zaehlerbaueme + 2, hoechsterpunkt[zaehlerbaueme] - 4] = "L";

                    //Oberste Leaves Reihe
                    GeneratorMap[zaehlerbaueme + 1, hoechsterpunkt[zaehlerbaueme] - 5] = "L";
                    GeneratorMap[zaehlerbaueme - 1, hoechsterpunkt[zaehlerbaueme] - 5] = "L";

                    //Baumkrone Leaves
                    GeneratorMap[zaehlerbaueme, hoechsterpunkt[zaehlerbaueme] - 6] = "L";
                }
            }

            //Stein generieren
            for (int zaehlerstein = 0; zaehlerstein < 5121; zaehlerstein++)
            {
                for (int zaehlerstein2 = hoechsterpunkt[zaehlerstein] + 3; zaehlerstein2 < 91; zaehlerstein2++)
                {
                    GeneratorMap[zaehlerstein, zaehlerstein2] = "S";
                }
            }

            //Eisen, Gold und Diamanten generieren generieren
            for (int zaehlererze = 0; zaehlererze < 5121; zaehlererze++)
            {
                //Eisen
                if (zaehlererze % 2 == 0)
                {
                    GeneratorMap[zaehlererze, rnd.Next(hoechsterpunkt[zaehlererze] + 7, 91)] = "I";
                }

                if (zaehlererze % 5 == 0)
                {
                    GeneratorMap[zaehlererze, rnd.Next(hoechsterpunkt[zaehlererze] + 20, 91)] = "O";
                }

                if (zaehlererze % 7 == 0)
                {
                    GeneratorMap[zaehlererze, rnd.Next(hoechsterpunkt[zaehlererze] + 30, 91)] = "D";
                }
            }

            //Border generieren
            for (int zaehler2 = 0; zaehler2 < 5121; zaehler2++)
            {
                GeneratorMap[zaehler2, 0] = "-";
                GeneratorMap[zaehler2, 90] = "-";
            }
            for (int zaehler3 = 0; zaehler3 < 91; zaehler3++)
            {
                GeneratorMap[0, zaehler3] = "|";
                GeneratorMap[5120, zaehler3] = "|";
            }

            //Die fertig generierte Map zurückgeben
            return GeneratorMap;
        }

        //Map auf Buttons anzeigen
        public void Map_neuladen(string[,] map)
        {
            //Gravity machen
            Gravity_Erweiterung();

            //Map auf die Buttons bringen
            Map_auf_Button(map);

            //Cordinaten refreshen
            Cordinaten_anzeigen();
        }

        //Map auf Button zeigen
        public void Map_auf_Button(string[,] map)
        {
            //Nach x-Achse sotierte Buttons einlesen
            Button[] btn = Buttons_einlesenx();

            //Ein Stringarray deklarieren in welchen die Character welche angezeigt werden sollen gespeichert werden
            string[,] buchstaben = new String[9, 8];

            //Mithilfe der for-Schleife einfügen
            int zaehler3 = 0;
            for (int zaehler1 = 0; zaehler1 < 8; zaehler1++)
            {
                for (int zaehler2 = 0; zaehler2 < 9; zaehler2++)
                {
                    //Buchstaben auf dem Block einfügen
                    btn[zaehler3].Text = map[zaehler2 + currentPlayerPosition_X, zaehler1 + currentPlayerPosition_Y - 5];

                    //Bild auf den Block einfügen
                    Bloecke_sind_Bilder(btn[zaehler3], btn[zaehler3].Text);

                    //Leere Buttons nicht anzeigen
                    if (btn[zaehler3].Text == " ")
                    {
                        btn[zaehler3].Visible = false;
                    }
                    else
                    {
                        btn[zaehler3].Visible = true;
                    }

                    zaehler3++;
                }
            }

            //Character anzeigen
            Button oberkoeper = (Button)Feld54;
            Button unterkoeper = (Button)Feld55;

            //Einsetzen was beim Körper angezeigt wird
            oberkoeper.Text = "*1";
            unterkoeper.Text = "*2";

            //Charakter Bild einfügen
            oberkoeper.BackgroundImage = new Bitmap("oberkoerper.png");
            unterkoeper.BackgroundImage = new Bitmap("unterkoerper.png");

            //Charakter Position immer sichtbar machen
            oberkoeper.Visible = true;
            unterkoeper.Visible = true;
        }

        //Blöcken ein Bild geben
        public void Bloecke_sind_Bilder(Button btn, string buchstabe)
        {
            //Mit Switch Statement checken welcher Block es ist
            switch (buchstabe)
            {
                case " ":
                    btn.BackgroundImage = null;
                    break;
                
                case "G":
                    btn.BackgroundImage = new Bitmap("minecraft_grass.png");
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    break;

                case "E":
                    btn.BackgroundImage = new Bitmap("minecraft_dirt.jpg");
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    break;

                case "S":
                    btn.BackgroundImage = new Bitmap("minecraft_stone.jpg");
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    break;

                case "H":
                    btn.BackgroundImage = new Bitmap("minecraft_wood.png");
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    break;

                case "L":
                    btn.BackgroundImage = new Bitmap("minecraft_leaves.png");
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    break;

                case "I":
                    btn.BackgroundImage = new Bitmap("minecraft_iron.png");
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    break;

                case "O":
                    btn.BackgroundImage = new Bitmap("minecraft_gold.jpg");
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    break;

                case "D":
                    btn.BackgroundImage = new Bitmap("minecraft_diamond.png");
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
            }
        }

        //Gravity Extension
        public void Gravity_Erweiterung()
        {
            //Kotrollieren ob etwas unter mir ist
            while (map_loader[currentPlayerPosition_X + 4, currentPlayerPosition_Y] == " ")
            {
                currentPlayerPosition_Y += 1;
            }
        }

        //Die Cordinaten anzeigen
        public void Cordinaten_anzeigen()
        {
            //X-Achse
            X_Anzeige.Text = "X: " + currentPlayerPosition_X;

            //Y-Anzeige
            Y_Anzeige.Text = "Y: " + currentPlayerPosition_Y;
        }

        //Platzieren Funktion
        public void Platzieren(Button btn, string Speicher_Platzieren)
        {
            //Alle Buttons rund um den Spieler herholen
            Button linksoben = (Button)Feld43;
            Button links1 = (Button)Feld44;
            Button links2 = (Button)Feld45;
            Button linksunten = (Button)Feld46;
            Button oben = (Button)Feld53;
            Button unten = (Button)Feld56;
            Button rechtsoben = (Button)Feld63;
            Button rechts1 = (Button)Feld64;
            Button rechts2 = (Button)Feld65;
            Button rechtsunten = (Button)Feld66;

            if (btn == linksoben)
            {
                map_loader[currentPlayerPosition_X + 3, currentPlayerPosition_Y - 3] = Speicher_Platzieren;
            }

            if (btn == links1)
            {
                map_loader[currentPlayerPosition_X + 3, currentPlayerPosition_Y - 2] = Speicher_Platzieren;
            }

            if (btn == links2)
            {
                map_loader[currentPlayerPosition_X + 3, currentPlayerPosition_Y - 1] = Speicher_Platzieren;
            }

            if (btn == linksunten)
            {
                map_loader[currentPlayerPosition_X + 3, currentPlayerPosition_Y] = Speicher_Platzieren;
            }

            if (btn == oben)
            {
                map_loader[currentPlayerPosition_X + 4, currentPlayerPosition_Y - 3] = Speicher_Platzieren;
            }

            if (btn == unten)
            {
                map_loader[currentPlayerPosition_X + 4, currentPlayerPosition_Y] = Speicher_Platzieren;
            }

            if (btn == rechtsoben)
            {
                map_loader[currentPlayerPosition_X + 5, currentPlayerPosition_Y - 3] = Speicher_Platzieren;
            }

            if (btn == rechts1)
            {
                map_loader[currentPlayerPosition_X + 5, currentPlayerPosition_Y - 2] = Speicher_Platzieren;
            }

            if (btn == rechts2)
            {
                map_loader[currentPlayerPosition_X + 5, currentPlayerPosition_Y - 1] = Speicher_Platzieren;
            }

            if (btn == rechtsunten)
            {
                map_loader[currentPlayerPosition_X + 5, currentPlayerPosition_Y] = Speicher_Platzieren;
            }
        }

        //Abbauen Funktion
        public string Abbauen(Button btn)
        {
            //Alle Buttons rund um den Spieler herholen
            Button linksoben = (Button)Feld43;
            Button links1 = (Button)Feld44;
            Button links2 = (Button)Feld45;
            Button linksunten = (Button)Feld46;
            Button oben = (Button)Feld53;
            Button unten = (Button)Feld56;
            Button rechtsoben = (Button)Feld63;
            Button rechts1 = (Button)Feld64;
            Button rechts2 = (Button)Feld65;
            Button rechtsunten = (Button)Feld66;

            //String welcher abgebaut wird speichern
            string speicher = "";

            if (btn == linksoben)
            {
                speicher = map_loader[currentPlayerPosition_X + 3, currentPlayerPosition_Y - 3];
                map_loader[currentPlayerPosition_X + 3, currentPlayerPosition_Y - 3] = " ";
            }

            if (btn == links1)
            {
                speicher = map_loader[currentPlayerPosition_X + 3, currentPlayerPosition_Y - 2];
                map_loader[currentPlayerPosition_X + 3, currentPlayerPosition_Y - 2] = " ";
            }

            if (btn == links2)
            {
                speicher = map_loader[currentPlayerPosition_X + 3, currentPlayerPosition_Y - 1];
                map_loader[currentPlayerPosition_X + 3, currentPlayerPosition_Y - 1] = " ";
            }

            if (btn == linksunten)
            {
                speicher = map_loader[currentPlayerPosition_X + 3, currentPlayerPosition_Y];
                map_loader[currentPlayerPosition_X + 3, currentPlayerPosition_Y] = " ";
            }

            if (btn == oben)
            {
                speicher = map_loader[currentPlayerPosition_X + 4, currentPlayerPosition_Y - 3];
                map_loader[currentPlayerPosition_X + 4, currentPlayerPosition_Y - 3] = " ";
            }

            if (btn == unten)
            {
                speicher = map_loader[currentPlayerPosition_X + 4, currentPlayerPosition_Y];
                map_loader[currentPlayerPosition_X + 4, currentPlayerPosition_Y] = " ";
            }

            if (btn == rechtsoben)
            {
                speicher = map_loader[currentPlayerPosition_X + 5, currentPlayerPosition_Y - 3];
                map_loader[currentPlayerPosition_X + 5, currentPlayerPosition_Y - 3] = " ";
            }

            if (btn == rechts1)
            {
                speicher = map_loader[currentPlayerPosition_X + 5, currentPlayerPosition_Y - 2];
                map_loader[currentPlayerPosition_X + 5, currentPlayerPosition_Y - 2] = " ";
            }

            if (btn == rechts2)
            {
                speicher = map_loader[currentPlayerPosition_X + 5, currentPlayerPosition_Y - 1];
                map_loader[currentPlayerPosition_X + 5, currentPlayerPosition_Y - 1] = " ";
            }

            if (btn == rechtsunten)
            {
                speicher = map_loader[currentPlayerPosition_X + 5, currentPlayerPosition_Y];
                map_loader[currentPlayerPosition_X + 5, currentPlayerPosition_Y] = " ";
            }

            return speicher;
        }

        //Inventoryslots einlesen
        public Button[] InventorySlotseinlesen()
        {
            //Variable für Button deklarieren
            Button[] Inventoryslots = new Button[9];

            //Buttons einzelt zum Verwenden eingeben
            Inventoryslots[0] = (Button)inventoryslot1;
            Inventoryslots[1] = (Button)inventoryslot2;
            Inventoryslots[2] = (Button)inventoryslot3;

            Inventoryslots[3] = (Button)inventoryslot4;
            Inventoryslots[4] = (Button)inventoryslot5;
            Inventoryslots[5] = (Button)inventoryslot6;

            Inventoryslots[6] = (Button)inventoryslot7;
            Inventoryslots[7] = (Button)inventoryslot8;
            Inventoryslots[8] = (Button)inventoryslot9;

            return Inventoryslots;
        }

        //Interact with Blocks Worker
        public void Interact_with_Blocks_Worker(Button button_sender)
        {
            //Checken ob der Block eine Workbench ist
            if (button_sender.Text == "C")
            {

            }
        }

        //Inventar laden
        public void Inventar_neuladen()
        {
            //Alles neu anzeigen
            inventoryslot1.Text = InventorySlot_Number[1] + "x" + " " + InventorySlot_Save[1];
            inventoryslot2.Text = InventorySlot_Number[2] + "x" + " " + InventorySlot_Save[2];
            inventoryslot3.Text = InventorySlot_Number[3] + "x" + " " + InventorySlot_Save[3];

            inventoryslot4.Text = InventorySlot_Number[4] + "x" + " " + InventorySlot_Save[4];
            inventoryslot5.Text = InventorySlot_Number[5] + "x" + " " + InventorySlot_Save[5];
            inventoryslot6.Text = InventorySlot_Number[6] + "x" + " " + InventorySlot_Save[6];

            inventoryslot7.Text = InventorySlot_Number[7] + "x" + " " + InventorySlot_Save[7];
            inventoryslot8.Text = InventorySlot_Number[8] + "x" + " " + InventorySlot_Save[8];
            inventoryslot9.Text = InventorySlot_Number[9] + "x" + " " + InventorySlot_Save[9];
        }

        //Inventar wenn ein Item leer ist nur mehr "" anzeigen
        public void Inventar_nothing_left()
        {
            //Wenn der Slot leer ist dann kein Save clearen
            if (InventorySlot_Number[ausgewählterslot] == 0)
            {
                InventorySlot_Save[ausgewählterslot] = "";
            }
        }
    }
}
