using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Rechner2.ViewModels
{
    public partial class RechnerViewModel : ObservableObject
    {
        private Random gen = new Random();

        // globale Variable, um im Konstruktor und
        // in der Check-Methode darauf zuzugreifen
        private int ergebnis = 0;

        public RechnerViewModel()
        {
           Generatecalculation();
        }

       

        [ObservableProperty]
        string _angabe = string.Empty;

        [ObservableProperty]
        string _eingabe = string.Empty;
        
        [ObservableProperty]
        string _feedback = string.Empty;

        void Generatecalculation()
        {

            int number1 = gen.Next(1, 11);
            int number2 = gen.Next(1, 11);

            // wird hier das Ergebnis definiert, so handelt es sich um
            // eine lokale Variable
            // int ergebnis = number1 + number2;

            // globales Ergebnis befüllen
            this.ergebnis = number1 + number2;

            this.Angabe = string.Format(number1 + " + " + number2 + " = ");
        }

        
        [RelayCommand]
        public void Check()
        {
            if (this.Eingabe.Length == 0)
            {
                this.Feedback = "Please put in a number";
                return; // mit return kann eine Methofe "schnell" verlassen werden
                
            }

            try
            {
                int benutzerEingabe = Convert.ToInt32(Eingabe);

                if (benutzerEingabe == this.ergebnis)
                {
                    this.Feedback = $"Nice! {Eingabe} is right!"; // Updated this line
                    this.Eingabe = string.Empty;
                }
                else
                {
                    this.Feedback = $"{Eingabe} is wrong! Try Again! ";
                    this.Eingabe = string.Empty;
                }
            }
            catch(FormatException ex)
            {
                this.Feedback = "Please put in a number";
            }
            catch (Exception ex)
            {
                this.Feedback = ex.ToString();
               

            }
            
            
        }


    }
    
}
