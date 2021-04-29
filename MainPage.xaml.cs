using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.ViewManagement;
using System.Windows;
using Windows.UI.Popups;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Cheems_Translator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void About_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog about = new ContentDialog()
            {
                Title = "About",
                Content = "haham supemr fumnny cheemms translatomr, im laughimng",
                CloseButtonText = "Close"
            };

            await about.ShowAsync();
        }

        // word must be 4 or more letters long
        // must end with consonant
        // m is inserted after final vowel

        private int lastNonendingVowelPos(string word)
        {
            
            char[] vowels = "aeiouAEIOU".ToCharArray();

            string output = "";

            foreach (char vowel in vowels)
            {

                if (!word.EndsWith(vowel))
                {
                    output = word.Remove(word.Length - 1);
                    
                    
                }
                
            }

            return output.LastIndexOfAny(vowels);
        }

        private async void fuckyou(string what)
        {
            var dialog = new MessageDialog(what);
            await dialog.ShowAsync();
        }

        private string cheemsify(string input)
        {

            char[] vowels = "aeiouAEIOU".ToCharArray();

            string[] words = input.Split(' ');

            string output = "";

            foreach(string word in words)
            {
                bool canReplace = false;

                if (word.Length >= 4)
                {
                    
                    foreach (char vowel in vowels)
                    {
                        
                        if (!word.EndsWith(vowel))
                        {
                            canReplace = true;
                        }
                        
                    }

                }

                if (canReplace)
                {
                    output += word.Insert(lastNonendingVowelPos(word) + 1, "m") + " ";
                } else
                {
                    output += word + " ";
                }
            }

            output.TrimEnd(' ');

            return output;
        }

        private void funnyWindowTitle()
        {
            var window = ApplicationView.GetForCurrentView();
            Random random = new System.Random();

            string[] funny = { "Cheemsburbger", "*CROMCH CHEW CRONCH*", 
                "A little trolling has happened", "Cheemsburger", 
                "nacho cheems", "Domgo", "" };

            window.Title = funny[random.Next(0, funny.Length)];
        }

        private void normalText_TextChanged(object sender, TextChangedEventArgs e)
        {
            cheemsText.Text = cheemsify(normalText.Text);
        }

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            funnyWindowTitle();
        }
    }
}
