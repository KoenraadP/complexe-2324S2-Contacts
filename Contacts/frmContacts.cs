using System;
using System.IO;
using System.Windows.Forms;

namespace Contacts
{
    public partial class frmContacts : Form
    {
        //globals
        //path = pad + bestandsnaam van geopend bestand
        //lines = verzameling van alle lijnen uit tekstbestand
        string fullPath;
        string[] linesFromFile;

        public frmContacts()
        {
            InitializeComponent();
        }

        //methode om bestand in te lezen
        //en personen toe te voegen aan dropdownlist
        private void AddPeople()
        {
            //geopend bestand koppelen aan variabele fullPath

            
            //alle regels uit tekstbestand in array linesFromFile stoppen
            

            //lines doorlopen en ieder lijntje splitsen
            //daarna personen aanmaken en waarden toekennen

            
        }

        //methode om persoon aan te passen
        //en alles opnieuw te bewaren in het geopende bestand
        private void UpdateFile()
        {
            //geselecteerde persoon omzetten naar Person
            

            //alle waarden van p opnieuw invullen
            //op basis van waarden die in textboxes staan
           

            //lijn van persoon in lines array vervangen door
            //nieuwe waarden
            

            //alle lijnen opnieuw naar tekstbestand schrijven
            

            //persoon in combobox ook aanpassen met nieuwe waarden
            

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            //standaardmap instellen indien beschikbaar

            string defaultPath = @"C:\contacten\";
            if (Directory.Exists(defaultPath))
            {
                ofd.InitialDirectory = defaultPath;
            }
            
            //dialoogvenster voor bestand openen starten

            ofd.ShowDialog();
        }

        private void ofd_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //AddPeople methode uitvoeren om alle namen in de combobox te plaatsen
            AddPeople();
            //eerste item uit de combobox selecteren
            cbPeople.SelectedIndex = 0;
        }

        private void cbPeople_SelectedIndexChanged(object sender, EventArgs e)
        {
            //geselecteerd item 'omzetten' (casten) naar Person
          

            //tekstvakken invullen met gegevens van persoon
            

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //UpdateFile methode uitvoeren om aangepaste persoon te bewaren
            UpdateFile();
        }
    }
}
